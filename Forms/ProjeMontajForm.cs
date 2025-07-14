using MySql.Data.MySqlClient;
using StokTakipOtomasyonu.Helpers;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace StokTakipOtomasyonu.Forms
{
    public partial class ProjeMontajForm : Form
    {
        private int _userId;
        private int _kullaniciYetki;

        public ProjeMontajForm(int userId)
        {
            this.Icon = new Icon("isp_logo2.ico");
            InitializeComponent();
            _userId = userId;
            _kullaniciYetki = GetKullaniciYetki(_userId);
            ConfigureDataGridView();
        }

        private int GetKullaniciYetki(int kullaniciId)
        {
            string query = "SELECT kullanici_yetki FROM kullanicilar WHERE kullanici_id = @id";
            object result = DatabaseHelper.ExecuteScalar(query, new MySqlParameter("@id", kullaniciId));
            return result != null ? Convert.ToInt32(result) : 0;
        }

        private void ProjeMontajForm_Load(object sender, EventArgs e)
        {
            LoadProjects();
        }

        private void ConfigureDataGridView()
        {
            dataGridViewProjeler.AllowUserToAddRows = false; // <-- Bu satırı ekle
            dataGridViewProjeler.AutoGenerateColumns = false;
            dataGridViewProjeler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewProjeler.MultiSelect = false;
            dataGridViewProjeler.RowHeadersVisible = false;
            dataGridViewProjeler.Columns.Clear();

            if (_kullaniciYetki == 1)
            {
                dataGridViewProjeler.Columns.Add(new DataGridViewButtonColumn
                {
                    Name = "btnSil",
                    HeaderText = "",
                    Text = "X",
                    UseColumnTextForButtonValue = true,
                    Width = 30
                });
            }

            dataGridViewProjeler.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "proje_id",
                DataPropertyName = "proje_id",
                HeaderText = "ID",
                Visible = false
            });

            dataGridViewProjeler.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "proje_kodu",
                DataPropertyName = "proje_kodu",
                HeaderText = "Proje Kodu",
                Width = 150
            });

            dataGridViewProjeler.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "proje_tanimi",
                DataPropertyName = "proje_tanimi",
                HeaderText = "Tanım",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dataGridViewProjeler.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "btnUrunListesi",
                HeaderText = "Ürün Durumu",
                Text = "Proje Ürün Durumunu Göster",
                UseColumnTextForButtonValue = true,
                Width = 200
            });

            dataGridViewProjeler.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "btnIslemGecmisi",
                HeaderText = "İşlem Geçmişi",
                Text = "İşlem Geçmişi",
                UseColumnTextForButtonValue = true,
                Width = 150
            });
        }


        private void LoadProjects()
        {
            string query = "SELECT proje_id, proje_kodu, proje_tanimi FROM projeler WHERE aktif = 1 ORDER BY proje_kodu";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);

            if (dt.Rows.Count == 0)
            {
                dataGridViewProjeler.Visible = false;
                lblBosProjeMesaji.Visible = true;
            }
            else
            {
                dataGridViewProjeler.DataSource = dt;
                dataGridViewProjeler.Visible = true;
                lblBosProjeMesaji.Visible = false;
            }
        }

        private void dataGridViewProjeler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var column = dataGridViewProjeler.Columns[e.ColumnIndex];
            var row = dataGridViewProjeler.Rows[e.RowIndex];

            int projeId = Convert.ToInt32(row.Cells["proje_id"].Value);
            string projeKodu = row.Cells["proje_kodu"].Value.ToString();

            if (column.Name == "btnUrunListesi")
            {
                var detayForm = new ProjeMontajDetayForm(projeId, _userId, projeKodu);
                detayForm.ShowDialog();
            }
            else if (column.Name == "btnIslemGecmisi")
            {
                ShowProjectTransactionHistory(projeId, projeKodu);
            }
            else if (column.Name == "btnSil" && _kullaniciYetki == 1)
            {
                var result = MessageBox.Show($"Projeyi silmek istiyor musunuz?\n\nProje Kodu: {projeKodu}", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    string query = "UPDATE projeler SET aktif = 0 WHERE proje_id = @pid";
                    DatabaseHelper.ExecuteNonQuery(query, new MySqlParameter("@pid", projeId));
                    LoadProjects();
                    MessageBox.Show("Proje başarıyla silindi (soft delete).", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void ShowProjectTransactionHistory(int projeId, string projeKodu)
        {
            string query = @"
                SELECT u.urun_kodu, u.urun_adi, ph.miktar, k.kullanici_adi, ph.islem_tarihi
                FROM proje_hareketleri ph
                JOIN urunler u ON ph.urun_id = u.urun_id
                JOIN kullanicilar k ON ph.kullanici_id = k.kullanici_id
                WHERE ph.proje_id = @proje_id
                ORDER BY ph.islem_tarihi DESC";

            var parameters = new[] { new MySqlParameter("@proje_id", projeId) };
            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Bu proje için işlem geçmişi bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string message = $"Proje: {projeKodu}\n\n";
            foreach (DataRow row in dt.Rows)
            {
                message += $"[{row["islem_tarihi"]}] {row["kullanici_adi"]} - {row["urun_adi"]} ({row["urun_kodu"]}) x{row["miktar"]}\n";
            }

            MessageBox.Show(message, "Proje İşlem Geçmişi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
