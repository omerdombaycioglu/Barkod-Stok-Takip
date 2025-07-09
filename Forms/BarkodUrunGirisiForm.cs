using MySql.Data.MySqlClient;
using StokTakipOtomasyonu.Helpers;
using System;
using System.Data;
using System.Management; // WMI için bu namespace'i ekleyin
using System.Windows.Forms;

namespace StokTakipOtomasyonu.Forms
{
    public partial class BarkodUrunGirisiForm : Form
    {
        private int _kullaniciId;
        private bool _barkodOkuyucuBagli = false;

        public BarkodUrunGirisiForm(int kullaniciId)
        {
            InitializeComponent();
            _kullaniciId = kullaniciId;
            BarkodOkuyucuKontrol();
        }

        private void BarkodOkuyucuKontrol()
        {
            try
            {
                // WMI kullanarak bağlı HID aygıtlarını sorgula
                var searcher = new ManagementObjectSearcher(
                    "SELECT * FROM Win32_PnPEntity WHERE Name LIKE '%HID%'");

                foreach (var device in searcher.Get())
                {
                    string deviceName = device["Name"]?.ToString() ?? "";
                    if (deviceName.Contains("Scanner") ||
                        deviceName.Contains("Barcode") ||
                        deviceName.Contains("Okuyucu"))
                    {
                        _barkodOkuyucuBagli = true;
                        break;
                    }
                }

                if (!_barkodOkuyucuBagli)
                {
                    MessageBox.Show("Barkod okuyucu bağlı değil! Manuel giriş yapabilirsiniz.",
                        "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Barkod okuyucu kontrolü sırasında hata: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBarkodOku_Click(object sender, EventArgs e)
        {
            BarkodOku();
        }

        private void BarkodOku()
        {
            string barkod = txtBarkod.Text.Trim();
            if (string.IsNullOrEmpty(barkod))
            {
                MessageBox.Show("Lütfen barkod giriniz!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = "SELECT urun_id, urun_adi, urun_kodu, miktar FROM urunler WHERE urun_barkod = @barkod";
                DataTable dt = DatabaseHelper.ExecuteQuery(query, new MySqlParameter("@barkod", barkod));

                if (dt.Rows.Count > 0)
                {
                    lblUrunAdi.Text = dt.Rows[0]["urun_adi"].ToString();
                    lblUrunKodu.Text = dt.Rows[0]["urun_kodu"].ToString();
                    lblMevcutMiktar.Text = dt.Rows[0]["miktar"].ToString();
                    txtMiktar.Enabled = true;
                    btnKaydet.Enabled = true;

                    // Default miktarı 1 yap
                    if (string.IsNullOrEmpty(txtMiktar.Text))
                        txtMiktar.Text = "1";
                }
                else
                {
                    MessageBox.Show("Barkod ile eşleşen ürün bulunamadı!", "Uyarı",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Temizle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Temizle()
        {
            lblUrunAdi.Text = "---";
            lblUrunKodu.Text = "---";
            lblMevcutMiktar.Text = "---";
            txtMiktar.Text = "";
            txtMiktar.Enabled = false;
            btnKaydet.Enabled = false;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtMiktar.Text, out int miktar) || miktar <= 0)
            {
                MessageBox.Show("Geçerli bir miktar giriniz!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string barkod = txtBarkod.Text.Trim();
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
                            // Ürün ID'sini al
                            string urunIdQuery = "SELECT urun_id FROM urunler WHERE urun_barkod = @barkod";
                            var urunIdCmd = new MySqlCommand(urunIdQuery, conn, transaction);
                            urunIdCmd.Parameters.AddWithValue("@barkod", barkod);
                            object urunIdObj = urunIdCmd.ExecuteScalar();

                            if (urunIdObj == null)
                            {
                                MessageBox.Show("Ürün bulunamadı!", "Hata",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            int urunId = Convert.ToInt32(urunIdObj);

                            // Stok güncelleme
                            string updateQuery = "UPDATE urunler SET miktar = miktar + @miktar WHERE urun_id = @urunId";
                            var updateCmd = new MySqlCommand(updateQuery, conn, transaction);
                            updateCmd.Parameters.AddWithValue("@miktar", miktar);
                            updateCmd.Parameters.AddWithValue("@urunId", urunId);
                            updateCmd.ExecuteNonQuery();

                            // Hareket kaydı
                            string insertQuery = @"INSERT INTO urun_hareketleri 
                                        (urun_id, hareket_turu, miktar, kullanici_id, aciklama, islem_turu_id) 
                                        VALUES 
                                        (@urunId, 'Giris', @miktar, @kullaniciId, @aciklama, 0)";
                            var insertCmd = new MySqlCommand(insertQuery, conn, transaction);
                            insertCmd.Parameters.AddWithValue("@urunId", urunId);
                            insertCmd.Parameters.AddWithValue("@miktar", miktar);
                            insertCmd.Parameters.AddWithValue("@kullaniciId", _kullaniciId);
                            insertCmd.Parameters.AddWithValue("@aciklama", aciklama);
                            insertCmd.ExecuteNonQuery();

                            transaction.Commit();
                            MessageBox.Show("Ürün girişi başarıyla kaydedildi!", "Bilgi",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Temizle();
                            txtBarkod.Text = "";
                            txtBarkod.Focus();
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
                MessageBox.Show("Hata: " + ex.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBarkod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Enter sesini engelle
                BarkodOku();
            }
        }
    }
}