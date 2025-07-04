using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using StokTakipOtomasyonu.Helpers;

namespace StokTakipOtomasyonu.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            string query = "SELECT kullanici_id, kullanici_yetki FROM kullanicilar " +
                         "WHERE kullanici_adi = @kadi AND sifre = SHA2(@sifre, 256) AND aktif = 1";

            try
            {
                var dt = DatabaseHelper.ExecuteQuery(query,
                    new MySqlParameter("@kadi", txtKullaniciAdi.Text),
                    new MySqlParameter("@sifre", txtSifre.Text));

                if (dt.Rows.Count > 0)
                {
                    int kullaniciId = Convert.ToInt32(dt.Rows[0]["kullanici_id"]);
                    int yetki = Convert.ToInt32(dt.Rows[0]["kullanici_yetki"]);

                    this.Hide();
                    new MainForm(kullaniciId, yetki).Show();
                }
                else
                {
                    MessageBox.Show("Geçersiz kullanıcı adı veya şifre!", "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Giriş hatası: " + ex.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}