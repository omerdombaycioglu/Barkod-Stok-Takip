using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

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

                    MySqlCommand cmd = new MySqlCommand("SELECT urun_id, urun_adi, miktar FROM urunler WHERE urun_barkod = @barkod", conn);
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
                        }
                        else
                        {
                            await ShowMessageAsync("Ürün bulunamadı.", false);
                            return;
                        }
                    }

                    // 🛑 Stok kontrolü
                    if (stokMiktari < miktar)
                    {
                        await ShowMessageAsync($"Yetersiz stok: Stokta sadece {stokMiktari} adet var.", false);
                        return;
                    }

                    string query = @"
                INSERT INTO urun_hareketleri (urun_id, hareket_turu, miktar, kullanici_id, islem_turu_id)
                VALUES (@uid, 'Cikis', @miktar, @kullanici_id, @islem_turu_id);
                UPDATE urunler SET miktar = miktar - @miktar WHERE urun_id = @uid;";

                    MySqlCommand updateCmd = new MySqlCommand(query, conn);
                    updateCmd.Parameters.AddWithValue("@uid", urunId);
                    updateCmd.Parameters.AddWithValue("@miktar", miktar);
                    updateCmd.Parameters.AddWithValue("@kullanici_id", _kullaniciId);
                    updateCmd.Parameters.AddWithValue("@islem_turu_id", cmbIslemTuru.SelectedIndex == 0 ? 0 : 2);

                    await updateCmd.ExecuteNonQueryAsync();

                    txtBarkod.Clear();
                    nudMiktar.Value = 1;
                    txtBarkod.Focus();

                    await ShowMessageAsync($"{urunAdi} ürününden {miktar} adet çıkış yapıldı.", true);
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
    }
}
