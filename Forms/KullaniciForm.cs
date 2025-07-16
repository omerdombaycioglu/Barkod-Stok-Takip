using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using StokTakipOtomasyonu.Helpers;

namespace StokTakipOtomasyonu.Forms
{
    public partial class KullaniciForm : Form
    {
        public KullaniciForm()
        {
            this.Icon = new Icon("isp_logo2.ico");
            InitializeComponent();
        }

        private void KullaniciForm_Load(object sender, EventArgs e)
        {
            cmbYeniYetki.Items.Clear();
            cmbYeniYetki.Items.Add("Yönetici");
            cmbYeniYetki.Items.Add("Standart Kullanıcı");
            cmbYeniYetki.SelectedIndex = 1;

            dgvKullanicilar.AutoGenerateColumns = false;
            dgvKullanicilar.AllowUserToAddRows = false;
            dgvKullanicilar.AllowUserToDeleteRows = false;
            dgvKullanicilar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKullanicilar.MultiSelect = false;
            dgvKullanicilar.EditMode = DataGridViewEditMode.EditOnEnter;

            dgvKullanicilar.Columns.Clear();
            dgvKullanicilar.Columns.Add("kullanici_id", "ID");
            dgvKullanicilar.Columns["kullanici_id"].ReadOnly = true;
            dgvKullanicilar.Columns["kullanici_id"].DataPropertyName = "kullanici_id";

            dgvKullanicilar.Columns.Add("kullanici_adi", "Kullanıcı Adı");
            dgvKullanicilar.Columns["kullanici_adi"].DataPropertyName = "kullanici_adi";

            dgvKullanicilar.Columns.Add("sifre", "Şifre");
            dgvKullanicilar.Columns["sifre"].DataPropertyName = "sifre";

            dgvKullanicilar.Columns.Add("ad_soyad", "Ad Soyad");
            dgvKullanicilar.Columns["ad_soyad"].DataPropertyName = "ad_soyad";

            var yetkiColumn = new DataGridViewComboBoxColumn
            {
                HeaderText = "Yetki",
                Name = "kullanici_yetki",
                DataPropertyName = "kullanici_yetki",
                DataSource = new[]
                {
                    new { Value = 1, Text = "Yönetici" },
                    new { Value = 2, Text = "Standart Kullanıcı" }
                },
                ValueMember = "Value",
                DisplayMember = "Text",
                FlatStyle = FlatStyle.Flat
            };
            dgvKullanicilar.Columns.Add(yetkiColumn);

            dgvKullanicilar.Columns.Add(new DataGridViewCheckBoxColumn()
            {
                HeaderText = "Aktif",
                Name = "aktif",
                DataPropertyName = "aktif"
            });

            dgvKullanicilar.Columns.Add("kayit_tarihi", "Kayıt Tarihi");
            dgvKullanicilar.Columns["kayit_tarihi"].DataPropertyName = "kayit_tarihi";
            dgvKullanicilar.Columns["kayit_tarihi"].ReadOnly = true;

            var silButton = new DataGridViewButtonColumn
            {
                HeaderText = "Sil",
                Text = "Sil",
                UseColumnTextForButtonValue = true,
                Name = "btnSil",
                FlatStyle = FlatStyle.Flat
            };
            dgvKullanicilar.Columns.Add(silButton);

            dgvKullanicilar.CellClick += dgvKullanicilar_CellClick;
            dgvKullanicilar.CellValueChanged += dgvKullanicilar_CellValueChanged;
            dgvKullanicilar.DataError += (s, ex) => { }; // suppress combobox errors

            KullanicilariYukle();
        }

        private void KullanicilariYukle()
        {
            try
            {
                string query = "SELECT * FROM kullanicilar WHERE silindi = 0";
                DataTable dt = DatabaseHelper.ExecuteQuery(query);
                dgvKullanicilar.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kullanıcılar yüklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dgvKullanicilar_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                var row = dgvKullanicilar.Rows[e.RowIndex];
                var kullanici_id = row.Cells["kullanici_id"].Value;
                var column = dgvKullanicilar.Columns[e.ColumnIndex].DataPropertyName;
                var newValue = row.Cells[e.ColumnIndex].Value;

                if (column == null) return;

                string query = $"UPDATE kullanicilar SET {column} = @value WHERE kullanici_id = @id";
                var parameters = new[]
                {
                    new MySqlParameter("@value", newValue),
                    new MySqlParameter("@id", kullanici_id)
                };

                DatabaseHelper.ExecuteNonQuery(query, parameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme hatası: " + ex.Message);
            }
        }

        private void dgvKullanicilar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvKullanicilar.Columns[e.ColumnIndex].Name == "btnSil")
            {
                var row = dgvKullanicilar.Rows[e.RowIndex];
                var id = row.Cells["kullanici_id"].Value;

                if (MessageBox.Show("Kullanıcıyı silmek istiyor musunuz? Bu işlem kullanıcıyı gizler ama tamamen silmez.",
                                    "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        string query = "UPDATE kullanicilar SET silindi = 1 WHERE kullanici_id = @id";
                        var param = new MySqlParameter("@id", id);
                        DatabaseHelper.ExecuteNonQuery(query, param);
                        KullanicilariYukle();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Silme (gizleme) hatası: " + ex.Message);
                    }
                }
            }
        }



        private void btnYeniKullanici_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtYeniKullaniciAdi.Text) || string.IsNullOrWhiteSpace(txtYeniSifre.Text))
            {
                MessageBox.Show("Kullanıcı adı ve şifre boş olamaz!");
                return;
            }

            string kadi = txtYeniKullaniciAdi.Text.Trim();
            string sifre = txtYeniSifre.Text.Trim();
            string adsoyad = txtYeniAdSoyad.Text.Trim();
            int yetki = cmbYeniYetki.SelectedIndex + 1;

            string query = @"INSERT INTO kullanicilar 
                (kullanici_adi, sifre, ad_soyad, kullanici_yetki, aktif, kayit_tarihi) 
                VALUES (@kadi, @sifre, @ad, @yetki, 1, NOW())";

            var parameters = new[]
            {
                new MySqlParameter("@kadi", kadi),
                new MySqlParameter("@sifre", sifre),
                new MySqlParameter("@ad", adsoyad),
                new MySqlParameter("@yetki", yetki)
            };

            try
            {
                DatabaseHelper.ExecuteNonQuery(query, parameters);
                KullanicilariYukle();
                txtYeniKullaniciAdi.Text = "";
                txtYeniSifre.Text = "";
                txtYeniAdSoyad.Text = "";
                cmbYeniYetki.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kullanıcı eklenemedi: " + ex.Message);
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
