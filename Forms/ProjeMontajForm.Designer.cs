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
            this.btnSil = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewUrunler = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProjeler)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUrunler)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewProjeler
            // 
            this.dataGridViewProjeler.AllowUserToAddRows = false;
            this.dataGridViewProjeler.AllowUserToDeleteRows = false;
            this.dataGridViewProjeler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProjeler.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.proje_id,
            this.proje_kodu,
            this.proje_tanimi,
            this.btnUrunListesi,
            this.btnSil});
            this.dataGridViewProjeler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewProjeler.Location = new System.Drawing.Point(3, 19);
            this.dataGridViewProjeler.Name = "dataGridViewProjeler";
            this.dataGridViewProjeler.ReadOnly = true;
            this.dataGridViewProjeler.Size = new System.Drawing.Size(894, 200);
            this.dataGridViewProjeler.TabIndex = 0;
            this.dataGridViewProjeler.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProjeler_CellContentClick);
            // 
            // proje_id
            // 
            this.proje_id.DataPropertyName = "proje_id";
            this.proje_id.HeaderText = "proje_id";
            this.proje_id.Name = "proje_id";
            this.proje_id.ReadOnly = true;
            this.proje_id.Visible = false;
            // 
            // proje_kodu
            // 
            this.proje_kodu.DataPropertyName = "proje_kodu";
            this.proje_kodu.HeaderText = "Proje Kodu";
            this.proje_kodu.Name = "proje_kodu";
            this.proje_kodu.ReadOnly = true;
            // 
            // proje_tanimi
            // 
            this.proje_tanimi.DataPropertyName = "proje_tanimi";
            this.proje_tanimi.HeaderText = "Proje Tanımı";
            this.proje_tanimi.Name = "proje_tanimi";
            this.proje_tanimi.ReadOnly = true;
            // 
            // btnUrunListesi
            // 
            this.btnUrunListesi.HeaderText = "Ürün Listesi";
            this.btnUrunListesi.Name = "btnUrunListesi";
            this.btnUrunListesi.ReadOnly = true;
            this.btnUrunListesi.Text = "Ürünleri Göster";
            this.btnUrunListesi.UseColumnTextForButtonValue = true;
            // 
            // btnSil
            // 
            this.btnSil.HeaderText = "Sil";
            this.btnSil.Name = "btnSil";
            this.btnSil.ReadOnly = true;
            this.btnSil.Text = "Sil";
            this.btnSil.UseColumnTextForButtonValue = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewProjeler);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(900, 222);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Projeler";
            // 
            // dataGridViewUrunler
            // 
            this.dataGridViewUrunler.AllowUserToAddRows = false;
            this.dataGridViewUrunler.AllowUserToDeleteRows = false;
            this.dataGridViewUrunler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUrunler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewUrunler.Location = new System.Drawing.Point(3, 19);
            this.dataGridViewUrunler.Name = "dataGridViewUrunler";
            this.dataGridViewUrunler.ReadOnly = true;
            this.dataGridViewUrunler.Size = new System.Drawing.Size(894, 200);
            this.dataGridViewUrunler.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridViewUrunler);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 222);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(900, 222);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Proje Ürünleri";
            // 
            // ProjeMontajForm
            // 
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
        private System.Windows.Forms.DataGridViewButtonColumn btnSil;
    }
}