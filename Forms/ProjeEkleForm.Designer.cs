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
            ((System.ComponentModel.ISupportInitialize)(this.dgvUrunler)).BeginInit();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();

            // panelTop
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(210, 210, 210);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Size = new System.Drawing.Size(1080, 60);
            this.panelTop.Controls.Add(this.lblBaslik);

            // lblBaslik
            this.lblBaslik.AutoSize = true;
            this.lblBaslik.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.ForeColor = System.Drawing.Color.DimGray;
            this.lblBaslik.Location = new System.Drawing.Point(20, 15);
            this.lblBaslik.Text = "Proje Ekle";

            // txtProjeKodu
            this.txtProjeKodu.Location = new System.Drawing.Point(150, 80);
            this.txtProjeKodu.Size = new System.Drawing.Size(200, 22);

            // txtProjeTanimi
            this.txtProjeTanimi.Location = new System.Drawing.Point(150, 120);
            this.txtProjeTanimi.Size = new System.Drawing.Size(400, 22);

            // btnYukle
            this.btnYukle.Location = new System.Drawing.Point(150, 160);
            this.btnYukle.Size = new System.Drawing.Size(200, 30);
            this.btnYukle.Text = "Özet Ürün Listesi Yükle";
            this.btnYukle.BackColor = System.Drawing.Color.FromArgb(128, 128, 128);
            this.btnYukle.ForeColor = System.Drawing.Color.White;
            this.btnYukle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYukle.FlatAppearance.BorderSize = 0;
            this.btnYukle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 153, 133);
            this.btnYukle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(0, 153, 133);
            this.btnYukle.Click += new System.EventHandler(this.btnYukle_Click);

            // lblProjeKodu
            this.lblProjeKodu.AutoSize = true;
            this.lblProjeKodu.Location = new System.Drawing.Point(50, 83);
            this.lblProjeKodu.Text = "Proje Kodu";

            // lblProjeTanimi
            this.lblProjeTanimi.AutoSize = true;
            this.lblProjeTanimi.Location = new System.Drawing.Point(50, 123);
            this.lblProjeTanimi.Text = "Proje Tanımı";

            // dgvUrunler
            this.dgvUrunler.Location = new System.Drawing.Point(30, 210);
            this.dgvUrunler.Size = new System.Drawing.Size(1000, 260);
            this.dgvUrunler.ReadOnly = true;
            this.dgvUrunler.AllowUserToAddRows = false;
            this.dgvUrunler.AllowUserToDeleteRows = false;
            this.dgvUrunler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            // btnKaydet
            this.btnKaydet.Location = new System.Drawing.Point(370, 160);
            this.btnKaydet.Size = new System.Drawing.Size(100, 30);
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Visible = false;
            this.btnKaydet.BackColor = System.Drawing.Color.FromArgb(128, 128, 128);
            this.btnKaydet.ForeColor = System.Drawing.Color.White;
            this.btnKaydet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKaydet.FlatAppearance.BorderSize = 0;
            this.btnKaydet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 153, 133);
            this.btnKaydet.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(0, 153, 133);
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);

            // btnTamEkran
            this.btnTamEkran.Location = new System.Drawing.Point(490, 160);
            this.btnTamEkran.Size = new System.Drawing.Size(200, 30);
            this.btnTamEkran.Text = "Tam Ekran Görüntüle";
            this.btnTamEkran.Visible = false;
            this.btnTamEkran.BackColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.btnTamEkran.ForeColor = System.Drawing.Color.White;
            this.btnTamEkran.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTamEkran.FlatAppearance.BorderSize = 0;
            this.btnTamEkran.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 153, 133);
            this.btnTamEkran.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(0, 153, 133);
            this.btnTamEkran.Click += new System.EventHandler(this.btnTamEkran_Click);

            // ProjeEkleForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(1080, 500);
            this.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvUrunler)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
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
