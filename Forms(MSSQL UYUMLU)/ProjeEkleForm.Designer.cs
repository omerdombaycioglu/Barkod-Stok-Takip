namespace StokTakipOtomasyonu.Forms
{
    partial class ProjeEkleForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblBaslik = new System.Windows.Forms.Label();
            this.txtProjeKodu = new System.Windows.Forms.TextBox();
            this.txtProjeTanimi = new System.Windows.Forms.TextBox();
            this.btnYukle = new System.Windows.Forms.Button();
            this.lblProjeKodu = new System.Windows.Forms.Label();
            this.lblProjeTanimi = new System.Windows.Forms.Label();
            this.dgvUrunler = new System.Windows.Forms.DataGridView();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.btnTamEkran = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUrunler)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.panelTop.Controls.Add(this.lblBaslik);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1080, 60);
            this.panelTop.TabIndex = 0;
            // 
            // lblBaslik
            // 
            this.lblBaslik.AutoSize = true;
            this.lblBaslik.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.ForeColor = System.Drawing.Color.DimGray;
            this.lblBaslik.Location = new System.Drawing.Point(20, 15);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(127, 32);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "Proje Ekle";
            // 
            // txtProjeKodu
            // 
            this.txtProjeKodu.Location = new System.Drawing.Point(150, 80);
            this.txtProjeKodu.Name = "txtProjeKodu";
            this.txtProjeKodu.Size = new System.Drawing.Size(200, 22);
            this.txtProjeKodu.TabIndex = 1;
            // 
            // txtProjeTanimi
            // 
            this.txtProjeTanimi.Location = new System.Drawing.Point(150, 120);
            this.txtProjeTanimi.Name = "txtProjeTanimi";
            this.txtProjeTanimi.Size = new System.Drawing.Size(400, 22);
            this.txtProjeTanimi.TabIndex = 2;
            // 
            // btnYukle
            // 
            this.btnYukle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnYukle.FlatAppearance.BorderSize = 0;
            this.btnYukle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(133)))));
            this.btnYukle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(133)))));
            this.btnYukle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYukle.ForeColor = System.Drawing.Color.White;
            this.btnYukle.Location = new System.Drawing.Point(150, 160);
            this.btnYukle.Name = "btnYukle";
            this.btnYukle.Size = new System.Drawing.Size(200, 30);
            this.btnYukle.TabIndex = 3;
            this.btnYukle.Text = "Özet Ürün Listesi Yükle";
            this.btnYukle.UseVisualStyleBackColor = false;
            this.btnYukle.Click += new System.EventHandler(this.btnYukle_Click);
            // 
            // lblProjeKodu
            // 
            this.lblProjeKodu.AutoSize = true;
            this.lblProjeKodu.Location = new System.Drawing.Point(50, 83);
            this.lblProjeKodu.Name = "lblProjeKodu";
            this.lblProjeKodu.Size = new System.Drawing.Size(73, 16);
            this.lblProjeKodu.TabIndex = 4;
            this.lblProjeKodu.Text = "Proje Kodu";
            // 
            // lblProjeTanimi
            // 
            this.lblProjeTanimi.AutoSize = true;
            this.lblProjeTanimi.Location = new System.Drawing.Point(50, 123);
            this.lblProjeTanimi.Name = "lblProjeTanimi";
            this.lblProjeTanimi.Size = new System.Drawing.Size(83, 16);
            this.lblProjeTanimi.TabIndex = 5;
            this.lblProjeTanimi.Text = "Proje Tanımı";
            // 
            // dgvUrunler
            // 
            this.dgvUrunler.AllowUserToAddRows = false;
            this.dgvUrunler.AllowUserToDeleteRows = false;
            this.dgvUrunler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUrunler.Location = new System.Drawing.Point(30, 210);
            this.dgvUrunler.Name = "dgvUrunler";
            this.dgvUrunler.ReadOnly = true;
            this.dgvUrunler.RowHeadersWidth = 51;
            this.dgvUrunler.Size = new System.Drawing.Size(1000, 260);
            this.dgvUrunler.TabIndex = 6;
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnKaydet.FlatAppearance.BorderSize = 0;
            this.btnKaydet.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(133)))));
            this.btnKaydet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(133)))));
            this.btnKaydet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKaydet.ForeColor = System.Drawing.Color.White;
            this.btnKaydet.Location = new System.Drawing.Point(370, 160);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(100, 30);
            this.btnKaydet.TabIndex = 7;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Visible = false;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnTamEkran
            // 
            this.btnTamEkran.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnTamEkran.FlatAppearance.BorderSize = 0;
            this.btnTamEkran.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(133)))));
            this.btnTamEkran.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(133)))));
            this.btnTamEkran.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTamEkran.ForeColor = System.Drawing.Color.White;
            this.btnTamEkran.Location = new System.Drawing.Point(490, 160);
            this.btnTamEkran.Name = "btnTamEkran";
            this.btnTamEkran.Size = new System.Drawing.Size(200, 30);
            this.btnTamEkran.TabIndex = 8;
            this.btnTamEkran.Text = "Tam Ekran Görüntüle";
            this.btnTamEkran.UseVisualStyleBackColor = false;
            this.btnTamEkran.Visible = false;
            this.btnTamEkran.Click += new System.EventHandler(this.btnTamEkran_Click);
            // 
            // ProjeEkleForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1080, 500);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.txtProjeKodu);
            this.Controls.Add(this.txtProjeTanimi);
            this.Controls.Add(this.btnYukle);
            this.Controls.Add(this.lblProjeKodu);
            this.Controls.Add(this.lblProjeTanimi);
            this.Controls.Add(this.dgvUrunler);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.btnTamEkran);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ProjeEkleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proje Ekle";
            this.Load += new System.EventHandler(this.ProjeEkleForm_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUrunler)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.TextBox txtProjeKodu;
        private System.Windows.Forms.TextBox txtProjeTanimi;
        private System.Windows.Forms.Button btnYukle;
        private System.Windows.Forms.Label lblProjeKodu;
        private System.Windows.Forms.Label lblProjeTanimi;
        private System.Windows.Forms.DataGridView dgvUrunler;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Button btnTamEkran;
    }
}
