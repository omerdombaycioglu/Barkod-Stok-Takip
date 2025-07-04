using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StokTakipOtomasyonu
{
    public partial class EnvanterKontrolForm : Form
    {
        private MySqlConnection connection;
        private string connectionString = "server=localhost;database=stok_takip_otomasyonu;uid=root;pwd=;";

        public EnvanterKontrolForm()
        {
            InitializeComponent();
            connection = new MySqlConnection(connectionString);
            EnvanteriYukle();
        }

        private void EnvanteriYukle()
        {
            try
            {
                connection.Open();
                string query = @"SELECT 
                                u.urun_id AS 'ID',
                                u.urun_adi AS 'Ürün Adı',
                                u.urun_kodu AS 'Ürün Kodu',
                                u.miktar AS 'Miktar',
                                u.birim AS 'Birim',
                                u.min_stok AS 'Min Stok',
                                u.max_stok AS 'Max Stok',
                                CASE 
                                    WHEN u.miktar < u.min_stok THEN 'STOK AZALDI'
                                    WHEN u.miktar > u.max_stok THEN 'STOK FAZLA'
                                    ELSE 'NORMAL'
                                END AS 'Durum'
                                FROM urunler u
                                WHERE u.min_stok > 0 OR u.max_stok > 0
                                ORDER BY 
                                CASE 
                                    WHEN u.miktar < u.min_stok THEN 0
                                    WHEN u.miktar > u.max_stok THEN 1
                                    ELSE 2
                                END, u.urun_adi";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.Columns["ID"].Visible = false; // ID sütununu gizle

                // Duruma göre renklendirme
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["Durum"].Value.ToString() == "STOK AZALDI")
                    {
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.LightCoral;
                    }
                    else if (row.Cells["Durum"].Value.ToString() == "STOK FAZLA")
                    {
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                    }
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

        private void btnYenile_Click(object sender, EventArgs e)
        {
            EnvanteriYukle();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}