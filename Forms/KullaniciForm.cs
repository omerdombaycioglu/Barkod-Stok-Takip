using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using StokTakipOtomasyonu.Helpers;
using System.Data;
using System.Drawing;

namespace StokTakipOtomasyonu.Forms
{
    public partial class KullaniciForm : Form
    {
        public KullaniciForm()
        {
            InitializeComponent();
            ConfigureDataGridView();
            LoadKullanicilar();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void ConfigureDataGridView()
        {
            dataGridViewKullanicilar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewKullanicilar.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dataGridViewKullanicilar.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewKullanicilar.EnableHeadersVisualStyles = false;
            dataGridViewKullanicilar.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 122, 183);
            dataGridViewKullanicilar.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewKullanicilar.RowHeadersVisible = false;
            dataGridViewKullanicilar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewKullanicilar.AllowUserToAddRows = true;
            dataGridViewKullanicilar.AllowUserToDeleteRows = true;
            dataGridViewKullanicilar.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
            dataGridViewKullanicilar.CellFormatting += DataGridViewKullanicilar_CellFormatting;
        }

        private void DataGridViewKullanicilar_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewKullanicilar.Columns[e.ColumnIndex].Name == "kullanici_yetki")
            {
                if (e.Value != null)
                {
                    int yetki = Convert.ToInt32(e.Value);
                    e.Value = yetki == 1 ? "Yönetici" : "Kullanıcı";
                    e.FormattingApplied = true;
                }
            }
        }

        private void LoadKullanicilar()
        {
            try
            {
                string query = "SELECT kullanici_id, kullanici_adi, ad_soyad, kullanici_yetki, aktif FROM kullanicilar";
                var dt = DatabaseHelper.ExecuteQuery(query);

                dataGridViewKullanicilar.DataSource = dt;

                // Yetki sütununu ComboBox olarak ayarla
                DataGridViewComboBoxColumn yetkiColumn = new DataGridViewComboBoxColumn();
                yetkiColumn.HeaderText = "Yetki";
                yetkiColumn.DataPropertyName = "kullanici_yetki";
                yetkiColumn.Name = "kullanici_yetki";
                yetkiColumn.DataSource = new[] {
                    new { Text = "Yönetici", Value = 1 },
                    new { Text = "Kullanıcı", Value = 2 }
                };
                yetkiColumn.DisplayMember = "Text";
                yetkiColumn.ValueMember = "Value";

                // Mevcut sütunu kaldır ve yenisi ekle
                if (dataGridViewKullanicilar.Columns.Contains("kullanici_yetki"))
                {
                    dataGridViewKullanicilar.Columns.Remove("kullanici_yetki");
                }
                dataGridViewKullanicilar.Columns.Add(yetkiColumn);

                // Şifre sütunu ekle (gizli olarak)
                DataGridViewTextBoxColumn sifreColumn = new DataGridViewTextBoxColumn();
                sifreColumn.HeaderText = "Şifre";
                sifreColumn.Name = "sifre";
                sifreColumn.DataPropertyName = "sifre";
                sifreColumn.Visible = false;
                dataGridViewKullanicilar.Columns.Add(sifreColumn);

                // Sütun sıralamasını ayarla
                dataGridViewKullanicilar.Columns["kullanici_id"].DisplayIndex = 0;
                dataGridViewKullanicilar.Columns["kullanici_adi"].DisplayIndex = 1;
                dataGridViewKullanicilar.Columns["ad_soyad"].DisplayIndex = 2;
                dataGridViewKullanicilar.Columns["kullanici_yetki"].DisplayIndex = 3;
                dataGridViewKullanicilar.Columns["aktif"].DisplayIndex = 4;

                // ID sütununu salt okunur yap
                dataGridViewKullanicilar.Columns["kullanici_id"].ReadOnly = true;
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
                                    bool isNew = row.Cells["kullanici_id"].Value == null ||
                                                 row.Cells["kullanici_id"].Value == DBNull.Value ||
                                                 Convert.ToInt32(row.Cells["kullanici_id"].Value) == 0;

                                    if (isNew)
                                    {
                                        // Yeni kullanıcı ekleme
                                        query = @"INSERT INTO kullanicilar 
                                                (kullanici_adi, sifre, kullanici_yetki, ad_soyad, aktif) 
                                                VALUES 
                                                (@kullanici_adi, SHA2(@sifre, 256), @kullanici_yetki, @ad_soyad, @aktif)";
                                    }
                                    else
                                    {
                                        // Mevcut kullanıcıyı güncelleme
                                        query = @"UPDATE kullanicilar SET 
                                                kullanici_adi = @kullanici_adi, 
                                                sifre = IF(@sifre IS NULL OR @sifre = '', sifre, SHA2(@sifre, 256)),
                                                kullanici_yetki = @kullanici_yetki, 
                                                ad_soyad = @ad_soyad, 
                                                aktif = @aktif 
                                                WHERE kullanici_id = @kullanici_id";
                                    }

                                    // Şifre kontrolü
                                    object sifreValue = DBNull.Value;
                                    if (isNew)
                                    {
                                        // Yeni kullanıcı için şifre zorunlu
                                        if (row.Cells["kullanici_adi"].Value == null ||
                                            string.IsNullOrWhiteSpace(row.Cells["kullanici_adi"].Value.ToString()))
                                        {
                                            MessageBox.Show("Kullanıcı adı boş olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            transaction.Rollback();
                                            return;
                                        }

                                        if (row.Cells["sifre"].Value == null ||
                                            string.IsNullOrWhiteSpace(row.Cells["sifre"].Value?.ToString()))
                                        {
                                            MessageBox.Show("Yeni kullanıcı için şifre boş olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            transaction.Rollback();
                                            return;
                                        }
                                        sifreValue = row.Cells["sifre"].Value;
                                    }
                                    else
                                    {
                                        // Mevcut kullanıcı için şifre opsiyonel
                                        sifreValue = row.Cells["sifre"].Value == null ||
                                                    string.IsNullOrWhiteSpace(row.Cells["sifre"].Value?.ToString()) ?
                                                    DBNull.Value : row.Cells["sifre"].Value;
                                    }

                                    DatabaseHelper.ExecuteNonQuery(query, transaction,
                                        new MySqlParameter("@kullanici_adi", row.Cells["kullanici_adi"].Value ?? DBNull.Value),
                                        new MySqlParameter("@sifre", sifreValue),
                                        new MySqlParameter("@kullanici_yetki", row.Cells["kullanici_yetki"].Value ?? 2),
                                        new MySqlParameter("@ad_soyad", row.Cells["ad_soyad"].Value ?? DBNull.Value),
                                        new MySqlParameter("@aktif", row.Cells["aktif"].Value ?? true),
                                        new MySqlParameter("@kullanici_id", row.Cells["kullanici_id"].Value ?? DBNull.Value));
                                }
                            }
                            transaction.Commit();
                            MessageBox.Show("Değişiklikler başarıyla kaydedildi.",
                                "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadKullanicilar(); // Verileri yenile
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Kayıt sırasında hata oluştu: " + ex.Message,
                                "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bağlantı hatası: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewKullanicilar_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.Cells["kullanici_id"].Value != null &&
                e.Row.Cells["kullanici_id"].Value != DBNull.Value)
            {
                int kullaniciId = Convert.ToInt32(e.Row.Cells["kullanici_id"].Value);

                // Admin kullanıcısını silmeyi engelle
                if (kullaniciId == 1)
                {
                    MessageBox.Show("Admin kullanıcısı silinemez!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                    return;
                }

                DialogResult result = MessageBox.Show("Bu kullanıcıyı silmek istediğinize emin misiniz?",
                    "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        string query = "DELETE FROM kullanicilar WHERE kullanici_id = @kullanici_id";
                        DatabaseHelper.ExecuteNonQuery(query,
                            new MySqlParameter("@kullanici_id", kullaniciId));

                        MessageBox.Show("Kullanıcı başarıyla silindi.",
                            "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Silme işlemi sırasında hata oluştu: " + ex.Message,
                            "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                    }
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void dataGridViewKullanicilar_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Geçersiz veri girişi: " + e.Exception.Message,
                "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            e.ThrowException = false;
        }
    }
}