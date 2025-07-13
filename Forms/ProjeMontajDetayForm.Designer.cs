using System.Windows.Forms;

namespace StokTakipOtomasyonu.Forms
{
    partial class ProjeMontajDetayForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblProjeKodu;
        private Label lblBarkod;
        private Label lblMiktar;
        private Label lblSonIslem;
        private TextBox txtBarkod;
        private NumericUpDown nudMiktar;
        private SplitContainer splitContainer;
        private DataGridView dgvProjeUrunler;
        private DataGridView dgvKullanilanlar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblProjeKodu = new Label();
            this.lblBarkod = new Label();
            this.lblMiktar = new Label();
            this.lblSonIslem = new Label();
            this.txtBarkod = new TextBox();
            this.nudMiktar = new NumericUpDown();
            this.splitContainer = new SplitContainer();
            this.dgvProjeUrunler = new DataGridView();
            this.dgvKullanilanlar = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.nudMiktar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProjeUrunler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKullanilanlar)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();

            // lblProjeKodu
            this.lblProjeKodu.AutoSize = true;
            this.lblProjeKodu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblProjeKodu.Location = new System.Drawing.Point(20, 15);
            this.lblProjeKodu.Name = "lblProjeKodu";
            this.lblProjeKodu.Size = new System.Drawing.Size(89, 19);
            this.lblProjeKodu.Text = "Proje: [KOD]";

            // lblBarkod
            this.lblBarkod.AutoSize = true;
            this.lblBarkod.Location = new System.Drawing.Point(20, 50);
            this.lblBarkod.Name = "lblBarkod";
            this.lblBarkod.Size = new System.Drawing.Size(49, 15);
            this.lblBarkod.Text = "Barkod:";

            // txtBarkod
            this.txtBarkod.Location = new System.Drawing.Point(75, 47);
            this.txtBarkod.Name = "txtBarkod";
            this.txtBarkod.Size = new System.Drawing.Size(200, 23);
            this.txtBarkod.TabIndex = 0;
            this.txtBarkod.KeyDown += new KeyEventHandler(this.txtBarkod_KeyDown);

            // lblMiktar
            this.lblMiktar.AutoSize = true;
            this.lblMiktar.Location = new System.Drawing.Point(290, 50);
            this.lblMiktar.Name = "lblMiktar";
            this.lblMiktar.Size = new System.Drawing.Size(45, 15);
            this.lblMiktar.Text = "Miktar:";

            // nudMiktar
            this.nudMiktar.Location = new System.Drawing.Point(340, 47);
            this.nudMiktar.Minimum = 1;
            this.nudMiktar.Maximum = 100000;
            this.nudMiktar.Value = 1;
            this.nudMiktar.Size = new System.Drawing.Size(80, 23);
            this.nudMiktar.Name = "nudMiktar";

            // lblSonIslem
            this.lblSonIslem.AutoSize = true;
            this.lblSonIslem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblSonIslem.Location = new System.Drawing.Point(20, 580);
            this.lblSonIslem.Name = "lblSonIslem";
            this.lblSonIslem.Size = new System.Drawing.Size(0, 15);

            // splitContainer
            this.splitContainer.Location = new System.Drawing.Point(20, 85);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = Orientation.Vertical;
            this.splitContainer.Size = new System.Drawing.Size(960, 480);
            this.splitContainer.SplitterDistance = 470;
            this.splitContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            // dgvProjeUrunler
            this.dgvProjeUrunler.Dock = DockStyle.Fill;
            this.dgvProjeUrunler.ReadOnly = true;
            this.dgvProjeUrunler.AllowUserToAddRows = false;
            this.dgvProjeUrunler.AllowUserToDeleteRows = false;
            this.dgvProjeUrunler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProjeUrunler.RowTemplate.Height = 25;

            // dgvKullanilanlar
            this.dgvKullanilanlar.Dock = DockStyle.Fill;
            this.dgvKullanilanlar.ReadOnly = true;
            this.dgvKullanilanlar.AllowUserToAddRows = false;
            this.dgvKullanilanlar.AllowUserToDeleteRows = false;
            this.dgvKullanilanlar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKullanilanlar.RowTemplate.Height = 25;

            // Add DataGrids to Panels
            this.splitContainer.Panel1.Controls.Add(this.dgvProjeUrunler);
            this.splitContainer.Panel2.Controls.Add(this.dgvKullanilanlar);

            // ProjeMontajDetayForm
            this.ClientSize = new System.Drawing.Size(1000, 610);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.lblSonIslem);
            this.Controls.Add(this.nudMiktar);
            this.Controls.Add(this.lblMiktar);
            this.Controls.Add(this.txtBarkod);
            this.Controls.Add(this.lblBarkod);
            this.Controls.Add(this.lblProjeKodu);
            this.Name = "ProjeMontajDetayForm";
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
