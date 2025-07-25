using Org.BouncyCastle.Tls;
using StokTakipOtomasyonu.Helpers;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace StokTakipOtomasyonu.Forms
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            lblLoading.Visible = false; // <-- Ekle
            LoadCurrentSettings();
        }

        private void LoadCurrentSettings()
        {
            // Mevcut connection string’i oku
            var connStr = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;

            // Bağlantı stringini parçala ve kutulara doldur
            var builder = new System.Data.SqlClient.SqlConnectionStringBuilder(connStr);
            txtServer.Text = builder.DataSource;
            txtDatabase.Text = builder.InitialCatalog;
            txtUser.Text = builder.UserID;
            txtPassword.Text = builder.Password;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            lblLoading.Visible = true;    // <-- 1. Kaydet basınca görünür yap
            btnSave.Enabled = false;
            Application.DoEvents();       // lblLoading hemen gözüksün diye

            // Yeni bağlantı stringini oluştur
            var builder = new System.Data.SqlClient.SqlConnectionStringBuilder
            {
                DataSource = txtServer.Text,
                InitialCatalog = txtDatabase.Text,
                UserID = txtUser.Text,
                Password = txtPassword.Text,
                IntegratedSecurity = false
            };
            UpdateConnectionString("MyDb", builder.ConnectionString);

            // Bağlantı test et
            bool result = DatabaseHelper.TestConnection();

            lblLoading.Visible = false;   // <-- 2. İşlem bitince gizle
            btnSave.Enabled = true;

            if (result)
            {
                MessageBox.Show("Bağlantı başarılı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Bağlantı hatası! Bağlantı bilgilerinizi kontrol edin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Form açık kalır, kullanıcı tekrar deneyebilir!
            }
        }


        private void UpdateConnectionString(string name, string connString)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.ConnectionStrings.ConnectionStrings[name].ConnectionString = connString;
            config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("connectionStrings");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
                this.DialogResult = DialogResult.Cancel;
        }
        private void btnBaglan_Click(object sender, EventArgs e)
        {           
            Application.DoEvents(); // ProgressBar hemen gözüksün diye

            // Zaman alan işlemin burada:
            bool result = DatabaseHelper.TestConnection();            

            if (result)
                MessageBox.Show("Bağlantı başarılı!");
            else
                MessageBox.Show("Bağlantı hatası!");
        }

        
    }
}

