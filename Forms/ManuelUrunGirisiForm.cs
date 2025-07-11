using System;
using System.Windows.Forms;

namespace StokTakipOtomasyonu.Forms
{
    public partial class ManuelUrunGirisiForm : Form
    {
        private int _kullaniciId;
        private readonly string _connectionString = "server=localhost;user=root;database=stok_takip_otomasyonu;password=;";
        private Timer mesajTimer;

        public ManuelUrunGirisiForm(int kullaniciId)
        {
            InitializeComponent();
            _kullaniciId = kullaniciId;

            txtIslemTuru.Text = "Stok";
            txtIslemTuru.ReadOnly = true;
            nudMiktar.Value = 1;

            lblBasariMesaji.Visible = false;
            mesajTimer = new Timer();
            mesajTimer.Interval = 2000; // 2 saniye
            mesajTimer.Tick += mesajTimer_Tick;

            // Barkod alanına Enter basıldığında butona tıkla
            txtBarkod.KeyDown += txtBarkod_KeyDown;
        }

        private void txtBarkod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnKaydet.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void mesajTimer_Tick(object sender, EventArgs e)
        {
            lblBasariMesaji.Visible = false;
            mesajTimer.Stop();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string barkod = txtBarkod.Text.Trim();
            int miktar = (int)nudMiktar.Value;

            if (string.IsNullOrEmpty(barkod))
            {
                MessageBox.Show("Lütfen barkod girin.");
                return;
            }

            using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                conn.Open();

                string urunSorgu = "SELECT urun_id FROM urunler WHERE urun_barkod = @barkod";
                var cmd = new MySql.Data.MySqlClient.MySqlCommand(urunSorgu, conn);
                cmd.Parameters.AddWithValue("@barkod", barkod);
                object result = cmd.ExecuteScalar();

                int urunId;

                if (result == null)
                {
                    string urunKodu = txtUrunKodu.Text.Trim();
                    if (string.IsNullOrEmpty(urunKodu))
                    {
                        MessageBox.Show("Ürün bulunamadı. Lütfen ürün kodu girin.");
                        return;
                    }

                    string kodSorgu = "SELECT urun_id FROM urunler WHERE urun_kodu = @urun_kodu";
                    var kodCmd = new MySql.Data.MySqlClient.MySqlCommand(kodSorgu, conn);
                    kodCmd.Parameters.AddWithValue("@urun_kodu", urunKodu);
                    object kodResult = kodCmd.ExecuteScalar();

                    if (kodResult == null)
                    {
                        MessageBox.Show("Ürün koduna göre de ürün bulunamadı.");
                        return;
                    }

                    urunId = Convert.ToInt32(kodResult);

                    string guncelle = "UPDATE urunler SET urun_barkod = @barkod WHERE urun_id = @urun_id";
                    var guncelleCmd = new MySql.Data.MySqlClient.MySqlCommand(guncelle, conn);
                    guncelleCmd.Parameters.AddWithValue("@barkod", barkod);
                    guncelleCmd.Parameters.AddWithValue("@urun_id", urunId);
                    guncelleCmd.ExecuteNonQuery();
                }
                else
                {
                    urunId = Convert.ToInt32(result);
                }

                // Ürün hareketi ekle
                string hareketEkle = @"INSERT INTO urun_hareketleri 
            (urun_id, hareket_turu, miktar, kullanici_id, islem_turu_id) 
            VALUES (@urun_id, 'Giris', @miktar, @kullanici_id, 0)";
                var hareketCmd = new MySql.Data.MySqlClient.MySqlCommand(hareketEkle, conn);
                hareketCmd.Parameters.AddWithValue("@urun_id", urunId);
                hareketCmd.Parameters.AddWithValue("@miktar", miktar);
                hareketCmd.Parameters.AddWithValue("@kullanici_id", _kullaniciId);
                hareketCmd.ExecuteNonQuery();

                // Miktarı güncelle
                string miktarGuncelle = "UPDATE urunler SET miktar = miktar + @miktar WHERE urun_id = @urun_id";
                var miktarCmd = new MySql.Data.MySqlClient.MySqlCommand(miktarGuncelle, conn);
                miktarCmd.Parameters.AddWithValue("@miktar", miktar);
                miktarCmd.Parameters.AddWithValue("@urun_id", urunId);
                miktarCmd.ExecuteNonQuery();

                // Ürün adı al
                string adSorgu = "SELECT urun_adi FROM urunler WHERE urun_id = @id";
                var adCmd = new MySql.Data.MySqlClient.MySqlCommand(adSorgu, conn);
                adCmd.Parameters.AddWithValue("@id", urunId);
                string urunAdi = adCmd.ExecuteScalar()?.ToString() ?? "(ad yok)";

                // Dinamik mesaj göster
                lblBasariMesaji.Text = $"✔ {urunAdi} ürününden {miktar} adet stok girişi yapıldı.";
                lblBasariMesaji.Visible = true;
                mesajTimer.Start();

                txtBarkod.Clear();
                txtUrunKodu.Clear();
                nudMiktar.Value = 1;
                txtBarkod.Focus();
            }
        }

    }
}
