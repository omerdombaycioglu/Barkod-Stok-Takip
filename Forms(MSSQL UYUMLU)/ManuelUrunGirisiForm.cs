using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace StokTakipOtomasyonu.Forms
{
    public partial class ManuelUrunGirisiForm : Form
    {
        private int _kullaniciId;
        private readonly string _connectionString = "Server=192.168.43.153;Database=stok_takip_otomasyonu;User Id=sa;Password=123;";

        private Timer mesajTimer;
        private System.Windows.Forms.ComboBox cmbDepoKonum;
        private System.Windows.Forms.Label lblDepoKonum;
        private ComboBox cmbBirim;


        public ManuelUrunGirisiForm(int kullaniciId)
        {
            this.Icon = new Icon("isp_logo2.ico");
            InitializeComponent();
            cmbBirim = new ComboBox();
            cmbBirim.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBirim.Items.AddRange(new[] { "adet", "metre", "cm" });
            cmbBirim.SelectedIndex = 0;
            cmbBirim.Width = 80;
            cmbBirim.Font = nudMiktar.Font;
            // Form üzerinde miktarın sağında olacak şekilde konumlandır:
            cmbBirim.Location = new Point(nudMiktar.Right + 8, nudMiktar.Top);

            // Form'a ekle
            this.Controls.Add(cmbBirim);


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
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT urun_kodu FROM urunler";
                var cmd = new SqlCommand(query, conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (!reader.IsDBNull(reader.GetOrdinal("urun_kodu")))
                    {
                        autoSource.Add(reader.GetString(reader.GetOrdinal("urun_kodu")));

                    }
                }
            }
            txtUrunKodu.AutoCompleteCustomSource = autoSource;
            cmbDepoKonum.Items.Clear();
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT id, harf, numara FROM depo_konum ORDER BY harf, numara", conn);
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
            string urunKodu = txtUrunKodu.Text.Trim();
            int miktar = (int)nudMiktar.Value;
            string birim = cmbBirim.SelectedItem?.ToString();

            // Depo konumunu seçmek zorunlu değil
            ComboBoxItem seciliKonum = null;
            int? seciliKonumId = null;
            if (cmbDepoKonum.SelectedItem != null)
            {
                seciliKonum = (ComboBoxItem)cmbDepoKonum.SelectedItem;
                seciliKonumId = seciliKonum.Value;
            }

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                int urunId = -1;
                bool yeniUrunEklendi = false;

                // 1- Barkod girilmişse önce barkod ile ara
                if (!string.IsNullOrEmpty(barkod))
                {
                    string urunSorgu = "SELECT urun_id FROM urunler WHERE urun_barkod = @barkod";
                    var cmd = new SqlCommand(urunSorgu, conn);
                    cmd.Parameters.AddWithValue("@barkod", barkod);
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        urunId = Convert.ToInt32(result);
                    }
                    else
                    {
                        // BARKOD YOKSA, ÜRÜN KODU BOŞSA FOCUSU ORAYA ALDIR!
                        if (string.IsNullOrEmpty(urunKodu))
                        {
                            MessageBox.Show("Barkod bulunamadı. Ürün kodu ile deneyin.");
                            txtUrunKodu.Focus();
                            return;
                        }
                        // ÜRÜN KODU VARSA BARKODSIZ ARA
                        else
                        {
                            string kodSorgu = "SELECT urun_id, urun_barkod FROM urunler WHERE urun_kodu = @urun_kodu";
                            var kodCmd = new SqlCommand(kodSorgu, conn);
                            kodCmd.Parameters.AddWithValue("@urun_kodu", urunKodu);
                            using (var reader = kodCmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    urunId = Convert.ToInt32(reader["urun_id"]);
                                    string mevcutBarkod = reader["urun_barkod"]?.ToString();

                                    if (string.IsNullOrEmpty(mevcutBarkod))
                                    {
                                        // Barkodu yoksa GİRİLEN BARKODU ATA
                                        reader.Close();
                                        string guncelle = "UPDATE urunler SET urun_barkod = @barkod WHERE urun_id = @urun_id";
                                        var guncelleCmd = new SqlCommand(guncelle, conn);
                                        guncelleCmd.Parameters.AddWithValue("@barkod", barkod);
                                        guncelleCmd.Parameters.AddWithValue("@urun_id", urunId);
                                        guncelleCmd.ExecuteNonQuery();
                                    }
                                    else
                                    {
                                        // Barkod varsa ve girilen barkod ile uyuşmuyor!
                                        if (mevcutBarkod != barkod)
                                        {
                                            MessageBox.Show("Girilen barkod ile ürün kodu uyuşmuyor, ürün bilgilerini kontrol edin.");
                                            return;
                                        }
                                    }
                                }
                                else
                                {
                                    // Ürün kodu da yok, yeni ürün sor
                                    reader.Close();
                                    var yeniUrunAdi = Microsoft.VisualBasic.Interaction.InputBox("Yeni ürün adı girin:", "Yeni Ürün", "");
                                    if (string.IsNullOrWhiteSpace(yeniUrunAdi))
                                    {
                                        MessageBox.Show("Ürün adı gerekli.");
                                        return;
                                    }
                                    string insert = "INSERT INTO urunler (urun_adi, urun_kodu, urun_barkod, miktar, birim) VALUES (@adi, @kodu, @barkod, 0, @birim); SELECT SCOPE_IDENTITY();";
                                    var insertCmd = new SqlCommand(insert, conn);
                                    insertCmd.Parameters.AddWithValue("@adi", yeniUrunAdi);
                                    insertCmd.Parameters.AddWithValue("@kodu", urunKodu);
                                    insertCmd.Parameters.AddWithValue("@barkod", barkod);
                                    insertCmd.Parameters.AddWithValue("@birim", birim);
                                    urunId = Convert.ToInt32(insertCmd.ExecuteScalar());
                                    yeniUrunEklendi = true;
                                }
                            }
                        }
                    }
                }
                else // Hiç barkod girilmediyse, sadece ürün koduna bak
                {
                    if (string.IsNullOrEmpty(urunKodu))
                    {
                        MessageBox.Show("Barkod veya ürün kodu girin.");
                        txtUrunKodu.Focus();
                        return;
                    }
                    // Ürün koduyla bul
                    string kodSorgu = "SELECT urun_id, urun_barkod FROM urunler WHERE urun_kodu = @urun_kodu";
                    var kodCmd = new SqlCommand(kodSorgu, conn);
                    kodCmd.Parameters.AddWithValue("@urun_kodu", urunKodu);
                    using (var reader = kodCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            urunId = Convert.ToInt32(reader["urun_id"]);
                        }
                        else
                        {
                            // Yeni ürün
                            reader.Close();
                            var yeniUrunAdi = Microsoft.VisualBasic.Interaction.InputBox("Yeni ürün adı girin:", "Yeni Ürün", "");
                            if (string.IsNullOrWhiteSpace(yeniUrunAdi))
                            {
                                MessageBox.Show("Ürün adı gerekli.");
                                return;
                            }
                            string insert = "INSERT INTO urunler (urun_adi, urun_kodu, urun_barkod, miktar, birim) VALUES (@adi, @kodu, '', 0, @birim); SELECT SCOPE_IDENTITY();";
                            var insertCmd = new SqlCommand(insert, conn);
                            insertCmd.Parameters.AddWithValue("@adi", yeniUrunAdi);
                            insertCmd.Parameters.AddWithValue("@kodu", urunKodu);
                            insertCmd.Parameters.AddWithValue("@birim", birim);
                            urunId = Convert.ToInt32(insertCmd.ExecuteScalar());
                            yeniUrunEklendi = true;
                        }
                    }
                }

                // Hiç ürün yoksa engelle
                if (urunId == -1)
                {
                    MessageBox.Show("Barkod veya ürün kodu bulunamadı. Ürün bilgilerini kontrol edin.");
                    return;
                }

                // Birim kontrolü (eski kodun aynısı)
                string urunBirimSorgu = "SELECT birim FROM urunler WHERE urun_id = @urun_id";
                var birimCmd = new SqlCommand(urunBirimSorgu, conn);
                birimCmd.Parameters.AddWithValue("@urun_id", urunId);
                string eskiBirim = (birimCmd.ExecuteScalar() as string) ?? "adet";
                if (!string.IsNullOrEmpty(eskiBirim) && eskiBirim != birim && !yeniUrunEklendi)
                {
                    if (MessageBox.Show(
                            $"Bu ürün daha önce '{eskiBirim}' birimiyle kayıtlı. Şimdi '{birim}' olarak giriş yapıyorsun. Devam edilsin mi?",
                            "Birim Değişiyor",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning) != DialogResult.Yes)
                        return;
                }

                // Stok hareketleri ve güncellemeler
                string hareketEkle = @"INSERT INTO urun_hareketleri 
