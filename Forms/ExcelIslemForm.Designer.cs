namespace StokTakipOtomasyonu.Forms
{
    partial class ExcelIslemForm
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

        private void InitializeComponent()
        {
            this.lblDosya = new System.Windows.Forms.Label();
            this.txtDosyaYolu = new System.Windows.Forms.TextBox();
            this.btnDosyaSec = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblIslemTuru = new System.Windows.Forms.Label();
            this.cmbIslemTuru = new System.Windows.Forms.ComboBox();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.btnIptal = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();

            // lblDosya
            this.lblDosya.AutoSize = true;
            this.lblDosya.Location = new System.Drawing.Point(20, 20);
            this.lblDosya.Name = "lblDosya";
            this.lblDosya.Size = new System.Drawing.Size(67, 13);
            this.lblDosya.TabIndex = 0;
            this.lblDosya.Text = "Excel Dosya:";

            // txtDosyaYolu
            this.txtDosyaYolu.Location = new System.Drawing.Point(100, 17);
            this.txtDosyaYolu.Name = "txtDosyaYolu";
            this.txtDosyaYolu.ReadOnly = true;
            this.txtDosyaYolu.Size = new System.Drawing.Size(300, 20);
            this.txtDosyaYolu.TabIndex = 1;

            // btnDosyaSec
            this.btnDosyaSec.Location = new System.Drawing.Point(420, 15);
            this.btnDosyaSec.Name = "btnDosyaSec";
            this.btnDosyaSec.Size = new System.Drawing.Size(80, 23);
            this.btnDosyaSec.TabIndex = 2;
            this.btnDosyaSec.Text = "Dosya Seç";
            this.btnDosyaSec.UseVisualStyleBackColor = true;
            this.btnDosyaSec.Click += new System.EventHandler(this.btnDosyaSec_Click);

            // dataGridView1
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(20, 60);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(560, 250);
            this.dataGridView1.TabIndex = 3;

            // lblIslemTuru
            this.lblIslemTuru.AutoSize = true;
            this.lblIslemTuru.Location = new System.Drawing.Point(20, 320);
            this.lblIslemTuru.Name = "lblIslemTuru";
            this.lblIslemTuru.Size = new System.Drawing.Size(56, 13);
            this.lblIslemTuru.TabIndex = 4;
            this.lblIslemTuru.Text = "İşlem Türü:";

            // cmbIslemTuru
            this.cmbIslemTuru.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIslemTuru.FormattingEnabled = true;
            this.cmbIslemTuru.Items.AddRange(new object[] {
            "Giriş",
            "Çıkış"});
            this.cmbIslemTuru.Location = new System.Drawing.Point(100, 317);
            this.cmbIslemTuru.Name = "cmbIslemTuru";
            this.cmbIslemTuru.Size = new System.Drawing.Size(100, 21);
            this.cmbIslemTuru.TabIndex = 5;

            // btnKaydet
            this.btnKaydet.Enabled = false;
            this.btnKaydet.Location = new System.Drawing.Point(420, 315);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(75, 30);
            this.btnKaydet.TabIndex = 6;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);

            // btnIptal
            this.btnIptal.Location = new System.Drawing.Point(505, 315);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(75, 30);
            this.btnIptal.TabIndex = 7;
            this.btnIptal.Text = "İptal";
            this.btnIptal.UseVisualStyleBackColor = true;
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);

            // ExcelIslemForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 360);
            this.Controls.Add(this.btnIptal);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.cmbIslemTuru);
            this.Controls.Add(this.lblIslemTuru);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnDosyaSec);
            this.Controls.Add(this.txtDosyaYolu);
            this.Controls.Add(this.lblDosya);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExcelIslemForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Excel ile Ürün Girişi/Çıkışı";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblDosya;
        private System.Windows.Forms.TextBox txtDosyaYolu;
        private System.Windows.Forms.Button btnDosyaSec;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblIslemTuru;
        private System.Windows.Forms.ComboBox cmbIslemTuru;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Button btnIptal;
    }
}