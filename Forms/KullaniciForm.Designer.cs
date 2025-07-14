using System.Windows.Forms;

namespace StokTakipOtomasyonu.Forms
{
    partial class KullaniciForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvKullanicilar;
        private System.Windows.Forms.TextBox txtYeniKullaniciAdi;
        private System.Windows.Forms.TextBox txtYeniSifre;
        private System.Windows.Forms.TextBox txtYeniAdSoyad;
        private System.Windows.Forms.ComboBox cmbYeniYetki;
        private System.Windows.Forms.Button btnYeniKullanici;
        private System.Windows.Forms.Button btnKapat;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblBaslik;

        private System.Windows.Forms.Label lblKullaniciAdi;
        private System.Windows.Forms.Label lblSifre;
        private System.Windows.Forms.Label lblAdSoyad;
        private System.Windows.Forms.Label lblYetki;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvKullanicilar = new System.Windows.Forms.DataGridView();
            this.txtYeniKullaniciAdi = new System.Windows.Forms.TextBox();
            this.txtYeniSifre = new System.Windows.Forms.TextBox();
            this.txtYeniAdSoyad = new System.Windows.Forms.TextBox();
            this.cmbYeniYetki = new System.Windows.Forms.ComboBox();
            this.btnYeniKullanici = new System.Windows.Forms.Button();
            this.btnKapat = new System.Windows.Forms.Button();
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblBaslik = new System.Windows.Forms.Label();
            this.lblKullaniciAdi = new System.Windows.Forms.Label();
            this.lblSifre = new System.Windows.Forms.Label();
            this.lblAdSoyad = new System.Windows.Forms.Label();
            this.lblYetki = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvKullanicilar)).BeginInit();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();

            // Panel
            this.panelTop.BackColor = System.Drawing.Color.LightGray;
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Height = 60;
            this.panelTop.Controls.Add(this.lblBaslik);

            this.lblBaslik.Text = "Kullanıcı Yönetimi";
            this.lblBaslik.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.Location = new System.Drawing.Point(20, 15);

            // Grid
            this.dgvKullanicilar.Anchor = ((System.Windows.Forms.AnchorStyles)
                ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvKullanicilar.Location = new System.Drawing.Point(20, 70);
            this.dgvKullanicilar.Size = new System.Drawing.Size(760, 240);
            this.dgvKullanicilar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKullanicilar.ReadOnly = false;
            this.dgvKullanicilar.AllowUserToAddRows = false;
            this.dgvKullanicilar.AllowUserToDeleteRows = false;

            // Labels
            this.lblKullaniciAdi.Text = "Kullanıcı Adı:";
            this.lblKullaniciAdi.Location = new System.Drawing.Point(20, 325);
            this.lblSifre.Text = "Şifre:";
            this.lblSifre.Location = new System.Drawing.Point(20, 355);
            this.lblAdSoyad.Text = "Ad Soyad:";
            this.lblAdSoyad.Location = new System.Drawing.Point(20, 385);
            this.lblYetki.Text = "Yetki:";
            this.lblYetki.Location = new System.Drawing.Point(20, 415);

            // Inputs
            this.txtYeniKullaniciAdi.Location = new System.Drawing.Point(120, 322);
            this.txtYeniKullaniciAdi.Size = new System.Drawing.Size(200, 22);

            this.txtYeniSifre.Location = new System.Drawing.Point(120, 352);
            this.txtYeniSifre.Size = new System.Drawing.Size(200, 22);

            this.txtYeniAdSoyad.Location = new System.Drawing.Point(120, 382);
            this.txtYeniAdSoyad.Size = new System.Drawing.Size(200, 22);

            this.cmbYeniYetki.Location = new System.Drawing.Point(120, 412);
            this.cmbYeniYetki.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbYeniYetki.Size = new System.Drawing.Size(200, 22);
            this.cmbYeniYetki.Items.AddRange(new object[] { "Yönetici", "Standart Kullanıcı" });

            // Butonlar
            this.btnYeniKullanici.Text = "Yeni Kullanıcı Ekle";
            this.btnYeniKullanici.Location = new System.Drawing.Point(350, 322);
            this.btnYeniKullanici.Size = new System.Drawing.Size(180, 40);
            this.btnYeniKullanici.BackColor = System.Drawing.Color.DimGray;
            this.btnYeniKullanici.ForeColor = System.Drawing.Color.White;
            this.btnYeniKullanici.FlatStyle = FlatStyle.Flat;
            this.btnYeniKullanici.FlatAppearance.BorderSize = 0;
            this.btnYeniKullanici.Click += new System.EventHandler(this.btnYeniKullanici_Click);

            this.btnKapat.Text = "Kapat";
            this.btnKapat.Location = new System.Drawing.Point(350, 372);
            this.btnKapat.Size = new System.Drawing.Size(180, 40);
            this.btnKapat.BackColor = System.Drawing.Color.IndianRed;
            this.btnKapat.ForeColor = System.Drawing.Color.White;
            this.btnKapat.FlatStyle = FlatStyle.Flat;
            this.btnKapat.FlatAppearance.BorderSize = 0;
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);

            // Form
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(800, 470);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.dgvKullanicilar);
            this.Controls.Add(this.lblKullaniciAdi);
            this.Controls.Add(this.txtYeniKullaniciAdi);
            this.Controls.Add(this.lblSifre);
            this.Controls.Add(this.txtYeniSifre);
            this.Controls.Add(this.lblAdSoyad);
            this.Controls.Add(this.txtYeniAdSoyad);
            this.Controls.Add(this.lblYetki);
            this.Controls.Add(this.cmbYeniYetki);
            this.Controls.Add(this.btnYeniKullanici);
            this.Controls.Add(this.btnKapat);
            this.Name = "KullaniciForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Kullanıcı Yönetimi";
            this.Load += new System.EventHandler(this.KullaniciForm_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvKullanicilar)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
