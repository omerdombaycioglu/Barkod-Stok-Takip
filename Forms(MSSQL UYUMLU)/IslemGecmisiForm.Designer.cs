namespace StokTakipOtomasyonu
{
    partial class IslemGecmisiForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnKapat = new System.Windows.Forms.Button();
            this.lblToplamGiris = new System.Windows.Forms.Label();
            this.lblToplamCikis = new System.Windows.Forms.Label();
            this.lblNetHareket = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(27, 25);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1013, 431);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnKapat
            // 
            this.btnKapat.Location = new System.Drawing.Point(933, 492);
            this.btnKapat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(107, 37);
            this.btnKapat.TabIndex = 1;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.UseVisualStyleBackColor = true;
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // lblToplamGiris
            // 
            this.lblToplamGiris.AutoSize = true;
            this.lblToplamGiris.Location = new System.Drawing.Point(27, 468);
            this.lblToplamGiris.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblToplamGiris.Name = "lblToplamGiris";
            this.lblToplamGiris.Size = new System.Drawing.Size(97, 16);
            this.lblToplamGiris.TabIndex = 2;
            this.lblToplamGiris.Text = "Toplam Giriş: 0";
            // 
            // lblToplamCikis
            // 
            this.lblToplamCikis.AutoSize = true;
            this.lblToplamCikis.Location = new System.Drawing.Point(27, 492);
            this.lblToplamCikis.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblToplamCikis.Name = "lblToplamCikis";
            this.lblToplamCikis.Size = new System.Drawing.Size(99, 16);
            this.lblToplamCikis.TabIndex = 3;
            this.lblToplamCikis.Text = "Toplam Çıkış: 0";
            // 
            // lblNetHareket
            // 
            this.lblNetHareket.AutoSize = true;
            this.lblNetHareket.Location = new System.Drawing.Point(27, 517);
            this.lblNetHareket.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNetHareket.Name = "lblNetHareket";
            this.lblNetHareket.Size = new System.Drawing.Size(92, 16);
            this.lblNetHareket.TabIndex = 4;
            this.lblNetHareket.Text = "Net Hareket: 0";
            // 
            // IslemGecmisiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.lblNetHareket);
            this.Controls.Add(this.lblToplamCikis);
            this.Controls.Add(this.lblToplamGiris);
            this.Controls.Add(this.btnKapat);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IslemGecmisiForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnKapat;
        private System.Windows.Forms.Label lblToplamGiris;
        private System.Windows.Forms.Label lblToplamCikis;
        private System.Windows.Forms.Label lblNetHareket;
    }
}