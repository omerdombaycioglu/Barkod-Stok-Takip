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
        private System.Windows.Forms.TextBox txtYeniUrunAdi;
        private System.Windows.Forms.Label lblYeniUrunAdi;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblBaslik;
        


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
            this.txtYeniUrunAdi = new System.Windows.Forms.TextBox();
            this.lblYeniUrunAdi = new System.Windows.Forms.Label();
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblBaslik = new System.Windows.Forms.Label();
            this.lblDepoKonum = new System.Windows.Forms.Label();
            this.cmbDepoKonum = new System.Windows.Forms.ComboBox();
            this.cmbBirim = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudMiktar)).BeginInit();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBarkod
            // 
            this.txtBarkod.Location = new System.Drawing.Point(160, 80);
            this.txtBarkod.Name = "txtBarkod";
            this.txtBarkod.Size = new System.Drawing.Size(220, 22);
            this.txtBarkod.TabIndex = 1;
            // 
            // txtIslemTuru
            // 
            this.txtIslemTuru.Location = new System.Drawing.Point(160, 115);
            this.txtIslemTuru.Name = "txtIslemTuru";
            this.txtIslemTuru.ReadOnly = true;
            this.txtIslemTuru.Size = new System.Drawing.Size(220, 22);
            this.txtIslemTuru.TabIndex = 2;
            // 
            // nudMiktar
            // 
            this.nudMiktar.Location = new System.Drawing.Point(160, 150);
            this.nudMiktar.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMiktar.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMiktar.Name = "nudMiktar";
            this.nudMiktar.Size = new System.Drawing.Size(80, 22);
            this.nudMiktar.TabIndex = 3;
            this.nudMiktar.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtUrunKodu
            // 
            this.txtUrunKodu.Location = new System.Drawing.Point(160, 188);
            this.txtUrunKodu.Name = "txtUrunKodu";
            this.txtUrunKodu.Size = new System.Drawing.Size(220, 22);
            this.txtUrunKodu.TabIndex = 4;
            // 
            // lblBarkod
            // 
            this.lblBarkod.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblBarkod.Location = new System.Drawing.Point(30, 83);
            this.lblBarkod.Name = "lblBarkod";
            this.lblBarkod.Size = new System.Drawing.Size(120, 20);
            this.lblBarkod.TabIndex = 8;
            this.lblBarkod.Text = "Barkod:";
            // 
            // lblIslemTuru
            // 
            this.lblIslemTuru.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblIslemTuru.Location = new System.Drawing.Point(30, 118);
            this.lblIslemTuru.Name = "lblIslemTuru";
            this.lblIslemTuru.Size = new System.Drawing.Size(120, 20);
            this.lblIslemTuru.TabIndex = 9;
            this.lblIslemTuru.Text = "İşlem Türü:";
            // 
            // lblMiktar
            // 
            this.lblMiktar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblMiktar.Location = new System.Drawing.Point(30, 153);
            this.lblMiktar.Name = "lblMiktar";
            this.lblMiktar.Size = new System.Drawing.Size(120, 20);
            this.lblMiktar.TabIndex = 10;
            this.lblMiktar.Text = "Miktar:";
            // 
            // lblUrunKodu
            // 
            this.lblUrunKodu.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblUrunKodu.Location = new System.Drawing.Point(30, 188);
            this.lblUrunKodu.Name = "lblUrunKodu";
            this.lblUrunKodu.Size = new System.Drawing.Size(120, 20);
            this.lblUrunKodu.TabIndex = 11;
            this.lblUrunKodu.Text = "Ürün Kodu:";
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnKaydet.FlatAppearance.BorderSize = 0;
            this.btnKaydet.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(133)))));
            this.btnKaydet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(133)))));
            this.btnKaydet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKaydet.ForeColor = System.Drawing.Color.White;
            this.btnKaydet.Location = new System.Drawing.Point(160, 281);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(220, 40);
            this.btnKaydet.TabIndex = 6;
            this.btnKaydet.Text = "Ürün Girişi Yap";
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // lblBasariMesaji
            // 
            this.lblBasariMesaji.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblBasariMesaji.ForeColor = System.Drawing.Color.Green;
            this.lblBasariMesaji.Location = new System.Drawing.Point(20, 315);
            this.lblBasariMesaji.Name = "lblBasariMesaji";
            this.lblBasariMesaji.Size = new System.Drawing.Size(400, 40);
            this.lblBasariMesaji.TabIndex = 7;
            this.lblBasariMesaji.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBasariMesaji.Visible = false;
            // 
            // txtYeniUrunAdi
            // 
            this.txtYeniUrunAdi.Location = new System.Drawing.Point(160, 266);
            this.txtYeniUrunAdi.Name = "txtYeniUrunAdi";
            this.txtYeniUrunAdi.Size = new System.Drawing.Size(220, 22);
            this.txtYeniUrunAdi.TabIndex = 5;
            this.txtYeniUrunAdi.Visible = false;
            // 
            // lblYeniUrunAdi
            // 
            this.lblYeniUrunAdi.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblYeniUrunAdi.Location = new System.Drawing.Point(34, 265);
            this.lblYeniUrunAdi.Name = "lblYeniUrunAdi";
            this.lblYeniUrunAdi.Size = new System.Drawing.Size(120, 20);
            this.lblYeniUrunAdi.TabIndex = 12;
            this.lblYeniUrunAdi.Text = "Yeni Ürün Adı:";
            this.lblYeniUrunAdi.Visible = false;
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.panelTop.Controls.Add(this.lblBaslik);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(419, 60);
            this.panelTop.TabIndex = 0;
            // 
            // lblBaslik
            // 
            this.lblBaslik.AutoSize = true;
            this.lblBaslik.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.ForeColor = System.Drawing.Color.DimGray;
            this.lblBaslik.Location = new System.Drawing.Point(20, 15);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(137, 32);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "Ürün Girişi";
            // 
            // lblDepoKonum
            // 
            this.lblDepoKonum.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDepoKonum.Location = new System.Drawing.Point(30, 227);
            this.lblDepoKonum.Name = "lblDepoKonum";
            this.lblDepoKonum.Size = new System.Drawing.Size(120, 20);
            this.lblDepoKonum.TabIndex = 13;
            this.lblDepoKonum.Text = "Depo Konum:";
            // 
            // cmbDepoKonum
            // 
            this.cmbDepoKonum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepoKonum.Location = new System.Drawing.Point(160, 223);
            this.cmbDepoKonum.Name = "cmbDepoKonum";
            this.cmbDepoKonum.Size = new System.Drawing.Size(220, 24);
            this.cmbDepoKonum.TabIndex = 14;
            // 
            // cmbBirim
            // 
            this.cmbBirim.FormattingEnabled = true;
            this.cmbBirim.Location = new System.Drawing.Point(246, 150);
            this.cmbBirim.Name = "cmbBirim";
            this.cmbBirim.Size = new System.Drawing.Size(134, 24);
            this.cmbBirim.TabIndex = 15;
            // 
            // ManuelUrunGirisiForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(419, 372);           
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.txtBarkod);
            this.Controls.Add(this.txtIslemTuru);
            this.Controls.Add(this.nudMiktar);
            this.Controls.Add(this.txtUrunKodu);
            this.Controls.Add(this.txtYeniUrunAdi);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.lblBasariMesaji);
            this.Controls.Add(this.lblBarkod);
            this.Controls.Add(this.lblIslemTuru);
            this.Controls.Add(this.lblMiktar);
            this.Controls.Add(this.lblUrunKodu);
            this.Controls.Add(this.lblYeniUrunAdi);
            this.Controls.Add(this.lblDepoKonum);
            this.Controls.Add(this.cmbDepoKonum);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ManuelUrunGirisiForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ürün Girişi";
            ((System.ComponentModel.ISupportInitialize)(this.nudMiktar)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ComboBox comboBox1;
    }
}