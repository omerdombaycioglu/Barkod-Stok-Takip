using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using StokTakipOtomasyonu.Helpers;
using System.Drawing;   

namespace StokTakipOtomasyonu.Forms
{
    public partial class KullaniciForm : Form
    {
        private DataGridViewComboBoxColumn yetkiColumn;

        public KullaniciForm()
        {
            InitializeComponent();
        }

        private void KullaniciForm_Load(object sender, EventArgs e)
        {
            // Yeni kullanıcı için yetki combobox'ını doldur
            cmbYeniYetki.Items.Add("Yönetici");
            cmbYeniYetki.Items.Add("Standart Kullanıcı");
            cmbYeniYetki.SelectedIndex = 1;

            KullanicilariYukle();
            DataGridViewAyarla();
        }

        private void KullanicilariYukle()
        {
            try
            {
                string query = "SELECT kullanici_id, kullanici_adi, sifre, ad_soyad, kullanici_yetki, aktif, kayit_tarihi FROM kullanicilar";
                DataTable dt = DatabaseHelper.ExecuteQuery(query);
                dgvKullanicilar.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kullanıcılar yüklenirken hata oluştu: " + ex.Message,
                              "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridViewAyarla()
        {
            dgvKullanicilar.AutoGenerateColumns = false;
            dgvKullanicilar.Columns.Clear();

            // ID kolonu
            dgvKullanicilar.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "kullanici_id",
                HeaderText = "ID",
                Name = "colId",
                ReadOnly = true
            });

            // Kullanıcı Adı kolonu
            dgvKullanicilar.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "kullanici_adi",
                HeaderText = "Kullanıcı Adı",
                Name = "colKullaniciAdi"
            });

