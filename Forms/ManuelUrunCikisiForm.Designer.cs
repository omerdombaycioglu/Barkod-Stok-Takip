namespace StokTakipOtomasyonu.Forms
{
    partial class ManuelUrunCikisiForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblBarkod;
        private System.Windows.Forms.TextBox txtBarkod;
        private System.Windows.Forms.Label lblIslemTuru;
        private System.Windows.Forms.ComboBox cmbIslemTuru;
        private System.Windows.Forms.Label lblMiktar;
        private System.Windows.Forms.NumericUpDown nudMiktar;
        private System.Windows.Forms.Label lblBasariMesaji;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblBaslik;

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
            this.cmbIslemTuru = new System.Windows.Forms.ComboBox();
            this.lblMiktar = new System.Windows.Forms.Label();
            this.nudMiktar = new System.Windows.Forms.NumericUpDown();
            this.lblBasariMesaji = new System.Windows.Forms.Label();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblBaslik = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.nudMiktar)).BeginInit();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();

            // PanelTop
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(210, 210, 210);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Size = new System.Drawing.Size(400, 60);
            this.panelTop.Controls.Add(this.lblBaslik);

            // Başlık
            this.lblBaslik.Text = "Ürün Çıkışı";
            this.lblBaslik.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.ForeColor = System.Drawing.Color.DimGray;
            this.lblBaslik.Location = new System.Drawing.Point(20, 15);
            this.lblBaslik.AutoSize = true;

            // Genel Form Ayarları
            this.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.ClientSize = new System.Drawing.Size(400, 280);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Text = "Ürün Çıkışı";

            // lblBarkod
            this.lblBarkod.Text = "Barkod:";
            this.lblBarkod.Location = new System.Drawing.Point(30, 80);
            this.lblBarkod.Size = new System.Drawing.Size(80, 20);

            // txtBarkod
            this.txtBarkod.Location = new System.Drawing.Point(130, 77);
            this.txtBarkod.Size = new System.Drawing.Size(220, 25);
            this.txtBarkod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarkod_KeyDown);

            // lblIslemTuru
            this.lblIslemTuru.Text = "İşlem Türü:";
            this.lblIslemTuru.Location = new System.Drawing.Point(30, 115);
            this.lblIslemTuru.Size = new System.Drawing.Size(80, 20);

            // cmbIslemTuru
            this.cmbIslemTuru.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIslemTuru.Items.AddRange(new object[] { "Stok", "Hurda/İade" });
            this.cmbIslemTuru.Location = new System.Drawing.Point(130, 112);
            this.cmbIslemTuru.Size = new System.Drawing.Size(220, 25);

            // lblMiktar
            this.lblMiktar.Text = "Miktar:";
            this.lblMiktar.Location = new System.Drawing.Point(30, 150);
            this.lblMiktar.Size = new System.Drawing.Size(80, 20);

            // nudMiktar
            this.nudMiktar.Location = new System.Drawing.Point(130, 147);
            this.nudMiktar.Minimum = 1;
            this.nudMiktar.Maximum = 100000;
            this.nudMiktar.Value = 1;
            this.nudMiktar.Size = new System.Drawing.Size(220, 25);

            // btnKaydet
            this.btnKaydet.Text = "Ürün Çıkışı Yap";
            this.btnKaydet.Location = new System.Drawing.Point(130, 185);
            this.btnKaydet.Size = new System.Drawing.Size(220, 40);
            this.btnKaydet.BackColor = System.Drawing.Color.FromArgb(128, 128, 128);
            this.btnKaydet.ForeColor = System.Drawing.Color.White;
            this.btnKaydet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKaydet.FlatAppearance.BorderSize = 0;
            this.btnKaydet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 153, 133);
            this.btnKaydet.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(0, 153, 133);
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);

            // lblBasariMesaji
            this.lblBasariMesaji.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblBasariMesaji.ForeColor = System.Drawing.Color.Green;
            this.lblBasariMesaji.Location = new System.Drawing.Point(20, 235);
            this.lblBasariMesaji.Size = new System.Drawing.Size(360, 30);
            this.lblBasariMesaji.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBasariMesaji.Visible = false;

            // Form Controls
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.lblBarkod);
            this.Controls.Add(this.txtBarkod);
            this.Controls.Add(this.lblIslemTuru);
            this.Controls.Add(this.cmbIslemTuru);
            this.Controls.Add(this.lblMiktar);
            this.Controls.Add(this.nudMiktar);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.lblBasariMesaji);

            ((System.ComponentModel.ISupportInitialize)(this.nudMiktar)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
