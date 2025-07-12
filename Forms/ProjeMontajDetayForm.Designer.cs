namespace StokTakipOtomasyonu.Forms
{
    partial class ProjeMontajDetayForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblProjeKodu;
        private System.Windows.Forms.Label lblBarkod;
        private System.Windows.Forms.TextBox txtBarkod;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.DataGridView dgvProjeUrunler;
        private System.Windows.Forms.DataGridView dgvKullanilanlar;

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
            this.txtBarkod = new System.Windows.Forms.TextBox();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.dgvProjeUrunler = new System.Windows.Forms.DataGridView();
            this.dgvKullanilanlar = new System.Windows.Forms.DataGridView();
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
            this.lblProjeKodu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblProjeKodu.Location = new System.Drawing.Point(20, 15);
            this.lblProjeKodu.Name = "lblProjeKodu";
            this.lblProjeKodu.Size = new System.Drawing.Size(92, 19);
            this.lblProjeKodu.TabIndex = 0;
            this.lblProjeKodu.Text = "Proje Kodu:";
            // 
            // lblBarkod
            // 
            this.lblBarkod.AutoSize = true;
            this.lblBarkod.Location = new System.Drawing.Point(20, 50);
            this.lblBarkod.Name = "lblBarkod";
            this.lblBarkod.Size = new System.Drawing.Size(94, 15);
            this.lblBarkod.TabIndex = 1;
            this.lblBarkod.Text = "Barkod Okutun:";
            // 
            // txtBarkod
            // 
            this.txtBarkod.Location = new System.Drawing.Point(120, 47);
            this.txtBarkod.Name = "txtBarkod";
            this.txtBarkod.Size = new System.Drawing.Size(250, 23);
            this.txtBarkod.TabIndex = 2;
            this.txtBarkod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarkod_KeyDown);
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.Location = new System.Drawing.Point(20, 80);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.dgvProjeUrunler);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.dgvKullanilanlar);
            this.splitContainer.Size = new System.Drawing.Size(960, 480);
            this.splitContainer.SplitterDistance = 240;
            this.splitContainer.TabIndex = 3;
            // 
            // dgvProjeUrunler
            // 
            this.dgvProjeUrunler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProjeUrunler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProjeUrunler.Location = new System.Drawing.Point(0, 0);
            this.dgvProjeUrunler.Name = "dgvProjeUrunler";
            this.dgvProjeUrunler.ReadOnly = true;
            this.dgvProjeUrunler.RowTemplate.Height = 25;
            this.dgvProjeUrunler.Size = new System.Drawing.Size(960, 240);
            // 
            // dgvKullanilanlar
            // 
            this.dgvKullanilanlar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKullanilanlar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKullanilanlar.Location = new System.Drawing.Point(0, 0);
            this.dgvKullanilanlar.Name = "dgvKullanilanlar";
            this.dgvKullanilanlar.ReadOnly = true;
            this.dgvKullanilanlar.RowTemplate.Height = 25;
            this.dgvKullanilanlar.Size = new System.Drawing.Size(960, 236);
            // 
            // ProjeMontajDetayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.txtBarkod);
            this.Controls.Add(this.lblBarkod);
            this.Controls.Add(this.lblProjeKodu);
            this.Name = "ProjeMontajDetayForm";
            this.Text = "Proje Montaj Detay";
            this.Load += new System.EventHandler(this.ProjeMontajDetayForm_Load);
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
