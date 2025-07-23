using MySql.Data.MySqlClient;
using NPOI.SS.Formula.Functions;
using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using static StokTakipOtomasyonu.Forms.ManuelUrunGirisiForm;

namespace StokTakipOtomasyonu.Forms
{
    public partial class ManuelUrunCikisiForm : Form
    {
        private readonly int _kullaniciId;
        private readonly string _connectionString = "server=localhost;user=root;database=stok_takip_otomasyonu;password=;";

        public ManuelUrunCikisiForm(int kullaniciId)
        {
            this.Icon = new Icon("isp_logo2.ico");
            InitializeComponent();
            _kullaniciId = kullaniciId;
            cmbIslemTuru.SelectedIndex = 0;
            txtBarkod.Focus();
            this.StartPosition = FormStartPosition.CenterParent;

            // Depo konumları doldur
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
            cmbDepoKonum.SelectedIndex = -1; // Otomatik seçmesin
        }


        private async void txtBarkod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                await UrunCikisIslemiAsync();
                e.SuppressKeyPress = true;
            }
        }

        private async void btnKaydet_Click(object sender, EventArgs e)
        {
            await UrunCikisIslemiAsync();
        }

        private async Task UrunCikisIslemiAsync()
        {
            string barkod = txtBarkod.Text.Trim();
            int miktar = (int)nudMiktar.Value;
            int? depoKonumId = null;
            if (cmbDepoKonum.SelectedItem != null)
                depoKonumId = ((ComboBoxItem)cmbDepoKonum.SelectedItem).Value;

            if (string.IsNullOrEmpty(barkod))
            {
                await ShowMessageAsync("Lütfen bir barkod girin.", false);
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connectionString))
                {
                    await conn.OpenAsync();

                    MySqlCommand cmd = new MySqlCommand("SELECT urun_id, urun_adi, miktar, birim FROM urunler WHERE urun_barkod = @barkod", conn);
                    string birim = "";
                    cmd.Parameters.AddWithValue("@barkod", barkod);

                    int urunId = 0;
                    string urunAdi = "";
                    int stokMiktari = 0;

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            urunId = Convert.ToInt32(reader["urun_id"]);
                            urunAdi = reader["urun_adi"].ToString();
                            stokMiktari = Convert.ToInt32(reader["miktar"]);
                            birim = reader["birim"].ToString();
                        }
                        else
                        {
                            await ShowMessageAsync("Ürün bulunamadı.", false);
                            return;
                        }
                    }

                    // Eğer depo konumu seçiliyse, o konumdan miktarı kontrol et ve çıkar
                    if (depoKonumId != null)
                    {
                        // Depo-konum stok kontrolü
                        MySqlCommand konumStokCmd = new MySqlCommand(
                            "SELECT miktar FROM urun_depo_konum WHERE urun_id=@urun_id AND depo_konum_id=@konum_id", conn);
                        konumStokCmd.Parameters.AddWithValue("@urun_id", urunId);
                        konumStokCmd.Parameters.AddWithValue("@konum_id", depoKonumId);
                        object mevcut = await konumStokCmd.ExecuteScalarAsync();

                        if (mevcut == null)
                        {
                            // Kayıt yoksa, bu ürün bu konumda hiç yok!
                            await ShowMessageAsync("Bu ürün seçilen depoda mevcut değil!", false);
                            return;
                        }

                        int konumStok = Convert.ToInt32(mevcut);

                        if (konumStok < miktar)
                        {
                            await ShowMessageAsync($"Yetersiz stok: Seçili konumda sadece {konumStok} {birim} var.", false);
                            return;
                        }

                        // Hareket ve konum-stok güncelle
                        string query = @"
    INSERT INTO urun_hareketleri (urun_id, hareket_turu, miktar, kullanici_id, islem_turu_id, depo_konum_id, aciklama)
    VALUES (@uid, 'Cikis', @miktar, @kullanici_id, @islem_turu_id, @konum_id, @aciklama);
    UPDATE urunler SET miktar = miktar - @miktar WHERE urun_id = @uid;
    UPDATE urun_depo_konum SET miktar = miktar - @miktar WHERE urun_id = @uid AND depo_konum_id = @konum_id;";


                        MySqlCommand updateCmd = new MySqlCommand(query, conn);
                        updateCmd.Parameters.AddWithValue("@uid", urunId);
                        updateCmd.Parameters.AddWithValue("@miktar", miktar);
                        updateCmd.Parameters.AddWithValue("@kullanici_id", _kullaniciId);
                        updateCmd.Parameters.AddWithValue("@islem_turu_id", cmbIslemTuru.SelectedIndex == 0 ? 0 : 2);
                        updateCmd.Parameters.AddWithValue("@konum_id", depoKonumId);
                        updateCmd.Parameters.AddWithValue("@aciklama", textBox1.Text.Trim());


                        await updateCmd.ExecuteNonQueryAsync();

                        await ShowMessageAsync($"{urunAdi} ürününden {miktar} {birim} çıkış yapıldı. (Konum: {((ComboBoxItem)cmbDepoKonum.SelectedItem).Text})", true);
                    }
                    else
                    {
                        // Depo konumu seçilmediyse klasik çıkar
                        if (stokMiktari < miktar)
                        {
                            await ShowMessageAsync($"Yetersiz stok: Stokta sadece {stokMiktari} {birim} var.", false);
                            return;
                        }

                        string query = @"
    INSERT INTO urun_hareketleri (urun_id, hareket_turu, miktar, kullanici_id, islem_turu_id, aciklama)
    VALUES (@uid, 'Cikis', @miktar, @kullanici_id, @islem_turu_id, @aciklama);
    UPDATE urunler SET miktar = miktar - @miktar WHERE urun_id = @uid;";


                        MySqlCommand updateCmd = new MySqlCommand(query, conn);
                        updateCmd.Parameters.AddWithValue("@uid", urunId);
                        updateCmd.Parameters.AddWithValue("@miktar", miktar);
                        updateCmd.Parameters.AddWithValue("@kullanici_id", _kullaniciId);
                        updateCmd.Parameters.AddWithValue("@islem_turu_id", cmbIslemTuru.SelectedIndex == 0 ? 0 : 2);
                        updateCmd.Parameters.AddWithValue("@aciklama", textBox1.Text.Trim());


                        await updateCmd.ExecuteNonQueryAsync();

                        await ShowMessageAsync($"{urunAdi} ürününden {miktar} {birim} çıkış yapıldı.", true);
                    }

                    txtBarkod.Clear();
                    nudMiktar.Value = 1;
                    txtBarkod.Focus();
                }
            }
            catch (Exception ex)
            {
                await ShowMessageAsync("Hata: " + ex.Message, false);
            }
        }




        private async Task ShowMessageAsync(string message, bool success)
        {
            lblBasariMesaji.Text = message;
            lblBasariMesaji.ForeColor = success ? Color.Green : Color.Red;
            lblBasariMesaji.Visible = true;
            await Task.Delay(2000);
            lblBasariMesaji.Visible = false;
        }
        public class ComboBoxItem
        {
            public string Text { get; set; }
            public int Value { get; set; }
            public override string ToString() { return Text; }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
