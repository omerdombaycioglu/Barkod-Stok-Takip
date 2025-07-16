namespace StokTakipOtomasyonu.Forms
{
    partial class MainForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnUrunListele = new System.Windows.Forms.Button();
            this.btnManuelUrunCikisi = new System.Windows.Forms.Button();
            this.btnManuelUrunGirisi = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnProjeEkle = new System.Windows.Forms.Button();
            this.btnProjeMontaj = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnDepoDuzenle = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btnUrunBilgiGuncelle = new System.Windows.Forms.Button();
            this.btnKullaniciIslemleri = new System.Windows.Forms.Button();
            this.btnSonIslemler = new System.Windows.Forms.Button();
            this.btnCikis = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.btnUrunListele);
            this.groupBox1.Controls.Add(this.btnManuelUrunCikisi);
            this.groupBox1.Controls.Add(this.btnManuelUrunGirisi);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox1.Location = new System.Drawing.Point(30, 112);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 182);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ürün İşlemleri";
            // 
            // btnUrunListele
            // 
            this.btnUrunListele.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnUrunListele.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUrunListele.FlatAppearance.BorderSize = 0;
            this.btnUrunListele.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(133)))));
            this.btnUrunListele.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(133)))));
            this.btnUrunListele.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUrunListele.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnUrunListele.ForeColor = System.Drawing.Color.White;
            this.btnUrunListele.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUrunListele.Location = new System.Drawing.Point(25, 122);
            this.btnUrunListele.Name = "btnUrunListele";
            this.btnUrunListele.Size = new System.Drawing.Size(200, 40);
            this.btnUrunListele.TabIndex = 0;
            this.btnUrunListele.Text = "📋 Ürün Listele/Ara/Filtrele";
            this.btnUrunListele.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUrunListele.UseVisualStyleBackColor = false;
            this.btnUrunListele.Click += new System.EventHandler(this.btnUrunListele_Click);
            // 
            // btnManuelUrunCikisi
            // 
            this.btnManuelUrunCikisi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnManuelUrunCikisi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnManuelUrunCikisi.FlatAppearance.BorderSize = 0;
            this.btnManuelUrunCikisi.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(133)))));
            this.btnManuelUrunCikisi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(133)))));
            this.btnManuelUrunCikisi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManuelUrunCikisi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnManuelUrunCikisi.ForeColor = System.Drawing.Color.White;
            this.btnManuelUrunCikisi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManuelUrunCikisi.Location = new System.Drawing.Point(25, 76);
            this.btnManuelUrunCikisi.Name = "btnManuelUrunCikisi";
            this.btnManuelUrunCikisi.Size = new System.Drawing.Size(200, 40);
            this.btnManuelUrunCikisi.TabIndex = 0;
            this.btnManuelUrunCikisi.Text = "➖ Ürün Çıkışı";
            this.btnManuelUrunCikisi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnManuelUrunCikisi.UseVisualStyleBackColor = false;
            this.btnManuelUrunCikisi.Click += new System.EventHandler(this.btnManuelUrunCikisi_Click);
            // 
            // btnManuelUrunGirisi
            // 
            this.btnManuelUrunGirisi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnManuelUrunGirisi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnManuelUrunGirisi.FlatAppearance.BorderSize = 0;
            this.btnManuelUrunGirisi.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(133)))));
            this.btnManuelUrunGirisi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(133)))));
            this.btnManuelUrunGirisi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManuelUrunGirisi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnManuelUrunGirisi.ForeColor = System.Drawing.Color.White;
            this.btnManuelUrunGirisi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManuelUrunGirisi.Location = new System.Drawing.Point(25, 30);
            this.btnManuelUrunGirisi.Name = "btnManuelUrunGirisi";
            this.btnManuelUrunGirisi.Size = new System.Drawing.Size(200, 40);
            this.btnManuelUrunGirisi.TabIndex = 0;
            this.btnManuelUrunGirisi.Text = "➕ Ürün Girişi";
            this.btnManuelUrunGirisi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnManuelUrunGirisi.UseVisualStyleBackColor = false;
            this.btnManuelUrunGirisi.Click += new System.EventHandler(this.btnManuelUrunGirisi_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.White;
            this.groupBox5.Controls.Add(this.btnProjeEkle);
            this.groupBox5.Controls.Add(this.btnProjeMontaj);
            this.groupBox5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox5.Location = new System.Drawing.Point(298, 112);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(250, 150);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Proje İşlemleri";
            // 
            // btnProjeEkle
            // 
            this.btnProjeEkle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnProjeEkle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProjeEkle.FlatAppearance.BorderSize = 0;
            this.btnProjeEkle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(133)))));
            this.btnProjeEkle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(133)))));
            this.btnProjeEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProjeEkle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnProjeEkle.ForeColor = System.Drawing.Color.White;
            this.btnProjeEkle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProjeEkle.Location = new System.Drawing.Point(25, 30);
            this.btnProjeEkle.Name = "btnProjeEkle";
            this.btnProjeEkle.Size = new System.Drawing.Size(200, 40);
            this.btnProjeEkle.TabIndex = 0;
            this.btnProjeEkle.Text = "📁 Proje Ekle";
            this.btnProjeEkle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProjeEkle.UseVisualStyleBackColor = false;
            this.btnProjeEkle.Click += new System.EventHandler(this.btnProjeEkle_Click);
            // 
            // btnProjeMontaj
            // 
            this.btnProjeMontaj.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnProjeMontaj.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProjeMontaj.FlatAppearance.BorderSize = 0;
            this.btnProjeMontaj.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(133)))));
            this.btnProjeMontaj.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(133)))));
            this.btnProjeMontaj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProjeMontaj.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnProjeMontaj.ForeColor = System.Drawing.Color.White;
            this.btnProjeMontaj.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProjeMontaj.Location = new System.Drawing.Point(25, 80);
            this.btnProjeMontaj.Name = "btnProjeMontaj";
            this.btnProjeMontaj.Size = new System.Drawing.Size(200, 40);
            this.btnProjeMontaj.TabIndex = 1;
            this.btnProjeMontaj.Text = "🔍 Proje Ürün Kontrol";
            this.btnProjeMontaj.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProjeMontaj.UseVisualStyleBackColor = false;
            this.btnProjeMontaj.Click += new System.EventHandler(this.btnProjeMontaj_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.Color.White;
            this.groupBox6.Controls.Add(this.btnDepoDuzenle);
            this.groupBox6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox6.Location = new System.Drawing.Point(30, 314);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(250, 111);
            this.groupBox6.TabIndex = 4;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Depo İşlemleri";
            // 
            // btnDepoDuzenle
            // 
            this.btnDepoDuzenle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnDepoDuzenle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDepoDuzenle.FlatAppearance.BorderSize = 0;
            this.btnDepoDuzenle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(133)))));
            this.btnDepoDuzenle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(133)))));
            this.btnDepoDuzenle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDepoDuzenle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnDepoDuzenle.ForeColor = System.Drawing.Color.White;
            this.btnDepoDuzenle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDepoDuzenle.Location = new System.Drawing.Point(25, 41);
            this.btnDepoDuzenle.Name = "btnDepoDuzenle";
            this.btnDepoDuzenle.Size = new System.Drawing.Size(200, 40);
            this.btnDepoDuzenle.TabIndex = 0;
            this.btnDepoDuzenle.Text = "🧱 Depo Düzenle";
            this.btnDepoDuzenle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDepoDuzenle.UseVisualStyleBackColor = false;
            this.btnDepoDuzenle.Click += new System.EventHandler(this.btnDepoDuzenle_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.BackColor = System.Drawing.Color.White;
            this.groupBox7.Controls.Add(this.btnUrunBilgiGuncelle);
            this.groupBox7.Controls.Add(this.btnKullaniciIslemleri);
            this.groupBox7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox7.Location = new System.Drawing.Point(298, 268);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(250, 157);
            this.groupBox7.TabIndex = 5;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Yönetici İşlemleri";
            // 
            // btnUrunBilgiGuncelle
            // 
            this.btnUrunBilgiGuncelle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnUrunBilgiGuncelle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUrunBilgiGuncelle.FlatAppearance.BorderSize = 0;
            this.btnUrunBilgiGuncelle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(133)))));
            this.btnUrunBilgiGuncelle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(133)))));
            this.btnUrunBilgiGuncelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUrunBilgiGuncelle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnUrunBilgiGuncelle.ForeColor = System.Drawing.Color.White;
            this.btnUrunBilgiGuncelle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUrunBilgiGuncelle.Location = new System.Drawing.Point(25, 97);
            this.btnUrunBilgiGuncelle.Name = "btnUrunBilgiGuncelle";
            this.btnUrunBilgiGuncelle.Size = new System.Drawing.Size(200, 40);
            this.btnUrunBilgiGuncelle.TabIndex = 0;
            this.btnUrunBilgiGuncelle.Text = " ✏️ Ürün Bilgi Güncelle";
            this.btnUrunBilgiGuncelle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUrunBilgiGuncelle.UseVisualStyleBackColor = false;
            this.btnUrunBilgiGuncelle.Click += new System.EventHandler(this.btnUrunBilgiGuncelle_Click);
            // 
            // btnKullaniciIslemleri
            // 
            this.btnKullaniciIslemleri.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnKullaniciIslemleri.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKullaniciIslemleri.FlatAppearance.BorderSize = 0;
            this.btnKullaniciIslemleri.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(133)))));
            this.btnKullaniciIslemleri.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(133)))));
            this.btnKullaniciIslemleri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKullaniciIslemleri.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnKullaniciIslemleri.ForeColor = System.Drawing.Color.White;
            this.btnKullaniciIslemleri.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKullaniciIslemleri.Location = new System.Drawing.Point(25, 44);
            this.btnKullaniciIslemleri.Name = "btnKullaniciIslemleri";
            this.btnKullaniciIslemleri.Size = new System.Drawing.Size(200, 40);
            this.btnKullaniciIslemleri.TabIndex = 1;
            this.btnKullaniciIslemleri.Text = "👤 Kullanıcı İşlemleri";
            this.btnKullaniciIslemleri.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnKullaniciIslemleri.UseVisualStyleBackColor = false;
            this.btnKullaniciIslemleri.Click += new System.EventHandler(this.btnKullaniciIslemleri_Click);
            // 
            // btnSonIslemler
            // 
            this.btnSonIslemler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnSonIslemler.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSonIslemler.FlatAppearance.BorderSize = 0;
            this.btnSonIslemler.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(133)))));
            this.btnSonIslemler.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(133)))));
            this.btnSonIslemler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSonIslemler.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSonIslemler.ForeColor = System.Drawing.Color.White;
            this.btnSonIslemler.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSonIslemler.Location = new System.Drawing.Point(242, 441);
            this.btnSonIslemler.Name = "btnSonIslemler";
            this.btnSonIslemler.Size = new System.Drawing.Size(150, 40);
            this.btnSonIslemler.TabIndex = 6;
            this.btnSonIslemler.Text = "📑 Son İşlemler";
            this.btnSonIslemler.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSonIslemler.UseVisualStyleBackColor = false;
            this.btnSonIslemler.Click += new System.EventHandler(this.btnSonIslemler_Click);
            // 
            // btnCikis
            // 
            this.btnCikis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnCikis.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCikis.FlatAppearance.BorderSize = 0;
            this.btnCikis.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(133)))));
            this.btnCikis.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(133)))));
            this.btnCikis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCikis.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCikis.ForeColor = System.Drawing.Color.White;
            this.btnCikis.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCikis.Location = new System.Drawing.Point(398, 441);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(150, 40);
            this.btnCikis.TabIndex = 7;
            this.btnCikis.Text = "🔚 Çıkış";
            this.btnCikis.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCikis.UseVisualStyleBackColor = false;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(577, 106);
            this.panel1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(251, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 41);
            this.label1.TabIndex = 1;
            this.label1.Text = "ISP Group Stok Takip";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::IspBarkodStok.Properties.Resources.isp_logo1;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(255, 103);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(577, 524);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.btnSonIslemler);
            this.Controls.Add(this.btnCikis);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stok Takip Otomasyonu - Ana Menü";
            this.groupBox1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button btnManuelUrunGirisi;
        private System.Windows.Forms.Button btnManuelUrunCikisi;
        private System.Windows.Forms.Button btnUrunListele;
        private System.Windows.Forms.Button btnProjeEkle;
        private System.Windows.Forms.Button btnProjeMontaj;
        private System.Windows.Forms.Button btnDepoDuzenle;
        private System.Windows.Forms.Button btnUrunBilgiGuncelle;
        private System.Windows.Forms.Button btnKullaniciIslemleri;
        private System.Windows.Forms.Button btnSonIslemler;
        private System.Windows.Forms.Button btnCikis;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}