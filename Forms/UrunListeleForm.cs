using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StokTakipOtomasyonu
{
    public partial class UrunListeleForm : Form
    {
        private MySqlConnection connection;
        private string connectionString = "server=localhost;database=stok_takip_otomasyonu;uid=root;pwd=;";

        public UrunListeleForm()
        {
            InitializeComponent();
            connection = new MySqlConnection(connectionString);
            UrunleriYukle();
        }

        private void UrunleriYukle()
        {
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
                                u.birim AS 'Birim',
                                u.min_stok AS 'Min Stok',
                                u.max_stok AS 'Max Stok'
                                FROM urunler u
                                ORDER BY u.urun_adi";

                MySqlCommand cmd = new MySqlCommand(query, connection);
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

        private void btnYenile_Click(object sender, EventArgs e)
        {
            UrunleriYukle();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtArama_TextChanged(object sender, EventArgs e)
        {
            string aramaKelimesi = txtArama.Text.Trim();
            if (dataGridView1.DataSource is DataTable dt)
            {
                dt.DefaultView.RowFilter = $"`Ürün Adı` LIKE '%{aramaKelimesi}%' OR " +
                                          $"`Ürün Kodu` LIKE '%{aramaKelimesi}%' OR " +
                                          $"`Barkod` LIKE '%{aramaKelimesi}%' OR " +
                                          $"`Marka` LIKE '%{aramaKelimesi}%'";
            }
        }
    }
}