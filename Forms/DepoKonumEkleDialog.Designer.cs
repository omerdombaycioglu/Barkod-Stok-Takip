namespace StokTakipOtomasyonu.Forms
{
    partial class DepoKonumEkleDialog
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHarf = new System.Windows.Forms.TextBox();
            this.txtNumara = new System.Windows.Forms.TextBox();
            this.btnTamam = new System.Windows.Forms.Button();
            this.btnIptal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Text = "Harf:";
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Size = new System.Drawing.Size(60, 30);
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F);
            // 
            // label2
            // 
            this.label2.Text = "Numara:";
            this.label2.Location = new System.Drawing.Point(20, 65);
            this.label2.Size = new System.Drawing.Size(80, 30);
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11F);
            // 
            // txtHarf
            // 
            this.txtHarf.Location = new System.Drawing.Point(110, 20);
            this.txtHarf.Size = new System.Drawing.Size(130, 28);
            this.txtHarf.Font = new System.Drawing.Font("Segoe UI", 11F);
            // 
            // txtNumara
            // 
            this.txtNumara.Location = new System.Drawing.Point(110, 65);
            this.txtNumara.Size = new System.Drawing.Size(130, 28);
            this.txtNumara.Font = new System.Drawing.Font("Segoe UI", 11F);
            // 
            // btnTamam
            // 
            this.btnTamam.Text = "Tamam";
            this.btnTamam.Location = new System.Drawing.Point(40, 110);
            this.btnTamam.Size = new System.Drawing.Size(90, 32);
            this.btnTamam.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnTamam.DialogResult = System.Windows.Forms.DialogResult.OK;
            // 
            // btnIptal
            // 
            this.btnIptal.Text = "İptal";
            this.btnIptal.Location = new System.Drawing.Point(140, 110);
            this.btnIptal.Size = new System.Drawing.Size(90, 32);
            this.btnIptal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnIptal.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            // 
            // DepoKonumEkleDialog
            // 
            this.AcceptButton = this.btnTamam;
            this.CancelButton = this.btnIptal;
            this.ClientSize = new System.Drawing.Size(270, 160); // BÜYÜTÜLDÜ
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtHarf);
            this.Controls.Add(this.txtNumara);
            this.Controls.Add(this.btnTamam);
            this.Controls.Add(this.btnIptal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Yeni Depo Konumu Oluştur";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtHarf;
        public System.Windows.Forms.TextBox txtNumara;
        private System.Windows.Forms.Button btnTamam;
        private System.Windows.Forms.Button btnIptal;
    }
}
