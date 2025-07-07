namespace StokTakipOtomasyonu.Forms
{
    partial class DepoDuzenleForm
    {
        private System.ComponentModel.IContainer components = null;

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
            this.lblBarkodArama = new System.Windows.Forms.Label();
            this.txtBarkodArama = new System.Windows.Forms.TextBox();
            this.dgvDepoKonumlari = new System.Windows.Forms.DataGridView();
            this.lblUrunBilgi = new System.Windows.Forms.Label();
            this.lblToplamMiktar = new System.Windows.Forms.Label();
            this.lblDepodakiToplam = new System.Windows.Forms.Label();
            this.lblUyari = new System.Windows.Forms.Label();
            this.btnYeniKonumEkle = new System.Windows.Forms.Button();
            this.cmbKatKonum = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMiktar = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepoKonumlari)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBarkodArama
            // 
            this.lblBarkodArama.AutoSize = true;
            this.lblBarkodArama.Location = new System.Drawing.Point(12, 15);
            this.lblBarkodArama.Name = "lblBarkodArama";
            this.lblBarkodArama.Size = new System.Drawing.Size(96, 16);
            this.lblBarkodArama.TabIndex = 0;
            this.lblBarkodArama.Text = "Barkod Ara:";
            // 
            // txtBarkodArama
            // 
            this.txtBarkodArama.Location = new System.Drawing.Point(114, 12);
            this.txtBarkodArama.Name = "txtBarkodArama";
            this.txtBarkodArama.Size = new System.Drawing.Size(200, 22);
            this.txtBarkodArama.TabIndex = 1;
            this.txtBarkodArama.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarkodArama_KeyDown);
            // 
            // dgvDepoKonumlari
            // 
            this.dgvDepoKonumlari.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDepoKonumlari.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDepoKonumlari.Location = new System.Drawing.Point(12, 140);
            this.dgvDepoKonumlari.Name = "dgvDepoKonumlari";
            this.dgvDepoKonumlari.RowHeadersWidth = 51;
            this.dgvDepoKonumlari.RowTemplate.Height = 24;
            this.dgvDepoKonumlari.Size = new System.Drawing.Size(760, 310);
            this.dgvDepoKonumlari.TabIndex = 2;
            this.dgvDepoKonumlari.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDepoKonumlari_CellContentClick);
            // 
            // lblUrunBilgi
            // 
            this.lblUrunBilgi.AutoSize = true;
            this.lblUrunBilgi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblUrunBilgi.Location = new System.Drawing.Point(12, 45);
            this.lblUrunBilgi.Name = "lblUrunBilgi";
            this.lblUrunBilgi.Size = new System.Drawing.Size(0, 18);
            this.lblUrunBilgi.TabIndex = 3;
            // 
            // lblToplamMiktar
            // 
            this.lblToplamMiktar.AutoSize = true;
            this.lblToplamMiktar.Location = new System.Drawing.Point(12, 70);
            this.lblToplamMiktar.Name = "lblToplamMiktar";
            this.lblToplamMiktar.Size = new System.Drawing.Size(0, 16);
            this.lblToplamMiktar.TabIndex = 4;
            // 
            // lblDepodakiToplam
            // 
            this.lblDepodakiToplam.AutoSize = true;
            this.lblDepodakiToplam.Location = new System.Drawing.Point(200, 70);
            this.lblDepodakiToplam.Name = "lblDepodakiToplam";
            this.lblDepodakiToplam.Size = new System.Drawing.Size(0, 16);
            this.lblDepodakiToplam.TabIndex = 5;
            // 
            // lblUyari
            // 
            this.lblUyari.AutoSize = true;
            this.lblUyari.ForeColor = System.Drawing.Color.Red;
            this.lblUyari.Location = new System.Drawing.Point(400, 70);
            this.lblUyari.Name = "lblUyari";
            this.lblUyari.Size = new System.Drawing.Size(0, 16);
            this.lblUyari.TabIndex = 6;
            // 
            // btnYeniKonumEkle
            // 
            this.btnYeniKonumEkle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYeniKonumEkle.Location = new System.Drawing.Point(650, 100);
            this.btnYeniKonumEkle.Name = "btnYeniKonumEkle";
            this.btnYeniKonumEkle.Size = new System.Drawing.Size(120, 30);
            this.btnYeniKonumEkle.TabIndex = 7;
            this.btnYeniKonumEkle.Text = "Konum Ekle";
            this.btnYeniKonumEkle.UseVisualStyleBackColor = true;
            this.btnYeniKonumEkle.Click += new System.EventHandler(this.btnYeniKonumEkle_Click);
            // 
            // cmbKatKonum
            // 
            this.cmbKatKonum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKatKonum.FormattingEnabled = true;
            this.cmbKatKonum.Location = new System.Drawing.Point(114, 100);
            this.cmbKatKonum.Name = "cmbKatKonum";
            this.cmbKatKonum.Size = new System.Drawing.Size(200, 24);
            this.cmbKatKonum.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Depo Konumu:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(320, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Miktar:";
            // 
            // txtMiktar
            // 
            this.txtMiktar.Location = new System.Drawing.Point(382, 100);
            this.txtMiktar.Name = "txtMiktar";
            this.txtMiktar.Size = new System.Drawing.Size(100, 22);
            this.txtMiktar.TabIndex = 11;
            // 
            // DepoDuzenleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.txtMiktar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbKatKonum);
            this.Controls.Add(this.btnYeniKonumEkle);
            this.Controls.Add(this.lblUyari);
            this.Controls.Add(this.lblDepodakiToplam);
            this.Controls.Add(this.lblToplamMiktar);
            this.Controls.Add(this.lblUrunBilgi);
            this.Controls.Add(this.dgvDepoKonumlari);
            this.Controls.Add(this.txtBarkodArama);
            this.Controls.Add(this.lblBarkodArama);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "DepoDuzenleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Depo Konum Düzenleme";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepoKonumlari)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblBarkodArama;
        private System.Windows.Forms.TextBox txtBarkodArama;
        private System.Windows.Forms.DataGridView dgvDepoKonumlari;
        private System.Windows.Forms.Label lblUrunBilgi;
        private System.Windows.Forms.Label lblToplamMiktar;
        private System.Windows.Forms.Label lblDepodakiToplam;
        private System.Windows.Forms.Label lblUyari;
        private System.Windows.Forms.Button btnYeniKonumEkle;
        private System.Windows.Forms.ComboBox cmbKatKonum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMiktar;
    }
}