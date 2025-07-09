namespace StokTakipOtomasyonu.Forms
{
    partial class UrunSecimForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dgvUrunler;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMiktar;
        private System.Windows.Forms.Button btnSec;
        private System.Windows.Forms.Button btnIptal;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvUrunler = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMiktar = new System.Windows.Forms.TextBox();
            this.btnSec = new System.Windows.Forms.Button();
            this.btnIptal = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUrunler)).BeginInit();
            this.SuspendLayout();

            // dgvUrunler
            this.dgvUrunler.AllowUserToAddRows = false;
            this.dgvUrunler.AllowUserToDeleteRows = false;
            this.dgvUrunler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUrunler.Location = new System.Drawing.Point(20, 20);
            this.dgvUrunler.Name = "dgvUrunler";
            this.dgvUrunler.ReadOnly = true;
            this.dgvUrunler.RowHeadersVisible = false;
            this.dgvUrunler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUrunler.Size = new System.Drawing.Size(400, 200);
            this.dgvUrunler.TabIndex = 0;

            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 240);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Miktar:";

            // txtMiktar
            this.txtMiktar.Location = new System.Drawing.Point(80, 237);
            this.txtMiktar.Name = "txtMiktar";
            this.txtMiktar.Size = new System.Drawing.Size(100, 22);
            this.txtMiktar.TabIndex = 2;
            this.txtMiktar.Text = "1";

            // btnSec
            this.btnSec.Location = new System.Drawing.Point(200, 230);
            this.btnSec.Name = "btnSec";
            this.btnSec.Size = new System.Drawing.Size(100, 30);
            this.btnSec.TabIndex = 3;
            this.btnSec.Text = "Seç";
            this.btnSec.UseVisualStyleBackColor = true;
            this.btnSec.Click += new System.EventHandler(this.btnSec_Click);

            // btnIptal
            this.btnIptal.Location = new System.Drawing.Point(320, 230);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(100, 30);
            this.btnIptal.TabIndex = 4;
            this.btnIptal.Text = "İptal";
            this.btnIptal.UseVisualStyleBackColor = true;
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);

            // UrunSecimForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 280);
            this.Controls.Add(this.btnIptal);
            this.Controls.Add(this.btnSec);
            this.Controls.Add(this.txtMiktar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvUrunler);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UrunSecimForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ürün Seçimi";
            ((System.ComponentModel.ISupportInitialize)(this.dgvUrunler)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}