namespace StokTakipOtomasyonu.Forms
{
    partial class ManuelUrunCikisiForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblBarkod;
        private System.Windows.Forms.TextBox txtBarkod;
        private System.Windows.Forms.Label lblIslemTuru;
        private System.Windows.Forms.TextBox txtIslemTuru;
        private System.Windows.Forms.Label lblMiktar;
        private System.Windows.Forms.NumericUpDown nudMiktar;
        private System.Windows.Forms.Label lblBasariMesaji;
        private System.Windows.Forms.Button btnKaydet;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblBarkod = new System.Windows.Forms.Label();
            this.txtBarkod = new System.Windows.Forms.TextBox();
            this.lblIslemTuru = new System.Windows.Forms.Label();
            this.txtIslemTuru = new System.Windows.Forms.TextBox();
            this.lblMiktar = new System.Windows.Forms.Label();
            this.nudMiktar = new System.Windows.Forms.NumericUpDown();
            this.lblBasariMesaji = new System.Windows.Forms.Label();
            this.btnKaydet = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudMiktar)).BeginInit();
            this.SuspendLayout();
            //
            // lblBarkod
            //
            this.lblBarkod.AutoSize = true;
            this.lblBarkod.Location = new System.Drawing.Point(30, 30);
            this.lblBarkod.Name = "lblBarkod";
            this.lblBarkod.Size = new System.Drawing.Size(55, 17);
            this.lblBarkod.Text = "Barkod:";
            //
            // txtBarkod
            //
            this.txtBarkod.Location = new System.Drawing.Point(120, 27);
            this.txtBarkod.Name = "txtBarkod";
            this.txtBarkod.Size = new System.Drawing.Size(200, 25);
            this.txtBarkod.TabIndex = 0;
            this.txtBarkod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarkod_KeyDown);
            //
            // lblIslemTuru
            //
            this.lblIslemTuru.AutoSize = true;
            this.lblIslemTuru.Location = new System.Drawing.Point(30, 70);
            this.lblIslemTuru.Name = "lblIslemTuru";
            this.lblIslemTuru.Size = new System.Drawing.Size(76, 17);
            this.lblIslemTuru.Text = "İşlem Türü:";
            //
            // txtIslemTuru
            //
            this.txtIslemTuru.Location = new System.Drawing.Point(120, 67);
            this.txtIslemTuru.Name = "txtIslemTuru";
            this.txtIslemTuru.ReadOnly = true;
            this.txtIslemTuru.Size = new System.Drawing.Size(200, 25);
            //
            // lblMiktar
            //
            this.lblMiktar.AutoSize = true;
            this.lblMiktar.Location = new System.Drawing.Point(30, 110);
            this.lblMiktar.Name = "lblMiktar";
            this.lblMiktar.Size = new System.Drawing.Size(50, 17);
            this.lblMiktar.Text = "Miktar:";
            //
            // nudMiktar
            //
            this.nudMiktar.Location = new System.Drawing.Point(120, 107);
            this.nudMiktar.Minimum = 1;
            this.nudMiktar.Maximum = 100000;
            this.nudMiktar.Value = 1;
            this.nudMiktar.Name = "nudMiktar";
            this.nudMiktar.Size = new System.Drawing.Size(200, 25);
            //
            // lblBasariMesaji
            //
            this.lblBasariMesaji.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblBasariMesaji.ForeColor = System.Drawing.Color.Green;
            this.lblBasariMesaji.Location = new System.Drawing.Point(30, 190);
            this.lblBasariMesaji.Name = "lblBasariMesaji";
            this.lblBasariMesaji.Size = new System.Drawing.Size(290, 40);
            this.lblBasariMesaji.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBasariMesaji.Visible = false;
            //
            // btnKaydet
            //
            this.btnKaydet.Location = new System.Drawing.Point(120, 150);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(200, 30);
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            //
            // ManuelUrunCikisiForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.ClientSize = new System.Drawing.Size(360, 250);
            this.Controls.Add(this.lblBarkod);
            this.Controls.Add(this.txtBarkod);
            this.Controls.Add(this.lblIslemTuru);
            this.Controls.Add(this.txtIslemTuru);
            this.Controls.Add(this.lblMiktar);
            this.Controls.Add(this.nudMiktar);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.lblBasariMesaji);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "ManuelUrunCikisiForm";
            this.Text = "Manuel Ürün Çıkışı";
            ((System.ComponentModel.ISupportInitialize)(this.nudMiktar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
