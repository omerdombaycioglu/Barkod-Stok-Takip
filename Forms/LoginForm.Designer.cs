namespace StokTakipOtomasyonu.Forms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblKullaniciAdi = new System.Windows.Forms.Label();
            this.txtKullaniciAdi = new System.Windows.Forms.TextBox();
            this.lblSifre = new System.Windows.Forms.Label();
            this.txtSifre = new System.Windows.Forms.TextBox();
            this.btnGiris = new System.Windows.Forms.Button();
            this.btnIptal = new System.Windows.Forms.Button();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();

            // lblKullaniciAdi
            this.lblKullaniciAdi.AutoSize = true;
            this.lblKullaniciAdi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblKullaniciAdi.ForeColor = System.Drawing.Color.DimGray;
            this.lblKullaniciAdi.Location = new System.Drawing.Point(40, 150);
            this.lblKullaniciAdi.Text = "Kullanıcı Adı:";

            // txtKullaniciAdi
            this.txtKullaniciAdi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtKullaniciAdi.Location = new System.Drawing.Point(160, 147);
            this.txtKullaniciAdi.Size = new System.Drawing.Size(199, 25);

            // lblSifre
            this.lblSifre.AutoSize = true;
            this.lblSifre.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSifre.ForeColor = System.Drawing.Color.DimGray;
            this.lblSifre.Location = new System.Drawing.Point(40, 195);
            this.lblSifre.Text = "Şifre:";

            // txtSifre
            this.txtSifre.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSifre.Location = new System.Drawing.Point(160, 192);
            this.txtSifre.PasswordChar = '*';
            this.txtSifre.Size = new System.Drawing.Size(199, 25);
            this.txtSifre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSifre_KeyDown);

            // btnGiris
            this.btnGiris.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.btnGiris.FlatAppearance.BorderSize = 0;
            this.btnGiris.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGiris.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnGiris.ForeColor = System.Drawing.Color.White;
            this.btnGiris.Location = new System.Drawing.Point(160, 240);
            this.btnGiris.Size = new System.Drawing.Size(90, 35);
            this.btnGiris.Text = "Giriş";
            this.btnGiris.UseVisualStyleBackColor = false;
            this.btnGiris.Click += new System.EventHandler(this.btnGiris_Click);

            // btnIptal
            this.btnIptal.BackColor = System.Drawing.Color.IndianRed;
            this.btnIptal.FlatAppearance.BorderSize = 0;
            this.btnIptal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIptal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnIptal.ForeColor = System.Drawing.Color.White;
            this.btnIptal.Location = new System.Drawing.Point(269, 240);
            this.btnIptal.Size = new System.Drawing.Size(90, 35);
            this.btnIptal.Text = "İptal";
            this.btnIptal.UseVisualStyleBackColor = false;
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);

            // pictureBoxLogo
            this.pictureBoxLogo.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxLogo.BorderStyle = System.Windows.Forms.BorderStyle.None; // Çerçeveyi kaldırdık
            this.pictureBoxLogo.Image = global::IspBarkodStok.Properties.Resources.isp_logo1;
            this.pictureBoxLogo.Location = new System.Drawing.Point(91, 20);
            this.pictureBoxLogo.Size = new System.Drawing.Size(218, 111);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabStop = false;

            // LoginForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.btnIptal);
            this.Controls.Add(this.btnGiris);
            this.Controls.Add(this.txtSifre);
            this.Controls.Add(this.txtKullaniciAdi);
            this.Controls.Add(this.lblSifre);
            this.Controls.Add(this.lblKullaniciAdi);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stok Takip Otomasyonu - Giriş";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblKullaniciAdi;
        private System.Windows.Forms.TextBox txtKullaniciAdi;
        private System.Windows.Forms.Label lblSifre;
        private System.Windows.Forms.TextBox txtSifre;
        private System.Windows.Forms.Button btnGiris;
        private System.Windows.Forms.Button btnIptal;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
    }
}
