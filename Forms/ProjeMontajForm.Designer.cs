namespace StokTakipOtomasyonu.Forms
{
    partial class ProjeMontajForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.ComboBox cmbProjeler;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblProjeTanimi;
        private System.Windows.Forms.DataGridView dgvProjeUrunleri;
        private System.Windows.Forms.Button btnUrunEkle;
        private System.Windows.Forms.Button btnUrunSil;
        private System.Windows.Forms.Button btnKapat;

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
            this.cmbProjeler = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblProjeTanimi = new System.Windows.Forms.Label();
            this.dgvProjeUrunleri = new System.Windows.Forms.DataGridView();
            this.btnUrunEkle = new System.Windows.Forms.Button();
            this.btnUrunSil = new System.Windows.Forms.Button();
            this.btnKapat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProjeUrunleri)).BeginInit();
            this.SuspendLayout();

            // cmbProjeler
            this.cmbProjeler.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProjeler.FormattingEnabled = true;
            this.cmbProjeler.Location = new System.Drawing.Point(120, 20);
            this.cmbProjeler.Name = "cmbProjeler";
            this.cmbProjeler.Size = new System.Drawing.Size(200, 24);
            this.cmbProjeler.TabIndex = 0;
            this.cmbProjeler.SelectedIndexChanged += new System.EventHandler(this.cmbProjeler_SelectedIndexChanged);

            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Proje Seçiniz:";

            // lblProjeTanimi
            this.lblProjeTanimi.AutoSize = true;
            this.lblProjeTanimi.Location = new System.Drawing.Point(20, 60);
            this.lblProjeTanimi.Name = "lblProjeTanimi";
            this.lblProjeTanimi.Size = new System.Drawing.Size(0, 16);
            this.lblProjeTanimi.TabIndex = 2;

            // dgvProjeUrunleri
            this.dgvProjeUrunleri.AllowUserToAddRows = false;
            this.dgvProjeUrunleri.AllowUserToDeleteRows = false;
            this.dgvProjeUrunleri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProjeUrunleri.Location = new System.Drawing.Point(20, 90);
            this.dgvProjeUrunleri.Name = "dgvProjeUrunleri";
            this.dgvProjeUrunleri.ReadOnly = true;
            this.dgvProjeUrunleri.RowHeadersVisible = false;
            this.dgvProjeUrunleri.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProjeUrunleri.Size = new System.Drawing.Size(500, 250);
            this.dgvProjeUrunleri.TabIndex = 3;

            // btnUrunEkle
            this.btnUrunEkle.Location = new System.Drawing.Point(20, 350);
            this.btnUrunEkle.Name = "btnUrunEkle";
            this.btnUrunEkle.Size = new System.Drawing.Size(120, 30);
            this.btnUrunEkle.TabIndex = 4;
            this.btnUrunEkle.Text = "Ürün Ekle";
            this.btnUrunEkle.UseVisualStyleBackColor = true;
            this.btnUrunEkle.Click += new System.EventHandler(this.btnUrunEkle_Click);

            // btnUrunSil
            this.btnUrunSil.Location = new System.Drawing.Point(150, 350);
            this.btnUrunSil.Name = "btnUrunSil";
            this.btnUrunSil.Size = new System.Drawing.Size(120, 30);
            this.btnUrunSil.TabIndex = 5;
            this.btnUrunSil.Text = "Ürün Sil";
            this.btnUrunSil.UseVisualStyleBackColor = true;
            this.btnUrunSil.Click += new System.EventHandler(this.btnUrunSil_Click);

            // btnKapat
            this.btnKapat.Location = new System.Drawing.Point(400, 350);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(120, 30);
            this.btnKapat.TabIndex = 6;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.UseVisualStyleBackColor = true;
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);

            // ProjeMontajForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 400);
            this.Controls.Add(this.btnKapat);
            this.Controls.Add(this.btnUrunSil);
            this.Controls.Add(this.btnUrunEkle);
            this.Controls.Add(this.dgvProjeUrunleri);
            this.Controls.Add(this.lblProjeTanimi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbProjeler);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProjeMontajForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Proje Montaj / Ürün Kontrol";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProjeUrunleri)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}