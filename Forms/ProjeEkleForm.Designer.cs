namespace StokTakipOtomasyonu.Forms
{
    partial class ProjeEkleForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProjeKodu;
        private System.Windows.Forms.TextBox txtProjeTanimi;
        private System.Windows.Forms.Button btnKaydet;
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProjeKodu = new System.Windows.Forms.TextBox();
            this.txtProjeTanimi = new System.Windows.Forms.TextBox();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.btnIptal = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Proje Kodu:";

            // label2
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Proje Tanımı:";

            // txtProjeKodu
            this.txtProjeKodu.Location = new System.Drawing.Point(120, 17);
            this.txtProjeKodu.MaxLength = 50;
            this.txtProjeKodu.Name = "txtProjeKodu";
            this.txtProjeKodu.Size = new System.Drawing.Size(200, 22);
            this.txtProjeKodu.TabIndex = 2;

            // txtProjeTanimi
            this.txtProjeTanimi.Location = new System.Drawing.Point(120, 57);
            this.txtProjeTanimi.MaxLength = 255;
            this.txtProjeTanimi.Name = "txtProjeTanimi";
            this.txtProjeTanimi.Size = new System.Drawing.Size(300, 22);
            this.txtProjeTanimi.TabIndex = 3;

            // btnKaydet
            this.btnKaydet.Location = new System.Drawing.Point(120, 100);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(100, 30);
            this.btnKaydet.TabIndex = 4;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);

            // btnIptal
            this.btnIptal.Location = new System.Drawing.Point(230, 100);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(100, 30);
            this.btnIptal.TabIndex = 5;
            this.btnIptal.Text = "İptal";
            this.btnIptal.UseVisualStyleBackColor = true;
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);

            // ProjeEkleForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 150);
            this.Controls.Add(this.btnIptal);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.txtProjeTanimi);
            this.Controls.Add(this.txtProjeKodu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProjeEkleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Yeni Proje Ekle";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}