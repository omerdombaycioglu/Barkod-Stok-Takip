using MySql.Data.MySqlClient;
using StokTakipOtomasyonu.Helpers;
using System;
using System.Data;
using System.Windows.Forms;

namespace StokTakipOtomasyonu.Forms
{
    public partial class ManuelUrunGirisiForm : Form
    {
        private int _kullaniciId;

        public ManuelUrunGirisiForm(int kullaniciId)
        {
            InitializeComponent();
            _kullaniciId = kullaniciId;
            UrunleriYukle();
        }

        private void UrunleriYukle()
        {
            try
            {
                string query = "SELECT urun_id, CONCAT(urun_adi, ' - ', urun_kodu) AS urun_bilgisi FROM urunler ORDER BY urun_adi";
                DataTable dt = DatabaseHelper.ExecuteQuery(query);

                cmbUrunler.DataSource = dt;
                cmbUrunler.DisplayMember = "urun_bilgisi";
                cmbUrunler.ValueMember = "urun_id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürünler yüklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (cmbUrunler.SelectedIndex == -1 || string.IsNullOrEmpty(txtMiktar.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtMiktar.Text, out int miktar) || miktar <= 0)
            {
                MessageBox.Show("Geçerli bir miktar giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int urunId = Convert.ToInt32(cmbUrunler.SelectedValue);
            string aciklama = txtAciklama.Text;

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (var transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // Stok güncelleme
                            string updateQuery = "UPDATE urunler SET miktar = miktar + @miktar WHERE urun_id = @urunId";
                            DatabaseHelper.ExecuteNonQuery(updateQuery, transaction,
                                new MySqlParameter("@miktar", miktar),
                                new MySqlParameter("@urunId", urunId));

                            // Hareket kaydı
                            string insertQuery = @"INSERT INTO urun_hareketleri 
                                                (urun_id, hareket_turu, miktar, kullanici_id, aciklama, islem_turu_id) 
                                                VALUES 
                                                (@urunId, 'Giris', @miktar, @kullaniciId, @aciklama, 0)";
                            DatabaseHelper.ExecuteNonQuery(insertQuery, transaction,
                                new MySqlParameter("@urunId", urunId),
                                new MySqlParameter("@miktar", miktar),
                                new MySqlParameter("@kullaniciId", _kullaniciId),
                                new MySqlParameter("@aciklama", aciklama));

                            transaction.Commit();
                            MessageBox.Show("Ürün girişi başarıyla kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}