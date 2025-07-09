using MySql.Data.MySqlClient;
using StokTakipOtomasyonu.Helpers;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace StokTakipOtomasyonu.Forms
{
    public partial class ProjeMontajForm : Form
    {
        private int _userId;

        public ProjeMontajForm(int userId)
        {
            InitializeComponent();
            _userId = userId;
            ConfigureDataGridViews();
        }

        private void ConfigureDataGridViews()
        {
            // Projeler DataGridView ayarları
            dataGridViewProjeler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewProjeler.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dataGridViewProjeler.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewProjeler.EnableHeadersVisualStyles = false;
            dataGridViewProjeler.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 122, 183);
            dataGridViewProjeler.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewProjeler.RowHeadersVisible = false;
            dataGridViewProjeler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Ürünler DataGridView ayarları
            dataGridViewUrunler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewUrunler.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dataGridViewUrunler.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewUrunler.EnableHeadersVisualStyles = false;
            dataGridViewUrunler.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 122, 183);
            dataGridViewUrunler.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewUrunler.RowHeadersVisible = false;
            dataGridViewUrunler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void ProjeMontajForm_Load(object sender, EventArgs e)
        {
            LoadProjects();
        }

        private void LoadProjects()
        {
            try
            {
                string query = "SELECT proje_id, proje_kodu, proje_tanimi FROM projeler WHERE aktif = 1 ORDER BY proje_kodu";
                DataTable dt = DatabaseHelper.ExecuteQuery(query);

                dataGridViewProjeler.DataSource = dt;
                dataGridViewProjeler.Columns["proje_id"].Visible = false;
                dataGridViewProjeler.Columns["proje_kodu"].HeaderText = "Proje Kodu";
                dataGridViewProjeler.Columns["proje_tanimi"].HeaderText = "Proje Tanımı";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Projeler yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewProjeler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewProjeler.Columns["btnUrunListesi"].Index && e.RowIndex >= 0)
            {
                int projeId = Convert.ToInt32(dataGridViewProjeler.Rows[e.RowIndex].Cells["proje_id"].Value);
                LoadProjectProducts(projeId);
            }
        }

        private void LoadProjectProducts(int projeId)
        {
            try
            {
                string query = @"SELECT 
                                p.urun_id, 
                                u.urun_kodu, 
                                u.urun_adi, 
                                u.urun_marka, 
                                p.miktar AS gerekli_miktar, 
                                u.miktar AS stok_miktari,
                                u.kritik_seviye,
                                CASE 
                                    WHEN u.miktar >= p.miktar THEN 'Stokta var'
                                    ELSE 'Stokta yok'
                                END AS stok_durumu
                            FROM proje_urunleri p
                            JOIN urunler u ON p.urun_id = u.urun_id
                            WHERE p.proje_id = @proje_id";

                var parameters = new[] { new MySqlParameter("@proje_id", projeId) };
                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

                dataGridViewUrunler.DataSource = dt;
                ApplyProductRowColoring();

                // Kolon başlıklarını düzenle
                dataGridViewUrunler.Columns["urun_id"].Visible = false;
                dataGridViewUrunler.Columns["urun_kodu"].HeaderText = "Ürün Kodu";
                dataGridViewUrunler.Columns["urun_adi"].HeaderText = "Ürün Adı";
                dataGridViewUrunler.Columns["urun_marka"].HeaderText = "Marka";
                dataGridViewUrunler.Columns["gerekli_miktar"].HeaderText = "Gerekli Miktar";
                dataGridViewUrunler.Columns["stok_miktari"].HeaderText = "Stok Miktarı";
                dataGridViewUrunler.Columns["kritik_seviye"].HeaderText = "Min. Miktar";
                dataGridViewUrunler.Columns["stok_durumu"].HeaderText = "Stok Durumu";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ürün listesi yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyProductRowColoring()
        {
            foreach (DataGridViewRow row in dataGridViewUrunler.Rows)
            {
                if (row.Cells["stok_durumu"].Value.ToString() == "Stokta var")
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.LightCoral;
                }

                // Kritik seviye kontrolü
                if (row.Cells["stok_miktari"].Value != DBNull.Value &&
                    row.Cells["kritik_seviye"].Value != DBNull.Value)
                {
                    int stokMiktari = Convert.ToInt32(row.Cells["stok_miktari"].Value);
                    int kritikSeviye = Convert.ToInt32(row.Cells["kritik_seviye"].Value);

                    if (stokMiktari < kritikSeviye)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                        row.Cells["stok_durumu"].Value = "Kritik seviyenin altında";
                    }
                }
            }
        }
    }
}