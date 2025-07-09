using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using StokTakipOtomasyonu.Helpers;

namespace StokTakipOtomasyonu.Forms
{
    public partial class UrunBilgiForm : Form
    {
        public UrunBilgiForm()
        {
            InitializeComponent();
            LoadUrunler();
        }

        private void LoadUrunler()
        {
            try
            {
                string query = "SELECT urun_id, urun_adi, urun_kodu, urun_barkod, urun_marka, urun_no, miktar, kritik_seviye FROM urunler";
                var dt = DatabaseHelper.ExecuteQuery(query);
                dataGridViewUrunler.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürünler yüklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (var transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            foreach (DataGridViewRow row in dataGridViewUrunler.Rows)
                            {
                                if (!row.IsNewRow)
                                {
                                    string query = @"UPDATE urunler SET 
                                                  urun_adi = @urun_adi, 
                                                  urun_kodu = @urun_kodu, 
                                                  urun_barkod = @urun_barkod, 
                                                  urun_marka = @urun_marka, 
                                                  urun_no = @urun_no, 
                                                  miktar = @miktar, 
                                                  kritik_seviye = @kritik_seviye 
                                                  WHERE urun_id = @urun_id";

                                    DatabaseHelper.ExecuteNonQuery(query, transaction,
                                        new MySqlParameter("@urun_adi", row.Cells["urun_adi"].Value ?? DBNull.Value),
                                        new MySqlParameter("@urun_kodu", row.Cells["urun_kodu"].Value ?? DBNull.Value),
                                        new MySqlParameter("@urun_barkod", row.Cells["urun_barkod"].Value ?? DBNull.Value),
                                        new MySqlParameter("@urun_marka", row.Cells["urun_marka"].Value ?? DBNull.Value),
                                        new MySqlParameter("@urun_no", row.Cells["urun_no"].Value ?? DBNull.Value),
                                        new MySqlParameter("@miktar", row.Cells["miktar"].Value ?? 0),
                                        new MySqlParameter("@kritik_seviye", row.Cells["kritik_seviye"].Value ?? DBNull.Value),
                                        new MySqlParameter("@urun_id", row.Cells["urun_id"].Value));
                                }
                            }
                            transaction.Commit();
                            MessageBox.Show("Değişiklikler başarıyla kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Kayıt sırasında hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bağlantı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}