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
            this.lblProje = new System.Windows.Forms.Label();
            this.cmbProje = new System.Windows.Forms.ComboBox();
            this.lblUrunKoduAra = new System.Windows.Forms.Label();
            this.txtUrunKoduAra = new System.Windows.Forms.TextBox();
            this.btnUrunKoduAra = new System.Windows.Forms.Button();
            this.panelYeniUrun.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBarkod
            // 
            this.lblBarkod.AutoSize = true;
            this.lblBarkod.Location = new System.Drawing.Point(30, 30);
            this.lblBarkod.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBarkod.Name = "lblBarkod";
            this.lblBarkod.Size = new System.Drawing.Size(44, 13);
            this.lblBarkod.TabIndex = 0;
            this.lblBarkod.Text = "Barkod:";
            // 
            // txtBarkod
            // 
            this.txtBarkod.Location = new System.Drawing.Point(80, 27);
            this.txtBarkod.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtBarkod.Name = "txtBarkod";
            this.txtBarkod.Size = new System.Drawing.Size(150, 20);
            this.txtBarkod.TabIndex = 1;
            // 
            // btnBarkodAra
            // 
            this.btnBarkodAra.Location = new System.Drawing.Point(240, 25);
            this.btnBarkodAra.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBarkodAra.Name = "btnBarkodAra";
            this.btnBarkodAra.Size = new System.Drawing.Size(75, 23);
            this.btnBarkodAra.TabIndex = 2;
            this.btnBarkodAra.Text = "Ara";
            this.btnBarkodAra.UseVisualStyleBackColor = true;
            // 
            // lblUrunBilgisi
            // 
            this.lblUrunBilgisi.AutoSize = true;
            this.lblUrunBilgisi.Location = new System.Drawing.Point(22, 86);
            this.lblUrunBilgisi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUrunBilgisi.Name = "lblUrunBilgisi";
            this.lblUrunBilgisi.Size = new System.Drawing.Size(58, 13);
            this.lblUrunBilgisi.TabIndex = 3;
            this.lblUrunBilgisi.Text = "Ürün bilgisi";
            // 
            // lblMiktar
            // 
            this.lblMiktar.AutoSize = true;
            this.lblMiktar.Location = new System.Drawing.Point(30, 114);
            this.lblMiktar.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMiktar.Name = "lblMiktar";
            this.lblMiktar.Size = new System.Drawing.Size(39, 13);
            this.lblMiktar.TabIndex = 4;
            this.lblMiktar.Text = "Miktar:";
            // 
            // txtMiktar
            // 
            this.txtMiktar.Enabled = false;
            this.txtMiktar.Location = new System.Drawing.Point(80, 110);
            this.txtMiktar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtMiktar.Name = "txtMiktar";
            this.txtMiktar.Size = new System.Drawing.Size(100, 20);
            this.txtMiktar.TabIndex = 5;
            // 
            // lblAciklama
            // 
            this.lblAciklama.AutoSize = true;
            this.lblAciklama.Location = new System.Drawing.Point(30, 144);
            this.lblAciklama.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAciklama.Name = "lblAciklama";
            this.lblAciklama.Size = new System.Drawing.Size(53, 13);
            this.lblAciklama.TabIndex = 6;
            this.lblAciklama.Text = "Açıklama:";
            // 
            // txtAciklama
            // 
            this.txtAciklama.Location = new System.Drawing.Point(32, 163);
            this.txtAciklama.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtAciklama.Multiline = true;
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new System.Drawing.Size(298, 28);
            this.txtAciklama.TabIndex = 7;
            // 
            // btnKaydet
            // 
            this.btnKaydet.Enabled = false;
            this.btnKaydet.Location = new System.Drawing.Point(179, 223);
            this.btnKaydet.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(75, 30);
            this.btnKaydet.TabIndex = 8;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            // 
            // btnIptal
            // 
            this.btnIptal.Location = new System.Drawing.Point(260, 223);
            this.btnIptal.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(75, 30);
            this.btnIptal.TabIndex = 9;
            this.btnIptal.Text = "İptal";
            this.btnIptal.UseVisualStyleBackColor = true;
            // 
            // lblIslemTuru
            // 
            this.lblIslemTuru.AutoSize = true;
            this.lblIslemTuru.Location = new System.Drawing.Point(200, 114);
            this.lblIslemTuru.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIslemTuru.Name = "lblIslemTuru";
            this.lblIslemTuru.Size = new System.Drawing.Size(59, 13);
            this.lblIslemTuru.TabIndex = 10;
            this.lblIslemTuru.Text = "İşlem Türü:";
            // 
            // cmbIslemTuru
            // 
            this.cmbIslemTuru.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIslemTuru.FormattingEnabled = true;
            this.cmbIslemTuru.Location = new System.Drawing.Point(260, 110);
            this.cmbIslemTuru.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbIslemTuru.Name = "cmbIslemTuru";
            this.cmbIslemTuru.Size = new System.Drawing.Size(70, 21);
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
            this.panelYeniUrun.Location = new System.Drawing.Point(32, 272);
            this.panelYeniUrun.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelYeniUrun.Name = "panelYeniUrun";
            this.panelYeniUrun.Size = new System.Drawing.Size(300, 138);
            this.panelYeniUrun.TabIndex = 12;
            this.panelYeniUrun.Visible = false;
            // 
            // txtUrunNo
            // 
            this.txtUrunNo.Location = new System.Drawing.Point(80, 90);
            this.txtUrunNo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtUrunNo.Name = "txtUrunNo";
            this.txtUrunNo.Size = new System.Drawing.Size(200, 20);
            this.txtUrunNo.TabIndex = 7;
            // 
            // lblUrunNo
            // 
            this.lblUrunNo.AutoSize = true;
            this.lblUrunNo.Location = new System.Drawing.Point(10, 93);
            this.lblUrunNo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUrunNo.Name = "lblUrunNo";
            this.lblUrunNo.Size = new System.Drawing.Size(50, 13);
            this.lblUrunNo.TabIndex = 6;
            this.lblUrunNo.Text = "Ürün No:";
            // 
            // txtUrunMarka
            // 
            this.txtUrunMarka.Location = new System.Drawing.Point(80, 60);
            this.txtUrunMarka.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtUrunMarka.Name = "txtUrunMarka";
            this.txtUrunMarka.Size = new System.Drawing.Size(200, 20);
            this.txtUrunMarka.TabIndex = 5;
            // 
            // lblUrunMarka
            // 
            this.lblUrunMarka.AutoSize = true;
            this.lblUrunMarka.Location = new System.Drawing.Point(10, 63);
            this.lblUrunMarka.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUrunMarka.Name = "lblUrunMarka";
            this.lblUrunMarka.Size = new System.Drawing.Size(66, 13);
            this.lblUrunMarka.TabIndex = 4;
            this.lblUrunMarka.Text = "Ürün Marka:";
            // 
            // txtUrunKodu
            // 
            this.txtUrunKodu.Location = new System.Drawing.Point(80, 30);
            this.txtUrunKodu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtUrunKodu.Name = "txtUrunKodu";
            this.txtUrunKodu.Size = new System.Drawing.Size(200, 20);
            this.txtUrunKodu.TabIndex = 3;
            // 
            // lblUrunKodu
            // 
            this.lblUrunKodu.AutoSize = true;
            this.lblUrunKodu.Location = new System.Drawing.Point(10, 33);
            this.lblUrunKodu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUrunKodu.Name = "lblUrunKodu";
            this.lblUrunKodu.Size = new System.Drawing.Size(61, 13);
            this.lblUrunKodu.TabIndex = 2;
            this.lblUrunKodu.Text = "Ürün Kodu:";
            // 
            // txtUrunAdi
            // 
            this.txtUrunAdi.Location = new System.Drawing.Point(80, 0);
            this.txtUrunAdi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtUrunAdi.Name = "txtUrunAdi";
            this.txtUrunAdi.Size = new System.Drawing.Size(200, 20);
            this.txtUrunAdi.TabIndex = 1;
            // 
            // lblUrunAdi
            // 
            this.lblUrunAdi.AutoSize = true;
            this.lblUrunAdi.Location = new System.Drawing.Point(10, 3);
            this.lblUrunAdi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUrunAdi.Name = "lblUrunAdi";
            this.lblUrunAdi.Size = new System.Drawing.Size(51, 13);
            this.lblUrunAdi.TabIndex = 0;
            this.lblUrunAdi.Text = "Ürün Adı:";
            // 
            // lblProje
            // 
            this.lblProje.AutoSize = true;
            this.lblProje.Location = new System.Drawing.Point(30, 202);
            this.lblProje.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProje.Name = "lblProje";
            this.lblProje.Size = new System.Drawing.Size(34, 13);
            this.lblProje.TabIndex = 13;
            this.lblProje.Text = "Proje:";
            this.lblProje.Visible = false;
            // 
            // cmbProje
            // 
            this.cmbProje.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProje.FormattingEnabled = true;
            this.cmbProje.Location = new System.Drawing.Point(80, 199);
            this.cmbProje.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbProje.Name = "cmbProje";
            this.cmbProje.Size = new System.Drawing.Size(250, 21);
            this.cmbProje.TabIndex = 14;
            this.cmbProje.Visible = false;
            // 
            // lblUrunKoduAra
            // 
            this.lblUrunKoduAra.AutoSize = true;
            this.lblUrunKoduAra.Location = new System.Drawing.Point(22, 57);
            this.lblUrunKoduAra.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUrunKoduAra.Name = "lblUrunKoduAra";
            this.lblUrunKoduAra.Size = new System.Drawing.Size(61, 13);
            this.lblUrunKoduAra.TabIndex = 15;
            this.lblUrunKoduAra.Text = "Ürün Kodu:";
            // 
            // txtUrunKoduAra
            // 
            this.txtUrunKoduAra.Location = new System.Drawing.Point(80, 54);
            this.txtUrunKoduAra.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtUrunKoduAra.Name = "txtUrunKoduAra";
            this.txtUrunKoduAra.Size = new System.Drawing.Size(150, 20);
            this.txtUrunKoduAra.TabIndex = 16;
            // 
            // btnUrunKoduAra
            // 
            this.btnUrunKoduAra.Location = new System.Drawing.Point(240, 52);
            this.btnUrunKoduAra.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnUrunKoduAra.Name = "btnUrunKoduAra";
            this.btnUrunKoduAra.Size = new System.Drawing.Size(75, 23);
            this.btnUrunKoduAra.TabIndex = 17;
            this.btnUrunKoduAra.Text = "Kod ile Ara";
            this.btnUrunKoduAra.UseVisualStyleBackColor = true;
            // 
            // ManuelUrunGirisiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 447);
            this.Controls.Add(this.btnUrunKoduAra);
            this.Controls.Add(this.txtUrunKoduAra);
            this.Controls.Add(this.lblUrunKoduAra);
            this.Controls.Add(this.cmbProje);
            this.Controls.Add(this.lblProje);
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
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
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
        private System.Windows.Forms.Label lblProje;
        private System.Windows.Forms.ComboBox cmbProje;
        private System.Windows.Forms.Label lblUrunKoduAra;
        private System.Windows.Forms.TextBox txtUrunKoduAra;
        private System.Windows.Forms.Button btnUrunKoduAra;
    }
}