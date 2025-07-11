namespace StokTakipOtomasyonu.Forms
{
    partial class ProjeEkleForm
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
            this.txtProjeKodu = new System.Windows.Forms.TextBox();
            this.txtProjeTanimi = new System.Windows.Forms.TextBox();
            this.btnYukle = new System.Windows.Forms.Button();
            this.lblProjeKodu = new System.Windows.Forms.Label();
            this.lblProjeTanimi = new System.Windows.Forms.Label();
            this.dgvUrunler = new System.Windows.Forms.DataGridView();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.btnTamEkran = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUrunler)).BeginInit();
            this.SuspendLayout();
            // 
            // txtProjeKodu
            // 
            this.txtProjeKodu.Location = new System.Drawing.Point(150, 30);
            this.txtProjeKodu.Name = "txtProjeKodu";
            this.txtProjeKodu.Size = new System.Drawing.Size(200, 22);
            this.txtProjeKodu.TabIndex = 0;
            // 
            // txtProjeTanimi
            // 
            this.txtProjeTanimi.Location = new System.Drawing.Point(150, 70);
            this.txtProjeTanimi.Name = "txtProjeTanimi";
            this.txtProjeTanimi.Size = new System.Drawing.Size(400, 22);
            this.txtProjeTanimi.TabIndex = 1;
            // 
            // btnYukle
            // 
            this.btnYukle.Location = new System.Drawing.Point(150, 110);
            this.btnYukle.Name = "btnYukle";
            this.btnYukle.Size = new System.Drawing.Size(150, 30);
            this.btnYukle.TabIndex = 2;
            this.btnYukle.Text = "Özet Ürün Listesi Yükle";
            this.btnYukle.UseVisualStyleBackColor = true;
            this.btnYukle.Click += new System.EventHandler(this.btnYukle_Click);
            // 
            // lblProjeKodu
            // 
            this.lblProjeKodu.AutoSize = true;
            this.lblProjeKodu.Location = new System.Drawing.Point(50, 33);
            this.lblProjeKodu.Name = "lblProjeKodu";
            this.lblProjeKodu.Size = new System.Drawing.Size(79, 17);
            this.lblProjeKodu.TabIndex = 3;
            this.lblProjeKodu.Text = "Proje Kodu";
            // 
            // lblProjeTanimi
            // 
            this.lblProjeTanimi.AutoSize = true;
            this.lblProjeTanimi.Location = new System.Drawing.Point(50, 73);
            this.lblProjeTanimi.Name = "lblProjeTanimi";
            this.lblProjeTanimi.Size = new System.Drawing.Size(88, 17);
            this.lblProjeTanimi.TabIndex = 4;
            this.lblProjeTanimi.Text = "Proje Tanımı";
            // 
            // dgvUrunler
            // 
            this.dgvUrunler.AllowUserToAddRows = false;
            this.dgvUrunler.AllowUserToDeleteRows = false;
            this.dgvUrunler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUrunler.Location = new System.Drawing.Point(30, 160);
            this.dgvUrunler.Name = "dgvUrunler";
            this.dgvUrunler.ReadOnly = true;
            this.dgvUrunler.RowTemplate.Height = 24;
            this.dgvUrunler.Size = new System.Drawing.Size(1000, 300);
            this.dgvUrunler.TabIndex = 5;
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(320, 110);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(100, 30);
            this.btnKaydet.TabIndex = 6;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            this.btnKaydet.Visible = false;
            // 
            // btnTamEkran
            // 
            this.btnTamEkran.Location = new System.Drawing.Point(440, 110);
            this.btnTamEkran.Name = "btnTamEkran";
            this.btnTamEkran.Size = new System.Drawing.Size(150, 30);
            this.btnTamEkran.TabIndex = 7;
            this.btnTamEkran.Text = "Tam Ekran Görüntüle";
            this.btnTamEkran.UseVisualStyleBackColor = true;
            this.btnTamEkran.Click += new System.EventHandler(this.btnTamEkran_Click);
            this.btnTamEkran.Visible = false;
            // 
            // ProjeEkleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 500);
            this.Controls.Add(this.btnTamEkran);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.dgvUrunler);
            this.Controls.Add(this.lblProjeTanimi);
            this.Controls.Add(this.lblProjeKodu);
            this.Controls.Add(this.btnYukle);
            this.Controls.Add(this.txtProjeTanimi);
            this.Controls.Add(this.txtProjeKodu);
            this.Name = "ProjeEkleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proje Ekle";
            ((System.ComponentModel.ISupportInitialize)(this.dgvUrunler)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

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
