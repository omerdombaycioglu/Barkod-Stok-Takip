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
            // 
            // dgvKullanicilar
            // 
            this.dgvKullanicilar.AllowUserToAddRows = false;
            this.dgvKullanicilar.AllowUserToDeleteRows = false;
            this.dgvKullanicilar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvKullanicilar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKullanicilar.ColumnHeadersHeight = 29;
            this.dgvKullanicilar.Location = new System.Drawing.Point(20, 70);
            this.dgvKullanicilar.Name = "dgvKullanicilar";
            this.dgvKullanicilar.RowHeadersWidth = 51;
            this.dgvKullanicilar.Size = new System.Drawing.Size(760, 240);
            this.dgvKullanicilar.TabIndex = 1;
            // 
            // txtYeniKullaniciAdi
            // 
            this.txtYeniKullaniciAdi.Location = new System.Drawing.Point(120, 322);
            this.txtYeniKullaniciAdi.Name = "txtYeniKullaniciAdi";
            this.txtYeniKullaniciAdi.Size = new System.Drawing.Size(200, 22);
            this.txtYeniKullaniciAdi.TabIndex = 3;
            // 
            // txtYeniSifre
            // 
            this.txtYeniSifre.Location = new System.Drawing.Point(120, 352);
            this.txtYeniSifre.Name = "txtYeniSifre";
            this.txtYeniSifre.Size = new System.Drawing.Size(200, 22);
            this.txtYeniSifre.TabIndex = 5;
            // 
            // txtYeniAdSoyad
            // 
            this.txtYeniAdSoyad.Location = new System.Drawing.Point(120, 382);
            this.txtYeniAdSoyad.Name = "txtYeniAdSoyad";
            this.txtYeniAdSoyad.Size = new System.Drawing.Size(200, 22);
            this.txtYeniAdSoyad.TabIndex = 7;
            // 
            // cmbYeniYetki
            // 
            this.cmbYeniYetki.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYeniYetki.Items.AddRange(new object[] {
            "Yönetici",
            "Standart Kullanıcı"});
            this.cmbYeniYetki.Location = new System.Drawing.Point(120, 412);
            this.cmbYeniYetki.Name = "cmbYeniYetki";
            this.cmbYeniYetki.Size = new System.Drawing.Size(200, 24);
            this.cmbYeniYetki.TabIndex = 9;
            // 
            // btnYeniKullanici
            // 
            this.btnYeniKullanici.BackColor = System.Drawing.Color.DimGray;
            this.btnYeniKullanici.FlatAppearance.BorderSize = 0;
            this.btnYeniKullanici.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYeniKullanici.ForeColor = System.Drawing.Color.White;
            this.btnYeniKullanici.Location = new System.Drawing.Point(350, 322);
            this.btnYeniKullanici.Name = "btnYeniKullanici";
            this.btnYeniKullanici.Size = new System.Drawing.Size(180, 40);
            this.btnYeniKullanici.TabIndex = 10;
            this.btnYeniKullanici.Text = "Yeni Kullanıcı Ekle";
            this.btnYeniKullanici.UseVisualStyleBackColor = false;
            this.btnYeniKullanici.Click += new System.EventHandler(this.btnYeniKullanici_Click);
            // 
            // btnKapat
            // 
            this.btnKapat.BackColor = System.Drawing.Color.IndianRed;
            this.btnKapat.FlatAppearance.BorderSize = 0;
            this.btnKapat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKapat.ForeColor = System.Drawing.Color.White;
            this.btnKapat.Location = new System.Drawing.Point(350, 372);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(180, 40);
            this.btnKapat.TabIndex = 11;
            this.btnKapat.Text = "Kaydet ve Kapat";
            this.btnKapat.UseVisualStyleBackColor = false;
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.LightGray;
            this.panelTop.Controls.Add(this.lblBaslik);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(800, 60);
            this.panelTop.TabIndex = 0;
            // 
            // lblBaslik
            // 
            this.lblBaslik.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.Location = new System.Drawing.Point(20, 15);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(287, 45);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "Kullanıcı Yönetimi";
            // 
            // lblKullaniciAdi
            // 
            this.lblKullaniciAdi.Location = new System.Drawing.Point(20, 325);
            this.lblKullaniciAdi.Name = "lblKullaniciAdi";
            this.lblKullaniciAdi.Size = new System.Drawing.Size(100, 23);
            this.lblKullaniciAdi.TabIndex = 2;
            this.lblKullaniciAdi.Text = "Kullanıcı Adı:";
            // 
            // lblSifre
            // 
            this.lblSifre.Location = new System.Drawing.Point(20, 355);
            this.lblSifre.Name = "lblSifre";
            this.lblSifre.Size = new System.Drawing.Size(100, 23);
            this.lblSifre.TabIndex = 4;
            this.lblSifre.Text = "Şifre:";
            // 
            // lblAdSoyad
            // 
            this.lblAdSoyad.Location = new System.Drawing.Point(20, 385);
            this.lblAdSoyad.Name = "lblAdSoyad";
            this.lblAdSoyad.Size = new System.Drawing.Size(100, 23);
            this.lblAdSoyad.TabIndex = 6;
            this.lblAdSoyad.Text = "Ad Soyad:";
            // 
            // lblYetki
            // 
            this.lblYetki.Location = new System.Drawing.Point(20, 415);
            this.lblYetki.Name = "lblYetki";
            this.lblYetki.Size = new System.Drawing.Size(100, 23);
            this.lblYetki.TabIndex = 8;
            this.lblYetki.Text = "Yetki:";
            // 
            // KullaniciForm
            // 
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
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kullanıcı Yönetimi";
            this.Load += new System.EventHandler(this.KullaniciForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKullanicilar)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
