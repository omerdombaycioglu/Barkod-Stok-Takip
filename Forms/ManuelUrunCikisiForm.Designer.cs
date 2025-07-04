namespace StokTakipOtomasyonu.Forms
{
    partial class ManuelUrunCikisiForm
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
            this.lblIslemTuru = new System.Windows.Forms.Label();
            this.cmbIslemTuru = new System.Windows.Forms.ComboBox();
            this.lblProje = new System.Windows.Forms.Label();
            this.cmbProjeler = new System.Windows.Forms.ComboBox();
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

            // lblIslemTuru
            this.lblIslemTuru.AutoSize = true;
            this.lblIslemTuru.Location = new System.Drawing.Point(30, 110);
            this.lblIslemTuru.Name = "lblIslemTuru";
            this.lblIslemTuru.Size = new System.Drawing.Size(56, 13);
            this.lblIslemTuru.TabIndex = 4;
            this.lblIslemTuru.Text = "İşlem Türü:";

            // cmbIslemTuru
            this.cmbIslemTuru.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIslemTuru.FormattingEnabled = true;
            this.cmbIslemTuru.Location = new System.Drawing.Point(100, 107);
            this.cmbIslemTuru.Name = "cmbIslemTuru";
            this.cmbIslemTuru.Size = new System.Drawing.Size(150, 21);
            this.cmbIslemTuru.TabIndex = 5;
            this.cmbIslemTuru.SelectedIndexChanged += new System.EventHandler(this.cmbIslemTuru_SelectedIndexChanged);

            // lblProje
            this.lblProje.AutoSize = true;
            this.lblProje.Location = new System.Drawing.Point(30, 150);
            this.lblProje.Name = "lblProje";
            this.lblProje.Size = new System.Drawing.Size(34, 13);
            this.lblProje.TabIndex = 6;
            this.lblProje.Text = "Proje:";

            // cmbProjeler
            this.cmbProjeler.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProjeler.FormattingEnabled = true;
            this.cmbProjeler.Location = new System.Drawing.Point(80, 147);
            this.cmbProjeler.Name = "cmbProjeler";
            this.cmbProjeler.Size = new System.Drawing.Size(250, 21);
            this.cmbProjeler.TabIndex = 7;

            // lblAciklama
            this.lblAciklama.AutoSize = true;
            this.lblAciklama.Location = new System.Drawing.Point(30, 190);
            this.lblAciklama.Name = "lblAciklama";
            this.lblAciklama.Size = new System.Drawing.Size(53, 13);
            this.lblAciklama.TabIndex = 8;
            this.lblAciklama.Text = "Açıklama:";

            // txtAciklama
            this.txtAciklama.Location = new System.Drawing.Point(30, 210);
            this.txtAciklama.Multiline = true;
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new System.Drawing.Size(300, 60);
            this.txtAciklama.TabIndex = 9;

            // btnKaydet
            this.btnKaydet.Location = new System.Drawing.Point(180, 280);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(75, 30);
            this.btnKaydet.TabIndex = 10;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);

            // btnIptal
            this.btnIptal.Location = new System.Drawing.Point(260, 280);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(75, 30);
            this.btnIptal.TabIndex = 11;
            this.btnIptal.Text = "İptal";
            this.btnIptal.UseVisualStyleBackColor = true;
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);

            // ManuelUrunCikisiForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 330);
            this.Controls.Add(this.btnIptal);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.txtAciklama);
            this.Controls.Add(this.lblAciklama);
            this.Controls.Add(this.cmbProjeler);
            this.Controls.Add(this.lblProje);
            this.Controls.Add(this.cmbIslemTuru);
            this.Controls.Add(this.lblIslemTuru);
            this.Controls.Add(this.txtMiktar);
            this.Controls.Add(this.lblMiktar);
            this.Controls.Add(this.cmbUrunler);
            this.Controls.Add(this.lblUrun);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ManuelUrunCikisiForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manuel Ürün Çıkışı";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblUrun;
        private System.Windows.Forms.ComboBox cmbUrunler;
        private System.Windows.Forms.Label lblMiktar;
        private System.Windows.Forms.TextBox txtMiktar;
        private System.Windows.Forms.Label lblIslemTuru;
        private System.Windows.Forms.ComboBox cmbIslemTuru;
        private System.Windows.Forms.Label lblProje;
        private System.Windows.Forms.ComboBox cmbProjeler;
        private System.Windows.Forms.Label lblAciklama;
        private System.Windows.Forms.TextBox txtAciklama;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Button btnIptal;
    }
}