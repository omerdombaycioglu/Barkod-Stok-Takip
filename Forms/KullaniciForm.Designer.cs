namespace StokTakipOtomasyonu.Forms
{
    partial class KullaniciForm
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
            this.dataGridViewKullanicilar = new System.Windows.Forms.DataGridView();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.btnIptal = new System.Windows.Forms.Button();
            this.btnSifreSifirla = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKullanicilar)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewKullanicilar
            // 
            this.dataGridViewKullanicilar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewKullanicilar.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewKullanicilar.Name = "dataGridViewKullanicilar";
            this.dataGridViewKullanicilar.Size = new System.Drawing.Size(760, 400);
            this.dataGridViewKullanicilar.TabIndex = 0;
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(535, 418);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(75, 30);
            this.btnKaydet.TabIndex = 1;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnIptal
            // 
            this.btnIptal.Location = new System.Drawing.Point(697, 418);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(75, 30);
            this.btnIptal.TabIndex = 2;
            this.btnIptal.Text = "İptal";
            this.btnIptal.UseVisualStyleBackColor = true;
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // btnSifreSifirla
            // 
            this.btnSifreSifirla.Location = new System.Drawing.Point(616, 418);
            this.btnSifreSifirla.Name = "btnSifreSifirla";
            this.btnSifreSifirla.Size = new System.Drawing.Size(75, 30);
            this.btnSifreSifirla.TabIndex = 3;
            this.btnSifreSifirla.Text = "Şifre Sıfırla";
            this.btnSifreSifirla.UseVisualStyleBackColor = true;
            this.btnSifreSifirla.Click += new System.EventHandler(this.btnSifreSifirla_Click);
            // 
            // KullaniciForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 460);
            this.Controls.Add(this.btnSifreSifirla);
            this.Controls.Add(this.btnIptal);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.dataGridViewKullanicilar);
            this.Name = "KullaniciForm";
            this.Text = "Kullanıcı Yönetimi";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKullanicilar)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewKullanicilar;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Button btnIptal;
        private System.Windows.Forms.Button btnSifreSifirla;
    }
}