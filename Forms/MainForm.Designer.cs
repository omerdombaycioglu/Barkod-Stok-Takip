namespace StokTakipOtomasyonu.Forms
{
    partial class MainForm
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
            this.btnManuelUrunGirisi = new System.Windows.Forms.Button();
            this.btnBarkodUrunGirisi = new System.Windows.Forms.Button();
            this.btnManuelUrunCikisi = new System.Windows.Forms.Button();
            this.btnBarkodUrunCikisi = new System.Windows.Forms.Button();
            this.btnUrunListele = new System.Windows.Forms.Button();
            this.btnExcelIslem = new System.Windows.Forms.Button();
            this.btnUrunAra = new System.Windows.Forms.Button();
            this.btnIslemGecmisi = new System.Windows.Forms.Button();
            this.btnEnvanterKontrol = new System.Windows.Forms.Button();
            this.btnCikis = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // btnManuelUrunGirisi
            this.btnManuelUrunGirisi.Location = new System.Drawing.Point(30, 30);
            this.btnManuelUrunGirisi.Name = "btnManuelUrunGirisi";
            this.btnManuelUrunGirisi.Size = new System.Drawing.Size(150, 50);
            this.btnManuelUrunGirisi.TabIndex = 0;
            this.btnManuelUrunGirisi.Text = "Manuel Ürün Girişi";
            this.btnManuelUrunGirisi.UseVisualStyleBackColor = true;
            this.btnManuelUrunGirisi.Click += new System.EventHandler(this.btnManuelUrunGirisi_Click);

            // btnBarkodUrunGirisi
            this.btnBarkodUrunGirisi.Location = new System.Drawing.Point(200, 30);
            this.btnBarkodUrunGirisi.Name = "btnBarkodUrunGirisi";
            this.btnBarkodUrunGirisi.Size = new System.Drawing.Size(150, 50);
            this.btnBarkodUrunGirisi.TabIndex = 1;
            this.btnBarkodUrunGirisi.Text = "Barkod ile Ürün Girişi";
            this.btnBarkodUrunGirisi.UseVisualStyleBackColor = true;
            this.btnBarkodUrunGirisi.Click += new System.EventHandler(this.btnBarkodUrunGirisi_Click);

            // btnManuelUrunCikisi
            this.btnManuelUrunCikisi.Location = new System.Drawing.Point(30, 100);
            this.btnManuelUrunCikisi.Name = "btnManuelUrunCikisi";
            this.btnManuelUrunCikisi.Size = new System.Drawing.Size(150, 50);
            this.btnManuelUrunCikisi.TabIndex = 2;
            this.btnManuelUrunCikisi.Text = "Manuel Ürün Çıkışı";
            this.btnManuelUrunCikisi.UseVisualStyleBackColor = true;
            this.btnManuelUrunCikisi.Click += new System.EventHandler(this.btnManuelUrunCikisi_Click);

            // btnBarkodUrunCikisi
            this.btnBarkodUrunCikisi.Location = new System.Drawing.Point(200, 100);
            this.btnBarkodUrunCikisi.Name = "btnBarkodUrunCikisi";
            this.btnBarkodUrunCikisi.Size = new System.Drawing.Size(150, 50);
            this.btnBarkodUrunCikisi.TabIndex = 3;
            this.btnBarkodUrunCikisi.Text = "Barkod ile Ürün Çıkışı";
            this.btnBarkodUrunCikisi.UseVisualStyleBackColor = true;
            this.btnBarkodUrunCikisi.Click += new System.EventHandler(this.btnBarkodUrunCikisi_Click);

            // btnUrunListele
            this.btnUrunListele.Location = new System.Drawing.Point(30, 170);
            this.btnUrunListele.Name = "btnUrunListele";
            this.btnUrunListele.Size = new System.Drawing.Size(150, 50);
            this.btnUrunListele.TabIndex = 4;
            this.btnUrunListele.Text = "Tüm Ürünleri Listele";
            this.btnUrunListele.UseVisualStyleBackColor = true;
            this.btnUrunListele.Click += new System.EventHandler(this.btnUrunListele_Click);

            // btnExcelIslem
            this.btnExcelIslem.Location = new System.Drawing.Point(200, 170);
            this.btnExcelIslem.Name = "btnExcelIslem";
            this.btnExcelIslem.Size = new System.Drawing.Size(150, 50);
            this.btnExcelIslem.TabIndex = 5;
            this.btnExcelIslem.Text = "Excel ile Ürün Giriş/Çıkış";
            this.btnExcelIslem.UseVisualStyleBackColor = true;
            this.btnExcelIslem.Click += new System.EventHandler(this.btnExcelIslem_Click);

            // btnUrunAra
            this.btnUrunAra.Location = new System.Drawing.Point(30, 240);
            this.btnUrunAra.Name = "btnUrunAra";
            this.btnUrunAra.Size = new System.Drawing.Size(150, 50);
            this.btnUrunAra.TabIndex = 6;
            this.btnUrunAra.Text = "Ürün Ara";
            this.btnUrunAra.UseVisualStyleBackColor = true;
            this.btnUrunAra.Click += new System.EventHandler(this.btnUrunAra_Click);

            // btnIslemGecmisi
            this.btnIslemGecmisi.Location = new System.Drawing.Point(200, 240);
            this.btnIslemGecmisi.Name = "btnIslemGecmisi";
            this.btnIslemGecmisi.Size = new System.Drawing.Size(150, 50);
            this.btnIslemGecmisi.TabIndex = 7;
            this.btnIslemGecmisi.Text = "İşlem Geçmişi";
            this.btnIslemGecmisi.UseVisualStyleBackColor = true;
            this.btnIslemGecmisi.Click += new System.EventHandler(this.btnIslemGecmisi_Click);

            // btnEnvanterKontrol
            this.btnEnvanterKontrol.Location = new System.Drawing.Point(115, 310);
            this.btnEnvanterKontrol.Name = "btnEnvanterKontrol";
            this.btnEnvanterKontrol.Size = new System.Drawing.Size(150, 50);
            this.btnEnvanterKontrol.TabIndex = 8;
            this.btnEnvanterKontrol.Text = "Envanter Kontrol";
            this.btnEnvanterKontrol.UseVisualStyleBackColor = true;
            this.btnEnvanterKontrol.Click += new System.EventHandler(this.btnEnvanterKontrol_Click);

            // btnCikis
            this.btnCikis.Location = new System.Drawing.Point(115, 380);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(150, 50);
            this.btnCikis.TabIndex = 9;
            this.btnCikis.Text = "Çıkış";
            this.btnCikis.UseVisualStyleBackColor = true;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 450);
            this.Controls.Add(this.btnCikis);
            this.Controls.Add(this.btnEnvanterKontrol);
            this.Controls.Add(this.btnIslemGecmisi);
            this.Controls.Add(this.btnUrunAra);
            this.Controls.Add(this.btnExcelIslem);
            this.Controls.Add(this.btnUrunListele);
            this.Controls.Add(this.btnBarkodUrunCikisi);
            this.Controls.Add(this.btnManuelUrunCikisi);
            this.Controls.Add(this.btnBarkodUrunGirisi);
            this.Controls.Add(this.btnManuelUrunGirisi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stok Takip Ana Menü";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnManuelUrunGirisi;
        private System.Windows.Forms.Button btnBarkodUrunGirisi;
        private System.Windows.Forms.Button btnManuelUrunCikisi;
        private System.Windows.Forms.Button btnBarkodUrunCikisi;
        private System.Windows.Forms.Button btnUrunListele;
        private System.Windows.Forms.Button btnExcelIslem;
        private System.Windows.Forms.Button btnUrunAra;
        private System.Windows.Forms.Button btnIslemGecmisi;
        private System.Windows.Forms.Button btnEnvanterKontrol;
        private System.Windows.Forms.Button btnCikis;
    }
}