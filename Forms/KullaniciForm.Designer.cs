namespace StokTakipOtomasyonu.Forms
{
    partial class KullaniciForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvKullanicilar = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbYeniYetki = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtYeniAdSoyad = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtYeniSifre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtYeniKullaniciAdi = new System.Windows.Forms.TextBox();
            this.lblYeniKullaniciAdi = new System.Windows.Forms.Label();
            this.btnYeniKullanici = new System.Windows.Forms.Button();
            this.btnKapat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKullanicilar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvKullanicilar
            // 
            this.dgvKullanicilar.AllowUserToAddRows = false;
            this.dgvKullanicilar.AllowUserToDeleteRows = false;
            this.dgvKullanicilar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvKullanicilar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKullanicilar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKullanicilar.Location = new System.Drawing.Point(12, 12);
            this.dgvKullanicilar.Name = "dgvKullanicilar";
            this.dgvKullanicilar.Size = new System.Drawing.Size(760, 300);
            this.dgvKullanicilar.TabIndex = 0;
            this.dgvKullanicilar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKullanicilar_CellContentClick);
            this.dgvKullanicilar.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKullanicilar_CellValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cmbYeniYetki);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtYeniAdSoyad);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtYeniSifre);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtYeniKullaniciAdi);
            this.groupBox1.Controls.Add(this.lblYeniKullaniciAdi);
            this.groupBox1.Controls.Add(this.btnYeniKullanici);
            this.groupBox1.Location = new System.Drawing.Point(12, 318);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(760, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Yeni Kullanıcı Ekle";
            // 
            // cmbYeniYetki
            // 
            this.cmbYeniYetki.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYeniYetki.FormattingEnabled = true;
            this.cmbYeniYetki.Items.AddRange(new object[] {
            "Yönetici",
            "Standart Kullanıcı"});
            this.cmbYeniYetki.Location = new System.Drawing.Point(500, 25);
            this.cmbYeniYetki.Name = "cmbYeniYetki";
            this.cmbYeniYetki.Size = new System.Drawing.Size(150, 21);
            this.cmbYeniYetki.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(450, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Yetki:";
            // 
            // txtYeniAdSoyad
            // 
            this.txtYeniAdSoyad.Location = new System.Drawing.Point(300, 25);
            this.txtYeniAdSoyad.Name = "txtYeniAdSoyad";
            this.txtYeniAdSoyad.Size = new System.Drawing.Size(140, 20);
            this.txtYeniAdSoyad.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(240, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ad Soyad:";
            // 
            // txtYeniSifre
            // 
            this.txtYeniSifre.Location = new System.Drawing.Point(150, 25);
            this.txtYeniSifre.Name = "txtYeniSifre";
            this.txtYeniSifre.Size = new System.Drawing.Size(80, 20);
            this.txtYeniSifre.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(120, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Şifre:";
            // 
            // txtYeniKullaniciAdi
            // 
            this.txtYeniKullaniciAdi.Location = new System.Drawing.Point(10, 25);
            this.txtYeniKullaniciAdi.Name = "txtYeniKullaniciAdi";
            this.txtYeniKullaniciAdi.Size = new System.Drawing.Size(100, 20);
            this.txtYeniKullaniciAdi.TabIndex = 2;
            // 
            // lblYeniKullaniciAdi
            // 
            this.lblYeniKullaniciAdi.AutoSize = true;
            this.lblYeniKullaniciAdi.Location = new System.Drawing.Point(10, 10);
            this.lblYeniKullaniciAdi.Name = "lblYeniKullaniciAdi";
            this.lblYeniKullaniciAdi.Size = new System.Drawing.Size(67, 13);
            this.lblYeniKullaniciAdi.TabIndex = 1;
            this.lblYeniKullaniciAdi.Text = "Kullanıcı Adı:";
            // 
            // btnYeniKullanici
            // 
            this.btnYeniKullanici.Location = new System.Drawing.Point(670, 25);
            this.btnYeniKullanici.Name = "btnYeniKullanici";
            this.btnYeniKullanici.Size = new System.Drawing.Size(80, 50);
            this.btnYeniKullanici.TabIndex = 0;
            this.btnYeniKullanici.Text = "Ekle";
            this.btnYeniKullanici.UseVisualStyleBackColor = true;
            this.btnYeniKullanici.Click += new System.EventHandler(this.btnYeniKullanici_Click);
            // 
            // btnKapat
            // 
            this.btnKapat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKapat.Location = new System.Drawing.Point(692, 424);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(80, 30);
            this.btnKapat.TabIndex = 2;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.UseVisualStyleBackColor = true;
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // KullaniciForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.btnKapat);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvKullanicilar);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "KullaniciForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kullanıcı Yönetimi";
            this.Load += new System.EventHandler(this.KullaniciForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKullanicilar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvKullanicilar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbYeniYetki;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtYeniAdSoyad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtYeniSifre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtYeniKullaniciAdi;
        private System.Windows.Forms.Label lblYeniKullaniciAdi;
        private System.Windows.Forms.Button btnYeniKullanici;
        private System.Windows.Forms.Button btnKapat;
    }
}
