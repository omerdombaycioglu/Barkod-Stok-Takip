namespace StokTakipOtomasyonu.Forms
{
    partial class ProjeMontajForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewProjeler;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dataGridViewProjeler = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProjeler)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewProjeler
            // 
            this.dataGridViewProjeler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProjeler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewProjeler.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewProjeler.Name = "dataGridViewProjeler";
            this.dataGridViewProjeler.RowTemplate.Height = 25;
            this.dataGridViewProjeler.Size = new System.Drawing.Size(1000, 600);
            this.dataGridViewProjeler.TabIndex = 0;
            this.dataGridViewProjeler.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProjeler_CellContentClick);
            // 
            // ProjeMontajForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.dataGridViewProjeler);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ProjeMontajForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proje Ürün Kontrol";
            this.Load += new System.EventHandler(this.ProjeMontajForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProjeler)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
