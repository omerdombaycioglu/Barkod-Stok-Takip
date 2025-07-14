using System.Windows.Forms;
using System.Drawing;

namespace StokTakipOtomasyonu.Forms
{
    partial class ProjeMontajDetayForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblProjeKodu;
        private Label lblBarkod;
        private Label lblMiktar;
        private Label lblSonIslem;
        private Label label1;
        private Label label2;
        private TextBox txtBarkod;
        private NumericUpDown nudMiktar;
        private SplitContainer splitContainer;
        private DataGridView dgvProjeUrunler;
        private DataGridView dgvKullanilanlar;
        private Button btnGeriAl; // <- EKLENDİ

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
            this.label1 = new Label();
            this.label2 = new Label();
            this.btnGeriAl = new Button(); // <- EKLENDİ

            ((System.ComponentModel.ISupportInitialize)(this.nudMiktar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProjeUrunler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKullanilanlar)).BeginInit();
            this.SuspendLayout();

            // Form Özellikleri
            this.BackColor = Color.FromArgb(240, 240, 240);
            this.Font = new Font("Segoe UI", 9F);
            this.ClientSize = new Size(1000, 610);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Proje Montaj Detayı";
            this.Load += new System.EventHandler(this.ProjeMontajDetayForm_Load);

            // lblProjeKodu
            this.lblProjeKodu.AutoSize = true;
            this.lblProjeKodu.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblProjeKodu.ForeColor = Color.DimGray;
            this.lblProjeKodu.Location = new Point(20, 15);
            this.lblProjeKodu.Text = "Proje: [KOD]";

            // lblBarkod
            this.lblBarkod.AutoSize = true;
            this.lblBarkod.Location = new Point(20, 50);
            this.lblBarkod.Text = "Barkod:";

            // txtBarkod
            this.txtBarkod.Font = new Font("Segoe UI", 9F);
            this.txtBarkod.Location = new Point(80, 47);
            this.txtBarkod.Size = new Size(200, 23);
            this.txtBarkod.TabIndex = 0;
            this.txtBarkod.KeyDown += new KeyEventHandler(this.txtBarkod_KeyDown);

            // lblMiktar
            this.lblMiktar.AutoSize = true;
            this.lblMiktar.Location = new Point(300, 50);
            this.lblMiktar.Text = "Miktar:";

            // nudMiktar
            this.nudMiktar.Location = new Point(350, 47);
            this.nudMiktar.Minimum = 1;
            this.nudMiktar.Maximum = 100000;
            this.nudMiktar.Value = 1;
            this.nudMiktar.Size = new Size(80, 23);

            // btnGeriAl
            this.btnGeriAl.Text = "Son İşlemi Geri Al";
            this.btnGeriAl.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnGeriAl.BackColor = Color.IndianRed;
            this.btnGeriAl.ForeColor = Color.White;
            this.btnGeriAl.FlatStyle = FlatStyle.Flat;
            this.btnGeriAl.Location = new Point(450, 45);
            this.btnGeriAl.Size = new Size(150, 27);
            this.btnGeriAl.Click += new System.EventHandler(this.BtnGeriAl_Click);

            // lblSonIslem
            this.lblSonIslem.AutoSize = true;
            this.lblSonIslem.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            this.lblSonIslem.ForeColor = Color.Gray;
            this.lblSonIslem.Location = new Point(20, 580);
            this.lblSonIslem.Text = "";

            // label2
            this.label2.AutoSize = true;
            this.label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.label2.Location = new Point(20, 70);
            this.label2.Text = "Montaj Ürün Listesi";

            // label1
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.label1.Location = new Point(500, 70);
            this.label1.Text = "Kullanılan Ürünler";

            // splitContainer
            this.splitContainer.Location = new Point(20, 90);
            this.splitContainer.Size = new Size(960, 470);
            this.splitContainer.SplitterDistance = 470;
            this.splitContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            // dgvProjeUrunler
            this.dgvProjeUrunler.AllowUserToAddRows = false;
            this.dgvProjeUrunler.AllowUserToDeleteRows = false;
            this.dgvProjeUrunler.ReadOnly = true;
            this.dgvProjeUrunler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProjeUrunler.Dock = DockStyle.Fill;
            this.dgvProjeUrunler.RowTemplate.Height = 24;
            this.dgvProjeUrunler.ColumnHeadersHeight = 28;
            this.dgvProjeUrunler.CellContentClick += new DataGridViewCellEventHandler(this.dgvProjeUrunler_CellContentClick);

            // dgvKullanilanlar
            this.dgvKullanilanlar.AllowUserToAddRows = false;
            this.dgvKullanilanlar.AllowUserToDeleteRows = false;
            this.dgvKullanilanlar.ReadOnly = true;
            this.dgvKullanilanlar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKullanilanlar.Dock = DockStyle.Fill;
            this.dgvKullanilanlar.RowTemplate.Height = 24;
            this.dgvKullanilanlar.ColumnHeadersHeight = 28;

            // Panel eklemeleri
            this.splitContainer.Panel1.Controls.Add(this.dgvProjeUrunler);
            this.splitContainer.Panel2.Controls.Add(this.dgvKullanilanlar);

            // Form kontrolleri
            this.Controls.Add(this.lblProjeKodu);
            this.Controls.Add(this.lblBarkod);
            this.Controls.Add(this.txtBarkod);
            this.Controls.Add(this.lblMiktar);
            this.Controls.Add(this.nudMiktar);
            this.Controls.Add(this.btnGeriAl); // <- EKLENDİ
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.lblSonIslem);

            ((System.ComponentModel.ISupportInitialize)(this.nudMiktar)).EndInit();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProjeUrunler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKullanilanlar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
