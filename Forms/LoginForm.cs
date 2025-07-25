using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Data.SqlClient;
using StokTakipOtomasyonu.Helpers;

namespace StokTakipOtomasyonu.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            this.Icon = new Icon("isp_logo2.ico");
            InitializeComponent();         

            this.Shown += (s, e) => txtKullaniciAdi.Focus();
        }
        
        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtKullaniciAdi.TabIndex = 0;
            txtSifre.TabIndex = 1;
            btnGiris.TabIndex = 2;
            btnIptal.TabIndex = 3;

            txtKullaniciAdi.Focus();
        }


        private void btnGiris_Click(object sender, EventArgs e)
        {
            string query = "SELECT kullanici_id, kullanici_yetki FROM kullanicilar " +
                         "WHERE kullanici_adi = @kadi AND sifre = @sifre AND aktif = 1";

            try
            {
                if (string.IsNullOrWhiteSpace(txtKullaniciAdi.Text) ||
                    string.IsNullOrWhiteSpace(txtSifre.Text))
                {
                    MessageBox.Show("Kullanıcı adı ve şifre boş olamaz!", "Uyarı",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var dt = DatabaseHelper.ExecuteQuery(query,
                    new SqlParameter("@kadi", txtKullaniciAdi.Text),
                    new SqlParameter("@sifre", txtSifre.Text));

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

        private void txtSifre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGiris.PerformClick();
            }
        }
    }
}