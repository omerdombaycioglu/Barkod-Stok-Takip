using MySql.Data.MySqlClient;
using StokTakipOtomasyonu.Helpers;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace StokTakipOtomasyonu.Forms
{
    public partial class ProjeMontajForm : Form
    {
        private int _userId;
        private int _currentProjeId;
        private string _currentProjeKodu;

        public ProjeMontajForm(int userId)
        {
            InitializeComponent();
            _userId = userId;
            ConfigureDataGridViews();
        }

        private void ConfigureDataGridViews()
        {
            // Projeler DataGridView ayarları
            dataGridViewProjeler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewProjeler.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dataGridViewProjeler.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewProjeler.EnableHeadersVisualStyles = false;
            dataGridViewProjeler.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 122, 183);
            dataGridViewProjeler.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewProjeler.RowHeadersVisible = false;
            dataGridViewProjeler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Ürünler DataGridView ayarları
            dataGridViewUrunler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewUrunler.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dataGridViewUrunler.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewUrunler.EnableHeadersVisualStyles = false;
            dataGridViewUrunler.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 122, 183);
            dataGridViewUrunler.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewUrunler.RowHeadersVisible = false;
        }

        private void ProjeMontajForm_Load(object sender, EventArgs e)
        {
            LoadProjects();
        }

        private void LoadProjects()
        {
            try
            {
                string query = "SELECT proje_id, proje_kodu, proje_tanimi FROM projeler WHERE aktif = 1 ORDER BY proje_kodu";
                DataTable dt = DatabaseHelper.ExecuteQuery(query);

                dataGridViewProjeler.DataSource = dt;
                dataGridViewProjeler.Columns["proje_id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Projeler yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewProjeler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                _currentProjeId = Convert.ToInt32(dataGridViewProjeler.Rows[e.RowIndex].Cells["proje_id"].Value);
                _currentProjeKodu = dataGridViewProjeler.Rows[e.RowIndex].Cells["proje_kodu"].Value.ToString();

                if (senderGrid.Columns[e.ColumnIndex].Name == "btnUrunListesi")
                {
                    LoadProjectProducts(_currentProjeId);
                }
                else if (senderGrid.Columns[e.ColumnIndex].Name == "btnIslemGecmisi")
                {
                    ShowProjectTransactionHistory(_currentProjeId, _currentProjeKodu);
                }
                else if (senderGrid.Columns[e.ColumnIndex].Name == "btnProjeSil")
                {
                    DeleteProject(_currentProjeId);
                }
            }
        }

        private void DeleteProject(int projeId)
        {
            try
            {
                var result = MessageBox.Show("Projeyi silmek istediğinize emin misiniz? Bu işlem geri alınamaz!",
                    "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // Önce proje hareketlerini sil
                    string deleteTransactionsQuery = "DELETE FROM proje_hareketleri WHERE proje_id = @proje_id";
                    var transactionParams = new[] { new MySqlParameter("@proje_id", projeId) };
                    DatabaseHelper.ExecuteNonQuery(deleteTransactionsQuery, transactionParams);

                    // Sonra proje ürünlerini sil
                    string deleteProductsQuery = "DELETE FROM proje_urunleri WHERE proje_id = @proje_id";
                    var productParams = new[] { new MySqlParameter("@proje_id", projeId) };
                    DatabaseHelper.ExecuteNonQuery(deleteProductsQuery, productParams);

                    // Sonra projeyi sil (aktif=0 yaparak)
                    string deleteProjectQuery = "UPDATE projeler SET aktif = 0 WHERE proje_id = @proje_id";
                    var projectParams = new[] { new MySqlParameter("@proje_id", projeId) };
                    DatabaseHelper.ExecuteNonQuery(deleteProjectQuery, projectParams);

                    MessageBox.Show("Proje ve ilişkili tüm kayıtlar başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadProjects();
                    dataGridViewUrunler.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Proje silinirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowProjectTransactionHistory(int projeId, string projeKodu)
        {
            try
            {
                string query = @"
                SELECT 
                    u.urun_kodu,
                    u.urun_adi,
                    ph.miktar,
                    k.kullanici_adi,
                    ph.islem_tarihi
                FROM 
                    proje_hareketleri ph
                    JOIN urunler u ON ph.urun_id = u.urun_id
                    JOIN kullanicilar k ON ph.kullanici_id = k.kullanici_id
                WHERE 
                    ph.proje_id = @proje_id
                ORDER BY 
                    ph.islem_tarihi DESC";

                var parameters = new[] { new MySqlParameter("@proje_id", projeId) };
                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Bu proje için henüz bir işlem geçmişi bulunmamaktadır.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string message = $"Proje: {projeKodu}\n\n";
                foreach (DataRow row in dt.Rows)
                {
                    message += $"[{row["islem_tarihi"]}] {row["kullanici_adi"]} - {row["urun_adi"]} ({row["urun_kodu"]}) x{row["miktar"]}\n";
                }

                MessageBox.Show(message, "Proje İşlem Geçmişi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"İşlem geçmişi yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProjectProducts(int projeId)
        {
            try
            {
                string query = @"
                SELECT 
                    pu.urun_id,
                    u.urun_kodu,
                    u.urun_adi,
                    u.miktar AS stok_miktari,
                    pu.miktar AS gerekli_miktar,
                    IFNULL((
                        SELECT SUM(ph.miktar) 
                        FROM proje_hareketleri ph 
                        WHERE ph.urun_id = pu.urun_id 
                        AND ph.proje_id = pu.proje_id
                    ), 0) AS kullanilan_miktar,
                    (pu.miktar - IFNULL((
                        SELECT SUM(ph.miktar) 
                        FROM proje_hareketleri ph 
                        WHERE ph.urun_id = pu.urun_id 
                        AND ph.proje_id = pu.proje_id
                    ), 0)) AS kalan_miktar,
                    0 AS alinacak_miktar
                FROM 
                    proje_urunleri pu
                    JOIN urunler u ON pu.urun_id = u.urun_id
                WHERE 
                    pu.proje_id = @proje_id";

                var parameters = new[] { new MySqlParameter("@proje_id", projeId) };
                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

                dataGridViewUrunler.DataSource = dt;
                ApplyProductRowColoring();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ürün listesi yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyProductRowColoring()
        {
            foreach (DataGridViewRow row in dataGridViewUrunler.Rows)
            {
                int kalanMiktar = Convert.ToInt32(row.Cells["kalan_miktar"].Value);

                if (kalanMiktar <= 0)
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                    row.Cells["alinacak_miktar"].ReadOnly = true;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.Cells["alinacak_miktar"].ReadOnly = false;
                }
            }
        }

        private void dataGridViewUrunler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewUrunler.Rows[e.RowIndex];
                int urunId = Convert.ToInt32(row.Cells["urun_id"].Value);
                string urunKodu = row.Cells["urun_kodu"].Value.ToString();
                string urunAdi = row.Cells["urun_adi"].Value.ToString();

                if (senderGrid.Columns[e.ColumnIndex].Name == "btnUrunCikis")
                {
                    HandleProductOutput(row, urunId, urunKodu, urunAdi);
                }
                else if (senderGrid.Columns[e.ColumnIndex].Name == "btnGeriAl")
                {
                    UndoLastTransaction(urunId, urunKodu, urunAdi);
                }
            }
        }

        private void HandleProductOutput(DataGridViewRow row, int urunId, string urunKodu, string urunAdi)
        {
            if (!int.TryParse(row.Cells["alinacak_miktar"].Value?.ToString(), out int alinacakMiktar) || alinacakMiktar <= 0)
            {
                MessageBox.Show("Geçerli bir miktar giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int kalanMiktar = Convert.ToInt32(row.Cells["kalan_miktar"].Value);
            if (alinacakMiktar > kalanMiktar)
            {
                MessageBox.Show("Alınacak miktar kalan miktardan fazla olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Proje hareketini kaydet
                string insertQuery = @"
                INSERT INTO proje_hareketleri 
                    (proje_id, urun_id, miktar, kullanici_id) 
                VALUES 
                    (@proje_id, @urun_id, @miktar, @kullanici_id)";

                var insertParams = new[]
                {
                    new MySqlParameter("@proje_id", _currentProjeId),
                    new MySqlParameter("@urun_id", urunId),
                    new MySqlParameter("@miktar", alinacakMiktar),
                    new MySqlParameter("@kullanici_id", _userId)
                };
                DatabaseHelper.ExecuteNonQuery(insertQuery, insertParams);

                MessageBox.Show($"{urunAdi} ({urunKodu}) ürününden {alinacakMiktar} adet proje çıkışı kaydedildi.",
                              "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadProjectProducts(_currentProjeId);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kayıt sırasında hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UndoLastTransaction(int urunId, string urunKodu, string urunAdi)
        {
            try
            {
                // Son hareketi bul
                string findQuery = @"
                SELECT id, miktar 
                FROM proje_hareketleri 
                WHERE proje_id = @proje_id AND urun_id = @urun_id 
                ORDER BY islem_tarihi DESC 
                LIMIT 1";

                var findParams = new[]
                {
                    new MySqlParameter("@proje_id", _currentProjeId),
                    new MySqlParameter("@urun_id", urunId)
                };

                DataTable dt = DatabaseHelper.ExecuteQuery(findQuery, findParams);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Bu ürün için geri alınabilecek işlem bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int hareketId = Convert.ToInt32(dt.Rows[0]["id"]);
                int miktar = Convert.ToInt32(dt.Rows[0]["miktar"]);

                var result = MessageBox.Show($"{urunAdi} ({urunKodu}) ürününden {miktar} adet çıkış işlemini geri almak istediğinize emin misiniz?",
                    "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Hareketi sil
                    string deleteQuery = "DELETE FROM proje_hareketleri WHERE id = @id";
                    var deleteParams = new[] { new MySqlParameter("@id", hareketId) };
                    DatabaseHelper.ExecuteNonQuery(deleteQuery, deleteParams);

                    MessageBox.Show("İşlem başarıyla geri alındı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadProjectProducts(_currentProjeId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Geri alma işlemi sırasında hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewUrunler_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewUrunler.Columns[e.ColumnIndex].Name == "alinacak_miktar" && e.Value != null)
            {
                // Alınacak miktar hücrelerini özelleştir
                e.CellStyle.BackColor = Color.LightCyan;
                e.CellStyle.Font = new Font(dataGridViewUrunler.Font, FontStyle.Bold);
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
    }
}