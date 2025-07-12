using System.Windows.Forms;

namespace StokTakipOtomasyonu.Forms
{
    partial class ProjeMontajDetayForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblProjeKodu;
        private System.Windows.Forms.TextBox txtBarkod;
        private System.Windows.Forms.NumericUpDown nudMiktar;
        private System.Windows.Forms.Label lblBarkod;
        private System.Windows.Forms.Label lblMiktar;
        private System.Windows.Forms.DataGridView dgvProjeUrunler;
        private System.Windows.Forms.DataGridView dgvKullanilanlar;
        private System.Windows.Forms.SplitContainer splitContainer;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblProjeKodu = new System.Windows.Forms.Label();
            this.txtBarkod = new System.Windows.Forms.TextBox();
            this.nudMiktar = new System.Windows.Forms.NumericUpDown();
            this.lblBarkod = new System.Windows.Forms.Label();
            this.lblMiktar = new System.Windows.Forms.Label();
            this.dgvProjeUrunler = new System.Windows.Forms.DataGridView();
            this.dgvKullanilanlar = new System.Windows.Forms.DataGridView();
            this.splitContainer = new System.Windows.Forms.SplitContainer();

            ((System.ComponentModel.ISupportInitialize)(this.nudMiktar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProjeUrunler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKullanilanlar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();

            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();

            // lblProjeKodu
            this.lblProjeKodu.AutoSize = true;
            this.lblProjeKodu.Location = new System.Drawing.Point(20, 15);
            this.lblProjeKodu.Size = new System.Drawing.Size(92, 15);
            this.lblProjeKodu.Text = "Proje: [KODU]";

            // lblBarkod
            this.lblBarkod.AutoSize = true;
            this.lblBarkod.Location = new System.Drawing.Point(20, 45);
            this.lblBarkod.Text = "Barkod:";

            // txtBarkod
            this.txtBarkod.Location = new System.Drawing.Point(80, 42);
            this.txtBarkod.Size = new System.Drawing.Size(200, 23);
            this.txtBarkod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarkod_KeyDown);

            // lblMiktar
            this.lblMiktar.AutoSize = true;
            this.lblMiktar.Location = new System.Drawing.Point(300, 45);
            this.lblMiktar.Text = "Miktar:";

            // nudMiktar
            this.nudMiktar.Location = new System.Drawing.Point(350, 42);
            this.nudMiktar.Minimum = 1;
            this.nudMiktar.Maximum = 10000;
            this.nudMiktar.Value = 1;
            this.nudMiktar.Size = new System.Drawing.Size(80, 23);

            // splitContainer
            this.splitContainer.Location = new System.Drawing.Point(20, 80);
            this.splitContainer.Size = new System.Drawing.Size(960, 480);
            this.splitContainer.SplitterDistance = 470;
            this.splitContainer.Orientation = Orientation.Vertical;
            this.splitContainer.Dock = DockStyle.Bottom;

            // dgvProjeUrunler
            this.dgvProjeUrunler.Dock = DockStyle.Fill;
            this.dgvProjeUrunler.ReadOnly = true;
            this.dgvProjeUrunler.AllowUserToAddRows = false;
            this.dgvProjeUrunler.AllowUserToDeleteRows = false;

            // dgvKullanilanlar
            this.dgvKullanilanlar.Dock = DockStyle.Fill;
            this.dgvKullanilanlar.ReadOnly = true;
            this.dgvKullanilanlar.AllowUserToAddRows = false;
            this.dgvKullanilanlar.AllowUserToDeleteRows = false;

            // Add controls to split panels
            this.splitContainer.Panel1.Controls.Add(this.dgvProjeUrunler);
            this.splitContainer.Panel2.Controls.Add(this.dgvKullanilanlar);

            // Form
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.lblProjeKodu);
            this.Controls.Add(this.lblBarkod);
            this.Controls.Add(this.txtBarkod);
            this.Controls.Add(this.lblMiktar);
            this.Controls.Add(this.nudMiktar);
            this.Controls.Add(this.splitContainer);
            this.Text = "Proje Montaj Detayı";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ProjeMontajDetayForm_Load);

            ((System.ComponentModel.ISupportInitialize)(this.nudMiktar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProjeUrunler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKullanilanlar)).EndInit();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
