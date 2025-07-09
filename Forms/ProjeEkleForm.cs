using MySql.Data.MySqlClient;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using StokTakipOtomasyonu.Helpers;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace StokTakipOtomasyonu.Forms
{
    public partial class ProjeEkleForm : Form
    {
        private int _userId;
        private DataTable _excelData;
        private int _projeId;
        private bool _excelYuklendi = false;

        public ProjeEkleForm(int userId)
        {
            InitializeComponent();
            _userId = userId;
            _excelData = new DataTable();
            InitializeDataTable();
            ConfigureDataGridView();
        }

        private void InitializeDataTable()
        {
            _excelData.Columns.Add("tip_no");
            _excelData.Columns.Add("siparis_no");
            _excelData.Columns.Add("aciklama");
            _excelData.Columns.Add("urun_kodu");
            _excelData.Columns.Add("marka");
            _excelData.Columns.Add("miktar", typeof(int));
            _excelData.Columns.Add("stok_miktari", typeof(int));
            _excelData.Columns.Add("kritik_seviye", typeof(int));
            _excelData.Columns.Add("stok_durumu");
            _excelData.Columns.Add("is_new", typeof(bool));
        }

        private void ConfigureDataGridView()
        {
            dataGridView1.DataSource = _excelData;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 122, 183);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.ScrollBars = ScrollBars.Both;
        }

        private void btnDevam_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProjeKodu.Text) || string.IsNullOrWhiteSpace(txtProjeAdi.Text))
            {
                MessageBox.Show("Proje kodu ve proje adı alanları boş bırakılamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            groupBox1.Enabled = false;
            groupBox2.Visible = true;
            btnExcelYukle.Focus();
        }

        private void btnExcelYukle_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Dosyaları (*.xlsx)|*.xlsx|Excel 97-2003 (*.xls)|*.xls|Tüm Dosyalar (*.*)|*.*";
                openFileDialog.FilterIndex = 1;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _excelData.Rows.Clear();
                        LoadExcelData(openFileDialog.FileName);
                        CheckStockAvailability();
                        dataGridView1.DataSource = _excelData;
                        ApplyRowColoring();
                        _excelYuklendi = true;
                        btnKaydet.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Excel dosyası okunurken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void LoadExcelData(string filePath)
        {
            IWorkbook workbook;
            using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                workbook = Path.GetExtension(filePath).ToLower() == ".xlsx" ?
                    (IWorkbook)new XSSFWorkbook(file) :
                    new HSSFWorkbook(file);
            }

            ISheet sheet = workbook.GetSheetAt(0);
            int startRow = 6; // 7. satır (0-based index)

            for (int rowIndex = startRow; rowIndex <= sheet.LastRowNum; rowIndex++)
            {
                IRow row = sheet.GetRow(rowIndex);
                if (row == null || row.GetCell(0) == null || string.IsNullOrWhiteSpace(row.GetCell(0).ToString()))
                    continue;

                DataRow dataRow = _excelData.NewRow();

                dataRow["tip_no"] = row.GetCell(0)?.ToString()?.Trim();
                dataRow["siparis_no"] = row.GetCell(1)?.ToString()?.Trim();
                dataRow["aciklama"] = row.GetCell(2)?.ToString()?.Trim();
                dataRow["urun_kodu"] = row.GetCell(3)?.ToString()?.Trim();
                dataRow["marka"] = row.GetCell(4)?.ToString()?.Trim();

                if (row.GetCell(5) != null)
                {
                    if (row.GetCell(5).CellType == CellType.Numeric)
                        dataRow["miktar"] = (int)row.GetCell(5).NumericCellValue;
                    else if (int.TryParse(row.GetCell(5).ToString()?.Trim(), out int miktar))
                        dataRow["miktar"] = miktar;
                }

                dataRow["is_new"] = false;
                _excelData.Rows.Add(dataRow);
            }
        }

        private void CheckStockAvailability()
        {
            foreach (DataRow row in _excelData.Rows)
            {
                string urunKodu = row["urun_kodu"].ToString();
                int miktar = Convert.ToInt32(row["miktar"]);

                string query = "SELECT miktar, kritik_seviye FROM urunler WHERE urun_kodu = @urun_kodu";
                var parameters = new[] { new MySqlParameter("@urun_kodu", urunKodu) };

                using (var dt = DatabaseHelper.ExecuteQuery(query, parameters))
                {
                    if (dt.Rows.Count > 0)
                    {
                        row["stok_miktari"] = Convert.ToInt32(dt.Rows[0]["miktar"]);
                        row["kritik_seviye"] = dt.Rows[0]["kritik_seviye"] != DBNull.Value ?
                            Convert.ToInt32(dt.Rows[0]["kritik_seviye"]) : 0;

                        int stokMiktari = Convert.ToInt32(row["stok_miktari"]);
                        row["stok_durumu"] = stokMiktari >= miktar ? "Stokta var" : "Stokta yok";
                    }
                    else
                    {
                        row["stok_miktari"] = 0;
                        row["kritik_seviye"] = 0;
                        row["stok_durumu"] = "Ürün bulunamadı";
                        row["is_new"] = true;
                    }
                }
            }
        }

        private void ApplyRowColoring()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["stok_durumu"].Value == null) continue;

                string durum = row.Cells["stok_durumu"].Value.ToString();
                bool isNew = Convert.ToBoolean(row.Cells["is_new"].Value);

                if (isNew)
                {
                    row.DefaultCellStyle.BackColor = Color.LightBlue;
                    row.Cells["stok_durumu"].Value = "Yeni ürün - kaydedilecek";
                }
                else if (durum == "Stokta var")
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                }
                else if (durum == "Stokta yok")
                {
                    row.DefaultCellStyle.BackColor = Color.LightCoral;
                }

                if (!isNew && row.Cells["kritik_seviye"].Value != null &&
                    row.Cells["stok_miktari"].Value != null &&
                    row.Cells["kritik_seviye"].Value != DBNull.Value)
                {
                    int stokMiktari = Convert.ToInt32(row.Cells["stok_miktari"].Value);
                    int kritikSeviye = Convert.ToInt32(row.Cells["kritik_seviye"].Value);

                    if (stokMiktari < kritikSeviye)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                        row.Cells["stok_durumu"].Value = "Kritik seviyenin altında";
                    }
                }
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (!_excelYuklendi)
            {
                MessageBox.Show("Önce Excel dosyası yüklemelisiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Projeyi kaydet
                            string query = "INSERT INTO projeler (proje_kodu, proje_tanimi) VALUES (@proje_kodu, @proje_tanimi); SELECT LAST_INSERT_ID();";
                            var parameters = new[]
                            {
                                new MySqlParameter("@proje_kodu", txtProjeKodu.Text),
                                new MySqlParameter("@proje_tanimi", txtProjeAdi.Text)
                            };

                            _projeId = Convert.ToInt32(DatabaseHelper.ExecuteScalar(query, transaction, parameters));

                            // Ürünleri işle
                            foreach (DataRow row in _excelData.Rows)
                            {
                                string urunKodu = row["urun_kodu"].ToString();
                                int miktar = Convert.ToInt32(row["miktar"]);
                                bool isNew = Convert.ToBoolean(row["is_new"]);

                                int urunId;
                                if (isNew)
                                {
                                    // Yeni ürünü ekle
                                    query = @"INSERT INTO urunler (urun_kodu, urun_adi, aciklama, urun_marka, miktar) 
                                              VALUES (@urun_kodu, @urun_adi, @aciklama, @marka, 0); 
                                              SELECT LAST_INSERT_ID();";
                                    parameters = new[]
                                    {
                                        new MySqlParameter("@urun_kodu", urunKodu),
                                        new MySqlParameter("@urun_adi", row["aciklama"].ToString()),
                                        new MySqlParameter("@aciklama", row["aciklama"].ToString()),
                                        new MySqlParameter("@marka", row["marka"].ToString())
                                    };

                                    urunId = Convert.ToInt32(DatabaseHelper.ExecuteScalar(query, transaction, parameters));
                                }
                                else
                                {
                                    // Var olan ürünün ID'sini al
                                    query = "SELECT urun_id FROM urunler WHERE urun_kodu = @urun_kodu";
                                    parameters = new[] { new MySqlParameter("@urun_kodu", urunKodu) };
                                    urunId = Convert.ToInt32(DatabaseHelper.ExecuteScalar(query, transaction, parameters));
                                }

                                // Proje-ürün ilişkisini kaydet
                                query = "INSERT INTO proje_urunleri (proje_id, urun_id, miktar, user_id) VALUES (@proje_id, @urun_id, @miktar, @user_id)";
                                parameters = new[]
                                {
                                    new MySqlParameter("@proje_id", _projeId),
                                    new MySqlParameter("@urun_id", urunId),
                                    new MySqlParameter("@miktar", miktar),
                                    new MySqlParameter("@user_id", _userId)
                                };

                                DatabaseHelper.ExecuteNonQuery(query, transaction, parameters);
                            }

                            transaction.Commit();
                            MessageBox.Show("Proje ve ürünler başarıyla kaydedildi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show($"Kayıt sırasında hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bağlantı hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ApplyRowColoring();
        }
    }
}