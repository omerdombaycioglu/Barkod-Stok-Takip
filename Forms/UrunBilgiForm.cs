using MySql.Data.MySqlClient;
using StokTakipOtomasyonu.Helpers;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace StokTakipOtomasyonu.Forms
{
    public partial class UrunBilgiForm : Form
    {
        private DataTable originalData;
        private int aktifKullaniciId;

        public UrunBilgiForm(int kullaniciId)
        {
            this.Icon = new Icon("isp_logo2.ico");
            InitializeComponent();
            aktifKullaniciId = kullaniciId;
            ConfigureDataGridView();
            LoadUrunler();
        }

        private void ConfigureDataGridView()
        {
            dataGridViewUrunler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewUrunler.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dataGridViewUrunler.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewUrunler.EnableHeadersVisualStyles = false;
            dataGridViewUrunler.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 122, 183);
            dataGridViewUrunler.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewUrunler.RowHeadersVisible = false;
            dataGridViewUrunler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void LoadUrunler()
        {
            try
            {
                string query = "SELECT urun_id, urun_adi, urun_kodu, urun_barkod, urun_marka, urun_no, miktar, kritik_seviye FROM urunler";
                originalData = DatabaseHelper.ExecuteQuery(query);
                originalData.AcceptChanges(); // 🔒 Karşılaştırma için önemli

                dataGridViewUrunler.DataSource = originalData;

                if (dataGridViewUrunler.Columns.Contains("miktar"))
                {
                    dataGridViewUrunler.Columns["miktar"].ReadOnly = true;
                    dataGridViewUrunler.Columns["miktar"].DefaultCellStyle.BackColor = Color.LightGray;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürünler yüklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            dataGridViewUrunler.EndEdit();
            dataGridViewUrunler.CurrentCell = null;

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (var transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            foreach (DataGridViewRow row in dataGridViewUrunler.Rows)
                            {
                                if (row.IsNewRow) continue;

                                if (!(row.DataBoundItem is DataRowView drv)) continue;

                                drv.EndEdit(); // ✅ En kritik satır — bağlanan DataRow'u günceller

                                DataRow originalRow = drv.Row;
                                int urunId = Convert.ToInt32(originalRow["urun_id"]);

                                string[] kolonlar = { "urun_adi", "urun_kodu", "urun_barkod", "urun_marka", "urun_no", "kritik_seviye" };
                                bool degisiklikVar = false;

                                foreach (string kolon in kolonlar)
                                {
                                    string eskiDeger = originalRow[kolon, DataRowVersion.Original]?.ToString()?.Trim() ?? "";
                                    string yeniDeger = originalRow[kolon]?.ToString()?.Trim() ?? "";

                                    if (eskiDeger != yeniDeger)
                                    {
                                        string logQuery = @"INSERT INTO urun_guncelleme_log 
                                    (urun_id, kolon_adi, eski_deger, yeni_deger, degistiren_id) 
                                    VALUES (@urun_id, @kolon, @eski, @yeni, @kullanici_id)";

                                        DatabaseHelper.ExecuteNonQuery(logQuery, transaction,
                                            new MySqlParameter("@urun_id", urunId),
                                            new MySqlParameter("@kolon", kolon),
                                            new MySqlParameter("@eski", eskiDeger),
                                            new MySqlParameter("@yeni", yeniDeger),
                                            new MySqlParameter("@kullanici_id", aktifKullaniciId));

                                        degisiklikVar = true;
                                    }
                                }

                                if (degisiklikVar)
                                {
                                    string updateQuery = @"UPDATE urunler SET 
                                urun_adi = @urun_adi, 
                                urun_kodu = @urun_kodu, 
                                urun_barkod = @urun_barkod, 
                                urun_marka = @urun_marka, 
                                urun_no = @urun_no, 
                                kritik_seviye = @kritik_seviye 
                                WHERE urun_id = @urun_id";

                                    DatabaseHelper.ExecuteNonQuery(updateQuery, transaction,
                                        new MySqlParameter("@urun_adi", originalRow["urun_adi"] ?? DBNull.Value),
                                        new MySqlParameter("@urun_kodu", originalRow["urun_kodu"] ?? DBNull.Value),
                                        new MySqlParameter("@urun_barkod", originalRow["urun_barkod"] ?? DBNull.Value),
                                        new MySqlParameter("@urun_marka", originalRow["urun_marka"] ?? DBNull.Value),
                                        new MySqlParameter("@urun_no", originalRow["urun_no"] ?? DBNull.Value),
                                        new MySqlParameter("@kritik_seviye", originalRow["kritik_seviye"] ?? DBNull.Value),
                                        new MySqlParameter("@urun_id", urunId));
                                }
                            }

                            transaction.Commit();
                            MessageBox.Show("Değişiklikler ve loglar başarıyla kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadUrunler();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Transaction hatası:\n" + ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bağlantı hatası:\n" + ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtArama_TextChanged(object sender, EventArgs e)
        {
            if (originalData != null)
            {
                string searchText = txtArama.Text.ToLower();
                DataView dv = originalData.DefaultView;
                dv.RowFilter = $"urun_adi LIKE '%{searchText}%' OR urun_kodu LIKE '%{searchText}%' OR urun_barkod LIKE '%{searchText}%'";
                dataGridViewUrunler.DataSource = dv;
            }
        }
    }
}
