using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using ExcelDataReader;

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
                            dataGridView1.DataSource = excelData;
                            btnKaydet.Enabled = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excel okuma hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (excelData == null || excelData.Rows.Count == 0)
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
                        foreach (DataRow row in excelData.Rows)
                        {
                            try
                            {
                                string barkod = row["Barkod"].ToString();
                                int miktar = Convert.ToInt32(row["Miktar"]);
                                string aciklama = row["Açıklama"].ToString();

                                // Ürün ID'sini bul
                                string urunQuery = "SELECT urun_id FROM urunler WHERE urun_barkod = @barkod";
                                MySqlCommand urunCmd = new MySqlCommand(urunQuery, connection, transaction);
                                urunCmd.Parameters.AddWithValue("@barkod", barkod);
                                object urunIdObj = urunCmd.ExecuteScalar();

                                if (urunIdObj == null)
                                {
                                    hatali++;
                                    continue;
                                }

                                int urunId = Convert.ToInt32(urunIdObj);

                                // Stok güncelleme
                                string updateQuery = hareketTuru == "Giris" ?
                                    "UPDATE urunler SET miktar = miktar + @miktar WHERE urun_id = @urunId" :
                                    "UPDATE urunler SET miktar = miktar - @miktar WHERE urun_id = @urunId";

                                MySqlCommand updateCmd = new MySqlCommand(updateQuery, connection, transaction);
                                updateCmd.Parameters.AddWithValue("@miktar", miktar);
                                updateCmd.Parameters.AddWithValue("@urunId", urunId);
                                updateCmd.ExecuteNonQuery();

                                // Hareket kaydı ekleme
                                string insertQuery = @"INSERT INTO urun_hareketleri 
                                                    (urun_id, hareket_turu, miktar, kullanici_id, aciklama, islem_turu_id) 
                                                    VALUES 
                                                    (@urunId, @hareketTuru, @miktar, @kullaniciId, @aciklama, 0)";
                                MySqlCommand insertCmd = new MySqlCommand(insertQuery, connection, transaction);
                                insertCmd.Parameters.AddWithValue("@urunId", urunId);
                                insertCmd.Parameters.AddWithValue("@hareketTuru", hareketTuru);
                                insertCmd.Parameters.AddWithValue("@miktar", miktar);
                                insertCmd.Parameters.AddWithValue("@kullaniciId", kullaniciId);
                                insertCmd.Parameters.AddWithValue("@aciklama", aciklama);
                                insertCmd.ExecuteNonQuery();

                                basarili++;
                            }
                            catch
                            {
                                hatali++;
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