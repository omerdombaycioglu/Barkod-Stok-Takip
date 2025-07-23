using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace StokTakipOtomasyonu.Forms
{
    public partial class FormIslemGecmisi : Form
    {
        public FormIslemGecmisi(DataTable islemGecmisi, string projeKodu)
        {
            InitializeComponent();
            this.Text = $"İşlem Geçmişi - {projeKodu}";

            // Yeni "durum" sütunu ekle
            islemGecmisi.Columns.Add("durum", typeof(string));

            foreach (DataRow row in islemGecmisi.Rows)
            {
                bool aktifMi = Convert.ToBoolean(row["aktif"]);
                if (aktifMi)
                {
                    row["durum"] = "✔ İşlem Geçerli";
                }
                else
                {
                    row["durum"] = "✘ Geri Alınan İşlem";                  
                }
            }


            dgvIslemler.DataSource = islemGecmisi;
            FormatGrid();
        }

        private void FormatGrid()
        {
            dgvIslemler.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvIslemler.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            dgvIslemler.BackgroundColor = Color.White;
            dgvIslemler.DefaultCellStyle.SelectionBackColor = Color.SteelBlue;
            dgvIslemler.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvIslemler.BorderStyle = BorderStyle.None;
            dgvIslemler.EnableHeadersVisualStyles = false;
            dgvIslemler.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 30, 30);
            dgvIslemler.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvIslemler.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvIslemler.ColumnHeadersHeight = 30;
            dgvIslemler.RowTemplate.Height = 28;
            dgvIslemler.ReadOnly = true;
            dgvIslemler.AllowUserToAddRows = false;
            dgvIslemler.AllowUserToDeleteRows = false;
            dgvIslemler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Pasif işlemleri kırmızı yap
            foreach (DataGridViewRow row in dgvIslemler.Rows)
            {
                bool aktifMi = Convert.ToBoolean(row.Cells["aktif"].Value);
                if (!aktifMi)
                {
                    row.DefaultCellStyle.BackColor = Color.LightPink;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
            }

            // Sütun adları
            dgvIslemler.Columns["urun_kodu"].HeaderText = "Ürün Kodu";
            dgvIslemler.Columns["urun_adi"].HeaderText = "Ürün Adı";
            dgvIslemler.Columns["miktar"].HeaderText = "Miktar";
            dgvIslemler.Columns["kullanici_adi"].HeaderText = "Kullanıcı";
            dgvIslemler.Columns["islem_tarihi"].HeaderText = "Tarih";
            dgvIslemler.Columns["durum"].HeaderText = "Durum";

            // Gereksiz sütunu gizle
            dgvIslemler.Columns["aktif"].Visible = false;
            dgvIslemler.Columns["durum"].HeaderText = "Durum";
            dgvIslemler.Columns["geri_alinan_islem"].HeaderText = "Geri Alınma Tarihi";


        }
    }
}
