namespace StokTakipOtomasyonu.Forms
{
    partial class ProjeMontajForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewProjeler;
        private System.Windows.Forms.Label lblBosProjeMesaji;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dataGridViewProjeler = new System.Windows.Forms.DataGridView();
            this.lblBosProjeMesaji = new System.Windows.Forms.Label();
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
            // lblBosProjeMesaji
            // 
            this.lblBosProjeMesaji.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBosProjeMesaji.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblBosProjeMesaji.ForeColor = System.Drawing.Color.Gray;
            this.lblBosProjeMesaji.Location = new System.Drawing.Point(0, 0);
            this.lblBosProjeMesaji.Name = "lblBosProjeMesaji";
            this.lblBosProjeMesaji.Size = new System.Drawing.Size(1000, 600);
            this.lblBosProjeMesaji.TabIndex = 1;
            this.lblBosProjeMesaji.Text = "Aktif proje bulunamadı.";
            this.lblBosProjeMesaji.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBosProjeMesaji.Visible = false;
            // 
            // ProjeMontajForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.lblBosProjeMesaji);
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
