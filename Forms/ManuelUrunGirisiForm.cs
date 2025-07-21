using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace StokTakipOtomasyonu.Forms
{
    public partial class ManuelUrunGirisiForm : Form
    {
        private int _kullaniciId;
        private readonly string _connectionString = "server=localhost;user=root;database=stok_takip_otomasyonu;password=;";
        private Timer mesajTimer;
        private System.Windows.Forms.ComboBox cmbDepoKonum;
        private System.Windows.Forms.Label lblDepoKonum;


        public ManuelUrunGirisiForm(int kullaniciId)
        {
            this.Icon = new Icon("isp_logo2.ico");
            InitializeComponent();
            _kullaniciId = kullaniciId;

            txtIslemTuru.Text = "Stok";
            txtIslemTuru.ReadOnly = true;
            nudMiktar.Value = 1;

            lblBasariMesaji.Visible = false;
            mesajTimer = new Timer();
            mesajTimer.Interval = 2000;
            mesajTimer.Tick += mesajTimer_Tick;

            txtBarkod.KeyDown += txtBarkod_KeyDown;
            txtUrunKodu.KeyDown += txtUrunKodu_KeyDown; // EKLENDİ

            txtUrunKodu.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtUrunKodu.AutoCompleteSource = AutoCompleteSource.CustomSource;

            var autoSource = new AutoCompleteStringCollection();
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT urun_kodu FROM urunler";
                var cmd = new MySqlCommand(query, conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (!reader.IsDBNull(reader.GetOrdinal("urun_kodu")))
                    {
                        autoSource.Add(reader.GetString("urun_kodu"));
                    }
                }
            }
            txtUrunKodu.AutoCompleteCustomSource = autoSource;
            cmbDepoKonum.Items.Clear();
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT id, harf, numara FROM depo_konum ORDER BY harf, numara", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string disp = $"{reader["harf"]}{reader["numara"]}";
                    cmbDepoKonum.Items.Add(new ComboBoxItem { Text = disp, Value = Convert.ToInt32(reader["id"]) });
                }
            }           

        }

        private void txtBarkod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnKaydet.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void txtUrunKodu_KeyDown(object sender, KeyEventArgs e) // EKLENDİ
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

            // Depo konumunu seçmek zorunlu değil
            ComboBoxItem seciliKonum = null;
            int? seciliKonumId = null;
            if (cmbDepoKonum.SelectedItem != null)
            {
                seciliKonum = (ComboBoxItem)cmbDepoKonum.SelectedItem;
                seciliKonumId = seciliKonum.Value;
            }

            if (string.IsNullOrEmpty(barkod))
            {
                MessageBox.Show("Lütfen barkod girin.");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();

                string urunSorgu = "SELECT urun_id FROM urunler WHERE urun_barkod = @barkod";
                var cmd = new MySqlCommand(urunSorgu, conn);
                cmd.Parameters.AddWithValue("@barkod", barkod);
                object result = cmd.ExecuteScalar();

                int urunId;

                if (result == null)
                {
                    string urunKodu = txtUrunKodu.Text.Trim();
                    if (string.IsNullOrEmpty(urunKodu))
                    {
                        MessageBox.Show("Ürün bulunamadı. Lütfen ürün kodu girin.");
                        txtUrunKodu.Focus();
                        return;
                    }

                    string kodSorgu = "SELECT urun_id FROM urunler WHERE urun_kodu = @urun_kodu";
                    var kodCmd = new MySqlCommand(kodSorgu, conn);
                    kodCmd.Parameters.AddWithValue("@urun_kodu", urunKodu);
                    object kodResult = kodCmd.ExecuteScalar();

                    if (kodResult == null)
                    {
                        var yeniUrunAdi = Microsoft.VisualBasic.Interaction.InputBox("Yeni ürün adı girin:", "Yeni Ürün", "");
                        if (string.IsNullOrWhiteSpace(yeniUrunAdi))
                        {
                            MessageBox.Show("Ürün adı gerekli.");
                            return;
                        }

                        string insert = "INSERT INTO urunler (urun_adi, urun_kodu, urun_barkod, miktar) VALUES (@adi, @kodu, @barkod, 0); SELECT LAST_INSERT_ID();";
                        var insertCmd = new MySqlCommand(insert, conn);
                        insertCmd.Parameters.AddWithValue("@adi", yeniUrunAdi);
                        insertCmd.Parameters.AddWithValue("@kodu", urunKodu);
                        insertCmd.Parameters.AddWithValue("@barkod", barkod);
                        urunId = Convert.ToInt32(insertCmd.ExecuteScalar());
                    }
                    else
                    {
                        urunId = Convert.ToInt32(kodResult);
                        string guncelle = "UPDATE urunler SET urun_barkod = @barkod WHERE urun_id = @urun_id";
                        var guncelleCmd = new MySqlCommand(guncelle, conn);
                        guncelleCmd.Parameters.AddWithValue("@barkod", barkod);
                        guncelleCmd.Parameters.AddWithValue("@urun_id", urunId);
                        guncelleCmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    urunId = Convert.ToInt32(result);
                }

                // 1. urun_hareketleri tablosuna ekle
                string hareketEkle = @"INSERT INTO urun_hareketleri 
            (urun_id, hareket_turu, miktar, kullanici_id, islem_turu_id) 
            VALUES (@urun_id, 'Giris', @miktar, @kullanici_id, 0)";
                var hareketCmd = new MySqlCommand(hareketEkle, conn);
                hareketCmd.Parameters.AddWithValue("@urun_id", urunId);
                hareketCmd.Parameters.AddWithValue("@miktar", miktar);
                hareketCmd.Parameters.AddWithValue("@kullanici_id", _kullaniciId);
                hareketCmd.ExecuteNonQuery();

                // 2. urunler tablosunda toplam miktarı güncelle
                string miktarGuncelle = "UPDATE urunler SET miktar = miktar + @miktar WHERE urun_id = @urun_id";
                var miktarCmd = new MySqlCommand(miktarGuncelle, conn);
                miktarCmd.Parameters.AddWithValue("@miktar", miktar);
                miktarCmd.Parameters.AddWithValue("@urun_id", urunId);
                miktarCmd.ExecuteNonQuery();

                // 3. urun_depo_konum tablosunu güncelle (sadece konum seçildiyse)
                if (seciliKonumId.HasValue)
                {
                    string kontrol = "SELECT miktar FROM urun_depo_konum WHERE urun_id=@urun_id AND depo_konum_id=@konum_id";
                    var kontrolCmd = new MySqlCommand(kontrol, conn);
                    kontrolCmd.Parameters.AddWithValue("@urun_id", urunId);
                    kontrolCmd.Parameters.AddWithValue("@konum_id", seciliKonumId.Value);
                    object mevcutMiktar = kontrolCmd.ExecuteScalar();

                    if (mevcutMiktar != null)
                    {
                        string guncelle = "UPDATE urun_depo_konum SET miktar = miktar + @eklenen WHERE urun_id = @urun_id AND depo_konum_id = @konum_id";
                        var guncelleCmd = new MySqlCommand(guncelle, conn);
                        guncelleCmd.Parameters.AddWithValue("@eklenen", miktar);
                        guncelleCmd.Parameters.AddWithValue("@urun_id", urunId);
                        guncelleCmd.Parameters.AddWithValue("@konum_id", seciliKonumId.Value);
                        guncelleCmd.ExecuteNonQuery();
                    }
                    else
                    {
                        string insert = "INSERT INTO urun_depo_konum (urun_id, depo_konum_id, miktar) VALUES (@urun_id, @konum_id, @eklenen)";
                        var insertCmd = new MySqlCommand(insert, conn);
                        insertCmd.Parameters.AddWithValue("@urun_id", urunId);
                        insertCmd.Parameters.AddWithValue("@konum_id", seciliKonumId.Value);
                        insertCmd.Parameters.AddWithValue("@eklenen", miktar);
                        insertCmd.ExecuteNonQuery();
                    }
                }
                // Seçilmediyse urun_depo_konum işlemi atlanır!

                // 4. Ürün adını çekip ekrana yaz
                string adSorgu = "SELECT urun_adi FROM urunler WHERE urun_id = @id";
                var adCmd = new MySqlCommand(adSorgu, conn);
                adCmd.Parameters.AddWithValue("@id", urunId);
                string urunAdi = adCmd.ExecuteScalar()?.ToString() ?? "(ad yok)";

                string konumMetni = seciliKonum != null ? seciliKonum.Text : "konum belirtilmedi";
                lblBasariMesaji.Text = $"✔ {urunAdi} ürününden {miktar} adet ({konumMetni}) stok girişi yapıldı.";
                lblBasariMesaji.Visible = true;
                mesajTimer.Start();

                txtBarkod.Clear();
                txtUrunKodu.Clear();
                nudMiktar.Value = 1;
                txtBarkod.Focus();
            }
        }


        // Helper class (Form sonuna ekle)
        public class ComboBoxItem
        {
            public string Text { get; set; }
            public int Value { get; set; }
            public override string ToString() { return Text; }
        }

    }
}