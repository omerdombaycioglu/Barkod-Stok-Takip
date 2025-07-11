namespace StokTakipOtomasyonu.Forms
{
    partial class ManuelUrunGirisiForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtBarkod;
        private System.Windows.Forms.TextBox txtIslemTuru;
        private System.Windows.Forms.NumericUpDown nudMiktar;
        private System.Windows.Forms.TextBox txtUrunKodu;
        private System.Windows.Forms.Label lblBarkod;
        private System.Windows.Forms.Label lblIslemTuru;
        private System.Windows.Forms.Label lblMiktar;
        private System.Windows.Forms.Label lblUrunKodu;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Label lblBasariMesaji;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtBarkod = new System.Windows.Forms.TextBox();
            this.txtIslemTuru = new System.Windows.Forms.TextBox();
            this.nudMiktar = new System.Windows.Forms.NumericUpDown();
            this.txtUrunKodu = new System.Windows.Forms.TextBox();
            this.lblBarkod = new System.Windows.Forms.Label();
            this.lblIslemTuru = new System.Windows.Forms.Label();
            this.lblMiktar = new System.Windows.Forms.Label();
            this.lblUrunKodu = new System.Windows.Forms.Label();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.lblBasariMesaji = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudMiktar)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBarkod
            // 
            this.txtBarkod.Location = new System.Drawing.Point(130, 30);
            this.txtBarkod.Name = "txtBarkod";
            this.txtBarkod.Size = new System.Drawing.Size(200, 22);
            this.txtBarkod.TabIndex = 0;
            // 
            // txtIslemTuru
            // 
            this.txtIslemTuru.Location = new System.Drawing.Point(130, 70);
            this.txtIslemTuru.Name = "txtIslemTuru";
            this.txtIslemTuru.ReadOnly = true;
            this.txtIslemTuru.Size = new System.Drawing.Size(200, 22);
            this.txtIslemTuru.TabIndex = 1;
            // 
            // nudMiktar
            // 
            this.nudMiktar.Location = new System.Drawing.Point(130, 110);
            this.nudMiktar.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMiktar.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMiktar.Name = "nudMiktar";
            this.nudMiktar.Size = new System.Drawing.Size(200, 22);
            this.nudMiktar.TabIndex = 2;
            this.nudMiktar.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtUrunKodu
            // 
            this.txtUrunKodu.Location = new System.Drawing.Point(130, 150);
            this.txtUrunKodu.Name = "txtUrunKodu";
            this.txtUrunKodu.Size = new System.Drawing.Size(200, 22);
            this.txtUrunKodu.TabIndex = 3;
            // 
            // lblBarkod
            // 
            this.lblBarkod.AutoSize = true;
            this.lblBarkod.Location = new System.Drawing.Point(30, 33);
            this.lblBarkod.Name = "lblBarkod";
            this.lblBarkod.Size = new System.Drawing.Size(53, 17);
            this.lblBarkod.TabIndex = 4;
            this.lblBarkod.Text = "Barkod:";
            // 
            // lblIslemTuru
            // 
            this.lblIslemTuru.AutoSize = true;
            this.lblIslemTuru.Location = new System.Drawing.Point(30, 73);
            this.lblIslemTuru.Name = "lblIslemTuru";
            this.lblIslemTuru.Size = new System.Drawing.Size(74, 17);
            this.lblIslemTuru.TabIndex = 5;
            this.lblIslemTuru.Text = "İşlem Türü:";
            // 
            // lblMiktar
            // 
            this.lblMiktar.AutoSize = true;
            this.lblMiktar.Location = new System.Drawing.Point(30, 113);
            this.lblMiktar.Name = "lblMiktar";
            this.lblMiktar.Size = new System.Drawing.Size(49, 17);
            this.lblMiktar.TabIndex = 6;
            this.lblMiktar.Text = "Miktar:";
            // 
            // lblUrunKodu
            // 
            this.lblUrunKodu.AutoSize = true;
            this.lblUrunKodu.Location = new System.Drawing.Point(30, 153);
            this.lblUrunKodu.Name = "lblUrunKodu";
            this.lblUrunKodu.Size = new System.Drawing.Size(76, 17);
            this.lblUrunKodu.TabIndex = 7;
            this.lblUrunKodu.Text = "Ürün Kodu:";
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(130, 190);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(200, 30);
            this.btnKaydet.TabIndex = 4;
            this.btnKaydet.Text = "Ürün Girişi Yap";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // lblBasariMesaji
            // 
            // 
            // lblBasariMesaji
            // 
            this.lblBasariMesaji.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblBasariMesaji.ForeColor = System.Drawing.Color.Green;
            this.lblBasariMesaji.Location = new System.Drawing.Point(20, 245); // bir tık aşağıda
            this.lblBasariMesaji.Name = "lblBasariMesaji";
            this.lblBasariMesaji.Size = new System.Drawing.Size(380, 40);
            this.lblBasariMesaji.AutoSize = false;
            this.lblBasariMesaji.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBasariMesaji.Visible = false;
            this.lblBasariMesaji.MaximumSize = new System.Drawing.Size(380, 60);

            // 
            // ManuelUrunGirisiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 350);
            this.Controls.Add(this.lblBasariMesaji);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.lblUrunKodu);
            this.Controls.Add(this.lblMiktar);
            this.Controls.Add(this.lblIslemTuru);
            this.Controls.Add(this.lblBarkod);
            this.Controls.Add(this.txtUrunKodu);
            this.Controls.Add(this.nudMiktar);
            this.Controls.Add(this.txtIslemTuru);
            this.Controls.Add(this.txtBarkod);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ManuelUrunGirisiForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ürün Girişi";
            ((System.ComponentModel.ISupportInitialize)(this.nudMiktar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
