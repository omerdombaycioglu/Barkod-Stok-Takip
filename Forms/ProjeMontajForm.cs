using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using StokTakipOtomasyonu.Helpers;

namespace StokTakipOtomasyonu.Forms
{
    public partial class ProjeMontajForm : Form
    {
        private int _kullaniciId;

        public ProjeMontajForm(int kullaniciId)
        {
            InitializeComponent();
            _kullaniciId = kullaniciId;
            ProjeleriYukle();
        }

        private void ProjeleriYukle()
        {
            try
            {
                string query = "SELECT proje_id, proje_kodu, proje_tanimi FROM projeler WHERE aktif = 1 ORDER BY proje_kodu";
                DataTable dt = DatabaseHelper.ExecuteQuery(query);

                cmbProjeler.DataSource = dt;
                cmbProjeler.DisplayMember = "proje_kodu";
                cmbProjeler.ValueMember = "proje_id";

                if (dt.Rows.Count > 0)
                {
                    ProjeUrunleriniYukle(Convert.ToInt32(cmbProjeler.SelectedValue));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Projeler yüklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ProjeUrunleriniYukle(int projeId)
        {
            try
            {
                string query = @"SELECT pu.id, u.urun_id, u.urun_kodu, u.urun_adi, pu.miktar 
                                FROM proje_urunleri pu
                                JOIN urunler u ON pu.urun_id = u.urun_id
                                WHERE pu.proje_id = @proje_id";
                var parameters = new[] { new MySqlParameter("@proje_id", projeId) };

                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
                dgvProjeUrunleri.DataSource = dt;

                // Kolon başlıklarını düzenle
                if (dgvProjeUrunleri.Columns.Count > 0)
                {
                    dgvProjeUrunleri.Columns["id"].Visible = false;
                    dgvProjeUrunleri.Columns["urun_id"].Visible = false;
                    dgvProjeUrunleri.Columns["urun_kodu"].HeaderText = "Ürün Kodu";
                    dgvProjeUrunleri.Columns["urun_adi"].HeaderText = "Ürün Adı";
                    dgvProjeUrunleri.Columns["miktar"].HeaderText = "Miktar";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Proje ürünleri yüklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbProjeler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProjeler.SelectedValue != null && int.TryParse(cmbProjeler.SelectedValue.ToString(), out int projeId))
            {
                ProjeUrunleriniYukle(projeId);
                lblProjeTanimi.Text = (cmbProjeler.SelectedItem as DataRowView)?["proje_tanimi"].ToString() ?? "";
            }
        }

        private void btnUrunEkle_Click(object sender, EventArgs e)
        {
            if (cmbProjeler.SelectedValue == null) return;

            int projeId = Convert.ToInt32(cmbProjeler.SelectedValue);
            using (var form = new UrunSecimForm())
            {
                if (form.ShowDialog() == DialogResult.OK && form.SecilenUrunId > 0)
                {
                    try
                    {
                        string query = @"INSERT INTO proje_urunleri (proje_id, urun_id, miktar, user_id) 
                                        VALUES (@proje_id, @urun_id, @miktar, @user_id)";
                        var parameters = new[]
                        {
                            new MySqlParameter("@proje_id", projeId),
                            new MySqlParameter("@urun_id", form.SecilenUrunId),
                            new MySqlParameter("@miktar", form.Miktar),
                            new MySqlParameter("@user_id", _kullaniciId)
                        };

                        int result = DatabaseHelper.ExecuteNonQuery(query, parameters);

                        if (result > 0)
                        {
                            ProjeUrunleriniYukle(projeId);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ürün eklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnUrunSil_Click(object sender, EventArgs e)
        {
            if (dgvProjeUrunleri.SelectedRows.Count == 0) return;

            int id = Convert.ToInt32(dgvProjeUrunleri.SelectedRows[0].Cells["id"].Value);
            int projeId = Convert.ToInt32(cmbProjeler.SelectedValue);

            if (MessageBox.Show("Seçili ürünü projeden çıkarmak istediğinize emin misiniz?", "Onay",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string query = "DELETE FROM proje_urunleri WHERE id = @id";
                    var parameters = new[] { new MySqlParameter("@id", id) };

                    int result = DatabaseHelper.ExecuteNonQuery(query, parameters);

                    if (result > 0)
                    {
                        ProjeUrunleriniYukle(projeId);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ürün silinirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}