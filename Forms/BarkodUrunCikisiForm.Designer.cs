namespace StokTakipOtomasyonu.Forms
{
    partial class BarkodUrunCikisiForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblBarkod = new System.Windows.Forms.Label();
            this.txtBarkod = new System.Windows.Forms.TextBox();
            this.btnBarkodOku = new System.Windows.Forms.Button();
            this.lblUrunBilgisi = new System.Windows.Forms.Label();
            this.lblUrunAdi = new System.Windows.Forms.Label();
            this.lblUrunKodu = new System.Windows.Forms.Label();
            this.lblMevcutStok = new System.Windows.Forms.Label();
            this.lblMevcutMiktar = new System.Windows.Forms.Label();
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
            // 
            // lblBarkod
            // 
            this.lblBarkod.AutoSize = true;
            this.lblBarkod.Location = new System.Drawing.Point(30, 30);
            this.lblBarkod.Name = "lblBarkod";
            this.lblBarkod.Size = new System.Drawing.Size(44, 13);
            this.lblBarkod.TabIndex = 0;
            this.lblBarkod.Text = "Barkod:";
            // 
            // txtBarkod
            // 
            this.txtBarkod.Location = new System.Drawing.Point(80, 27);
            this.txtBarkod.Name = "txtBarkod";
            this.txtBarkod.Size = new System.Drawing.Size(200, 20);
            this.txtBarkod.TabIndex = 1;
            // 
            // btnBarkodOku
            // 
            this.btnBarkodOku.Location = new System.Drawing.Point(290, 25);
            this.btnBarkodOku.Name = "btnBarkodOku";
            this.btnBarkodOku.Size = new System.Drawing.Size(90, 23);
            this.btnBarkodOku.TabIndex = 2;
            this.btnBarkodOku.Text = "Barkod Oku";
            this.btnBarkodOku.UseVisualStyleBackColor = true;
            this.btnBarkodOku.Click += new System.EventHandler(this.btnBarkodOku_Click);
            // 
            // lblUrunBilgisi
            // 
            this.lblUrunBilgisi.AutoSize = true;
            this.lblUrunBilgisi.Location = new System.Drawing.Point(30, 70);
            this.lblUrunBilgisi.Name = "lblUrunBilgisi";
            this.lblUrunBilgisi.Size = new System.Drawing.Size(61, 13);
            this.lblUrunBilgisi.TabIndex = 3;
            this.lblUrunBilgisi.Text = "Ürün Bilgisi:";
            // 
            // lblUrunAdi
            // 
            this.lblUrunAdi.AutoSize = true;
            this.lblUrunAdi.Location = new System.Drawing.Point(100, 70);
            this.lblUrunAdi.Name = "lblUrunAdi";
            this.lblUrunAdi.Size = new System.Drawing.Size(19, 13);
            this.lblUrunAdi.TabIndex = 4;
            this.lblUrunAdi.Text = "---";
            // 
            // lblUrunKodu
            // 
            this.lblUrunKodu.AutoSize = true;
            this.lblUrunKodu.Location = new System.Drawing.Point(100, 90);
            this.lblUrunKodu.Name = "lblUrunKodu";
            this.lblUrunKodu.Size = new System.Drawing.Size(19, 13);
            this.lblUrunKodu.TabIndex = 5;
            this.lblUrunKodu.Text = "---";
            // 
            // lblMevcutStok
            // 
            this.lblMevcutStok.AutoSize = true;
            this.lblMevcutStok.Location = new System.Drawing.Point(30, 110);
            this.lblMevcutStok.Name = "lblMevcutStok";
            this.lblMevcutStok.Size = new System.Drawing.Size(67, 13);
            this.lblMevcutStok.TabIndex = 6;
            this.lblMevcutStok.Text = "Mevcut Stok:";
            // 
            // lblMevcutMiktar
            // 
            this.lblMevcutMiktar.AutoSize = true;
            this.lblMevcutMiktar.Location = new System.Drawing.Point(100, 110);
            this.lblMevcutMiktar.Name = "lblMevcutMiktar";
            this.lblMevcutMiktar.Size = new System.Drawing.Size(19, 13);
            this.lblMevcutMiktar.TabIndex = 7;
            this.lblMevcutMiktar.Text = "---";
            // 
            // lblMiktar
            // 
            this.lblMiktar.AutoSize = true;
            this.lblMiktar.Location = new System.Drawing.Point(30, 140);
            this.lblMiktar.Name = "lblMiktar";
            this.lblMiktar.Size = new System.Drawing.Size(36, 13);
            this.lblMiktar.TabIndex = 8;
            this.lblMiktar.Text = "Miktar:";
            // 
            // txtMiktar
            // 
            this.txtMiktar.Enabled = false;
            this.txtMiktar.Location = new System.Drawing.Point(80, 137);
            this.txtMiktar.Name = "txtMiktar";
            this.txtMiktar.Size = new System.Drawing.Size(100, 20);
            this.txtMiktar.TabIndex = 9;
            // 
            // lblIslemTuru
            // 
            this.lblIslemTuru.AutoSize = true;
            this.lblIslemTuru.Location = new System.Drawing.Point(30, 170);
            this.lblIslemTuru.Name = "lblIslemTuru";
            this.lblIslemTuru.Size = new System.Drawing.Size(56, 13);
            this.lblIslemTuru.TabIndex = 10;
            this.lblIslemTuru.Text = "İşlem Türü:";
            // 
            // cmbIslemTuru
            // 
            this.cmbIslemTuru.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIslemTuru.FormattingEnabled = true;
            this.cmbIslemTuru.Location = new System.Drawing.Point(100, 167);
            this.cmbIslemTuru.Name = "cmbIslemTuru";
            this.cmbIslemTuru.Size = new System.Drawing.Size(150, 21);
            this.cmbIslemTuru.TabIndex = 11;
            this.cmbIslemTuru.SelectedIndexChanged += new System.EventHandler(this.cmbIslemTuru_SelectedIndexChanged);
            // 
            // lblProje
            // 
            this.lblProje.AutoSize = true;
            this.lblProje.Location = new System.Drawing.Point(30, 200);
            this.lblProje.Name = "lblProje";
            this.lblProje.Size = new System.Drawing.Size(34, 13);
            this.lblProje.TabIndex = 12;
            this.lblProje.Text = "Proje:";
            // 
            // cmbProjeler
            // 
            this.cmbProjeler.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProjeler.Enabled = false;
            this.cmbProjeler.FormattingEnabled = true;
            this.cmbProjeler.Location = new System.Drawing.Point(100, 197);
            this.cmbProjeler.Name = "cmbProjeler";
            this.cmbProjeler.Size = new System.Drawing.Size(250, 21);
            this.cmbProjeler.TabIndex = 13;
            // 
            // lblAciklama
            // 
            this.lblAciklama.AutoSize = true;
            this.lblAciklama.Location = new System.Drawing.Point(30, 230);
            this.lblAciklama.Name = "lblAciklama";
            this.lblAciklama.Size = new System.Drawing.Size(53, 13);
            this.lblAciklama.TabIndex = 14;
            this.lblAciklama.Text = "Açıklama:";
            // 
            // txtAciklama
            // 
            this.txtAciklama.Location = new System.Drawing.Point(30, 250);
            this.txtAciklama.Multiline = true;
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new System.Drawing.Size(350, 60);
            this.txtAciklama.TabIndex = 15;
            // 
            // btnKaydet
            // 
            this.btnKaydet.Enabled = false;
            this.btnKaydet.Location = new System.Drawing.Point(220, 320);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(75, 30);
            this.btnKaydet.TabIndex = 16;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnIptal
            // 
            this.btnIptal.Location = new System.Drawing.Point(305, 320);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(75, 30);
            this.btnIptal.TabIndex = 17;
            this.btnIptal.Text = "İptal";
            this.btnIptal.UseVisualStyleBackColor = true;
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // BarkodUrunCikisiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 370);
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
            this.Controls.Add(this.lblMevcutMiktar);
            this.Controls.Add(this.lblMevcutStok);
            this.Controls.Add(this.lblUrunKodu);
            this.Controls.Add(this.lblUrunAdi);
            this.Controls.Add(this.lblUrunBilgisi);
            this.Controls.Add(this.btnBarkodOku);
            this.Controls.Add(this.txtBarkod);
            this.Controls.Add(this.lblBarkod);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BarkodUrunCikisiForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Barkod ile Ürün Çıkışı";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBarkod;
        private System.Windows.Forms.TextBox txtBarkod;
        private System.Windows.Forms.Button btnBarkodOku;
        private System.Windows.Forms.Label lblUrunBilgisi;
        private System.Windows.Forms.Label lblUrunAdi;
        private System.Windows.Forms.Label lblUrunKodu;
        private System.Windows.Forms.Label lblMevcutStok;
        private System.Windows.Forms.Label lblMevcutMiktar;
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