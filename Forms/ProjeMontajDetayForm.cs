using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using StokTakipOtomasyonu.Helpers;

namespace StokTakipOtomasyonu.Forms
{
    public partial class ProjeMontajDetayForm : Form
    {
        private readonly int _projeId;
        private readonly int _kullaniciId;
        private readonly string _projeKodu;
        private DataTable _tumUrunler;
        private DataTable _kullanilanlar;

        public ProjeMontajDetayForm(int projeId, int kullaniciId, string projeKodu)
        {
            InitializeComponent();
            _projeId = projeId;
            _kullaniciId = kullaniciId;
            _projeKodu = projeKodu;
            lblProjeKodu.Text = $"Proje: {_projeKodu}";
        }

        private void ProjeMontajDetayForm_Load(object sender, EventArgs e)
        {
            LoadProjeUrunleri();
            LoadKullanilanUrunler();
            txtBarkod.Focus();
        }

        private void LoadProjeUrunleri()
        {
            string query = @"SELECT u.urun_id, u.urun_kodu, u.urun_adi, pu.miktar AS gerekli_miktar,
                                IFNULL((SELECT SUM(miktar) FROM proje_hareketleri WHERE proje_id = pu.proje_id AND urun_id = pu.urun_id), 0) AS kullanilan_miktar
                             FROM proje_urunleri pu
                             JOIN urunler u ON pu.urun_id = u.urun_id
                             WHERE pu.proje_id = @pid";

            _tumUrunler = DatabaseHelper.ExecuteQuery(query, new MySqlParameter("@pid", _projeId));
            _tumUrunler.Columns.Add("tamamlandi", typeof(string));

            foreach (DataRow row in _tumUrunler.Rows)
            {
                int gerekli = Convert.ToInt32(row["gerekli_miktar"]);
                int kullanilan = Convert.ToInt32(row["kullanilan_miktar"]);
                row["tamamlandi"] = gerekli <= kullanilan ? "✔" : "";
            }

            dgvProjeUrunler.DataSource = _tumUrunler;
            dgvProjeUrunler.Columns["urun_id"].Visible = false;

            foreach (DataGridViewRow gridRow in dgvProjeUrunler.Rows)
            {
                if (gridRow.Cells["tamamlandi"].Value?.ToString() == "✔")
                    gridRow.DefaultCellStyle.BackColor = Color.LightGreen;
            }
        }

        private void LoadKullanilanUrunler()
        {
            string query = @"SELECT u.urun_kodu, u.urun_adi, ph.miktar, ph.islem_tarihi
                             FROM proje_hareketleri ph
                             JOIN urunler u ON ph.urun_id = u.urun_id
                             WHERE ph.proje_id = @pid
                             ORDER BY ph.islem_tarihi DESC";

            _kullanilanlar = DatabaseHelper.ExecuteQuery(query, new MySqlParameter("@pid", _projeId));
            dgvKullanilanlar.DataSource = _kullanilanlar;
        }

        private void txtBarkod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            string barkod = txtBarkod.Text.Trim();
            int miktar = (int)nudMiktar.Value;
            if (string.IsNullOrEmpty(barkod) || miktar <= 0) return;

            string query = "SELECT urun_id FROM urunler WHERE urun_barkod = @barkod";
            object result = DatabaseHelper.ExecuteScalar(query, new MySqlParameter("@barkod", barkod));

            if (result == null)
            {
                MessageBox.Show("Barkod bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBarkod.Clear();
                return;
            }

            int urunId = Convert.ToInt32(result);
            DataRow[] match = _tumUrunler.Select($"urun_id = {urunId}");

            if (match.Length == 0)
            {
                MessageBox.Show("Bu ürün projeye ait değil.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBarkod.Clear();
                return;
            }

            var row = match[0];
            int gerekli = Convert.ToInt32(row["gerekli_miktar"]);
            int kullanilan = Convert.ToInt32(row["kullanilan_miktar"]);

            if (kullanilan + miktar > gerekli)
            {
                MessageBox.Show("Girilen miktar, gerekli miktarı aşıyor.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBarkod.Clear();
                return;
            }

            // 1. proje_hareketleri tablosuna ekle
            string insertProje = @"INSERT INTO proje_hareketleri 
        (proje_id, urun_id, miktar, kullanici_id) 
        VALUES (@pid, @uid, @miktar, @kid)";
            DatabaseHelper.ExecuteNonQuery(insertProje,
                new MySqlParameter("@pid", _projeId),
                new MySqlParameter("@uid", urunId),
                new MySqlParameter("@miktar", miktar),
                new MySqlParameter("@kid", _kullaniciId));

            // 2. urunler tablosundan stok düş
            string stokDus = @"UPDATE urunler SET miktar = miktar - @miktar WHERE urun_id = @uid";
            DatabaseHelper.ExecuteNonQuery(stokDus,
                new MySqlParameter("@miktar", miktar),
                new MySqlParameter("@uid", urunId));

            // 3. urun_hareketleri tablosuna kayıt (Stok Çıkış)
            string insertStok = @"INSERT INTO urun_hareketleri 
        (urun_id, hareket_turu, miktar, kullanici_id, islem_turu_id, proje_id) 
        VALUES (@uid, 'Cikis', @miktar, @kid, 1, @pid)";
            DatabaseHelper.ExecuteNonQuery(insertStok,
                new MySqlParameter("@uid", urunId),
                new MySqlParameter("@miktar", miktar),
                new MySqlParameter("@kid", _kullaniciId),
                new MySqlParameter("@pid", _projeId));

            txtBarkod.Clear();
            nudMiktar.Value = 1;
            LoadProjeUrunleri();
            LoadKullanilanUrunler();
        }

    }
}