            // Şifre kolonu
            dgvKullanicilar.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "sifre",
                HeaderText = "Şifre",
                Name = "colSifre"
            });

            // Ad Soyad kolonu
            dgvKullanicilar.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "ad_soyad",
                HeaderText = "Ad Soyad",
                Name = "colAdSoyad"
            });

            // Yetki ComboBox kolonu
            yetkiColumn = new DataGridViewComboBoxColumn();
            yetkiColumn.DataPropertyName = "kullanici_yetki";
            yetkiColumn.HeaderText = "Yetki";
            yetkiColumn.Name = "colYetki";

            // ComboBox için veri kaynağı oluştur
            DataTable yetkiData = new DataTable();
            yetkiData.Columns.Add("Value", typeof(int));
            yetkiData.Columns.Add("Display", typeof(string));
            yetkiData.Rows.Add(1, "Yönetici");
            yetkiData.Rows.Add(2, "Standart Kullanıcı");

            yetkiColumn.DataSource = yetkiData;
            yetkiColumn.ValueMember = "Value";
            yetkiColumn.DisplayMember = "Display";
            yetkiColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing; // Daha temiz görünüm

            dgvKullanicilar.Columns.Add(yetkiColumn);

            // Aktif kolonu
            dgvKullanicilar.Columns.Add(new DataGridViewCheckBoxColumn()
            {
                DataPropertyName = "aktif",
                HeaderText = "Aktif",
                Name = "colAktif"
            });

            // Kayıt Tarihi kolonu
            dgvKullanicilar.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "kayit_tarihi",
                HeaderText = "Kayıt Tarihi",
                Name = "colKayitTarihi",
                ReadOnly = true
            });

            // Silme butonu
            var btnSil = new DataGridViewButtonColumn()
            {
                HeaderText = "Sil",
                Text = "Sil",
                Name = "colSil",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat,
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    BackColor = Color.LightCoral,
                    ForeColor = Color.White
                }
            };
            dgvKullanicilar.Columns.Add(btnSil);

            // DataGridView ayarları
            dgvKullanicilar.AllowUserToAddRows = false;
            dgvKullanicilar.AllowUserToDeleteRows = false;
            dgvKullanicilar.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvKullanicilar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKullanicilar.RowHeadersVisible = false;
            dgvKullanicilar.Columns["colKayitTarihi"].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";

            // Event handlers
            dgvKullanicilar.DataError += DgvKullanicilar_DataError;
            dgvKullanicilar.CellFormatting += DgvKullanicilar_CellFormatting;
            dgvKullanicilar.CellParsing += DgvKullanicilar_CellParsing;
        }

        private void DgvKullanicilar_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception != null && e.Context.HasFlag(DataGridViewDataErrorContexts.Commit))
            {
                MessageBox.Show("Geçersiz veri girişi. Lütfen geçerli bir değer seçin.",
                              "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.ThrowException = false;
                e.Cancel = true;
            }
        }

        private void DgvKullanicilar_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // ComboBox sütunundaki değerleri görüntüleme
            if (e.ColumnIndex == yetkiColumn.Index && e.Value != null)
            {
                if (e.Value.ToString() == "1")
                    e.Value = "Yönetici";
                else if (e.Value.ToString() == "2")
                    e.Value = "Standart Kullanıcı";
                e.FormattingApplied = true;
            }
        }

        private void DgvKullanicilar_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            // ComboBox sütunundaki değerleri veritabanına kaydetme
            if (e.ColumnIndex == yetkiColumn.Index)
            {
                if (e.Value.ToString() == "Yönetici")
                    e.Value = 1;
                else if (e.Value.ToString() == "Standart Kullanıcı")
                    e.Value = 2;
                e.ParsingApplied = true;
            }
        }

        private void dgvKullanicilar_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            try
            {
                DataGridViewRow row = dgvKullanicilar.Rows[e.RowIndex];
                int kullaniciId = Convert.ToInt32(row.Cells["colId"].Value);

                string columnName = dgvKullanicilar.Columns[e.ColumnIndex].DataPropertyName;
                object newValue = row.Cells[e.ColumnIndex].Value;

                string query = $"UPDATE kullanicilar SET {columnName} = @value WHERE kullanici_id = @id";
                MySqlParameter[] parameters = {
                    new MySqlParameter("@value", newValue),
                    new MySqlParameter("@id", kullaniciId)
                };

                int affectedRows = DatabaseHelper.ExecuteNonQuery(query, parameters);
                if (affectedRows > 0)
                {
                    MessageBox.Show("Değişiklikler kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Değişiklikler kaydedilirken hata oluştu: " + ex.Message,
                              "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                KullanicilariYukle();
            }
        }

        private void dgvKullanicilar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvKullanicilar.Columns[e.ColumnIndex].Name == "colSil")
            {
                int kullaniciId = Convert.ToInt32(dgvKullanicilar.Rows[e.RowIndex].Cells["colId"].Value);
                string kullaniciAdi = dgvKullanicilar.Rows[e.RowIndex].Cells["colKullaniciAdi"].Value.ToString();

                if (MessageBox.Show($"{kullaniciAdi} kullanıcısını silmek istediğinize emin misiniz?",
                    "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        string query = "DELETE FROM kullanicilar WHERE kullanici_id = @id";
                        int affectedRows = DatabaseHelper.ExecuteNonQuery(query, new MySqlParameter("@id", kullaniciId));

                        if (affectedRows > 0)
                        {
                            MessageBox.Show("Kullanıcı başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            KullanicilariYukle();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Kullanıcı silinirken hata oluştu: " + ex.Message,
                                      "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnYeniKullanici_Click(object sender, EventArgs e)
        {
            try
            {
                // Giriş doğrulama
                if (string.IsNullOrWhiteSpace(txtYeniKullaniciAdi.Text))
                {
                    MessageBox.Show("Kullanıcı adı boş olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtYeniKullaniciAdi.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtYeniSifre.Text))
                {
                    MessageBox.Show("Şifre boş olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtYeniSifre.Focus();
                    return;
                }

                // Yetki kontrolü
                if (cmbYeniYetki.SelectedIndex == -1)
                {
                    MessageBox.Show("Lütfen bir yetki seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbYeniYetki.Focus();
                    return;
                }

                string kullaniciAdi = txtYeniKullaniciAdi.Text.Trim();
                string sifre = txtYeniSifre.Text.Trim();
                string adSoyad = txtYeniAdSoyad.Text.Trim();
                int yetki = cmbYeniYetki.SelectedIndex + 1; // 1: Yönetici, 2: Standart Kullanıcı

                // Kullanıcı adı kontrolü
                string checkQuery = "SELECT COUNT(*) FROM kullanicilar WHERE kullanici_adi = @kadi";
                var count = DatabaseHelper.ExecuteScalar(checkQuery, new MySqlParameter("@kadi", kullaniciAdi));

                if (Convert.ToInt32(count) > 0)
                {
                    MessageBox.Show("Bu kullanıcı adı zaten kayıtlı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtYeniKullaniciAdi.Focus();
                    return;
                }

                // Kullanıcı ekleme sorgusu
                string insertQuery = @"INSERT INTO kullanicilar 
                            (kullanici_adi, sifre, kullanici_yetki, ad_soyad, aktif, kayit_tarihi) 
                            VALUES (@kadi, @sifre, @yetki, @adsoyad, 1, NOW())";

                MySqlParameter[] parameters = {
            new MySqlParameter("@kadi", kullaniciAdi),
            new MySqlParameter("@sifre", sifre),
            new MySqlParameter("@yetki", yetki),
            new MySqlParameter("@adsoyad", string.IsNullOrWhiteSpace(adSoyad) ? DBNull.Value : (object)adSoyad)
        };

                int affectedRows = DatabaseHelper.ExecuteNonQuery(insertQuery, parameters);

                if (affectedRows > 0)
                {
                    MessageBox.Show("Kullanıcı başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Alanları temizle
                    txtYeniKullaniciAdi.Text = "";
                    txtYeniSifre.Text = "";
                    txtYeniAdSoyad.Text = "";
                    cmbYeniYetki.SelectedIndex = 1;

                    // Listeyi yenile
                    KullanicilariYukle();
                }
                else
                {
                    MessageBox.Show("Kullanıcı eklenirken bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kullanıcı eklenirken hata oluştu: {ex.Message}",
                              "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
