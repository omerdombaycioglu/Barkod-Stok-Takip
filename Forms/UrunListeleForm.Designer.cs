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

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();

            // panelTop
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(210, 210, 210);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Size = new System.Drawing.Size(800, 60);
            this.panelTop.Controls.Add(this.lblBaslik);

            // lblBaslik
            this.lblBaslik.AutoSize = true;
            this.lblBaslik.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.ForeColor = System.Drawing.Color.DimGray;
            this.lblBaslik.Location = new System.Drawing.Point(20, 15);
            this.lblBaslik.Text = "Ürün Listesi";

            // dataGridView1
            this.dataGridView1.Location = new System.Drawing.Point(20, 110);
            this.dataGridView1.Size = new System.Drawing.Size(760, 350);
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);

            // btnYenile
            this.btnYenile.Text = "Yenile";
            this.btnYenile.Location = new System.Drawing.Point(600, 470);
            this.btnYenile.Size = new System.Drawing.Size(80, 30);
            this.btnYenile.BackColor = System.Drawing.Color.FromArgb(128, 128, 128);
            this.btnYenile.ForeColor = System.Drawing.Color.White;
            this.btnYenile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYenile.FlatAppearance.BorderSize = 0;
            this.btnYenile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 153, 133);
            this.btnYenile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(0, 153, 133);
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);

            // btnKapat
            this.btnKapat.Text = "Kapat";
            this.btnKapat.Location = new System.Drawing.Point(700, 470);
            this.btnKapat.Size = new System.Drawing.Size(80, 30);
            this.btnKapat.BackColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.btnKapat.ForeColor = System.Drawing.Color.White;
            this.btnKapat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKapat.FlatAppearance.BorderSize = 0;
            this.btnKapat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 153, 133);
            this.btnKapat.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(0, 153, 133);
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);

            // txtArama
            this.txtArama.Location = new System.Drawing.Point(70, 70);
            this.txtArama.Size = new System.Drawing.Size(200, 22);
            this.txtArama.TextChanged += new System.EventHandler(this.txtArama_TextChanged);

            // lblArama
            this.lblArama.Location = new System.Drawing.Point(20, 73);
            this.lblArama.AutoSize = true;
            this.lblArama.Text = "Arama:";

            // cmbProjeler
            this.cmbProjeler.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProjeler.Location = new System.Drawing.Point(360, 70);
            this.cmbProjeler.Size = new System.Drawing.Size(250, 22);
            this.cmbProjeler.SelectedIndexChanged += new System.EventHandler(this.cmbProjeler_SelectedIndexChanged);

            // lblProje
            this.lblProje.Location = new System.Drawing.Point(310, 73);
            this.lblProje.AutoSize = true;
            this.lblProje.Text = "Proje:";

            // UrunListeleForm
            this.ClientSize = new System.Drawing.Size(800, 520);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnYenile);
            this.Controls.Add(this.btnKapat);
            this.Controls.Add(this.txtArama);
            this.Controls.Add(this.lblArama);
            this.Controls.Add(this.cmbProjeler);
            this.Controls.Add(this.lblProje);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UrunListeleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ürün Listesi";

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
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
    }
}
