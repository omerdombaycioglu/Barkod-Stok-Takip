using MySql.Data.MySqlClient;
using StokTakipOtomasyonu.Helpers;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            this.Icon = new Icon("isp_logo2.ico");
            InitializeComponent();
            _projeId = projeId;
            _kullaniciId = kullaniciId;
            _projeKodu = projeKodu;
            lblProjeKodu.Text = $"Proje: {_projeKodu}";
            nudMiktar.Value = 1;                                                      

            // Soldaki gridin boyutunu ayarla (butona yer açılsın)
            splitContainer.Height -= 50;
        }


        private void ProjeMontajDetayForm_Load(object sender, EventArgs e)
        {
            LoadProjeUrunleri();
            LoadKullanilanUrunler();
            txtBarkod.Focus();
            dgvKullanilanlar.CellClick += DgvKullanilanlar_CellClick;
            dgvProjeUrunler.CellClick += DgvProjeUrunler_CellClick;

            // Ekle butonu
            DataGridViewButtonColumn btnUrunEkle = new DataGridViewButtonColumn
            {
                Name = "btnUrunEkle",
                HeaderText = "Projeye Ekle",
                Text = "+",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat
            };

            // Çıkar butonu
            DataGridViewButtonColumn btnUrunCikar = new DataGridViewButtonColumn
            {
                Name = "btnUrunCikar",
                HeaderText = "Projeden Çıkar",
                Text = "-",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat
            };

            // Çöp kutusu butonu (ürünü projeden tamamen kaldırır)
            DataGridViewButtonColumn btnUrunSil = new DataGridViewButtonColumn
            {
                Name = "btnUrunSil",
                HeaderText = "Ürünü Kaldır",
                Text = "🗑️",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat
            };

            dgvProjeUrunler.Columns.Insert(0, btnUrunSil); // Kolonu başa koyar

            // Kolonları ekle
            
            dgvProjeUrunler.Columns.Add(btnUrunEkle);
            dgvProjeUrunler.Columns.Add(btnUrunCikar);

            Button btnProjeyeYeniUrunEkle = new Button
            {
                Name = "btnProjeyeYeniUrunEkle",
                Text = "📦 Projeye Yeni Ürün Ekle",
                BackColor = Color.SeaGreen,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Size = new Size(220, 35),
                Location = new Point(25, this.ClientSize.Height - 50),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left
            };

            btnProjeyeYeniUrunEkle.Click += BtnProjeyeYeniUrunEkle_Click;
            this.Controls.Add(btnProjeyeYeniUrunEkle);
            splitContainer.Height -= 50;
        }



        private void LoadProjeUrunleri()
        {
            string query = @"
        SELECT 
            u.urun_id, 
            u.urun_kodu, 
            u.urun_adi, 
            pu.miktar AS gerekli_miktar,
            IFNULL((SELECT SUM(miktar) FROM proje_hareketleri 
                    WHERE proje_id = pu.proje_id AND urun_id = pu.urun_id AND aktif = 1), 0) AS kullanilan_miktar
        FROM proje_urunleri pu
        JOIN urunler u ON pu.urun_id = u.urun_id
        WHERE pu.proje_id = @pid";

            _tumUrunler = DatabaseHelper.ExecuteQuery(query, new MySqlParameter("@pid", _projeId));
            _tumUrunler.Columns.Add("tamamlandi", typeof(string));

            foreach (DataRow row in _tumUrunler.Rows)
            {
                int gerekli = Convert.ToInt32(row["gerekli_miktar"]);
                int kullanilan = Convert.ToInt32(row["kullanilan_miktar"]);
                row["tamamlandi"] = kullanilan >= gerekli ? "✔" : "";
            }

            dgvProjeUrunler.DataSource = _tumUrunler;
            dgvProjeUrunler.Columns["urun_id"].Visible = false;

            foreach (DataGridViewRow row in dgvProjeUrunler.Rows)
            {
                if (row.Cells["tamamlandi"].Value?.ToString() == "✔")
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
            }
        }
        private void DgvProjeUrunler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Hücre gerçekten bir veri hücresi mi? (satır başlığı veya kolon başlığı tıklanmışsa işlemi iptal et)
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            var row = dgvProjeUrunler.Rows[e.RowIndex];

            // Satırda urun_id veya urun_adi yoksa (örneğin boş satır, yeni satır, vs) işlemi iptal et
            if (row.Cells["urun_id"].Value == null || row.Cells["urun_adi"].Value == null)
                return;

            int urunId = Convert.ToInt32(row.Cells["urun_id"].Value);
            string urunAdi = row.Cells["urun_adi"].Value.ToString();

            // Kolonun adını alın (tıklanan kolonun ne olduğunu kontrol ediyoruz)
            string colName = dgvProjeUrunler.Columns[e.ColumnIndex].Name;

            if (colName == "btnUrunEkle")
            {
                DatabaseHelper.ExecuteNonQuery(@"
            UPDATE proje_urunleri SET miktar = miktar + 1
            WHERE proje_id = @pid AND urun_id = @uid",
                    new MySqlParameter("@pid", _projeId),
                    new MySqlParameter("@uid", urunId));

                lblSonIslem.Text = $"{urunAdi} ürününün proje için gerekli miktarı 1 artırıldı.";
                lblSonIslem.ForeColor = Color.DarkGreen;
                LoadProjeUrunleri();
            }
            else if (colName == "btnUrunCikar")
            {
                int gerekliMiktar = Convert.ToInt32(row.Cells["gerekli_miktar"].Value);

                if (gerekliMiktar <= 1)
                {
                    MessageBox.Show("Ürünün miktarı 1'den küçük olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DatabaseHelper.ExecuteNonQuery(@"
            UPDATE proje_urunleri SET miktar = miktar - 1
            WHERE proje_id = @pid AND urun_id = @uid",
                    new MySqlParameter("@pid", _projeId),
                    new MySqlParameter("@uid", urunId));

                lblSonIslem.Text = $"{urunAdi} ürününün proje için gerekli miktarı 1 azaltıldı.";
                lblSonIslem.ForeColor = Color.IndianRed;
                LoadProjeUrunleri();
            }
            else if (colName == "btnUrunSil")
            {
                var dialogResult = MessageBox.Show($"{urunAdi} ürününü projeden kaldırmak istediğinizden emin misiniz?",
                                                    "Ürünü Projeden Kaldır",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Warning);

                if (dialogResult != DialogResult.Yes) return;

                // Ürüne ait aktif hareket var mı kontrol et
                object hareketSayisi = DatabaseHelper.ExecuteScalar(@"
            SELECT COUNT(*) FROM proje_hareketleri 
            WHERE proje_id = @pid AND urun_id = @uid AND aktif = 1",
                    new MySqlParameter("@pid", _projeId),
                    new MySqlParameter("@uid", urunId));

                if (Convert.ToInt32(hareketSayisi) > 0)
                {
                    MessageBox.Show($"Bu ürüne ait aktif hareketler mevcut ({hareketSayisi} adet). Lütfen önce bu hareketleri geri alın.",
                                    "Aktif Hareketler Mevcut",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                // Ürünü projeden kaldır (aktif hareket yoksa güvenli)
                DatabaseHelper.ExecuteNonQuery(@"
            DELETE FROM proje_urunleri 
            WHERE proje_id = @pid AND urun_id = @uid",
                    new MySqlParameter("@pid", _projeId),
                    new MySqlParameter("@uid", urunId));

                lblSonIslem.Text = $"{urunAdi} ürünü projeden kaldırıldı.";
                lblSonIslem.ForeColor = Color.Red;

                LoadProjeUrunleri();
                LoadKullanilanUrunler();
            }
        }

        

        private void BtnProjeyeYeniUrunEkle_Click(object sender, EventArgs e)
        {
            using (var urunSecForm = new UrunListeleForm(true, "ProjeMontajDetayForm"))
            {
                if (urunSecForm.ShowDialog() == DialogResult.OK)
                {
                    int secilenUrunId = urunSecForm.SecilenUrunId;
                    int secilenUrunMiktar = urunSecForm.SecilenMiktar;

                    // Önce ürünün projeye daha önce eklenip eklenmediğini kontrol et
                    object varMi = DatabaseHelper.ExecuteScalar(@"
                SELECT COUNT(*) FROM proje_urunleri
                WHERE proje_id = @pid AND urun_id = @uid",
                        new MySqlParameter("@pid", _projeId),
                        new MySqlParameter("@uid", secilenUrunId));

                    if (Convert.ToInt32(varMi) > 0)
                    {
                        // Ürün varsa miktarı güncelle
                        DatabaseHelper.ExecuteNonQuery(@"
                    UPDATE proje_urunleri SET miktar = miktar + @miktar
                    WHERE proje_id = @pid AND urun_id = @uid",
                            new MySqlParameter("@pid", _projeId),
                            new MySqlParameter("@uid", secilenUrunId),
                            new MySqlParameter("@miktar", secilenUrunMiktar));
                    }
                    else
                    {
                        // Ürün yoksa yeni ekle
                        DatabaseHelper.ExecuteNonQuery(@"
                    INSERT INTO proje_urunleri (proje_id, urun_id, miktar, user_id)
                    VALUES (@pid, @uid, @miktar, @kid)",
                            new MySqlParameter("@pid", _projeId),
                            new MySqlParameter("@uid", secilenUrunId),
                            new MySqlParameter("@miktar", secilenUrunMiktar),
                            new MySqlParameter("@kid", _kullaniciId));
                    }

                    lblSonIslem.Text = $"Yeni ürün projeye eklendi veya miktarı güncellendi.";
                    lblSonIslem.ForeColor = Color.DarkGreen;

                    LoadProjeUrunleri();
                }
            }
        }






        private void LoadKullanilanUrunler()
        {
            string query = @"
        SELECT 
            ph.id AS hareket_id, 
            u.urun_id,
            u.urun_kodu, 
            u.urun_adi, 
            ph.miktar, 
            ph.islem_tarihi
        FROM proje_hareketleri ph
        JOIN urunler u ON ph.urun_id = u.urun_id
        WHERE ph.proje_id = @pid AND ph.aktif = 1
        ORDER BY ph.islem_tarihi DESC";

            _kullanilanlar = DatabaseHelper.ExecuteQuery(query, new MySqlParameter("@pid", _projeId));
            dgvKullanilanlar.DataSource = _kullanilanlar;

            // Buton kolonunu ekle (eğer daha önce eklenmediyse)
            if (!dgvKullanilanlar.Columns.Contains("btnGeriAl"))
            {
                DataGridViewButtonColumn btnGeriAl = new DataGridViewButtonColumn
                {
                    Name = "btnGeriAl",
                    HeaderText = "İşlem",
                    Text = "Geri Al",
                    UseColumnTextForButtonValue = true,
                    FlatStyle = FlatStyle.Flat
                };

                dgvKullanilanlar.Columns.Add(btnGeriAl);
            }

            // Gereksiz kolonları gizle
            dgvKullanilanlar.Columns["hareket_id"].Visible = false;
            dgvKullanilanlar.Columns["urun_id"].Visible = false;
        }

        private void DgvKullanilanlar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Yalnızca gerçek veri hücrelerine tıklandığında çalışsın
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            // Kolon ismini kontrol et
            if (dgvKullanilanlar.Columns[e.ColumnIndex].Name != "btnGeriAl")
                return;

            var row = dgvKullanilanlar.Rows[e.RowIndex];

            // Tıklanan satırda gerekli veriler var mı kontrolü
            if (row.Cells["hareket_id"].Value == null ||
                row.Cells["urun_id"].Value == null ||
                row.Cells["miktar"].Value == null ||
                row.Cells["urun_adi"].Value == null)
                return;

            int hareketId = Convert.ToInt32(row.Cells["hareket_id"].Value);
            int urunId = Convert.ToInt32(row.Cells["urun_id"].Value);
            int miktar = Convert.ToInt32(row.Cells["miktar"].Value);
            string urunAdi = row.Cells["urun_adi"].Value.ToString();

            var dialogResult = MessageBox.Show(
                $"{urunAdi} ürününden {miktar} adet işlemi geri almak istediğinizden emin misiniz?",
                "İşlem Geri Al",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dialogResult != DialogResult.Yes) return;

            // İşlemi pasif hale getir ve geri alındığı tarihi kaydet
            DatabaseHelper.ExecuteNonQuery(@"
        UPDATE proje_hareketleri 
        SET aktif = 0, geri_alinan_islem = NOW() 
        WHERE id = @hid",
                new MySqlParameter("@hid", hareketId));

            // Ürün miktarını stokta güncelle
            DatabaseHelper.ExecuteNonQuery(@"
        UPDATE urunler 
        SET miktar = miktar + @miktar 
        WHERE urun_id = @uid",
                new MySqlParameter("@miktar", miktar),
                new MySqlParameter("@uid", urunId));

            // Urun hareketlerini de loglayalım (Giriş olarak, proje geri alma işlemi)
            DatabaseHelper.ExecuteNonQuery(@"
        INSERT INTO urun_hareketleri (urun_id, hareket_turu, miktar, kullanici_id, islem_turu_id, proje_id, aciklama)
        VALUES (@uid, 'Giris', @miktar, @kid, 1, @pid, 'İşlem geri alındı')",
                new MySqlParameter("@uid", urunId),
                new MySqlParameter("@miktar", miktar),
                new MySqlParameter("@kid", _kullaniciId),
                new MySqlParameter("@pid", _projeId));

            lblSonIslem.Text = $"{miktar} adet {urunAdi} stoklara geri eklendi.";
            lblSonIslem.ForeColor = Color.Blue;

            // Listeyi güncelle
            LoadProjeUrunleri();
            LoadKullanilanUrunler();
        }





        private async void txtBarkod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            string barkod = txtBarkod.Text.Trim();
            int miktar = (int)nudMiktar.Value;
            if (string.IsNullOrEmpty(barkod) || miktar <= 0) return;

            string getUrunIdQuery = "SELECT urun_id, urun_adi FROM urunler WHERE urun_barkod = @barkod";
            var param = new MySqlParameter("@barkod", barkod);
            DataTable urunResult = DatabaseHelper.ExecuteQuery(getUrunIdQuery, param);

            if (urunResult.Rows.Count == 0)
            {
                MessageBox.Show("Barkod bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBarkod.Clear();
                txtBarkod.Focus();
                return;
            }

            int urunId = Convert.ToInt32(urunResult.Rows[0]["urun_id"]);
            string urunAdi = urunResult.Rows[0]["urun_adi"].ToString();

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
                MessageBox.Show("Girilmek istenen miktar, gerekli miktarı aşamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBarkod.Clear();
                return;
            }

            object stokObj = DatabaseHelper.ExecuteScalar("SELECT miktar FROM urunler WHERE urun_id = @id", new MySqlParameter("@id", urunId));
            int stok = Convert.ToInt32(stokObj ?? 0);

            if (stok < miktar)
            {
                MessageBox.Show($"Stokta yeterli ürün yok. Kalan stok: {stok}", "Yetersiz Stok", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBarkod.Clear();
                return;
            }

            DatabaseHelper.ExecuteNonQuery(@"INSERT INTO proje_hareketleri (proje_id, urun_id, miktar, kullanici_id) 
                                             VALUES (@pid, @uid, @miktar, @kid)",
                new MySqlParameter("@pid", _projeId),
                new MySqlParameter("@uid", urunId),
                new MySqlParameter("@miktar", miktar),
                new MySqlParameter("@kid", _kullaniciId));

            DatabaseHelper.ExecuteNonQuery(@"INSERT INTO urun_hareketleri (urun_id, hareket_turu, miktar, kullanici_id, islem_turu_id, proje_id)
                                             VALUES (@uid, 'Cikis', @miktar, @kid, 1, @pid)",
                new MySqlParameter("@uid", urunId),
                new MySqlParameter("@miktar", miktar),
                new MySqlParameter("@kid", _kullaniciId),
                new MySqlParameter("@pid", _projeId));

            DatabaseHelper.ExecuteNonQuery("UPDATE urunler SET miktar = miktar - @miktar WHERE urun_id = @id",
                new MySqlParameter("@miktar", miktar),
                new MySqlParameter("@id", urunId));

            int rowIndex = dgvProjeUrunler.Rows
                .Cast<DataGridViewRow>()
                .FirstOrDefault(r => Convert.ToInt32(r.Cells["urun_id"].Value) == urunId)?.Index ?? -1;

            if (rowIndex != -1)
            {
                var currentRow = dgvProjeUrunler.Rows[rowIndex];
                var originalColor = currentRow.DefaultCellStyle.BackColor;
                currentRow.DefaultCellStyle.BackColor = Color.LightBlue;
                await Task.Delay(1000);
                currentRow.DefaultCellStyle.BackColor = originalColor;
            }

            lblSonIslem.Text = $"Son Giriş: {urunAdi} ürününden {miktar} adet eklendi.";
            lblSonIslem.ForeColor = Color.DarkGreen;

            txtBarkod.Clear();
            nudMiktar.Value = 1;
            LoadProjeUrunleri();
            LoadKullanilanUrunler();
        }

        private async void BtnGeriAl_Click(object sender, EventArgs e)
        {
            string query = @"
        SELECT ph.id AS hareket_id, ph.urun_id, ph.miktar 
        FROM proje_hareketleri ph
        WHERE ph.proje_id = @pid AND ph.aktif = 1
        ORDER BY ph.islem_tarihi DESC 
        LIMIT 1";

            DataTable dt = DatabaseHelper.ExecuteQuery(query, new MySqlParameter("@pid", _projeId));
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Geri alınabilecek bir işlem yok.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int hareketId = Convert.ToInt32(dt.Rows[0]["hareket_id"]);
            int urunId = Convert.ToInt32(dt.Rows[0]["urun_id"]);
            int miktar = Convert.ToInt32(dt.Rows[0]["miktar"]);

            DatabaseHelper.ExecuteNonQuery(
    "UPDATE proje_hareketleri SET aktif = 0, geri_alinan_islem = NOW() WHERE id = @hid",
    new MySqlParameter("@hid", hareketId));

            DatabaseHelper.ExecuteNonQuery("UPDATE urunler SET miktar = miktar + @miktar WHERE urun_id = @uid",
                new MySqlParameter("@miktar", miktar),
                new MySqlParameter("@uid", urunId));

            string urunAdi = DatabaseHelper.ExecuteScalar(
                "SELECT urun_adi FROM urunler WHERE urun_id = @uid",
                new MySqlParameter("@uid", urunId)
            )?.ToString() ?? "[Bilinmeyen Ürün]";

            lblSonIslem.Text = $"{miktar} adet {urunAdi} stoklara geri eklendi.";
            lblSonIslem.ForeColor = Color.Blue;

            await Task.Delay(1000);
            lblSonIslem.Text = "";

            LoadProjeUrunleri();
            LoadKullanilanUrunler();
        }


        private void dgvProjeUrunler_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
    }
}