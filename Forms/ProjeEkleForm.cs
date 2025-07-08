using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using StokTakipOtomasyonu.Helpers;

namespace StokTakipOtomasyonu.Forms
{
    public partial class ProjeEkleForm : Form
    {
        private int _kullaniciId;

        public ProjeEkleForm(int kullaniciId)
        {
            InitializeComponent();
            _kullaniciId = kullaniciId;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProjeKodu.Text) || string.IsNullOrWhiteSpace(txtProjeTanimi.Text))
            {
                MessageBox.Show("Proje kodu ve tanımı boş olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = "INSERT INTO projeler (proje_kodu, proje_tanimi) VALUES (@proje_kodu, @proje_tanimi)";
                var parameters = new[]
                {
                    new MySqlParameter("@proje_kodu", txtProjeKodu.Text.Trim()),
                    new MySqlParameter("@proje_tanimi", txtProjeTanimi.Text.Trim())
                };

                int result = DatabaseHelper.ExecuteNonQuery(query, parameters);

                if (result > 0)
                {
                    MessageBox.Show("Proje başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062) // Duplicate entry
                {
                    MessageBox.Show("Bu proje kodu zaten mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Proje eklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Proje eklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}