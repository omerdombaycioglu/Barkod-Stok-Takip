namespace StokTakipOtomasyonu.Forms
{
    partial class ManuelUrunGirisiForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblBarkod = new System.Windows.Forms.Label();
            this.txtBarkod = new System.Windows.Forms.TextBox();
            this.btnBarkodAra = new System.Windows.Forms.Button();
            this.lblUrunBilgisi = new System.Windows.Forms.Label();
            this.lblMiktar = new System.Windows.Forms.Label();
            this.txtMiktar = new System.Windows.Forms.TextBox();
            this.lblAciklama = new System.Windows.Forms.Label();
            this.txtAciklama = new System.Windows.Forms.TextBox();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.btnIptal = new System.Windows.Forms.Button();
            this.lblIslemTuru = new System.Windows.Forms.Label();
            this.cmbIslemTuru = new System.Windows.Forms.ComboBox();
            this.panelYeniUrun = new System.Windows.Forms.Panel();
            this.txtUrunNo = new System.Windows.Forms.TextBox();
            this.lblUrunNo = new System.Windows.Forms.Label();
            this.txtUrunMarka = new System.Windows.Forms.TextBox();
            this.lblUrunMarka = new System.Windows.Forms.Label();
            this.txtUrunKodu = new System.Windows.Forms.TextBox();
            this.lblUrunKodu = new System.Windows.Forms.Label();
            this.txtUrunAdi = new System.Windows.Forms.TextBox();
            this.lblUrunAdi = new System.Windows.Forms.Label();
            this.panelYeniUrun.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBarkod
            // 
            this.lblBarkod.AutoSize = true;
            this.lblBarkod.Location = new System.Drawing.Point(40, 37);
            this.lblBarkod.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBarkod.Name = "lblBarkod";
            this.lblBarkod.Size = new System.Drawing.Size(54, 16);
            this.lblBarkod.TabIndex = 0;
            this.lblBarkod.Text = "Barkod:";
            // 
            // txtBarkod
            // 
            this.txtBarkod.Location = new System.Drawing.Point(107, 33);
            this.txtBarkod.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBarkod.Name = "txtBarkod";
            this.txtBarkod.Size = new System.Drawing.Size(199, 22);
            this.txtBarkod.TabIndex = 1;
            this.txtBarkod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarkod_KeyDown);
            // 
            // btnBarkodAra
            // 
            this.btnBarkodAra.Location = new System.Drawing.Point(320, 31);
            this.btnBarkodAra.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBarkodAra.Name = "btnBarkodAra";
            this.btnBarkodAra.Size = new System.Drawing.Size(100, 28);
            this.btnBarkodAra.TabIndex = 2;
            this.btnBarkodAra.Text = "Ara";
            this.btnBarkodAra.UseVisualStyleBackColor = true;
            this.btnBarkodAra.Click += new System.EventHandler(this.btnBarkodAra_Click);
            // 
            // lblUrunBilgisi
            // 
            this.lblUrunBilgisi.AutoSize = true;
            this.lblUrunBilgisi.Location = new System.Drawing.Point(40, 74);
            this.lblUrunBilgisi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUrunBilgisi.Name = "lblUrunBilgisi";
            this.lblUrunBilgisi.Size = new System.Drawing.Size(73, 16);
            this.lblUrunBilgisi.TabIndex = 3;
            this.lblUrunBilgisi.Text = "Ürün bilgisi";
            // 
            // lblMiktar
            // 
            this.lblMiktar.AutoSize = true;
            this.lblMiktar.Location = new System.Drawing.Point(40, 111);
            this.lblMiktar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMiktar.Name = "lblMiktar";
            this.lblMiktar.Size = new System.Drawing.Size(46, 16);
            this.lblMiktar.TabIndex = 4;
            this.lblMiktar.Text = "Miktar:";
            // 
            // txtMiktar
            // 
            this.txtMiktar.Enabled = false;
            this.txtMiktar.Location = new System.Drawing.Point(107, 107);
            this.txtMiktar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMiktar.Name = "txtMiktar";
            this.txtMiktar.Size = new System.Drawing.Size(132, 22);
            this.txtMiktar.TabIndex = 5;
            // 
            // lblAciklama
            // 
            this.lblAciklama.AutoSize = true;
            this.lblAciklama.Location = new System.Drawing.Point(40, 148);
            this.lblAciklama.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAciklama.Name = "lblAciklama";
            this.lblAciklama.Size = new System.Drawing.Size(66, 16);
            this.lblAciklama.TabIndex = 6;
            this.lblAciklama.Text = "Açıklama:";
            // 
            // txtAciklama
            // 
            this.txtAciklama.Location = new System.Drawing.Point(43, 172);
            this.txtAciklama.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAciklama.Multiline = true;
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new System.Drawing.Size(396, 34);
            this.txtAciklama.TabIndex = 7;
            // 
            // btnKaydet
            // 
            this.btnKaydet.Enabled = false;
            this.btnKaydet.Location = new System.Drawing.Point(239, 229);
            this.btnKaydet.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(100, 37);
            this.btnKaydet.TabIndex = 8;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnIptal
            // 
            this.btnIptal.Location = new System.Drawing.Point(347, 229);
            this.btnIptal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(100, 37);
            this.btnIptal.TabIndex = 9;
            this.btnIptal.Text = "İptal";
            this.btnIptal.UseVisualStyleBackColor = true;
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // lblIslemTuru
            // 
            this.lblIslemTuru.AutoSize = true;
            this.lblIslemTuru.Location = new System.Drawing.Point(267, 111);
            this.lblIslemTuru.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIslemTuru.Name = "lblIslemTuru";
            this.lblIslemTuru.Size = new System.Drawing.Size(72, 16);
            this.lblIslemTuru.TabIndex = 10;
            this.lblIslemTuru.Text = "İşlem Türü:";
            // 
            // cmbIslemTuru
            // 
            this.cmbIslemTuru.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIslemTuru.FormattingEnabled = true;
            this.cmbIslemTuru.Location = new System.Drawing.Point(347, 107);
            this.cmbIslemTuru.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbIslemTuru.Name = "cmbIslemTuru";
            this.cmbIslemTuru.Size = new System.Drawing.Size(92, 24);
            this.cmbIslemTuru.TabIndex = 11;
            // 
            // panelYeniUrun
            // 
            this.panelYeniUrun.Controls.Add(this.txtUrunNo);
            this.panelYeniUrun.Controls.Add(this.lblUrunNo);
            this.panelYeniUrun.Controls.Add(this.txtUrunMarka);
            this.panelYeniUrun.Controls.Add(this.lblUrunMarka);
            this.panelYeniUrun.Controls.Add(this.txtUrunKodu);
            this.panelYeniUrun.Controls.Add(this.lblUrunKodu);
            this.panelYeniUrun.Controls.Add(this.txtUrunAdi);
            this.panelYeniUrun.Controls.Add(this.lblUrunAdi);
            this.panelYeniUrun.Location = new System.Drawing.Point(40, 332);
            this.panelYeniUrun.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelYeniUrun.Name = "panelYeniUrun";
            this.panelYeniUrun.Size = new System.Drawing.Size(400, 246);
            this.panelYeniUrun.TabIndex = 12;
            this.panelYeniUrun.Visible = false;
            // 
            // txtUrunNo
            // 
            this.txtUrunNo.Location = new System.Drawing.Point(107, 111);
            this.txtUrunNo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtUrunNo.Name = "txtUrunNo";
            this.txtUrunNo.Size = new System.Drawing.Size(265, 22);
            this.txtUrunNo.TabIndex = 7;
            // 
            // lblUrunNo
            // 
            this.lblUrunNo.AutoSize = true;
            this.lblUrunNo.Location = new System.Drawing.Point(13, 114);
            this.lblUrunNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUrunNo.Name = "lblUrunNo";
            this.lblUrunNo.Size = new System.Drawing.Size(59, 16);
            this.lblUrunNo.TabIndex = 6;
            this.lblUrunNo.Text = "Ürün No:";
            // 
            // txtUrunMarka
            // 
            this.txtUrunMarka.Location = new System.Drawing.Point(107, 74);
            this.txtUrunMarka.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtUrunMarka.Name = "txtUrunMarka";
            this.txtUrunMarka.Size = new System.Drawing.Size(265, 22);
            this.txtUrunMarka.TabIndex = 5;
            // 
            // lblUrunMarka
            // 
            this.lblUrunMarka.AutoSize = true;
            this.lblUrunMarka.Location = new System.Drawing.Point(13, 78);
            this.lblUrunMarka.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUrunMarka.Name = "lblUrunMarka";
            this.lblUrunMarka.Size = new System.Drawing.Size(79, 16);
            this.lblUrunMarka.TabIndex = 4;
            this.lblUrunMarka.Text = "Ürün Marka:";
            // 
            // txtUrunKodu
            // 
            this.txtUrunKodu.Location = new System.Drawing.Point(107, 37);
            this.txtUrunKodu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtUrunKodu.Name = "txtUrunKodu";
            this.txtUrunKodu.Size = new System.Drawing.Size(265, 22);
            this.txtUrunKodu.TabIndex = 3;
            // 
            // lblUrunKodu
            // 
            this.lblUrunKodu.AutoSize = true;
            this.lblUrunKodu.Location = new System.Drawing.Point(13, 41);
            this.lblUrunKodu.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUrunKodu.Name = "lblUrunKodu";
            this.lblUrunKodu.Size = new System.Drawing.Size(72, 16);
            this.lblUrunKodu.TabIndex = 2;
            this.lblUrunKodu.Text = "Ürün Kodu:";
            // 
            // txtUrunAdi
            // 
            this.txtUrunAdi.Location = new System.Drawing.Point(107, 0);
            this.txtUrunAdi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtUrunAdi.Name = "txtUrunAdi";
            this.txtUrunAdi.Size = new System.Drawing.Size(265, 22);
            this.txtUrunAdi.TabIndex = 1;
            // 
            // lblUrunAdi
            // 
            this.lblUrunAdi.AutoSize = true;
            this.lblUrunAdi.Location = new System.Drawing.Point(13, 4);
            this.lblUrunAdi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUrunAdi.Name = "lblUrunAdi";
            this.lblUrunAdi.Size = new System.Drawing.Size(61, 16);
            this.lblUrunAdi.TabIndex = 0;
            this.lblUrunAdi.Text = "Ürün Adı:";
            // 
            // ManuelUrunGirisiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 295);
            this.Controls.Add(this.panelYeniUrun);
            this.Controls.Add(this.cmbIslemTuru);
            this.Controls.Add(this.lblIslemTuru);
            this.Controls.Add(this.btnIptal);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.txtAciklama);
            this.Controls.Add(this.lblAciklama);
            this.Controls.Add(this.txtMiktar);
            this.Controls.Add(this.lblMiktar);
            this.Controls.Add(this.lblUrunBilgisi);
            this.Controls.Add(this.btnBarkodAra);
            this.Controls.Add(this.txtBarkod);
            this.Controls.Add(this.lblBarkod);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "ManuelUrunGirisiForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manuel Ürün Girişi";
            this.panelYeniUrun.ResumeLayout(false);
            this.panelYeniUrun.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBarkod;
        private System.Windows.Forms.TextBox txtBarkod;
        private System.Windows.Forms.Button btnBarkodAra;
        private System.Windows.Forms.Label lblUrunBilgisi;
        private System.Windows.Forms.Label lblMiktar;
        private System.Windows.Forms.TextBox txtMiktar;
        private System.Windows.Forms.Label lblAciklama;
        private System.Windows.Forms.TextBox txtAciklama;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Button btnIptal;
        private System.Windows.Forms.Label lblIslemTuru;
        private System.Windows.Forms.ComboBox cmbIslemTuru;
        private System.Windows.Forms.Panel panelYeniUrun;
        private System.Windows.Forms.TextBox txtUrunAdi;
        private System.Windows.Forms.Label lblUrunAdi;
        private System.Windows.Forms.TextBox txtUrunKodu;
        private System.Windows.Forms.Label lblUrunKodu;
        private System.Windows.Forms.TextBox txtUrunMarka;
        private System.Windows.Forms.Label lblUrunMarka;
        private System.Windows.Forms.TextBox txtUrunNo;
        private System.Windows.Forms.Label lblUrunNo;
    }
}