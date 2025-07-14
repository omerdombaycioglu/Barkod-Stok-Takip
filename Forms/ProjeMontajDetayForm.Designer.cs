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
            this.lblProjeKodu = new System.Windows.Forms.Label();
            this.lblBarkod = new System.Windows.Forms.Label();
            this.lblMiktar = new System.Windows.Forms.Label();
            this.lblSonIslem = new System.Windows.Forms.Label();
            this.txtBarkod = new System.Windows.Forms.TextBox();
            this.nudMiktar = new System.Windows.Forms.NumericUpDown();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.dgvProjeUrunler = new System.Windows.Forms.DataGridView();
            this.dgvKullanilanlar = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGeriAl = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudMiktar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProjeUrunler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKullanilanlar)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProjeKodu
            // 
            this.lblProjeKodu.AutoSize = true;
            this.lblProjeKodu.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblProjeKodu.ForeColor = System.Drawing.Color.DimGray;
            this.lblProjeKodu.Location = new System.Drawing.Point(20, 15);
            this.lblProjeKodu.Name = "lblProjeKodu";
            this.lblProjeKodu.Size = new System.Drawing.Size(122, 25);
            this.lblProjeKodu.TabIndex = 0;
            this.lblProjeKodu.Text = "Proje: [KOD]";
            // 
            // lblBarkod
            // 
            this.lblBarkod.AutoSize = true;
            this.lblBarkod.Location = new System.Drawing.Point(20, 47);
            this.lblBarkod.Name = "lblBarkod";
            this.lblBarkod.Size = new System.Drawing.Size(59, 20);
            this.lblBarkod.TabIndex = 1;
            this.lblBarkod.Text = "Barkod:";
            // 
            // lblMiktar
            // 
            this.lblMiktar.AutoSize = true;
            this.lblMiktar.Location = new System.Drawing.Point(290, 43);
            this.lblMiktar.Name = "lblMiktar";
            this.lblMiktar.Size = new System.Drawing.Size(54, 20);
            this.lblMiktar.TabIndex = 2;
            this.lblMiktar.Text = "Miktar:";
            // 
            // lblSonIslem
            // 
            this.lblSonIslem.AutoSize = true;
            this.lblSonIslem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblSonIslem.ForeColor = System.Drawing.Color.Gray;
            this.lblSonIslem.Location = new System.Drawing.Point(20, 580);
            this.lblSonIslem.Name = "lblSonIslem";
            this.lblSonIslem.Size = new System.Drawing.Size(0, 20);
            this.lblSonIslem.TabIndex = 8;
            // 
            // txtBarkod
            // 
            this.txtBarkod.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBarkod.Location = new System.Drawing.Point(84, 40);
            this.txtBarkod.Name = "txtBarkod";
            this.txtBarkod.Size = new System.Drawing.Size(200, 27);
            this.txtBarkod.TabIndex = 0;
            this.txtBarkod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarkod_KeyDown);
            // 
            // nudMiktar
            // 
            this.nudMiktar.Location = new System.Drawing.Point(350, 41);
            this.nudMiktar.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudMiktar.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMiktar.Name = "nudMiktar";
            this.nudMiktar.Size = new System.Drawing.Size(80, 27);
            this.nudMiktar.TabIndex = 3;
            this.nudMiktar.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.Location = new System.Drawing.Point(20, 90);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.dgvProjeUrunler);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.dgvKullanilanlar);
            this.splitContainer.Size = new System.Drawing.Size(960, 470);
            this.splitContainer.SplitterDistance = 470;
            this.splitContainer.TabIndex = 7;
            // 
            // dgvProjeUrunler
            // 
            this.dgvProjeUrunler.AllowUserToAddRows = false;
            this.dgvProjeUrunler.AllowUserToDeleteRows = false;
            this.dgvProjeUrunler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProjeUrunler.ColumnHeadersHeight = 28;
            this.dgvProjeUrunler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProjeUrunler.Location = new System.Drawing.Point(0, 0);
            this.dgvProjeUrunler.Name = "dgvProjeUrunler";
            this.dgvProjeUrunler.ReadOnly = true;
            this.dgvProjeUrunler.RowHeadersWidth = 51;
            this.dgvProjeUrunler.RowTemplate.Height = 24;
            this.dgvProjeUrunler.Size = new System.Drawing.Size(470, 470);
            this.dgvProjeUrunler.TabIndex = 0;
            this.dgvProjeUrunler.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProjeUrunler_CellContentClick);
            // 
            // dgvKullanilanlar
            // 
            this.dgvKullanilanlar.AllowUserToAddRows = false;
            this.dgvKullanilanlar.AllowUserToDeleteRows = false;
            this.dgvKullanilanlar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKullanilanlar.ColumnHeadersHeight = 28;
            this.dgvKullanilanlar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKullanilanlar.Location = new System.Drawing.Point(0, 0);
            this.dgvKullanilanlar.Name = "dgvKullanilanlar";
            this.dgvKullanilanlar.ReadOnly = true;
            this.dgvKullanilanlar.RowHeadersWidth = 51;
            this.dgvKullanilanlar.RowTemplate.Height = 24;
            this.dgvKullanilanlar.Size = new System.Drawing.Size(486, 470);
            this.dgvKullanilanlar.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(500, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Kullanılan Ürünler";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(20, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Montaj Ürün Listesi";
            // 
            // btnGeriAl
            // 
            this.btnGeriAl.BackColor = System.Drawing.Color.IndianRed;
            this.btnGeriAl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGeriAl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGeriAl.ForeColor = System.Drawing.Color.White;
            this.btnGeriAl.Location = new System.Drawing.Point(830, 50);
            this.btnGeriAl.Name = "btnGeriAl";
            this.btnGeriAl.Size = new System.Drawing.Size(150, 27);
            this.btnGeriAl.TabIndex = 4;
            this.btnGeriAl.Text = "Son İşlemi Geri Al";
            this.btnGeriAl.UseVisualStyleBackColor = false;
            this.btnGeriAl.Click += new System.EventHandler(this.BtnGeriAl_Click);
            // 
            // ProjeMontajDetayForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1000, 610);
            this.Controls.Add(this.lblProjeKodu);
            this.Controls.Add(this.lblBarkod);
            this.Controls.Add(this.txtBarkod);
            this.Controls.Add(this.lblMiktar);
            this.Controls.Add(this.nudMiktar);
            this.Controls.Add(this.btnGeriAl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.lblSonIslem);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "ProjeMontajDetayForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proje Montaj Detayı";
            this.Load += new System.EventHandler(this.ProjeMontajDetayForm_Load);
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
