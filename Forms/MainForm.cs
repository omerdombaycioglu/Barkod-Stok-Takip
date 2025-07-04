using System;
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
        }

        private void YetkiKontrol()
        {
            if (_yetki == 2) // Standart kullanıcı
            {
                // Örnek: btnKullaniciYonetimi.Enabled = false;
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

        private void btnBarkodUrunGirisi_Click(object sender, EventArgs e)
        {
            new BarkodUrunGirisiForm(_kullaniciId).ShowDialog();
        }

        private void btnManuelUrunCikisi_Click(object sender, EventArgs e)
        {
            new ManuelUrunCikisiForm(_kullaniciId).ShowDialog();
        }

        private void btnBarkodUrunCikisi_Click(object sender, EventArgs e)
        {
            new BarkodUrunCikisiForm(_kullaniciId).ShowDialog();
        }

        private void btnUrunListele_Click(object sender, EventArgs e)
        {
            new UrunListeleForm().ShowDialog();
        }

        private void btnExcelIslem_Click(object sender, EventArgs e)
        {
            new ExcelIslemForm(_kullaniciId).ShowDialog();
        }

        private void btnUrunAra_Click(object sender, EventArgs e)
        {
            new UrunAramaForm().ShowDialog();
        }

        private void btnIslemGecmisi_Click(object sender, EventArgs e)
        {
            new IslemGecmisiForm().ShowDialog();
        }

        private void btnEnvanterKontrol_Click(object sender, EventArgs e)
        {
            new EnvanterKontrolForm().ShowDialog();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}