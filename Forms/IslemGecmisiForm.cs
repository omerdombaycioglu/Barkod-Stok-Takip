using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace StokTakipOtomasyonu
{
    public partial class IslemGecmisiForm : Form
    {
        private int _urunId;
        private string _urunAdi;
        private string connectionString = "server=localhost;database=stok_takip_otomasyonu;uid=root;pwd=;";

        public IslemGecmisiForm(int urunId, string urunAdi)
        {
            InitializeComponent();
            _urunId = urunId;
            _urunAdi = urunAdi;
            this.Text = $"{urunAdi} - İşlem Geçmişi";
            HareketleriYukle();
        }

        private void HareketleriYukle()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"SELECT 
                                    uh.id AS 'ID',
                                    uh.log_date AS 'Tarih',
                                    uh.hareket_turu AS 'Hareket Türü',
                                    uh.miktar AS 'Miktar',
                                    it.tanim AS 'İşlem Türü',
                                    CONCAT(k.ad_soyad, ' (', k.kullanici_adi, ')') AS 'Kullanıcı',
                                    uh.aciklama AS 'Açıklama',
                                    CASE 
                                        WHEN uh.islem_turu_id = 1 THEN p.proje_kodu
                                        ELSE ''
                                    END AS 'Proje Kodu'
                                    FROM urun_hareketleri uh
                                    JOIN kullanicilar k ON uh.kullanici_id = k.kullanici_id
                                    JOIN islem_turu it ON uh.islem_turu_id = it.islem_turu_id
                                    LEFT JOIN projeler p ON uh.islem_turu_id = 1 AND EXISTS (
                                        SELECT 1 FROM proje_urunleri pu 
                                        WHERE pu.proje_id = p.proje_id 
                                        AND pu.urun_id = uh.urun_id
                                        AND pu.log_date = uh.log_date
                                    )
                                    WHERE uh.urun_id = @urunId
                                    ORDER BY uh.log_date DESC";

                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@urunId", _urunId);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridView1.DataSource = dt;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView1.Columns["ID"].Visible = false;

                    // Toplam giriş/çıkış miktarlarını hesapla
                    int toplamGiris = 0;
                    int toplamCikis = 0;

                    foreach (DataRow row in dt.Rows)
                    {
                        int miktar = Convert.ToInt32(row["Miktar"]);
                        if (row["Hareket Türü"].ToString() == "Giris")
                            toplamGiris += miktar;
                        else
                            toplamCikis += miktar;
                    }

                    lblToplamGiris.Text = $"Toplam Giriş: {toplamGiris}";
                    lblToplamCikis.Text = $"Toplam Çıkış: {toplamCikis}";
                    lblNetHareket.Text = $"Net Hareket: {toplamGiris - toplamCikis}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}