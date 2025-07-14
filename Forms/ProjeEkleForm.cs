// ProjeEkleForm.cs
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace StokTakipOtomasyonu.Forms
{
    public partial class ProjeEkleForm : Form
    {
        private readonly string _connectionString = "server=localhost;user=root;database=stok_takip_otomasyonu;password=;";
        private int _kullaniciId;
        private int _projeId;
        private DataTable _excelData;

        public ProjeEkleForm(int kullaniciId)
        {
            this.Icon = new Icon("isp_logo2.ico");
            InitializeComponent();
            _kullaniciId = kullaniciId;
            btnKaydet.Visible = false;
            btnTamEkran.Visible = false;

            // Yeni buton
            Button btnExcelCikart = new Button
            {
                Text = "Yetersiz Ürünleri Excel'e Çıkart",
                Location = new Point(btnTamEkran.Right + 10, btnTamEkran.Top),
                AutoSize = true
            };
            btnExcelCikart.Click += BtnExcelCikart_Click;
            this.Controls.Add(btnExcelCikart);
        }

        private void btnYukle_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel Dosyaları|*.xlsx";
            if (ofd.ShowDialog() != DialogResult.OK) return;

            DataTable table = new DataTable();
            table.Columns.Add("Tip No");
            table.Columns.Add("Sipariş No");
            table.Columns.Add("Açıklama");
            table.Columns.Add("Ürün No");
            table.Columns.Add("Marka");
            table.Columns.Add("Miktar", typeof(int));
            table.Columns.Add("Stoktaki Miktar", typeof(int));
            table.Columns.Add("Gereken Minimum Miktar", typeof(int));
            table.Columns.Add("Stok Durumu");

            using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read))
            {
                IWorkbook workbook = new XSSFWorkbook(fs);
                ISheet sheet = workbook.GetSheetAt(0);

                using (MySqlConnection conn = new MySqlConnection(_connectionString))
                {
                    conn.Open();
                    for (int i = 6; i <= sheet.LastRowNum; i++)
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null || row.Cells.TrueForAll(c => string.IsNullOrWhiteSpace(c?.ToString()))) continue;

                        string tipNo = row.GetCell(0)?.ToString();
                        string siparisNo = row.GetCell(1)?.ToString();
                        string aciklama = row.GetCell(2)?.ToString();
                        string urunNo = row.GetCell(3)?.ToString();
                        string marka = row.GetCell(4)?.ToString();

                        int miktar = 0;
                        try
                        {
                            var cell = row.GetCell(5);
                            if (cell != null && cell.CellType == CellType.Numeric)
                                miktar = (int)cell.NumericCellValue;
                            else if (cell != null && cell.CellType == CellType.String)
                                int.TryParse(cell.StringCellValue, out miktar);
                        }
                        catch { miktar = 0; }

                        int stokMiktar = 0;
                        string stokDurum = "Yetersiz";

                        string checkQuery = "SELECT urun_id, miktar FROM urunler WHERE urun_kodu = @kod";
                        MySqlCommand cmd = new MySqlCommand(checkQuery, conn);
                        cmd.Parameters.AddWithValue("@kod", siparisNo);

                        int urunId = -1;
                        bool urunVar = false;

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                urunId = reader.GetInt32("urun_id");
                                stokMiktar = reader.GetInt32("miktar");
                                stokDurum = stokMiktar >= miktar ? "Yeterli" : "Yetersiz";
                                urunVar = true;
                            }
                        }

                        if (!urunVar)
                        {
                            string insertUrun = "INSERT INTO urunler (urun_kodu, urun_adi, urun_marka, miktar) VALUES (@kod, @adi, @marka, 0); SELECT LAST_INSERT_ID();";
                            MySqlCommand insertCmd = new MySqlCommand(insertUrun, conn);
                            insertCmd.Parameters.AddWithValue("@kod", siparisNo);
                            insertCmd.Parameters.AddWithValue("@adi", aciklama);
                            insertCmd.Parameters.AddWithValue("@marka", marka);
                            urunId = Convert.ToInt32(insertCmd.ExecuteScalar());
                        }

                        int gerekenMiktar = Math.Max(0, miktar - stokMiktar);

                        table.Rows.Add(tipNo, siparisNo, aciklama, urunNo, marka, miktar, stokMiktar, gerekenMiktar, stokDurum);
                    }
                }
            }

            _excelData = table;
            dgvUrunler.DataSource = table;

            foreach (DataGridViewRow row in dgvUrunler.Rows)
            {
                if (row.Cells["Stok Durumu"].Value?.ToString() == "Yeterli")
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                else
                    row.DefaultCellStyle.BackColor = Color.LightCoral;
            }

            btnKaydet.Visible = true;
            btnTamEkran.Visible = true;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (_excelData == null || _excelData.Rows.Count == 0)
            {
                MessageBox.Show("Önce Excel dosyasını yüklemelisiniz.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtProjeKodu.Text) || string.IsNullOrWhiteSpace(txtProjeTanimi.Text))
            {
                MessageBox.Show("Proje bilgilerini girin.");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string insertProje = "INSERT INTO projeler (proje_kodu, proje_tanimi, olusturan_id) VALUES (@kod, @tanimi, @olusturan); SELECT LAST_INSERT_ID();";
                MySqlCommand cmd = new MySqlCommand(insertProje, conn);
                cmd.Parameters.AddWithValue("@kod", txtProjeKodu.Text.Trim());
                cmd.Parameters.AddWithValue("@tanimi", txtProjeTanimi.Text.Trim());
                cmd.Parameters.AddWithValue("@olusturan", _kullaniciId);
                _projeId = Convert.ToInt32(cmd.ExecuteScalar());

                foreach (DataRow row in _excelData.Rows)
                {
                    string siparisNo = row["Sipariş No"].ToString();
                    int miktar = Convert.ToInt32(row["Miktar"]);

                    string getIdQuery = "SELECT urun_id FROM urunler WHERE urun_kodu = @kod";
                    MySqlCommand getIdCmd = new MySqlCommand(getIdQuery, conn);
                    getIdCmd.Parameters.AddWithValue("@kod", siparisNo);
                    int urunId = Convert.ToInt32(getIdCmd.ExecuteScalar());

                    string insertProjeUrun = "INSERT INTO proje_urunleri (proje_id, urun_id, miktar, user_id) VALUES (@proje, @urun, @miktar, @kullanici)";
                    MySqlCommand insertCmd = new MySqlCommand(insertProjeUrun, conn);
                    insertCmd.Parameters.AddWithValue("@proje", _projeId);
                    insertCmd.Parameters.AddWithValue("@urun", urunId);
                    insertCmd.Parameters.AddWithValue("@miktar", miktar);
                    insertCmd.Parameters.AddWithValue("@kullanici", _kullaniciId);
                    insertCmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Proje ve ürünler başarıyla kaydedildi.");
        }

        private void btnTamEkran_Click(object sender, EventArgs e)
        {
            Form tamEkranForm = new Form
            {
                WindowState = FormWindowState.Maximized,
                Text = "Tam Ekran Ürün Listesi"
            };

            DataGridView dgvTamEkran = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                DataSource = dgvUrunler.DataSource
            };

            tamEkranForm.Controls.Add(dgvTamEkran);
            tamEkranForm.Show();

            // Renkleri tekrar uygula
            foreach (DataGridViewRow row in dgvTamEkran.Rows)
            {
                string durum = row.Cells["Stok Durumu"]?.Value?.ToString();
                if (durum == "Yeterli")
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                else if (durum == "Yetersiz")
                    row.DefaultCellStyle.BackColor = Color.LightCoral;
            }
        }

        private void BtnExcelCikart_Click(object sender, EventArgs e)
        {
            if (_excelData == null || _excelData.Rows.Count == 0)
            {
                MessageBox.Show("Önce Excel dosyasını yüklemelisiniz.");
                return;
            }

            string projeKodu = txtProjeKodu.Text.Trim();
            if (string.IsNullOrWhiteSpace(projeKodu))
            {
                MessageBox.Show("Proje kodu boş olamaz.");
                return;
            }

            var yetersizUrunler = _excelData.Select("`Stok Durumu` = 'Yetersiz'");
            if (yetersizUrunler.Length == 0)
            {
                MessageBox.Show("Tüm ürünlerin stoğu yeterli.");
                return;
            }

            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("Stok Dışı Ürünler");

            IRow header = sheet.CreateRow(0);
            header.CreateCell(0).SetCellValue("Sipariş No");
            header.CreateCell(1).SetCellValue("Açıklama");
            header.CreateCell(2).SetCellValue("Marka");
            header.CreateCell(3).SetCellValue("Projede Gerekli Miktar");
            header.CreateCell(4).SetCellValue("Stoktaki Miktar");
            header.CreateCell(5).SetCellValue("Gereken Minimum Miktar");
            header.CreateCell(6).SetCellValue("Stok Durumu");

            int rowIndex = 1;
            foreach (var row in yetersizUrunler)
            {
                IRow excelRow = sheet.CreateRow(rowIndex++);
                excelRow.CreateCell(0).SetCellValue(row["Sipariş No"].ToString());
                excelRow.CreateCell(1).SetCellValue(row["Açıklama"].ToString());
                excelRow.CreateCell(2).SetCellValue(row["Marka"].ToString());
                excelRow.CreateCell(3).SetCellValue(Convert.ToInt32(row["Miktar"]));
                excelRow.CreateCell(4).SetCellValue(Convert.ToInt32(row["Stoktaki Miktar"]));
                excelRow.CreateCell(5).SetCellValue(Convert.ToInt32(row["Gereken Minimum Miktar"]));
                excelRow.CreateCell(6).SetCellValue(row["Stok Durumu"].ToString());
            }

            string fileName = $"{projeKodu}_stokdisiurunler.xlsx";
            SaveFileDialog sfd = new SaveFileDialog
            {
                FileName = fileName,
                Filter = "Excel Dosyası|*.xlsx"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (var fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write))
                {
                    workbook.Write(fs);
                }

                MessageBox.Show("Yetersiz ürünler başarıyla Excel dosyasına aktarıldı.");
            }
        }
    }
}
