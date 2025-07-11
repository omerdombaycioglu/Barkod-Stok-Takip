using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using ExcelDataReader;
using System.Drawing;

namespace StokTakipOtomasyonu.Forms
{
    public partial class ExcelIslemForm : Form
    {
        private MySqlConnection connection;
        private string connectionString = "server=localhost;database=stok_takip_otomasyonu;uid=root;pwd=;";
        private int kullaniciId;
        private DataTable excelData;

        public ExcelIslemForm(int kullaniciId)
        {
            InitializeComponent();
            this.kullaniciId = kullaniciId;
            connection = new MySqlConnection(connectionString);
            cmbIslemTuru.SelectedIndex = 0;
        }

        private void btnDosyaSec_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Dosyaları|*.xls;*.xlsx|Tüm Dosyalar|*.*";
                openFileDialog.Title = "Excel Dosyası Seç";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtDosyaYolu.Text = openFileDialog.FileName;
                    ExcelOku(openFileDialog.FileName);
                }
            }
        }

        private void ExcelOku(string filePath)
        {
            try
            {
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

                using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                        {
                            ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                            {
                                UseHeaderRow = true
                            }
                        });

                        if (result.Tables.Count > 0)
                        {
                            excelData = result.Tables[0];

                            // Excel'den gelen verileri işle
                            DataTable processedData = new DataTable();
                            processedData.Columns.Add("Barkod");
                            processedData.Columns.Add("Ürün Adı");
                            processedData.Columns.Add("Ürün Kodu");
                            processedData.Columns.Add("Marka");
                            processedData.Columns.Add("Miktar");
                            processedData.Columns.Add("Stoktaki Miktar");
                            processedData.Columns.Add("Durum");

                            foreach (DataRow row in excelData.Rows)
                            {
                                string urunAdi = row["aciklama"].ToString();
                                string urunKodu = row["siparis_no"].ToString();
                                string marka = row["marka"].ToString();
                                string miktarStr = row["miktar"].ToString();

                                if (int.TryParse(miktarStr, out int miktar))
                                {
                                    // Veritabanında bu ürünü ara
                                    int stokMiktari = 0;
                                    string durum = "Yeni Ürün";
                                    string barkod = "";

                                    string query = "SELECT urun_id, urun_barkod, miktar FROM urunler WHERE urun_kodu = @urunKodu";
                                    MySqlCommand cmd = new MySqlCommand(query, connection);
                                    cmd.Parameters.AddWithValue("@urunKodu", urunKodu);

                                    if (connection.State != ConnectionState.Open)
                                        connection.Open();

                                    using (MySqlDataReader dr = cmd.ExecuteReader())
                                    {
                                        if (dr.Read())
                                        {
                                            barkod = dr["urun_barkod"].ToString();
                                            stokMiktari = Convert.ToInt32(dr["miktar"]);
                                            durum = stokMiktari >= miktar ? "Stokta Var" : "Stok Yetersiz";
                                        }
                                    }

                                    processedData.Rows.Add(barkod, urunAdi, urunKodu, marka, miktar, stokMiktari, durum);
                                }
                            }

                            dataGridView1.DataSource = processedData;
                            dataGridView1.Columns["Stoktaki Miktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dataGridView1.Columns["Miktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                            // Hücre renklendirme
                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                string durum = row.Cells["Durum"].Value.ToString();
                                if (durum == "Stokta Var")
                                {
                                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                                }
                                else if (durum == "Stok Yetersiz")
                                {
                                    row.DefaultCellStyle.BackColor = Color.LightCoral;
                                }
                                else // Yeni Ürün
                                {
                                    row.DefaultCellStyle.BackColor = Color.LightBlue;
                                }
                            }

                            btnKaydet.Enabled = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excel okuma hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource == null)
            {
                MessageBox.Show("Önce excel dosyasını yükleyin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string hareketTuru = cmbIslemTuru.SelectedItem.ToString() == "Giriş" ? "Giris" : "Cikis";
            int basarili = 0, hatali = 0;

            try
            {
                connection.Open();

                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        DataTable dt = (DataTable)dataGridView1.DataSource;

                        foreach (DataRow row in dt.Rows)
                        {
                            try
                            {
                                string urunAdi = row["Ürün Adı"].ToString();
                                string urunKodu = row["Ürün Kodu"].ToString();
                                string marka = row["Marka"].ToString();
                                int miktar = Convert.ToInt32(row["Miktar"]);
                                string barkod = row["Barkod"].ToString();
                                string durum = row["Durum"].ToString();

                                // Ürün ID'sini bul veya yeni ürün oluştur
                                int urunId;

                                if (durum == "Yeni Ürün")
                                {
                                    // Yeni ürün ekle
                                    string insertQuery = @"INSERT INTO urunler 
                                                        (urun_adi, urun_kodu, urun_marka, miktar, urun_barkod) 
                                                        VALUES 
                                                        (@urunAdi, @urunKodu, @marka, 0, @barkod)";
                                    MySqlCommand insertCmd = new MySqlCommand(insertQuery, connection, transaction);
                                    insertCmd.Parameters.AddWithValue("@urunAdi", urunAdi);
                                    insertCmd.Parameters.AddWithValue("@urunKodu", urunKodu);
                                    insertCmd.Parameters.AddWithValue("@marka", marka);
                                    insertCmd.Parameters.AddWithValue("@barkod", barkod);
                                    insertCmd.ExecuteNonQuery();

                                    urunId = (int)insertCmd.LastInsertedId;
                                }
                                else
                                {
                                    // Var olan ürünü bul
                                    string urunQuery = "SELECT urun_id FROM urunler WHERE urun_kodu = @urunKodu";
                                    MySqlCommand urunCmd = new MySqlCommand(urunQuery, connection, transaction);
                                    urunCmd.Parameters.AddWithValue("@urunKodu", urunKodu);
                                    urunId = Convert.ToInt32(urunCmd.ExecuteScalar());
                                }

                                // Stok güncelleme
                                string updateQuery = hareketTuru == "Giris" ?
                                    "UPDATE urunler SET miktar = miktar + @miktar WHERE urun_id = @urunId" :
                                    "UPDATE urunler SET miktar = miktar - @miktar WHERE urun_id = @urunId";

                                MySqlCommand updateCmd = new MySqlCommand(updateQuery, connection, transaction);
                                updateCmd.Parameters.AddWithValue("@miktar", miktar);
                                updateCmd.Parameters.AddWithValue("@urunId", urunId);
                                updateCmd.ExecuteNonQuery();

                                // Hareket kaydı ekleme
                                string hareketQuery = @"INSERT INTO urun_hareketleri 
                                                    (urun_id, hareket_turu, miktar, kullanici_id, aciklama, islem_turu_id) 
                                                    VALUES 
                                                    (@urunId, @hareketTuru, @miktar, @kullaniciId, @aciklama, 0)";
                                MySqlCommand hareketCmd = new MySqlCommand(hareketQuery, connection, transaction);
                                hareketCmd.Parameters.AddWithValue("@urunId", urunId);
                                hareketCmd.Parameters.AddWithValue("@hareketTuru", hareketTuru);
                                hareketCmd.Parameters.AddWithValue("@miktar", miktar);
                                hareketCmd.Parameters.AddWithValue("@kullaniciId", kullaniciId);
                                hareketCmd.Parameters.AddWithValue("@aciklama", "Excel ile toplu işlem");
                                hareketCmd.ExecuteNonQuery();

                                basarili++;
                            }
                            catch (Exception ex)
                            {
                                hatali++;
                                // Hata detayını loglayabilirsiniz
                                Console.WriteLine("Hata: " + ex.Message);
                            }
                        }

                        transaction.Commit();
                        MessageBox.Show($"İşlem tamamlandı!\nBaşarılı: {basarili}\nHatalı: {hatali}", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bağlantı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}