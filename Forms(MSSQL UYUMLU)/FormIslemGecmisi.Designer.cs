namespace StokTakipOtomasyonu.Forms
{
    partial class FormIslemGecmisi
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvIslemler;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvIslemler = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIslemler)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvIslemler
            // 
            this.dgvIslemler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvIslemler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvIslemler.Location = new System.Drawing.Point(0, 0);
            this.dgvIslemler.Name = "dgvIslemler";
            this.dgvIslemler.Size = new System.Drawing.Size(1000, 600); // Ekranı dolduracak boyut
            this.dgvIslemler.TabIndex = 0;
            this.dgvIslemler.ReadOnly = true;
            this.dgvIslemler.AllowUserToAddRows = false;
            this.dgvIslemler.AllowUserToDeleteRows = false;
            this.dgvIslemler.RowHeadersVisible = false;
            // 
            // FormIslemGecmisi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.dgvIslemler);
            this.Name = "FormIslemGecmisi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "İşlem Geçmişi";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            ((System.ComponentModel.ISupportInitialize)(this.dgvIslemler)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
