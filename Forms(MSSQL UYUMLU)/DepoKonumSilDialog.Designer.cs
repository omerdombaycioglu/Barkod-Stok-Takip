namespace StokTakipOtomasyonu.Forms
{
    partial class DepoKonumSilDialog
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.cmbKonumlar = new System.Windows.Forms.ComboBox();
            this.btnTamam = new System.Windows.Forms.Button();
            this.btnIptal = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Text = "Silinecek Konum:";
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Size = new System.Drawing.Size(120, 30);
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F);
            // 
            // cmbKonumlar
            // 
            this.cmbKonumlar.Location = new System.Drawing.Point(20, 55);
            this.cmbKonumlar.Size = new System.Drawing.Size(200, 28);
            this.cmbKonumlar.Font = new System.Drawing.Font("Segoe UI", 11F);
            // 
            // btnTamam
            // 
            this.btnTamam.Text = "Sil";
            this.btnTamam.Location = new System.Drawing.Point(40, 100);
            this.btnTamam.Size = new System.Drawing.Size(80, 32);
            this.btnTamam.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnTamam.DialogResult = System.Windows.Forms.DialogResult.OK;
            // 
            // btnIptal
            // 
            this.btnIptal.Text = "İptal";
            this.btnIptal.Location = new System.Drawing.Point(140, 100);
            this.btnIptal.Size = new System.Drawing.Size(80, 32);
            this.btnIptal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnIptal.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            // 
            // DepoKonumSilDialog
            // 
            this.AcceptButton = this.btnTamam;
            this.CancelButton = this.btnIptal;
            this.ClientSize = new System.Drawing.Size(250, 150); // BÜYÜTÜLDÜ
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbKonumlar);
            this.Controls.Add(this.btnTamam);
            this.Controls.Add(this.btnIptal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mevcut Depo Konumunu Sil";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        public System.Windows.Forms.ComboBox cmbKonumlar;
        private System.Windows.Forms.Button btnTamam;
        private System.Windows.Forms.Button btnIptal;
        private System.Windows.Forms.Label label1;
    }
}
