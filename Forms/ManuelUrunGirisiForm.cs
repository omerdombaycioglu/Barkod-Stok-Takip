using MySql.Data.MySqlClient;
using NPOI.SS.Formula.Functions;
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


        public ManuelUrunGirisiForm(int kullaniciId)
        {
            this.Icon = new Icon("isp_logo2.ico");
            InitializeComponent();
            _kullaniciId = kullaniciId;

            cmbBirim.Items.Clear();
            cmbBirim.Items.AddRange(new object[] { "adet", "metre", "cm" });
            cmbBirim.SelectedIndex = 0;

            txtIslemTuru.Text = "Stok";
            txtIslemTuru.ReadOnly = true;
            nudMiktar.Value = 1;

            lblBasariMesaji.Visible = false;
            mesajTimer = new Timer();
            mesajTimer.Interval = 2000;
            mesajTimer.Tick += mesajTimer_Tick;

            txtBarkod.KeyDown += txtBarkod_KeyDown;
            txtUrunKodu.KeyDown += txtUrunKodu_KeyDown;

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

            // **Load eventini burada bağla**
            this.Load += ManuelUrunGirisiForm_Load;
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

        private void ManuelUrunGirisiForm_Load(object sender, EventArgs e)
        {
            txtBarkod.Focus();
        }


        private void mesajTimer_Tick(object sender, EventArgs e)
        {
            lblBasariMesaji.Visible = false;
            mesajTimer.Stop();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string birim = cmbBirim.SelectedItem.ToString();
            string barkod = txtBarkod.Text.Trim();
            string urunKodu = txtUrunKodu.Text.Trim();
            int miktar = (int)nudMiktar.Value;

            if (string.IsNullOrEmpty(barkod) && string.IsNullOrEmpty(urunKodu))
            {
                MessageBox.Show("Lütfen barkod veya ürün kodu girin.");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();

                object result = null;
                if (!string.IsNullOrEmpty(barkod))
                {
                    string urunSorgu = "SELECT urun_id FROM urunler WHERE urun_barkod = @barkod";
                    var cmd = new MySqlCommand(urunSorgu, conn);
                    cmd.Parameters.AddWithValue("@barkod", barkod);
                    result = cmd.ExecuteScalar();
                }

                // Eğer barkoddan ürün bulunamazsa veya barkod girilmemişse, ürün kodundan ara
                if (result == null && !string.IsNullOrEmpty(urunKodu))
                {
                    string kodSorgu = "SELECT urun_id FROM urunler WHERE urun_kodu = @urun_kodu";
                    var kodCmd = new MySqlCommand(kodSorgu, conn);
                    kodCmd.Parameters.AddWithValue("@urun_kodu", urunKodu);
                    result = kodCmd.ExecuteScalar();
                }

                int urunId;

                if (result == null)
                {
                    // Yeni ürün ekleme süreci aynı kalacak
                    var yeniUrunAdi = Microsoft.VisualBasic.Interaction.InputBox("Yeni ürün adı girin:", "Yeni Ürün", "");
                    if (string.IsNullOrWhiteSpace(yeniUrunAdi))
                    {
                        MessageBox.Show("Ürün adı gerekli.");
                        return;
                    }
                    string insert = "INSERT INTO urunler (urun_adi, urun_kodu, urun_barkod, miktar, birim) VALUES (@adi, @kodu, @barkod, 0, @birim); SELECT LAST_INSERT_ID();";
                    var insertCmd = new MySqlCommand(insert, conn);
                    insertCmd.Parameters.AddWithValue("@adi", yeniUrunAdi);
                    insertCmd.Parameters.AddWithValue("@kodu", urunKodu);
                    insertCmd.Parameters.AddWithValue("@barkod", barkod);
                    insertCmd.Parameters.AddWithValue("@birim", birim);
                    urunId = Convert.ToInt32(insertCmd.ExecuteScalar());
                }
                else
                {
                    urunId = Convert.ToInt32(result);

                    // Birim güncellemesi
                    string guncelleBirim = "UPDATE urunler SET birim = @birim WHERE urun_id = @urun_id";
                    var guncelleCmd = new MySqlCommand(guncelleBirim, conn);
                    guncelleCmd.Parameters.AddWithValue("@birim", birim);
                    guncelleCmd.Parameters.AddWithValue("@urun_id", urunId);
                    guncelleCmd.ExecuteNonQuery();
                }

                // Hareket kaydı ve miktar güncellemesi
                string hareketEkle = @"INSERT INTO urun_hareketleri 
            (urun_id, hareket_turu, miktar, kullanici_id, islem_turu_id) 
            VALUES (@urun_id, 'Giris', @miktar, @kullanici_id, 0)";
                var hareketCmd = new MySqlCommand(hareketEkle, conn);
                hareketCmd.Parameters.AddWithValue("@urun_id", urunId);
                hareketCmd.Parameters.AddWithValue("@miktar", miktar);
                hareketCmd.Parameters.AddWithValue("@kullanici_id", _kullaniciId);
                hareketCmd.ExecuteNonQuery();

                string miktarGuncelle = "UPDATE urunler SET miktar = miktar + @miktar WHERE urun_id = @urun_id";
                var miktarCmd = new MySqlCommand(miktarGuncelle, conn);
                miktarCmd.Parameters.AddWithValue("@miktar", miktar);
                miktarCmd.Parameters.AddWithValue("@urun_id", urunId);
                miktarCmd.ExecuteNonQuery();

                string adSorgu = "SELECT urun_adi FROM urunler WHERE urun_id = @id";
                var adCmd = new MySqlCommand(adSorgu, conn);
                adCmd.Parameters.AddWithValue("@id", urunId);
                string urunAdi = adCmd.ExecuteScalar()?.ToString() ?? "(ad yok)";

                lblBasariMesaji.Text = $"✔ {urunAdi} ürününden {miktar} {birim} stok girişi yapıldı.";
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
