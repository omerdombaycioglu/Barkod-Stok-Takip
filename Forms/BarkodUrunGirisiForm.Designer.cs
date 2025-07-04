namespace StokTakipOtomasyonu.Forms
{
    partial class BarkodUrunGirisiForm
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
            this.lblAciklama = new System.Windows.Forms.Label();
            this.txtAciklama = new System.Windows.Forms.TextBox();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.btnIptal = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblBarkod
            this.lblBarkod.AutoSize = true;
            this.lblBarkod.Location = new System.Drawing.Point(30, 30);
            this.lblBarkod.Name = "lblBarkod";
            this.lblBarkod.Size = new System.Drawing.Size(44, 13);
            this.lblBarkod.TabIndex = 0;
            this.lblBarkod.Text = "Barkod:";

            // txtBarkod
            this.txtBarkod.Location = new System.Drawing.Point(80, 27);
            this.txtBarkod.Name = "txtBarkod";
            this.txtBarkod.Size = new System.Drawing.Size(150, 20);
            this.txtBarkod.TabIndex = 1;

            // btnBarkodOku
            this.btnBarkodOku.Location = new System.Drawing.Point(240, 25);
            this.btnBarkodOku.Name = "btnBarkodOku";
            this.btnBarkodOku.Size = new System.Drawing.Size(75, 23);
            this.btnBarkodOku.TabIndex = 2;
            this.btnBarkodOku.Text = "Barkod Oku";
            this.btnBarkodOku.UseVisualStyleBackColor = true;
            this.btnBarkodOku.Click += new System.EventHandler(this.btnBarkodOku_Click);

            // lblUrunBilgisi
            this.lblUrunBilgisi.AutoSize = true;
            this.lblUrunBilgisi.Location = new System.Drawing.Point(30, 70);
            this.lblUrunBilgisi.Name = "lblUrunBilgisi";
            this.lblUrunBilgisi.Size = new System.Drawing.Size(61, 13);
            this.lblUrunBilgisi.TabIndex = 3;
            this.lblUrunBilgisi.Text = "Ürün Bilgisi:";

            // lblUrunAdi
            this.lblUrunAdi.AutoSize = true;
            this.lblUrunAdi.Location = new System.Drawing.Point(100, 70);
            this.lblUrunAdi.Name = "lblUrunAdi";
            this.lblUrunAdi.Size = new System.Drawing.Size(19, 13);
            this.lblUrunAdi.TabIndex = 4;
            this.lblUrunAdi.Text = "---";

            // lblUrunKodu
            this.lblUrunKodu.AutoSize = true;
            this.lblUrunKodu.Location = new System.Drawing.Point(100, 90);
            this.lblUrunKodu.Name = "lblUrunKodu";
            this.lblUrunKodu.Size = new System.Drawing.Size(19, 13);
            this.lblUrunKodu.TabIndex = 5;
            this.lblUrunKodu.Text = "---";

            // lblMevcutStok
            this.lblMevcutStok.AutoSize = true;
            this.lblMevcutStok.Location = new System.Drawing.Point(30, 110);
            this.lblMevcutStok.Name = "lblMevcutStok";
            this.lblMevcutStok.Size = new System.Drawing.Size(67, 13);
            this.lblMevcutStok.TabIndex = 6;
            this.lblMevcutStok.Text = "Mevcut Stok:";

            // lblMevcutMiktar
            this.lblMevcutMiktar.AutoSize = true;
            this.lblMevcutMiktar.Location = new System.Drawing.Point(100, 110);
            this.lblMevcutMiktar.Name = "lblMevcutMiktar";
            this.lblMevcutMiktar.Size = new System.Drawing.Size(19, 13);
            this.lblMevcutMiktar.TabIndex = 7;
            this.lblMevcutMiktar.Text = "---";

            // lblMiktar
            this.lblMiktar.AutoSize = true;
            this.lblMiktar.Location = new System.Drawing.Point(30, 140);
            this.lblMiktar.Name = "lblMiktar";
            this.lblMiktar.Size = new System.Drawing.Size(36, 13);
            this.lblMiktar.TabIndex = 8;
            this.lblMiktar.Text = "Miktar:";

            // txtMiktar
            this.txtMiktar.Enabled = false;
            this.txtMiktar.Location = new System.Drawing.Point(80, 137);
            this.txtMiktar.Name = "txtMiktar";
            this.txtMiktar.Size = new System.Drawing.Size(100, 20);
            this.txtMiktar.TabIndex = 9;

            // lblAciklama
            this.lblAciklama.AutoSize = true;
            this.lblAciklama.Location = new System.Drawing.Point(30, 170);
            this.lblAciklama.Name = "lblAciklama";
            this.lblAciklama.Size = new System.Drawing.Size(53, 13);
            this.lblAciklama.TabIndex = 10;
            this.lblAciklama.Text = "Açıklama:";

            // txtAciklama
            this.txtAciklama.Location = new System.Drawing.Point(30, 190);
            this.txtAciklama.Multiline = true;
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new System.Drawing.Size(285, 60);
            this.txtAciklama.TabIndex = 11;

            // btnKaydet
            this.btnKaydet.Enabled = false;
            this.btnKaydet.Location = new System.Drawing.Point(160, 260);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(75, 30);
            this.btnKaydet.TabIndex = 12;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);

            // btnIptal
            this.btnIptal.Location = new System.Drawing.Point(240, 260);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(75, 30);
            this.btnIptal.TabIndex = 13;
            this.btnIptal.Text = "İptal";
            this.btnIptal.UseVisualStyleBackColor = true;
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);

            // BarkodUrunGirisiForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 310);
            this.Controls.Add(this.btnIptal);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.txtAciklama);
            this.Controls.Add(this.lblAciklama);
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
            this.Name = "BarkodUrunGirisiForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Barkod ile Ürün Girişi";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

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
        private System.Windows.Forms.Label lblAciklama;
        private System.Windows.Forms.TextBox txtAciklama;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Button btnIptal;
    }
}