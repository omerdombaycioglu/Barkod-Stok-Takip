using System;
using System.Data;
using System.Windows.Forms;
using StokTakipOtomasyonu.Helpers;

namespace StokTakipOtomasyonu.Forms
{
    public partial class SonIslemlerForm : Form
    {
        public SonIslemlerForm()
        {
            InitializeComponent();
            LoadSonIslemler();
            ConfigureDataGridView();
        }

        private void LoadSonIslemler()
        {
            try
            {
                string query = @"SELECT uh.id, u.urun_adi, 
                                CASE uh.hareket_turu 
                                    WHEN 'Giris' THEN 'Giriş' 
                                    WHEN 'Cikis' THEN 'Çıkış' 
                                END AS hareket_turu,
                                uh.miktar, 
                                DATE_FORMAT(uh.log_date, '%d.%m.%Y %H:%i:%s') AS tarih, 
                                k.ad_soyad AS kullanici,
                                CASE 
                                    WHEN uh.islem_turu_id = 0 THEN 'Stok'
                                    WHEN uh.islem_turu_id = 1 THEN 'Proje'
                                    WHEN uh.islem_turu_id = 2 THEN 'Hurda/İade'
                                    ELSE ''
                                END AS islem_turu,
                                p.proje_kodu,
                                uh.aciklama
                                FROM urun_hareketleri uh
                                JOIN urunler u ON uh.urun_id = u.urun_id
                                JOIN kullanicilar k ON uh.kullanici_id = k.kullanici_id
                                LEFT JOIN projeler p ON uh.proje_id = p.proje_id
                                ORDER BY uh.log_date DESC
                                LIMIT 200";

                DataTable dt = DatabaseHelper.ExecuteQuery(query);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Son işlemler yüklenirken hata oluştu: " + ex.Message,
                                "Hata",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void ConfigureDataGridView()
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns["id"].HeaderText = "ID";
                dataGridView1.Columns["urun_adi"].HeaderText = "Ürün Adı";
                dataGridView1.Columns["hareket_turu"].HeaderText = "Hareket Türü";
                dataGridView1.Columns["miktar"].HeaderText = "Miktar";
                dataGridView1.Columns["tarih"].HeaderText = "Tarih";
                dataGridView1.Columns["kullanici"].HeaderText = "Kullanıcı";
                dataGridView1.Columns["islem_turu"].HeaderText = "İşlem Türü";
                dataGridView1.Columns["proje_kodu"].HeaderText = "Proje Kodu";
                dataGridView1.Columns["aciklama"].HeaderText = "Açıklama";
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            LoadSonIslemler();
        }
    }
}
