using System;
using System.Drawing;
using System.Windows.Forms;

namespace StokTakipOtomasyonu.Forms
{
    public partial class MainForm : Form
    {
        private int _kullaniciId;
        private int _yetki;

        public MainForm(int kullaniciId, int yetki)
        {
            InitializeComponent();
            _kullaniciId = kullaniciId;
            _yetki = yetki;
            YetkiKontrol();
            this.FormClosed += MainForm_FormClosed;
            ApplyModernTheme();
        }

        private void ApplyModernTheme()
        {
            // Form arka plan rengi
            this.BackColor = Color.FromArgb(240, 240, 240);

            // Başlık çubuğu
            this.Text = "ISP Group Stok Takip - Ana Menü";
            this.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 162);

            // Tüm groupbox'lar için stil
            foreach (Control control in this.Controls)
            {
                if (control is GroupBox groupBox)
                {
                    groupBox.BackColor = Color.White;
                    groupBox.ForeColor = Color.FromArgb(64, 64, 64);
                    groupBox.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                }
            }
        }

        private void YetkiKontrol()
        {
            if (_yetki == 2) // Standart kullanıcı
            {
                btnDepoDuzenle.Enabled = true;
                btnProjeEkle.Enabled = false;
                btnProjeMontaj.Enabled = false;
                btnKullaniciIslemleri.Enabled = false;
                groupBox7.Enabled = false; // Yönetici işlemlerini gizle
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnManuelUrunGirisi_Click(object sender, EventArgs e)
        {
            new ManuelUrunGirisiForm(_kullaniciId).ShowDialog();
        }

        private void btnManuelUrunCikisi_Click(object sender, EventArgs e)
        {
            new ManuelUrunCikisiForm(_kullaniciId).ShowDialog();
        }

        private void btnUrunListele_Click(object sender, EventArgs e)
        {
            new UrunListeleForm().ShowDialog();
        }

        private void btnExcelIslem_Click(object sender, EventArgs e)
        {
            new ExcelIslemForm(_kullaniciId).ShowDialog();
        }

        private void btnDepoDuzenle_Click(object sender, EventArgs e)
        {
            new DepoDuzenleForm().ShowDialog();
        }

        private void btnSonIslemler_Click(object sender, EventArgs e)
        {
            new SonIslemlerForm().ShowDialog();
        }

        private void btnProjeEkle_Click(object sender, EventArgs e)
        {
            new ProjeEkleForm(_kullaniciId).ShowDialog();
        }

        private void btnProjeMontaj_Click(object sender, EventArgs e)
        {
            new ProjeMontajForm(_kullaniciId).ShowDialog();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUrunBilgiGuncelle_Click(object sender, EventArgs e)
        {
            new UrunBilgiForm().ShowDialog();
        }

        private void btnKullaniciIslemleri_Click(object sender, EventArgs e)
        {
            new KullaniciForm().ShowDialog();
        }
    }
}