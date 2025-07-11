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

        public ProjeEkleForm(int kullaniciId)
        {
            InitializeComponent();
            _kullaniciId = kullaniciId;
            btnYukle.Enabled = false;
            btnYukle.Visible = false;
        }

        private void btnDevamEt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProjeKodu.Text) || string.IsNullOrWhiteSpace(txtProjeTanimi.Text))
            {
                MessageBox.Show("Proje kodu ve tanımı boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string insertQuery = "INSERT INTO projeler (proje_kodu, proje_tanimi, olusturan_id) VALUES (@kod, @tanimi, @olusturan)";
                MySqlCommand cmd = new MySqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@kod", txtProjeKodu.Text.Trim());
                cmd.Parameters.AddWithValue("@tanimi", txtProjeTanimi.Text.Trim());
                cmd.Parameters.AddWithValue("@olusturan", _kullaniciId);
                cmd.ExecuteNonQuery();
                _projeId = (int)cmd.LastInsertedId;
            }

            btnYukle.Visible = true;
            btnYukle.Enabled = true;
            txtProjeKodu.Enabled = false;
            txtProjeTanimi.Enabled = false;
            btnDevamEt.Enabled = false;
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
            table.Columns.Add("Stok Durumu");
            table.Columns.Add("Stoktaki Miktar", typeof(int));
            table.Columns.Add("Gereken Minimum Miktar", typeof(int));

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
                        if (row == null || row.Cells.TrueForAll(c => string.IsNullOrWhiteSpace(c.ToString()))) continue;

                        string tipNo = row.GetCell(0)?.ToString();
                        string siparisNo = row.GetCell(1)?.ToString();
                        string aciklama = row.GetCell(2)?.ToString();
                        string urunNo = row.GetCell(3)?.ToString();
                        string marka = row.GetCell(4)?.ToString();
                        int miktar = 0;
                        if (int.TryParse(row.GetCell(5)?.ToString(), out int parsed)) miktar = parsed;

                        int urunId = -1;
                        bool urunVar = false;
                        int stoktakiMiktar = 0;
                        int gerekenMinimum = 0;
                        string stokDurum = "Yetersiz";

                        string checkQuery = "SELECT urun_id, miktar FROM urunler WHERE urun_kodu = @kod";
                        MySqlCommand cmd = new MySqlCommand(checkQuery, conn);
                        cmd.Parameters.AddWithValue("@kod", siparisNo);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                urunId = reader.GetInt32("urun_id");
                                stoktakiMiktar = reader.GetInt32("miktar");
                                gerekenMinimum = stoktakiMiktar - miktar;
                                if (stoktakiMiktar >= miktar) stokDurum = "Yeterli";
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
                            stoktakiMiktar = 0;
                            gerekenMinimum = 0 - miktar;
                        }

                        string insertProjeUrun = "INSERT INTO proje_urunleri (proje_id, urun_id, miktar, user_id) VALUES (@proje, @urun, @miktar, @kullanici)";
                        MySqlCommand projecmd = new MySqlCommand(insertProjeUrun, conn);
                        projecmd.Parameters.AddWithValue("@proje", _projeId);
                        projecmd.Parameters.AddWithValue("@urun", urunId);
                        projecmd.Parameters.AddWithValue("@miktar", miktar);
                        projecmd.Parameters.AddWithValue("@kullanici", _kullaniciId);
                        projecmd.ExecuteNonQuery();

                        table.Rows.Add(tipNo, siparisNo, aciklama, urunNo, marka, miktar, stokDurum, stoktakiMiktar, gerekenMinimum);
                    }
                }
            }

            dgvUrunler.DataSource = table;
            dgvUrunler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            foreach (DataGridViewRow row in dgvUrunler.Rows)
            {
                if (row.Cells["Stok Durumu"].Value?.ToString() == "Yeterli")
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                else
                    row.DefaultCellStyle.BackColor = Color.LightCoral;
            }
        }
        private void btnTamEkran_Click(object sender, EventArgs e)
        {
            Form tamEkranForm = new Form();
            tamEkranForm.Text = "Tam Ekran Ürün Listesi";
            tamEkranForm.WindowState = FormWindowState.Maximized;

            DataGridView dgvTamEkran = new DataGridView();
            dgvTamEkran.Dock = DockStyle.Fill;
            dgvTamEkran.DataSource = dgvUrunler.DataSource;
            dgvTamEkran.ReadOnly = true;
            dgvTamEkran.AllowUserToAddRows = false;
            dgvTamEkran.AllowUserToDeleteRows = false;
            dgvTamEkran.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            tamEkranForm.Controls.Add(dgvTamEkran);
            tamEkranForm.ShowDialog();
        }

    }
}
