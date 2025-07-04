using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StokTakipOtomasyonu
{
    public partial class UrunAramaForm : Form
    {
        private MySqlConnection connection;
        private string connectionString = "server=localhost;database=stok_takip_otomasyonu;uid=root;pwd=;";

        public UrunAramaForm()
        {
            InitializeComponent();
            connection = new MySqlConnection(connectionString);
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            string aramaKelimesi = txtArama.Text.Trim();
            if (string.IsNullOrEmpty(aramaKelimesi))
            {
                MessageBox.Show("Lütfen arama kriteri giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                connection.Open();
                string query = @"SELECT 
                                u.urun_id AS 'ID',
                                u.urun_adi AS 'Ürün Adı',
                                u.urun_kodu AS 'Ürün Kodu',
                                u.urun_barkod AS 'Barkod',
                                u.urun_marka AS 'Marka',
                                u.miktar AS 'Miktar',
                                u.birim AS 'Birim'
                                FROM urunler u
                                WHERE u.urun_adi LIKE @arama OR 
                                      u.urun_kodu LIKE @arama OR 
                                      u.urun_barkod LIKE @arama OR 
                                      u.urun_marka LIKE @arama
                                ORDER BY u.urun_adi";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@arama", "%" + aramaKelimesi + "%");
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.Columns["ID"].Visible = false; // ID sütununu gizle

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Arama kriterlerine uygun ürün bulunamadı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                string urunBilgisi = $"{row.Cells["Ürün Adı"].Value} - {row.Cells["Ürün Kodu"].Value}";
                MessageBox.Show($"Seçilen Ürün: {urunBilgisi}\nBarkod: {row.Cells["Barkod"].Value}\nMiktar: {row.Cells["Miktar"].Value} {row.Cells["Birim"].Value}",
                    "Ürün Detay", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}