using MySql.Data.MySqlClient;
using StokTakipOtomasyonu.Helpers;
using System;
using System.Data;
using System.Windows.Forms;

namespace StokTakipOtomasyonu.Forms
{
    public partial class ManuelUrunCikisiForm : Form
    {
        private int _kullaniciId;

        public ManuelUrunCikisiForm(int kullaniciId)
        {
            InitializeComponent();
            _kullaniciId = kullaniciId;
            UrunleriYukle();
            IslemTurleriniYukle();
            ProjeleriYukle();
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

        private void IslemTurleriniYukle()
        {
            try
            {
                string query = "SELECT islem_turu_id, tanim FROM islem_turu";
                DataTable dt = DatabaseHelper.ExecuteQuery(query);

                cmbIslemTuru.DataSource = dt;
                cmbIslemTuru.DisplayMember = "tanim";
                cmbIslemTuru.ValueMember = "islem_turu_id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("İşlem türleri yüklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ProjeleriYukle()
        {
            try
            {
                string query = "SELECT proje_id, CONCAT(proje_kodu, ' - ', proje_tanimi) AS proje_bilgisi FROM projeler WHERE aktif = 1";
                DataTable dt = DatabaseHelper.ExecuteQuery(query);

                cmbProjeler.DataSource = dt;
                cmbProjeler.DisplayMember = "proje_bilgisi";
                cmbProjeler.ValueMember = "proje_id";
                cmbProjeler.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Projeler yüklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbIslemTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbIslemTuru.SelectedValue != null)
            {
                int islemTuruId = Convert.ToInt32(cmbIslemTuru.SelectedValue);
                cmbProjeler.Enabled = (islemTuruId == 1); // Sadece proje işlem türünde aktif
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (cmbUrunler.SelectedIndex == -1 || string.IsNullOrEmpty(txtMiktar.Text) || cmbIslemTuru.SelectedIndex == -1)
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
            int islemTuruId = Convert.ToInt32(cmbIslemTuru.SelectedValue);
            int? projeId = (islemTuruId == 1 && cmbProjeler.SelectedValue != null) ?
                Convert.ToInt32(cmbProjeler.SelectedValue) : (int?)null;
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
                            // Stok kontrolü
                            string stokQuery = "SELECT miktar FROM urunler WHERE urun_id = @urunId FOR UPDATE";
                            var stokCmd = new MySqlCommand(stokQuery, conn, transaction);
                            stokCmd.Parameters.AddWithValue("@urunId", urunId);
                            int mevcutStok = Convert.ToInt32(stokCmd.ExecuteScalar());

                            if (mevcutStok < miktar)
                            {
                                MessageBox.Show($"Yetersiz stok! Mevcut stok: {mevcutStok}", "Uyarı",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            // Stok güncelleme
                            string updateQuery = "UPDATE urunler SET miktar = miktar - @miktar WHERE urun_id = @urunId";
                            var updateCmd = new MySqlCommand(updateQuery, conn, transaction);
                            updateCmd.Parameters.AddWithValue("@miktar", miktar);
                            updateCmd.Parameters.AddWithValue("@urunId", urunId);
                            updateCmd.ExecuteNonQuery();

                            // Hareket kaydı
                            string insertQuery = @"INSERT INTO urun_hareketleri 
                                                (urun_id, hareket_turu, miktar, kullanici_id, aciklama, islem_turu_id, referans_id) 
                                                VALUES 
                                                (@urunId, 'Cikis', @miktar, @kullaniciId, @aciklama, @islemTuruId, @referansId)";
                            var insertCmd = new MySqlCommand(insertQuery, conn, transaction);
                            insertCmd.Parameters.AddWithValue("@urunId", urunId);
                            insertCmd.Parameters.AddWithValue("@miktar", miktar);
                            insertCmd.Parameters.AddWithValue("@kullaniciId", _kullaniciId);
                            insertCmd.Parameters.AddWithValue("@aciklama", aciklama);
                            insertCmd.Parameters.AddWithValue("@islemTuruId", islemTuruId);
                            insertCmd.Parameters.AddWithValue("@referansId", projeId ?? (object)DBNull.Value);
                            insertCmd.ExecuteNonQuery();

                            // Proje ürünleri tablosuna ekleme (eğer proje ise)
                            if (islemTuruId == 1 && projeId.HasValue)
                            {
                                string projeUrunQuery = @"INSERT INTO proje_urunleri 
                                                        (proje_id, urun_id, miktar, user_id) 
                                                        VALUES 
                                                        (@projeId, @urunId, @miktar, @userId)";
                                var projeUrunCmd = new MySqlCommand(projeUrunQuery, conn, transaction);
                                projeUrunCmd.Parameters.AddWithValue("@projeId", projeId.Value);
                                projeUrunCmd.Parameters.AddWithValue("@urunId", urunId);
                                projeUrunCmd.Parameters.AddWithValue("@miktar", miktar);
                                projeUrunCmd.Parameters.AddWithValue("@userId", _kullaniciId);
                                projeUrunCmd.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            MessageBox.Show("Ürün çıkışı başarıyla kaydedildi!", "Bilgi",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Hata: " + ex.Message, "Hata",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
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