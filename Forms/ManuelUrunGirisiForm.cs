using MySql.Data.MySqlClient;
using StokTakipOtomasyonu.Helpers;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace StokTakipOtomasyonu.Forms
{
    public partial class ManuelUrunGirisiForm : Form
    {
        private int _kullaniciId;
        private DataTable _urunlerDt;

        public ManuelUrunGirisiForm(int kullaniciId)
        {
            InitializeComponent();
            _kullaniciId = kullaniciId;
            IslemTurleriYukle();
            TumUrunleriYukle();
            txtBarkod.Focus();
        }

        private void IslemTurleriYukle()
        {
            try
            {
                // Sadece Stok (0) ve Proje (1) işlem türlerini yükle
                string query = "SELECT * FROM islem_turu WHERE islem_turu_id IN (0, 1)";
                var dt = DatabaseHelper.ExecuteQuery(query);

                cmbIslemTuru.DataSource = dt;
                cmbIslemTuru.DisplayMember = "tanim";
                cmbIslemTuru.ValueMember = "islem_turu_id";
                cmbIslemTuru.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("İşlem türleri yüklenirken hata oluştu: " + ex.Message,
                              "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TumUrunleriYukle()
        {
            try
            {
                string query = "SELECT urun_id, urun_adi, urun_kodu, urun_barkod FROM urunler";
                _urunlerDt = DatabaseHelper.ExecuteQuery(query);

                var barkodSource = new AutoCompleteStringCollection();
                barkodSource.AddRange(_urunlerDt.AsEnumerable()
                    .Select(row => row.Field<string>("urun_barkod"))
                    .Where(b => !string.IsNullOrEmpty(b))
                    .ToArray());

                txtBarkod.AutoCompleteCustomSource = barkodSource;
                txtBarkod.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtBarkod.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürünler yüklenirken hata oluştu: " + ex.Message,
                              "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBarkodAra_Click(object sender, EventArgs e)
        {
            BarkodAra(txtBarkod.Text);
        }

        private void BarkodAra(string barkod)
        {
            if (string.IsNullOrWhiteSpace(barkod))
            {
                MessageBox.Show("Lütfen bir barkod numarası giriniz!",
                              "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = "SELECT urun_id, urun_adi, urun_kodu, miktar FROM urunler WHERE urun_barkod = @barkod";
                DataTable dt = DatabaseHelper.ExecuteQuery(query, new MySqlParameter("@barkod", barkod));

                if (dt.Rows.Count > 0)
                {
                    // Barkod bulundu, mevcut ürünü güncelleme modu
                    var row = dt.Rows[0];
                    lblUrunBilgisi.Text = $"{row["urun_adi"]} - {row["urun_kodu"]} (Stok: {row["miktar"]})";
                    txtMiktar.Enabled = true;
                    btnKaydet.Enabled = true;
                    panelYeniUrun.Visible = false;
                    this.Height = 270; // Normal boyut
                }
                else
                {
                    // Barkod bulunamadı, yeni ürün ekleme modu
                    lblUrunBilgisi.Text = "Yeni ürün kaydedilecek";
                    txtMiktar.Enabled = true;
                    btnKaydet.Enabled = true;
                    panelYeniUrun.Visible = true;
                    this.Height = 500; // Büyük boyut

                    // Varsayılan değerleri ayarla
                    txtUrunAdi.Text = "YENİ ÜRÜN";
                    txtUrunKodu.Text = barkod;
                    txtUrunMarka.Text = "";
                    txtUrunNo.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBarkod.Text) || string.IsNullOrWhiteSpace(txtMiktar.Text))
            {
                MessageBox.Show("Lütfen zorunlu alanları doldurun!",
                              "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtMiktar.Text, out int miktar) || miktar <= 0)
            {
                MessageBox.Show("Geçerli bir miktar giriniz!",
                              "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string barkod = txtBarkod.Text;
            string aciklama = txtAciklama.Text;
            int islemTuruId = Convert.ToInt32(cmbIslemTuru.SelectedValue);

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (var transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            int urunId;

                            // Ürün var mı kontrol et
                            string checkQuery = "SELECT urun_id FROM urunler WHERE urun_barkod = @barkod";
                            var checkDt = DatabaseHelper.ExecuteQuery(checkQuery, transaction,
                                new MySqlParameter("@barkod", barkod));

                            if (checkDt.Rows.Count == 0)
                            {
                                // Yeni ürün ekle (ürün adı zorunlu değil)
                                string urunAdi = string.IsNullOrWhiteSpace(txtUrunAdi.Text) ? "YENİ ÜRÜN" : txtUrunAdi.Text;

                                string insertQuery = @"INSERT INTO urunler 
                                    (urun_adi, urun_kodu, urun_barkod, urun_marka, urun_no, miktar) 
                                    VALUES 
                                    (@adi, @kod, @barkod, @marka, @no, 0);
                                    SELECT LAST_INSERT_ID();";

                                urunId = Convert.ToInt32(DatabaseHelper.ExecuteScalar(insertQuery, transaction,
                                    new MySqlParameter("@adi", urunAdi),
                                    new MySqlParameter("@kod", txtUrunKodu.Text),
                                    new MySqlParameter("@barkod", barkod),
                                    new MySqlParameter("@marka", txtUrunMarka.Text),
                                    new MySqlParameter("@no", txtUrunNo.Text)));
                            }
                            else
                            {
                                urunId = Convert.ToInt32(checkDt.Rows[0]["urun_id"]);
                            }

                            // Stok güncelleme
                            string updateQuery = "UPDATE urunler SET miktar = miktar + @miktar WHERE urun_id = @urunId";
                            DatabaseHelper.ExecuteNonQuery(updateQuery, transaction,
                                new MySqlParameter("@miktar", miktar),
                                new MySqlParameter("@urunId", urunId));

                            // Hareket kaydı
                            string insertHareketQuery = @"INSERT INTO urun_hareketleri 
                                                        (urun_id, hareket_turu, miktar, kullanici_id, aciklama, islem_turu_id) 
                                                        VALUES 
                                                        (@urunId, 'Giris', @miktar, @kullaniciId, @aciklama, @islemTuruId)";
                            DatabaseHelper.ExecuteNonQuery(insertHareketQuery, transaction,
                                new MySqlParameter("@urunId", urunId),
                                new MySqlParameter("@miktar", miktar),
                                new MySqlParameter("@kullaniciId", _kullaniciId),
                                new MySqlParameter("@aciklama", aciklama),
                                new MySqlParameter("@islemTuruId", islemTuruId));

                            transaction.Commit();
                            MessageBox.Show("Ürün girişi başarıyla kaydedildi!",
                                          "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Hata: " + ex.Message,
                                          "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message,
                              "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBarkod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BarkodAra(txtBarkod.Text);
                e.SuppressKeyPress = true;
            }
        }
    }
}