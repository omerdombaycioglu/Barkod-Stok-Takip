using Org.BouncyCastle.Tls;
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

            MessageBox.Show("Bağlantı bilgileri kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
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

    }
}

