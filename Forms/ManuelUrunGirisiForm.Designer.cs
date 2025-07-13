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

            ((System.ComponentModel.ISupportInitialize)(this.nudMiktar)).BeginInit();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();

            // Panel
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(210, 210, 210);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Size = new System.Drawing.Size(440, 60);
            this.panelTop.Controls.Add(this.lblBaslik);

            // Başlık
            this.lblBaslik.Text = "Manuel Ürün Girişi";
            this.lblBaslik.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.ForeColor = System.Drawing.Color.DimGray;
            this.lblBaslik.Location = new System.Drawing.Point(20, 15);
            this.lblBaslik.AutoSize = true;

            // Genel Form
            this.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.ClientSize = new System.Drawing.Size(440, 400);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // txtBarkod
            this.txtBarkod.Location = new System.Drawing.Point(160, 80);
            this.txtBarkod.Size = new System.Drawing.Size(220, 22);

            // txtIslemTuru
            this.txtIslemTuru.Location = new System.Drawing.Point(160, 115);
            this.txtIslemTuru.Size = new System.Drawing.Size(220, 22);
            this.txtIslemTuru.ReadOnly = true;

            // nudMiktar
            this.nudMiktar.Location = new System.Drawing.Point(160, 150);
            this.nudMiktar.Minimum = 1;
            this.nudMiktar.Maximum = 10000;
            this.nudMiktar.Value = 1;
            this.nudMiktar.Size = new System.Drawing.Size(220, 22);

            // txtUrunKodu
            this.txtUrunKodu.Location = new System.Drawing.Point(160, 185);
            this.txtUrunKodu.Size = new System.Drawing.Size(220, 22);

            // txtYeniUrunAdi
            this.txtYeniUrunAdi.Location = new System.Drawing.Point(160, 220);
            this.txtYeniUrunAdi.Size = new System.Drawing.Size(220, 22);
            this.txtYeniUrunAdi.Visible = false;

            // btnKaydet
            this.btnKaydet.Text = "Ürün Girişi Yap";
            this.btnKaydet.Location = new System.Drawing.Point(160, 260);
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
            this.lblBasariMesaji.Location = new System.Drawing.Point(20, 315);
            this.lblBasariMesaji.Size = new System.Drawing.Size(400, 40);
            this.lblBasariMesaji.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBasariMesaji.Visible = false;

            // Label'ler
            void SetupLabel(System.Windows.Forms.Label lbl, string text, int top)
            {
                lbl.Text = text;
                lbl.Location = new System.Drawing.Point(30, top);
                lbl.Size = new System.Drawing.Size(120, 20);
                lbl.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            }

            SetupLabel(this.lblBarkod, "Barkod:", 83);
            SetupLabel(this.lblIslemTuru, "İşlem Türü:", 118);
            SetupLabel(this.lblMiktar, "Miktar:", 153);
            SetupLabel(this.lblUrunKodu, "Ürün Kodu:", 188);
            SetupLabel(this.lblYeniUrunAdi, "Yeni Ürün Adı:", 223);
            this.lblYeniUrunAdi.Visible = false;

            // Controls
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

            this.Name = "ManuelUrunGirisiForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ürün Girişi";

            ((System.ComponentModel.ISupportInitialize)(this.nudMiktar)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
