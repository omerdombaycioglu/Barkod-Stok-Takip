using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;


namespace StokTakipOtomasyonu.Forms
{
    public partial class MainForm : Form
    {
        private int _kullaniciId;
        private int _yetki;

        public MainForm(int kullaniciId, int yetki)
        {

            InitializeComponent();
            // Logo burada ayarlanıyor
            this.Icon = new Icon("isp_logo2.ico");

            _kullaniciId = kullaniciId;
            _yetki = yetki;
            YetkiKontrol();
            this.FormClosed += MainForm_FormClosed;
            this.Load += MainForm_Load;
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
                btnKullaniciIslemleri.Enabled = false;
                groupBox7.Enabled = false; // Yönetici işlemlerini gizle
            }
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Tüm butonları kontrol et
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is GroupBox group)
                {
                    foreach (Control item in group.Controls)
                    {
                        if (item is Button btn)
                        {
                            ButonStilGuncelle(btn);
                            btn.EnabledChanged += (s, ev) => ButonStilGuncelle(btn);
                        }
                    }
                }
                else if (ctrl is Button btn)
                {
                    ButonStilGuncelle(btn);
                    btn.EnabledChanged += (s, ev) => ButonStilGuncelle(btn);
                }
            }
        }

        private void ButonStilGuncelle(Button btn)
        {
            if (!btn.Enabled)
            {
                if (!btn.Text.StartsWith("🔒 ")) // Kilit zaten yoksa ekle
                    btn.Text = "🔒 " + btn.Text;

                btn.BackColor = Color.FromArgb(200, 200, 200);
                btn.ForeColor = Color.FromArgb(100, 100, 100);
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 1;
                btn.FlatAppearance.BorderColor = Color.DarkGray;
                btn.Cursor = Cursors.No;
            }
            else
            {
                if (btn.Text.StartsWith("🔒 "))
                    btn.Text = btn.Text.Substring(2); // Kilidi kaldır

                btn.BackColor = Color.FromArgb(128, 128, 128);
                btn.ForeColor = Color.White;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatStyle = FlatStyle.Flat;
                btn.Cursor = Cursors.Hand;
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
            new UrunBilgiForm(_kullaniciId).ShowDialog();
        }

        private void btnKullaniciIslemleri_Click(object sender, EventArgs e)
        {
            new KullaniciForm().ShowDialog();
        }
    }
}