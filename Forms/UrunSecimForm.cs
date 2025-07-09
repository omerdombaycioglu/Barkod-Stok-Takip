using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using StokTakipOtomasyonu.Helpers;

namespace StokTakipOtomasyonu.Forms
{
    public partial class UrunSecimForm : Form
    {
        public int SecilenUrunId { get; private set; }
        public int Miktar { get; private set; }

        public UrunSecimForm()
        {
            InitializeComponent();
            UrunleriYukle();
            SecilenUrunId = -1;
            Miktar = 1;
        }

        private void UrunleriYukle()
        {
            try
            {
                string query = "SELECT urun_id, urun_kodu, urun_adi FROM urunler ORDER BY urun_kodu";
                DataTable dt = DatabaseHelper.ExecuteQuery(query);

                dgvUrunler.DataSource = dt;

                // Kolon başlıklarını düzenle
                if (dgvUrunler.Columns.Count > 0)
                {
                    dgvUrunler.Columns["urun_id"].Visible = false;
                    dgvUrunler.Columns["urun_kodu"].HeaderText = "Ürün Kodu";
                    dgvUrunler.Columns["urun_adi"].HeaderText = "Ürün Adı";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürünler yüklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSec_Click(object sender, EventArgs e)
        {
            if (dgvUrunler.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen bir ürün seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtMiktar.Text, out int miktar) || miktar <= 0)
            {
                MessageBox.Show("Geçerli bir miktar giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SecilenUrunId = Convert.ToInt32(dgvUrunler.SelectedRows[0].Cells["urun_id"].Value);
            Miktar = miktar;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}