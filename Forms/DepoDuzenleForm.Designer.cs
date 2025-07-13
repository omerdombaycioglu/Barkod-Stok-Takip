namespace StokTakipOtomasyonu.Forms
{
    partial class DepoDuzenleForm
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
            this.lblBarkodArama = new System.Windows.Forms.Label();
            this.txtBarkodArama = new System.Windows.Forms.TextBox();
            this.dgvDepoKonumlari = new System.Windows.Forms.DataGridView();
            this.lblUrunBilgi = new System.Windows.Forms.Label();
            this.lblToplamMiktar = new System.Windows.Forms.Label();
            this.lblDepodakiToplam = new System.Windows.Forms.Label();
            this.lblUyari = new System.Windows.Forms.Label();
            this.btnYeniKonumEkle = new System.Windows.Forms.Button();
            this.cmbKatKonum = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMiktar = new System.Windows.Forms.TextBox();
            this.lblUyari2 = new System.Windows.Forms.Label();

            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepoKonumlari)).BeginInit();
            this.SuspendLayout();

            // panelTop
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(210, 210, 210);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Height = 50;
            this.panelTop.Controls.Add(this.lblBaslik);

            // lblBaslik
            this.lblBaslik.AutoSize = true;
            this.lblBaslik.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.ForeColor = System.Drawing.Color.DimGray;
            this.lblBaslik.Location = new System.Drawing.Point(20, 10);
            this.lblBaslik.Text = "Depo Konum Düzenleme";

            // lblBarkodArama
            this.lblBarkodArama.Location = new System.Drawing.Point(20, 70);
            this.lblBarkodArama.Text = "Barkod Ara:";

            // txtBarkodArama
            this.txtBarkodArama.Location = new System.Drawing.Point(110, 67);
            this.txtBarkodArama.Size = new System.Drawing.Size(200, 22);
            this.txtBarkodArama.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarkodArama_KeyDown);

            // lblUrunBilgi
            this.lblUrunBilgi.Location = new System.Drawing.Point(20, 100);
            this.lblUrunBilgi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            // lblToplamMiktar
            this.lblToplamMiktar.Location = new System.Drawing.Point(20, 125);

            // lblDepodakiToplam
            this.lblDepodakiToplam.Location = new System.Drawing.Point(180, 125);

            // lblUyari
            this.lblUyari.ForeColor = System.Drawing.Color.Orange;
            this.lblUyari.Location = new System.Drawing.Point(400, 125);

            // label1 - Depo Konumu
            this.label1.Location = new System.Drawing.Point(20, 160);
            this.label1.Text = "Depo Konumu:";

            // cmbKatKonum
            this.cmbKatKonum.Location = new System.Drawing.Point(120, 157);
            this.cmbKatKonum.Size = new System.Drawing.Size(200, 24);
            this.cmbKatKonum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // label2 - Miktar
            this.label2.Location = new System.Drawing.Point(340, 160);
            this.label2.Text = "Miktar:";

            // txtMiktar
            this.txtMiktar.Location = new System.Drawing.Point(400, 157);
            this.txtMiktar.Size = new System.Drawing.Size(100, 22);

            // btnYeniKonumEkle
            this.btnYeniKonumEkle.Location = new System.Drawing.Point(520, 155);
            this.btnYeniKonumEkle.Size = new System.Drawing.Size(140, 28);
            this.btnYeniKonumEkle.Text = "Konum Ekle";
            this.btnYeniKonumEkle.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.btnYeniKonumEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYeniKonumEkle.FlatAppearance.BorderSize = 0;
            this.btnYeniKonumEkle.ForeColor = System.Drawing.Color.White;
            this.btnYeniKonumEkle.Click += new System.EventHandler(this.btnYeniKonumEkle_Click);

            // lblUyari2
            this.lblUyari2.Location = new System.Drawing.Point(400, 145);
            this.lblUyari2.ForeColor = System.Drawing.Color.Red;

            // dgvDepoKonumlari
            this.dgvDepoKonumlari.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom |
                                           System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dgvDepoKonumlari.Location = new System.Drawing.Point(20, 200);
            this.dgvDepoKonumlari.Size = new System.Drawing.Size(740, 250);
            this.dgvDepoKonumlari.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            // DepoDuzenleForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.lblBarkodArama);
            this.Controls.Add(this.txtBarkodArama);
            this.Controls.Add(this.lblUrunBilgi);
            this.Controls.Add(this.lblToplamMiktar);
            this.Controls.Add(this.lblDepodakiToplam);
            this.Controls.Add(this.lblUyari);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbKatKonum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMiktar);
            this.Controls.Add(this.btnYeniKonumEkle);
            this.Controls.Add(this.lblUyari2);
            this.Controls.Add(this.dgvDepoKonumlari);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "DepoDuzenleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Depo Konum Düzenleme";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepoKonumlari)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.Label lblBarkodArama;
        private System.Windows.Forms.TextBox txtBarkodArama;
        private System.Windows.Forms.DataGridView dgvDepoKonumlari;
        private System.Windows.Forms.Label lblUrunBilgi;
        private System.Windows.Forms.Label lblToplamMiktar;
        private System.Windows.Forms.Label lblDepodakiToplam;
        private System.Windows.Forms.Label lblUyari;
        private System.Windows.Forms.Button btnYeniKonumEkle;
        private System.Windows.Forms.ComboBox cmbKatKonum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMiktar;
        private System.Windows.Forms.Label lblUyari2;
    }
}
