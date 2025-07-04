namespace StokTakipOtomasyonu.Forms
{
    partial class ManuelUrunGirisiForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblUrun = new System.Windows.Forms.Label();
            this.cmbUrunler = new System.Windows.Forms.ComboBox();
            this.lblMiktar = new System.Windows.Forms.Label();
            this.txtMiktar = new System.Windows.Forms.TextBox();
            this.lblAciklama = new System.Windows.Forms.Label();
            this.txtAciklama = new System.Windows.Forms.TextBox();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.btnIptal = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblUrun
            this.lblUrun.AutoSize = true;
            this.lblUrun.Location = new System.Drawing.Point(30, 30);
            this.lblUrun.Name = "lblUrun";
            this.lblUrun.Size = new System.Drawing.Size(32, 13);
            this.lblUrun.TabIndex = 0;
            this.lblUrun.Text = "Ürün:";

            // cmbUrunler
            this.cmbUrunler.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUrunler.FormattingEnabled = true;
            this.cmbUrunler.Location = new System.Drawing.Point(80, 27);
            this.cmbUrunler.Name = "cmbUrunler";
            this.cmbUrunler.Size = new System.Drawing.Size(250, 21);
            this.cmbUrunler.TabIndex = 1;

            // lblMiktar
            this.lblMiktar.AutoSize = true;
            this.lblMiktar.Location = new System.Drawing.Point(30, 70);
            this.lblMiktar.Name = "lblMiktar";
            this.lblMiktar.Size = new System.Drawing.Size(36, 13);
            this.lblMiktar.TabIndex = 2;
            this.lblMiktar.Text = "Miktar:";

            // txtMiktar
            this.txtMiktar.Location = new System.Drawing.Point(80, 67);
            this.txtMiktar.Name = "txtMiktar";
            this.txtMiktar.Size = new System.Drawing.Size(100, 20);
            this.txtMiktar.TabIndex = 3;

            // lblAciklama
            this.lblAciklama.AutoSize = true;
            this.lblAciklama.Location = new System.Drawing.Point(30, 110);
            this.lblAciklama.Name = "lblAciklama";
            this.lblAciklama.Size = new System.Drawing.Size(53, 13);
            this.lblAciklama.TabIndex = 4;
            this.lblAciklama.Text = "Açıklama:";

            // txtAciklama
            this.txtAciklama.Location = new System.Drawing.Point(30, 130);
            this.txtAciklama.Multiline = true;
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new System.Drawing.Size(300, 80);
            this.txtAciklama.TabIndex = 5;

            // btnKaydet
            this.btnKaydet.Location = new System.Drawing.Point(180, 220);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(75, 30);
            this.btnKaydet.TabIndex = 6;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);

            // btnIptal
            this.btnIptal.Location = new System.Drawing.Point(260, 220);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(75, 30);
            this.btnIptal.TabIndex = 7;
            this.btnIptal.Text = "İptal";
            this.btnIptal.UseVisualStyleBackColor = true;
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);

            // ManuelUrunGirisiForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 270);
            this.Controls.Add(this.btnIptal);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.txtAciklama);
            this.Controls.Add(this.lblAciklama);
            this.Controls.Add(this.txtMiktar);
            this.Controls.Add(this.lblMiktar);
            this.Controls.Add(this.cmbUrunler);
            this.Controls.Add(this.lblUrun);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ManuelUrunGirisiForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manuel Ürün Girişi";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblUrun;
        private System.Windows.Forms.ComboBox cmbUrunler;
        private System.Windows.Forms.Label lblMiktar;
        private System.Windows.Forms.TextBox txtMiktar;
        private System.Windows.Forms.Label lblAciklama;
        private System.Windows.Forms.TextBox txtAciklama;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Button btnIptal;
    }
}