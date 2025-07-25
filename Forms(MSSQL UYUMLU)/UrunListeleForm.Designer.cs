namespace StokTakipOtomasyonu
{
    partial class UrunListeleForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblBaslik = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnYenile = new System.Windows.Forms.Button();
            this.btnKapat = new System.Windows.Forms.Button();
            this.txtArama = new System.Windows.Forms.TextBox();
            this.lblArama = new System.Windows.Forms.Label();
            this.cmbProjeler = new System.Windows.Forms.ComboBox();
            this.lblProje = new System.Windows.Forms.Label();
            this.btnSec = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.panelTop.Controls.Add(this.lblBaslik);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(800, 60);
            this.panelTop.TabIndex = 0;
            // 
            // lblBaslik
            // 
            this.lblBaslik.AutoSize = true;
            this.lblBaslik.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.ForeColor = System.Drawing.Color.DimGray;
            this.lblBaslik.Location = new System.Drawing.Point(20, 15);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(148, 32);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "Ürün Listesi";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(20, 110);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(760, 350);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnYenile
            // 
            this.btnYenile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnYenile.FlatAppearance.BorderSize = 0;
            this.btnYenile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(133)))));
            this.btnYenile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(133)))));
            this.btnYenile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYenile.ForeColor = System.Drawing.Color.White;
            this.btnYenile.Location = new System.Drawing.Point(600, 470);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(80, 30);
            this.btnYenile.TabIndex = 2;
            this.btnYenile.Text = "Yenile";
            this.btnYenile.UseVisualStyleBackColor = false;
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // btnKapat
            // 
            this.btnKapat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnKapat.FlatAppearance.BorderSize = 0;
            this.btnKapat.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(133)))));
            this.btnKapat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(133)))));
            this.btnKapat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKapat.ForeColor = System.Drawing.Color.White;
            this.btnKapat.Location = new System.Drawing.Point(700, 470);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(80, 30);
            this.btnKapat.TabIndex = 3;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.UseVisualStyleBackColor = false;
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // txtArama
            // 
            this.txtArama.Location = new System.Drawing.Point(70, 70);
            this.txtArama.Name = "txtArama";
            this.txtArama.Size = new System.Drawing.Size(200, 27);
            this.txtArama.TabIndex = 4;
            this.txtArama.TextChanged += new System.EventHandler(this.txtArama_TextChanged);
            // 
            // lblArama
            // 
            this.lblArama.AutoSize = true;
            this.lblArama.Location = new System.Drawing.Point(20, 73);
            this.lblArama.Name = "lblArama";
            this.lblArama.Size = new System.Drawing.Size(56, 20);
            this.lblArama.TabIndex = 5;
            this.lblArama.Text = "Arama:";
            // 
            // cmbProjeler
            // 
            this.cmbProjeler.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProjeler.Location = new System.Drawing.Point(360, 70);
            this.cmbProjeler.Name = "cmbProjeler";
            this.cmbProjeler.Size = new System.Drawing.Size(250, 28);
            this.cmbProjeler.TabIndex = 6;
            this.cmbProjeler.SelectedIndexChanged += new System.EventHandler(this.cmbProjeler_SelectedIndexChanged);
            // 
            // lblProje
            // 
            this.lblProje.AutoSize = true;
            this.lblProje.Location = new System.Drawing.Point(310, 73);
            this.lblProje.Name = "lblProje";
            this.lblProje.Size = new System.Drawing.Size(46, 20);
            this.lblProje.TabIndex = 7;
            this.lblProje.Text = "Proje:";
            // 
            // btnSec
            // 
            this.btnSec.Location = new System.Drawing.Point(713, 70);
            this.btnSec.Name = "btnSec";
            this.btnSec.Size = new System.Drawing.Size(144, 34);
            this.btnSec.TabIndex = 8;
            this.btnSec.Text = "Projeye ürünü ekle";
            this.btnSec.UseVisualStyleBackColor = true;
            this.btnSec.Click += new System.EventHandler(this.btnSec_Click);
            // 
            // UrunListeleForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(800, 520);
            this.Controls.Add(this.btnSec);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnYenile);
            this.Controls.Add(this.btnKapat);
            this.Controls.Add(this.txtArama);
            this.Controls.Add(this.lblArama);
            this.Controls.Add(this.cmbProjeler);
            this.Controls.Add(this.lblProje);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UrunListeleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ürün Listesi";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnYenile;
        private System.Windows.Forms.Button btnKapat;
        private System.Windows.Forms.TextBox txtArama;
        private System.Windows.Forms.Label lblArama;
        private System.Windows.Forms.ComboBox cmbProjeler;
        private System.Windows.Forms.Label lblProje;
        private System.Windows.Forms.Button btnSec;
    }
}
