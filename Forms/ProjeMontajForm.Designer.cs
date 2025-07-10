namespace StokTakipOtomasyonu.Forms
{
    partial class ProjeMontajForm
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
            this.dataGridViewProjeler = new System.Windows.Forms.DataGridView();
            this.proje_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proje_kodu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proje_tanimi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnUrunListesi = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnIslemGecmisi = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnProjeSil = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewUrunler = new System.Windows.Forms.DataGridView();
            this.urun_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.urun_kodu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.urun_adi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stok_miktari = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gerekli_miktar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kullanilan_miktar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kalan_miktar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alinacak_miktar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnUrunCikis = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnGeriAl = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProjeler)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUrunler)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();

            // dataGridViewProjeler
            this.dataGridViewProjeler.AllowUserToAddRows = false;
            this.dataGridViewProjeler.AllowUserToDeleteRows = false;
            this.dataGridViewProjeler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProjeler.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.proje_id,
            this.proje_kodu,
            this.proje_tanimi,
            this.btnUrunListesi,
            this.btnIslemGecmisi,
            this.btnProjeSil});
            this.dataGridViewProjeler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewProjeler.Location = new System.Drawing.Point(3, 19);
            this.dataGridViewProjeler.Name = "dataGridViewProjeler";
            this.dataGridViewProjeler.ReadOnly = true;
            this.dataGridViewProjeler.Size = new System.Drawing.Size(894, 200);
            this.dataGridViewProjeler.TabIndex = 0;
            this.dataGridViewProjeler.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProjeler_CellContentClick);

            // proje_id
            this.proje_id.DataPropertyName = "proje_id";
            this.proje_id.HeaderText = "proje_id";
            this.proje_id.Name = "proje_id";
            this.proje_id.ReadOnly = true;
            this.proje_id.Visible = false;

            // proje_kodu
            this.proje_kodu.DataPropertyName = "proje_kodu";
            this.proje_kodu.HeaderText = "Proje Kodu";
            this.proje_kodu.Name = "proje_kodu";
            this.proje_kodu.ReadOnly = true;
            this.proje_kodu.Width = 150;

            // proje_tanimi
            this.proje_tanimi.DataPropertyName = "proje_tanimi";
            this.proje_tanimi.HeaderText = "Proje Tanımı";
            this.proje_tanimi.Name = "proje_tanimi";
            this.proje_tanimi.ReadOnly = true;
            this.proje_tanimi.Width = 300;

            // btnUrunListesi
            this.btnUrunListesi.HeaderText = "Ürünleri Listele";
            this.btnUrunListesi.Name = "btnUrunListesi";
            this.btnUrunListesi.ReadOnly = true;
            this.btnUrunListesi.Text = "Ürünleri Göster";
            this.btnUrunListesi.UseColumnTextForButtonValue = true;
            this.btnUrunListesi.Width = 120;

            // btnIslemGecmisi
            this.btnIslemGecmisi.HeaderText = "İşlem Geçmişi";
            this.btnIslemGecmisi.Name = "btnIslemGecmisi";
            this.btnIslemGecmisi.ReadOnly = true;
            this.btnIslemGecmisi.Text = "İşlem Geçmişi";
            this.btnIslemGecmisi.UseColumnTextForButtonValue = true;
            this.btnIslemGecmisi.Width = 120;

            // btnProjeSil
            this.btnProjeSil.HeaderText = "Projeyi Sil";
            this.btnProjeSil.Name = "btnProjeSil";
            this.btnProjeSil.ReadOnly = true;
            this.btnProjeSil.Text = "Projeyi Sil";
            this.btnProjeSil.UseColumnTextForButtonValue = true;
            this.btnProjeSil.Width = 100;

            // groupBox1
            this.groupBox1.Controls.Add(this.dataGridViewProjeler);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(900, 222);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Projeler";

            // dataGridViewUrunler
            this.dataGridViewUrunler.AllowUserToAddRows = false;
            this.dataGridViewUrunler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUrunler.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.urun_id,
            this.urun_kodu,
            this.urun_adi,
            this.stok_miktari,
            this.gerekli_miktar,
            this.kullanilan_miktar,
            this.kalan_miktar,
            this.alinacak_miktar,
            this.btnUrunCikis,
            this.btnGeriAl});
            this.dataGridViewUrunler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewUrunler.Location = new System.Drawing.Point(3, 19);
            this.dataGridViewUrunler.Name = "dataGridViewUrunler";
            this.dataGridViewUrunler.Size = new System.Drawing.Size(894, 200);
            this.dataGridViewUrunler.TabIndex = 0;
            this.dataGridViewUrunler.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewUrunler_CellContentClick);
            this.dataGridViewUrunler.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewUrunler_CellFormatting);

            // urun_id
            this.urun_id.DataPropertyName = "urun_id";
            this.urun_id.HeaderText = "urun_id";
            this.urun_id.Name = "urun_id";
            this.urun_id.Visible = false;

            // urun_kodu
            this.urun_kodu.DataPropertyName = "urun_kodu";
            this.urun_kodu.HeaderText = "Ürün Kodu";
            this.urun_kodu.Name = "urun_kodu";
            this.urun_kodu.ReadOnly = true;
            this.urun_kodu.Width = 120;

            // urun_adi
            this.urun_adi.DataPropertyName = "urun_adi";
            this.urun_adi.HeaderText = "Ürün Adı";
            this.urun_adi.Name = "urun_adi";
            this.urun_adi.ReadOnly = true;
            this.urun_adi.Width = 180;

            // stok_miktari
            this.stok_miktari.DataPropertyName = "stok_miktari";
            this.stok_miktari.HeaderText = "Stok Miktarı";
            this.stok_miktari.Name = "stok_miktari";
            this.stok_miktari.ReadOnly = true;
            this.stok_miktari.Width = 80;

            // gerekli_miktar
            this.gerekli_miktar.DataPropertyName = "gerekli_miktar";
            this.gerekli_miktar.HeaderText = "Gerekli Miktar";
            this.gerekli_miktar.Name = "gerekli_miktar";
            this.gerekli_miktar.ReadOnly = true;
            this.gerekli_miktar.Width = 80;

            // kullanilan_miktar
            this.kullanilan_miktar.DataPropertyName = "kullanilan_miktar";
            this.kullanilan_miktar.HeaderText = "Kullanılan Miktar";
            this.kullanilan_miktar.Name = "kullanilan_miktar";
            this.kullanilan_miktar.ReadOnly = true;
            this.kullanilan_miktar.Width = 80;

            // kalan_miktar
            this.kalan_miktar.DataPropertyName = "kalan_miktar";
            this.kalan_miktar.HeaderText = "Kalan Miktar";
            this.kalan_miktar.Name = "kalan_miktar";
            this.kalan_miktar.ReadOnly = true;
            this.kalan_miktar.Width = 80;

            // alinacak_miktar
            this.alinacak_miktar.DataPropertyName = "alinacak_miktar";
            this.alinacak_miktar.HeaderText = "Alınacak Miktar";
            this.alinacak_miktar.Name = "alinacak_miktar";
            this.alinacak_miktar.Width = 80;

            // btnUrunCikis
            this.btnUrunCikis.HeaderText = "Ürün Çıkışı";
            this.btnUrunCikis.Name = "btnUrunCikis";
            this.btnUrunCikis.Text = "Çıkış Yap";
            this.btnUrunCikis.UseColumnTextForButtonValue = true;
            this.btnUrunCikis.Width = 80;

            // btnGeriAl
            this.btnGeriAl.HeaderText = "Son İşlemi Geri Al";
            this.btnGeriAl.Name = "btnGeriAl";
            this.btnGeriAl.Text = "Geri Al";
            this.btnGeriAl.UseColumnTextForButtonValue = true;
            this.btnGeriAl.Width = 100;

            // groupBox2
            this.groupBox2.Controls.Add(this.dataGridViewUrunler);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 222);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(900, 222);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Proje Ürünleri";

            // ProjeMontajForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 444);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ProjeMontajForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proje Montaj";
            this.Load += new System.EventHandler(this.ProjeMontajForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProjeler)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUrunler)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewProjeler;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridViewUrunler;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn proje_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn proje_kodu;
        private System.Windows.Forms.DataGridViewTextBoxColumn proje_tanimi;
        private System.Windows.Forms.DataGridViewButtonColumn btnUrunListesi;
        private System.Windows.Forms.DataGridViewButtonColumn btnIslemGecmisi;
        private System.Windows.Forms.DataGridViewButtonColumn btnProjeSil;
        private System.Windows.Forms.DataGridViewTextBoxColumn urun_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn urun_kodu;
        private System.Windows.Forms.DataGridViewTextBoxColumn urun_adi;
        private System.Windows.Forms.DataGridViewTextBoxColumn stok_miktari;
        private System.Windows.Forms.DataGridViewTextBoxColumn gerekli_miktar;
        private System.Windows.Forms.DataGridViewTextBoxColumn kullanilan_miktar;
        private System.Windows.Forms.DataGridViewTextBoxColumn kalan_miktar;
        private System.Windows.Forms.DataGridViewTextBoxColumn alinacak_miktar;
        private System.Windows.Forms.DataGridViewButtonColumn btnUrunCikis;
        private System.Windows.Forms.DataGridViewButtonColumn btnGeriAl;
    }
}