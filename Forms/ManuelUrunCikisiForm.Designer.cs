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
            this.lblBarkod = new System.Windows.Forms.Label();
            this.txtBarkod = new System.Windows.Forms.TextBox();
            this.btnBarkodAra = new System.Windows.Forms.Button();
            this.lblUrunBilgisi = new System.Windows.Forms.Label();
            this.lblStokMiktari = new System.Windows.Forms.Label();
            this.lblProjedekiMiktar = new System.Windows.Forms.Label();
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
            this.dgvProjelerdekiUrunler = new System.Windows.Forms.DataGridView();
            this.lblProjeDetay = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProjelerdekiUrunler)).BeginInit();
            this.SuspendLayout();

            // lblBarkod
            this.lblBarkod.AutoSize = true;
            this.lblBarkod.Location = new System.Drawing.Point(20, 20);
            this.lblBarkod.Name = "lblBarkod";
            this.lblBarkod.Size = new System.Drawing.Size(44, 13);
            this.lblBarkod.TabIndex = 0;
            this.lblBarkod.Text = "Barkod:";

            // txtBarkod
            this.txtBarkod.Location = new System.Drawing.Point(70, 17);
            this.txtBarkod.Name = "txtBarkod";
            this.txtBarkod.Size = new System.Drawing.Size(150, 20);
            this.txtBarkod.TabIndex = 1;

            // btnBarkodAra
            this.btnBarkodAra.Location = new System.Drawing.Point(230, 15);
            this.btnBarkodAra.Name = "btnBarkodAra";
            this.btnBarkodAra.Size = new System.Drawing.Size(75, 23);
            this.btnBarkodAra.TabIndex = 2;
            this.btnBarkodAra.Text = "Ara";
            this.btnBarkodAra.UseVisualStyleBackColor = true;
            this.btnBarkodAra.Click += new System.EventHandler(this.btnBarkodAra_Click);

            // lblUrunBilgisi
            this.lblUrunBilgisi.AutoSize = true;
            this.lblUrunBilgisi.Location = new System.Drawing.Point(20, 50);
            this.lblUrunBilgisi.Name = "lblUrunBilgisi";
            this.lblUrunBilgisi.Size = new System.Drawing.Size(67, 13);
            this.lblUrunBilgisi.TabIndex = 3;
            this.lblUrunBilgisi.Text = "Ürün Bilgisi:";

            // lblStokMiktari
            this.lblStokMiktari.AutoSize = true;
            this.lblStokMiktari.Location = new System.Drawing.Point(20, 80);
            this.lblStokMiktari.Name = "lblStokMiktari";
            this.lblStokMiktari.Size = new System.Drawing.Size(35, 13);
            this.lblStokMiktari.TabIndex = 4;
            this.lblStokMiktari.Text = "Stok:";

            // lblProjedekiMiktar
            this.lblProjedekiMiktar.AutoSize = true;
            this.lblProjedekiMiktar.Location = new System.Drawing.Point(20, 110);
            this.lblProjedekiMiktar.Name = "lblProjedekiMiktar";
            this.lblProjedekiMiktar.Size = new System.Drawing.Size(103, 13);
            this.lblProjedekiMiktar.TabIndex = 5;
            this.lblProjedekiMiktar.Text = "Projelerdeki Toplam:";

            // lblMiktar
            this.lblMiktar.AutoSize = true;
            this.lblMiktar.Location = new System.Drawing.Point(20, 140);
            this.lblMiktar.Name = "lblMiktar";
            this.lblMiktar.Size = new System.Drawing.Size(36, 13);
            this.lblMiktar.TabIndex = 6;
            this.lblMiktar.Text = "Miktar:";

            // txtMiktar
            this.txtMiktar.Location = new System.Drawing.Point(70, 137);
            this.txtMiktar.Name = "txtMiktar";
            this.txtMiktar.Size = new System.Drawing.Size(100, 20);
            this.txtMiktar.TabIndex = 7;

            // lblIslemTuru
            this.lblIslemTuru.AutoSize = true;
            this.lblIslemTuru.Location = new System.Drawing.Point(20, 170);
            this.lblIslemTuru.Name = "lblIslemTuru";
            this.lblIslemTuru.Size = new System.Drawing.Size(56, 13);
            this.lblIslemTuru.TabIndex = 8;
            this.lblIslemTuru.Text = "İşlem Türü:";

            // cmbIslemTuru
            this.cmbIslemTuru.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIslemTuru.FormattingEnabled = true;
            this.cmbIslemTuru.Location = new System.Drawing.Point(90, 167);
            this.cmbIslemTuru.Name = "cmbIslemTuru";
            this.cmbIslemTuru.Size = new System.Drawing.Size(150, 21);
            this.cmbIslemTuru.TabIndex = 9;
            this.cmbIslemTuru.SelectedIndexChanged += new System.EventHandler(this.cmbIslemTuru_SelectedIndexChanged);

            // lblProje
            this.lblProje.AutoSize = true;
            this.lblProje.Location = new System.Drawing.Point(20, 200);
            this.lblProje.Name = "lblProje";
            this.lblProje.Size = new System.Drawing.Size(34, 13);
            this.lblProje.TabIndex = 10;
            this.lblProje.Text = "Proje:";

            // cmbProjeler
            this.cmbProjeler.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProjeler.FormattingEnabled = true;
            this.cmbProjeler.Location = new System.Drawing.Point(70, 197);
            this.cmbProjeler.Name = "cmbProjeler";
            this.cmbProjeler.Size = new System.Drawing.Size(250, 21);
            this.cmbProjeler.TabIndex = 11;

            // lblAciklama
            this.lblAciklama.AutoSize = true;
            this.lblAciklama.Location = new System.Drawing.Point(20, 230);
            this.lblAciklama.Name = "lblAciklama";
            this.lblAciklama.Size = new System.Drawing.Size(53, 13);
            this.lblAciklama.TabIndex = 12;
            this.lblAciklama.Text = "Açıklama:";

            // txtAciklama
            this.txtAciklama.Location = new System.Drawing.Point(20, 250);
            this.txtAciklama.Multiline = true;
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new System.Drawing.Size(300, 60);
            this.txtAciklama.TabIndex = 13;

            // btnKaydet
            this.btnKaydet.Location = new System.Drawing.Point(160, 550);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(75, 30);
            this.btnKaydet.TabIndex = 14;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);

            // btnIptal
            this.btnIptal.Location = new System.Drawing.Point(245, 550);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(75, 30);
            this.btnIptal.TabIndex = 15;
            this.btnIptal.Text = "İptal";
            this.btnIptal.UseVisualStyleBackColor = true;
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);

            // dgvProjelerdekiUrunler
            this.dgvProjelerdekiUrunler.AllowUserToAddRows = false;
            this.dgvProjelerdekiUrunler.AllowUserToDeleteRows = false;
            this.dgvProjelerdekiUrunler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProjelerdekiUrunler.Location = new System.Drawing.Point(20, 350);
            this.dgvProjelerdekiUrunler.Name = "dgvProjelerdekiUrunler";
            this.dgvProjelerdekiUrunler.ReadOnly = true;
            this.dgvProjelerdekiUrunler.Size = new System.Drawing.Size(300, 180);
            this.dgvProjelerdekiUrunler.TabIndex = 16;

            // lblProjeDetay
            this.lblProjeDetay.AutoSize = true;
            this.lblProjeDetay.Location = new System.Drawing.Point(20, 330);
            this.lblProjeDetay.Name = "lblProjeDetay";
            this.lblProjeDetay.Size = new System.Drawing.Size(123, 13);
            this.lblProjeDetay.TabIndex = 17;
            this.lblProjeDetay.Text = "Projelerdeki Ürün Detayı:";

            // ManuelUrunCikisiForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 600);
            this.Controls.Add(this.lblProjeDetay);
            this.Controls.Add(this.dgvProjelerdekiUrunler);
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
            this.Controls.Add(this.lblProjedekiMiktar);
            this.Controls.Add(this.lblStokMiktari);
            this.Controls.Add(this.lblUrunBilgisi);
            this.Controls.Add(this.btnBarkodAra);
            this.Controls.Add(this.txtBarkod);
            this.Controls.Add(this.lblBarkod);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ManuelUrunCikisiForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manuel Ürün Çıkışı";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProjelerdekiUrunler)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblBarkod;
        private System.Windows.Forms.TextBox txtBarkod;
        private System.Windows.Forms.Button btnBarkodAra;
        private System.Windows.Forms.Label lblUrunBilgisi;
        private System.Windows.Forms.Label lblStokMiktari;
        private System.Windows.Forms.Label lblProjedekiMiktar;
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
        private System.Windows.Forms.DataGridView dgvProjelerdekiUrunler;
        private System.Windows.Forms.Label lblProjeDetay;
    }
}