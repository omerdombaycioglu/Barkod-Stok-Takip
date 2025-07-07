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
        private DataTable _projelerDt;

        public ManuelUrunGirisiForm(int kullaniciId)
        {
            InitializeComponent();
            _kullaniciId = kullaniciId;
            IslemTurleriYukle();
            ProjeleriYukle();
            TumUrunleriYukle();
            txtBarkod.Focus();

            // Event handlers
            btnBarkodAra.Click += BtnBarkodAra_Click;
            btnKaydet.Click += BtnKaydet_Click;
            btnIptal.Click += BtnIptal_Click;
            txtBarkod.KeyDown += TxtBarkod_KeyDown;
            cmbIslemTuru.SelectedIndexChanged += CmbIslemTuru_SelectedIndexChanged;
        }

        private void BtnBarkodAra_Click(object sender, EventArgs e)
        {
            BarkodAra(txtBarkod.Text);
        }

        private void ProjeleriYukle()
        {
            try
            {
                string query = "SELECT proje_id, proje_kodu, proje_tanimi FROM projeler WHERE aktif = 1";
                _projelerDt = DatabaseHelper.ExecuteQuery(query);

                cmbProje.DataSource = _projelerDt;
                cmbProje.DisplayMember = "proje_kodu";
                cmbProje.ValueMember = "proje_id";
                cmbProje.SelectedIndex = -1;
                cmbProje.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Projeler yüklenirken hata oluştu: " + ex.Message,
                              "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void IslemTurleriYukle()
        {
            try
            {
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

        private void CmbIslemTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbIslemTuru.SelectedValue != null)
            {
                DataRowView selectedRow = (DataRowView)cmbIslemTuru.SelectedItem;
                int selectedValue = Convert.ToInt32(selectedRow["islem_turu_id"]);
                bool isProje = (selectedValue == 1);

                lblProje.Visible = isProje;
                cmbProje.Visible = isProje;
                cmbProje.Enabled = isProje;

                if (!isProje)
                {
                    cmbProje.SelectedIndex = -1;
                }

                // Form boyutunu ayarla
                if (panelYeniUrun.Visible)
                {
                    this.Height = isProje ? 500 : 420;
                }
                else
                {
                    this.Height = isProje ? 350 : 270;
                }
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
                    var row = dt.Rows[0];
                    lblUrunBilgisi.Text = $"{row["urun_adi"]} - {row["urun_kodu"]} (Stok: {row["miktar"]})";
                    txtMiktar.Enabled = true;
                    btnKaydet.Enabled = true;
                    panelYeniUrun.Visible = false;

                    bool isProje = cmbIslemTuru.SelectedValue != null &&
                                 Convert.ToInt32(((DataRowView)cmbIslemTuru.SelectedItem)["islem_turu_id"]) == 1;
                    this.Height = isProje ? 350 : 270;
                }
                else
                {
                    lblUrunBilgisi.Text = "Yeni ürün kaydedilecek";
                    txtMiktar.Enabled = true;
                    btnKaydet.Enabled = true;
                    panelYeniUrun.Visible = true;

                    bool isProje = cmbIslemTuru.SelectedValue != null &&
                                 Convert.ToInt32(((DataRowView)cmbIslemTuru.SelectedItem)["islem_turu_id"]) == 1;
                    this.Height = isProje ? 500 : 420;

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

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBarkod.Text) || string.IsNullOrWhiteSpace(txtMiktar.Text))
            {
                MessageBox.Show("Lütfen zorunlu alanları doldurun!",
                              "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (panelYeniUrun.Visible && string.IsNullOrWhiteSpace(txtUrunAdi.Text))
            {
                MessageBox.Show("Ürün adı zorunludur!",
                              "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUrunAdi.Focus();
                return;
            }

            if (!int.TryParse(txtMiktar.Text, out int miktar) || miktar <= 0)
            {
                MessageBox.Show("Geçerli bir miktar giriniz!",
                              "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataRowView selectedRow = (DataRowView)cmbIslemTuru.SelectedItem;
            int islemTuruId = Convert.ToInt32(selectedRow["islem_turu_id"]);

            if (islemTuruId == 1 && (cmbProje.SelectedIndex == -1 || cmbProje.SelectedValue == null))
            {
                MessageBox.Show("Proje işlemi için proje seçimi zorunludur!",
                              "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string barkod = txtBarkod.Text;
            string aciklama = txtAciklama.Text;

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

                            string checkQuery = "SELECT urun_id FROM urunler WHERE urun_barkod = @barkod";
                            var checkDt = DatabaseHelper.ExecuteQuery(checkQuery, transaction,
                                new MySqlParameter("@barkod", barkod));

                            if (checkDt.Rows.Count == 0)
                            {
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

                            if (islemTuruId == 0) // Stok işlemi
                            {
                                string updateQuery = "UPDATE urunler SET miktar = miktar + @miktar WHERE urun_id = @urunId";
                                DatabaseHelper.ExecuteNonQuery(updateQuery, transaction,
                                    new MySqlParameter("@miktar", miktar),
                                    new MySqlParameter("@urunId", urunId));
                            }

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

                            if (islemTuruId == 1) // Proje işlemi
                            {
                                int projeId = Convert.ToInt32(cmbProje.SelectedValue);

                                // Önce bu ürünün projede olup olmadığını kontrol et
                                string checkProjeUrunQuery = @"SELECT id FROM proje_urunleri 
                                                     WHERE proje_id = @projeId AND urun_id = @urunId";
                                var checkProjeUrunDt = DatabaseHelper.ExecuteQuery(checkProjeUrunQuery, transaction,
                                    new MySqlParameter("@projeId", projeId),
                                    new MySqlParameter("@urunId", urunId));

                                if (checkProjeUrunDt.Rows.Count > 0)
                                {
                                    // Var olan kaydı güncelle
                                    string updateProjeUrunQuery = @"UPDATE proje_urunleri 
                                                          SET miktar = miktar + @miktar 
                                                          WHERE proje_id = @projeId AND urun_id = @urunId";
                                    DatabaseHelper.ExecuteNonQuery(updateProjeUrunQuery, transaction,
                                        new MySqlParameter("@miktar", miktar),
                                        new MySqlParameter("@projeId", projeId),
                                        new MySqlParameter("@urunId", urunId));
                                }
                                else
                                {
                                    // Yeni kayıt oluştur
                                    string insertProjeUrunQuery = @"INSERT INTO proje_urunleri 
                                                          (proje_id, urun_id, miktar, user_id) 
                                                          VALUES 
                                                          (@projeId, @urunId, @miktar, @userId)";
                                    DatabaseHelper.ExecuteNonQuery(insertProjeUrunQuery, transaction,
                                        new MySqlParameter("@projeId", projeId),
                                        new MySqlParameter("@urunId", urunId),
                                        new MySqlParameter("@miktar", miktar),
                                        new MySqlParameter("@userId", _kullaniciId));
                                }
                            }

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

        private void BtnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtBarkod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BarkodAra(txtBarkod.Text);
                e.SuppressKeyPress = true;
            }
        }
    }
}