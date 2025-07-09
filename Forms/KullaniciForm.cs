using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using StokTakipOtomasyonu.Helpers;

namespace StokTakipOtomasyonu.Forms
{
    public partial class KullaniciForm : Form
    {
        public KullaniciForm()
        {
            InitializeComponent();
            LoadKullanicilar();
        }

        private void LoadKullanicilar()
        {
            try
            {
                string query = "SELECT kullanici_id, kullanici_adi, ad_soyad, kullanici_yetki, aktif FROM kullanicilar";
                var dt = DatabaseHelper.ExecuteQuery(query);
                dataGridViewKullanicilar.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kullanıcılar yüklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (var transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            foreach (DataGridViewRow row in dataGridViewKullanicilar.Rows)
                            {
                                if (!row.IsNewRow)
                                {
                                    string query;
                                    if (row.Cells["kullanici_id"].Value == null || Convert.ToInt32(row.Cells["kullanici_id"].Value) == 0)
                                    {
                                        // Yeni kullanıcı ekleme
                                        query = @"INSERT INTO kullanicilar 
                                                (kullanici_adi, sifre, kullanici_yetki, ad_soyad, aktif) 
                                                VALUES 
                                                (@kullanici_adi, SHA2('123456', 256), @kullanici_yetki, @ad_soyad, @aktif)";
                                    }
                                    else
                                    {
                                        // Mevcut kullanıcıyı güncelleme
                                        query = @"UPDATE kullanicilar SET 
                                                kullanici_adi = @kullanici_adi, 
                                                kullanici_yetki = @kullanici_yetki, 
                                                ad_soyad = @ad_soyad, 
                                                aktif = @aktif 
                                                WHERE kullanici_id = @kullanici_id";
                                    }

                                    DatabaseHelper.ExecuteNonQuery(query, transaction,
                                        new MySqlParameter("@kullanici_adi", row.Cells["kullanici_adi"].Value ?? DBNull.Value),
                                        new MySqlParameter("@kullanici_yetki", row.Cells["kullanici_yetki"].Value ?? 2),
                                        new MySqlParameter("@ad_soyad", row.Cells["ad_soyad"].Value ?? DBNull.Value),
                                        new MySqlParameter("@aktif", row.Cells["aktif"].Value ?? true),
                                        new MySqlParameter("@kullanici_id", row.Cells["kullanici_id"].Value ?? DBNull.Value));
                                }
                            }
                            transaction.Commit();
                            MessageBox.Show("Değişiklikler başarıyla kaydedildi. Yeni kullanıcılar için varsayılan şifre: 123456",
                                "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Kayıt sırasında hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bağlantı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSifreSifirla_Click(object sender, EventArgs e)
        {
            if (dataGridViewKullanicilar.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridViewKullanicilar.SelectedRows[0];
                int kullaniciId = Convert.ToInt32(selectedRow.Cells["kullanici_id"].Value);
                string kullaniciAdi = selectedRow.Cells["kullanici_adi"].Value.ToString();

                if (MessageBox.Show($"{kullaniciAdi} kullanıcısının şifresini sıfırlamak istediğinize emin misiniz?\nYeni şifre: 123456",
                    "Şifre Sıfırlama", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        string query = "UPDATE kullanicilar SET sifre = SHA2('123456', 256) WHERE kullanici_id = @kullanici_id";
                        DatabaseHelper.ExecuteNonQuery(query, new MySqlParameter("@kullanici_id", kullaniciId));
                        MessageBox.Show("Şifre başarıyla sıfırlandı. Yeni şifre: 123456", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Şifre sıfırlama hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir kullanıcı seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}