(urun_id, hareket_turu, miktar, kullanici_id, islem_turu_id, birim, depo_konum_id) 
VALUES (@urun_id, 'Giris', @miktar, @kullanici_id, 0, @birim, @depo_konum_id)";
                var hareketCmd = new SqlCommand(hareketEkle, conn);
                hareketCmd.Parameters.AddWithValue("@urun_id", urunId);
                hareketCmd.Parameters.AddWithValue("@miktar", miktar);
                hareketCmd.Parameters.AddWithValue("@kullanici_id", _kullaniciId);
                hareketCmd.Parameters.AddWithValue("@birim", birim);
                hareketCmd.Parameters.AddWithValue("@depo_konum_id", seciliKonumId.HasValue ? (object)seciliKonumId.Value : DBNull.Value);
                hareketCmd.ExecuteNonQuery();


                string miktarGuncelle = "UPDATE urunler SET miktar = miktar + @miktar, birim = @birim WHERE urun_id = @urun_id";
                var miktarCmd = new SqlCommand(miktarGuncelle, conn);
                miktarCmd.Parameters.AddWithValue("@miktar", miktar);
                miktarCmd.Parameters.AddWithValue("@birim", birim);
                miktarCmd.Parameters.AddWithValue("@urun_id", urunId);
                miktarCmd.ExecuteNonQuery();

                if (seciliKonumId.HasValue)
                {
                    string kontrol = "SELECT miktar FROM urun_depo_konum WHERE urun_id=@urun_id AND depo_konum_id=@konum_id";
                    var kontrolCmd = new SqlCommand(kontrol, conn);
                    kontrolCmd.Parameters.AddWithValue("@urun_id", urunId);
                    kontrolCmd.Parameters.AddWithValue("@konum_id", seciliKonumId.Value);
                    object mevcutMiktar = kontrolCmd.ExecuteScalar();

                    if (mevcutMiktar != null)
                    {
                        string guncelle = "UPDATE urun_depo_konum SET miktar = miktar + @eklenen WHERE urun_id = @urun_id AND depo_konum_id = @konum_id";
                        var guncelleCmd = new SqlCommand(guncelle, conn);
                        guncelleCmd.Parameters.AddWithValue("@eklenen", miktar);
                        guncelleCmd.Parameters.AddWithValue("@urun_id", urunId);
                        guncelleCmd.Parameters.AddWithValue("@konum_id", seciliKonumId.Value);
                        guncelleCmd.ExecuteNonQuery();
                    }
                    else
                    {
                        string insert = "INSERT INTO urun_depo_konum (urun_id, depo_konum_id, miktar) VALUES (@urun_id, @konum_id, @eklenen)";
                        var insertCmd = new SqlCommand(insert, conn);
                        insertCmd.Parameters.AddWithValue("@urun_id", urunId);
                        insertCmd.Parameters.AddWithValue("@konum_id", seciliKonumId.Value);
                        insertCmd.Parameters.AddWithValue("@eklenen", miktar);
                        insertCmd.ExecuteNonQuery();
                    }
                }

                string adSorgu = "SELECT urun_adi FROM urunler WHERE urun_id = @id";
                var adCmd = new SqlCommand(adSorgu, conn);
                adCmd.Parameters.AddWithValue("@id", urunId);
                string urunAdi = adCmd.ExecuteScalar()?.ToString() ?? "(ad yok)";

                string konumMetni = seciliKonum != null ? seciliKonum.Text : "konum belirtilmedi";
                lblBasariMesaji.Text = $"✔ {urunAdi} ürününden {miktar} {birim} ({konumMetni}) stok girişi yapıldı.";
                lblBasariMesaji.Visible = true;
                mesajTimer.Start();

                txtBarkod.Clear();
                txtUrunKodu.Clear();
                nudMiktar.Value = 1;
                txtBarkod.Focus();
            }
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
