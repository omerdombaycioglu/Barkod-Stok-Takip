using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StokTakipOtomasyonu
{
    public partial class IslemGecmisiForm : Form
    {
        private MySqlConnection connection;
        private string connectionString = "server=localhost;database=stok_takip_otomasyonu;uid=root;pwd=;";

        public IslemGecmisiForm()
        {
            InitializeComponent();
            connection = new MySqlConnection(connectionString);
            dtpBaslangic.Value = DateTime.Now.AddDays(-30);
            dtpBitis.Value = DateTime.Now;
            IslemGecmisiniYukle();
        }

        private void IslemGecmisiniYukle()
        {
            try
            {
                connection.Open();
                string query = @"SELECT 
                                h.id AS 'ID',
                                u.urun_adi AS 'Ürün Adı',
                                u.urun_kodu AS 'Ürün Kodu',
                                CASE 
                                    WHEN h.hareket_turu = 'Giris' THEN 'Giriş' 
                                    ELSE 'Çıkış' 
                                END AS 'Hareket Türü',
                                h.miktar AS 'Miktar',
                                k.kullanici_adi AS 'Kullanıcı',
                                it.tanim AS 'İşlem Türü',
                                h.aciklama AS 'Açıklama',
                                h.log_date AS 'Tarih'
                                FROM urun_hareketleri h
                                JOIN urunler u ON h.urun_id = u.urun_id
                                JOIN kullanicilar k ON h.kullanici_id = k.kullanici_id
                                LEFT JOIN islem_turu it ON h.islem_turu_id = it.islem_turu_id
                                WHERE h.log_date BETWEEN @baslangic AND @bitis
                                ORDER BY h.log_date DESC";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@baslangic", dtpBaslangic.Value.Date);
                cmd.Parameters.AddWithValue("@bitis", dtpBitis.Value.Date.AddDays(1).AddSeconds(-1));
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.Columns["ID"].Visible = false; // ID sütununu gizle
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

        private void btnFiltrele_Click(object sender, EventArgs e)
        {
            IslemGecmisiniYukle();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}