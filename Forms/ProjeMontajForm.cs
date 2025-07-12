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
            ConfigureDataGridView();
        }

        private void ProjeMontajForm_Load(object sender, EventArgs e)
        {
            LoadProjects();
        }

        private void ConfigureDataGridView()
        {
            dataGridViewProjeler.AutoGenerateColumns = false;
            dataGridViewProjeler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewProjeler.MultiSelect = false;
            dataGridViewProjeler.RowHeadersVisible = false;

            // Sütunları elle ekle
            dataGridViewProjeler.Columns.Clear();

            dataGridViewProjeler.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "proje_id",
                DataPropertyName = "proje_id",
                HeaderText = "ID",
                Visible = false
            });

            dataGridViewProjeler.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "proje_kodu",
                DataPropertyName = "proje_kodu",
                HeaderText = "Proje Kodu",
                Width = 150
            });

            dataGridViewProjeler.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "proje_tanimi",
                DataPropertyName = "proje_tanimi",
                HeaderText = "Tanım",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dataGridViewProjeler.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "btnUrunListesi",
                HeaderText = "Ürün Durumu",
                Text = "Proje Ürün Durumunu Göster",
                UseColumnTextForButtonValue = true,
                Width = 200
            });

            dataGridViewProjeler.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "btnIslemGecmisi",
                HeaderText = "İşlem Geçmişi",
                Text = "İşlem Geçmişi",
                UseColumnTextForButtonValue = true,
                Width = 150
            });
        }

        private void LoadProjects()
        {
            string query = "SELECT proje_id, proje_kodu, proje_tanimi FROM projeler WHERE aktif = 1 ORDER BY proje_kodu";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            dataGridViewProjeler.DataSource = dt;
        }

        private void dataGridViewProjeler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || !(dataGridViewProjeler.Columns[e.ColumnIndex] is DataGridViewButtonColumn))
                return;

            int projeId = Convert.ToInt32(dataGridViewProjeler.Rows[e.RowIndex].Cells["proje_id"].Value);
            string projeKodu = dataGridViewProjeler.Rows[e.RowIndex].Cells["proje_kodu"].Value.ToString();

            if (dataGridViewProjeler.Columns[e.ColumnIndex].Name == "btnUrunListesi")
            {
                var detayForm = new ProjeMontajDetayForm(projeId, _userId, projeKodu);
                detayForm.ShowDialog();
            }
            else if (dataGridViewProjeler.Columns[e.ColumnIndex].Name == "btnIslemGecmisi")
            {
                ShowProjectTransactionHistory(projeId, projeKodu);
            }
        }

        private void ShowProjectTransactionHistory(int projeId, string projeKodu)
        {
            string query = @"
                SELECT u.urun_kodu, u.urun_adi, ph.miktar, k.kullanici_adi, ph.islem_tarihi
                FROM proje_hareketleri ph
                JOIN urunler u ON ph.urun_id = u.urun_id
                JOIN kullanicilar k ON ph.kullanici_id = k.kullanici_id
                WHERE ph.proje_id = @proje_id
                ORDER BY ph.islem_tarihi DESC";

            var parameters = new[] { new MySqlParameter("@proje_id", projeId) };
            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Bu proje için işlem geçmişi bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string message = $"Proje: {projeKodu}\n\n";
            foreach (DataRow row in dt.Rows)
            {
                message += $"[{row["islem_tarihi"]}] {row["kullanici_adi"]} - {row["urun_adi"]} ({row["urun_kodu"]}) x{row["miktar"]}\n";
            }

            MessageBox.Show(message, "Proje İşlem Geçmişi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
