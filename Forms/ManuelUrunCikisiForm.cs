using MySql.Data.MySqlClient;
using StokTakipOtomasyonu.Forms;
using StokTakipOtomasyonu.Helpers;
using System;
using System.Data;
using System.Windows.Forms;

namespace StokTakipOtomasyonu.Forms
{
    public partial class ManuelUrunCikisiForm : Form
    {
        private int _kullaniciId;
        private int _secilenUrunId = 0;
        private int _mevcutStok = 0;
        private int _projelerdekiToplam = 0;

        public ManuelUrunCikisiForm(int kullaniciId)
        {
            InitializeComponent();
            _kullaniciId = kullaniciId;
            IslemTurleriniYukle();
            ProjeleriYukle();
            cmbProjeler.Enabled = false;

            // Event handlers
            cmbProjeler.SelectedIndexChanged += cmbProjeler_SelectedIndexChanged; // Yeni eklenen satır
        }

        private void IslemTurleriniYukle()
        {
            try
            {
                string query = "SELECT islem_turu_id, tanim FROM islem_turu";
                DataTable dt = DatabaseHelper.ExecuteQuery(query);

                cmbIslemTuru.DisplayMember = "tanim";
                cmbIslemTuru.ValueMember = "islem_turu_id";
                cmbIslemTuru.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("İşlem türleri yüklenirken hata oluştu: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ProjeleriYukle()
        {
            try
            {
                string query = "SELECT proje_id, CONCAT(proje_kodu, ' - ', proje_tanimi) AS proje_bilgisi FROM projeler WHERE aktif = 1";
                DataTable dt = DatabaseHelper.ExecuteQuery(query);

                cmbProjeler.DisplayMember = "proje_bilgisi";
                cmbProjeler.ValueMember = "proje_id";
                cmbProjeler.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Projeler yüklenirken hata oluştu: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbIslemTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbIslemTuru.SelectedItem != null && cmbIslemTuru.SelectedValue != null)
            {
                int islemTuruId;
                if (int.TryParse(cmbIslemTuru.SelectedValue.ToString(), out islemTuruId))
                {
                    cmbProjeler.Enabled = (islemTuruId == 1); // Sadece proje işlem türünde aktif
                }
            }
        }

        private void btnBarkodAra_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBarkod.Text))
            {
                MessageBox.Show("Lütfen bir barkod numarası giriniz!",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Ürün bilgilerini ve stok miktarını getir
                string urunQuery = @"SELECT urun_id, urun_adi, urun_kodu, miktar 
                                   FROM urunler 
                                   WHERE urun_barkod = @barkod";
                DataTable urunDt = DatabaseHelper.ExecuteQuery(urunQuery,
                    new MySqlParameter("@barkod", txtBarkod.Text));

                if (urunDt.Rows.Count == 0)
                {
                    MessageBox.Show("Bu barkod numarasına ait ürün bulunamadı!",
                        "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Temizle();
                    return;
                }

                DataRow urunRow = urunDt.Rows[0];
                _secilenUrunId = Convert.ToInt32(urunRow["urun_id"]);
                _mevcutStok = Convert.ToInt32(urunRow["miktar"]);

                // Projelerdeki toplam miktarı getir
                string projeQuery = @"SELECT IFNULL(SUM(miktar), 0) AS toplam 
                                    FROM proje_urunleri 
                                    WHERE urun_id = @urunId";
                DataTable projeDt = DatabaseHelper.ExecuteQuery(projeQuery,
                    new MySqlParameter("@urunId", _secilenUrunId));

                _projelerdekiToplam = Convert.ToInt32(projeDt.Rows[0]["toplam"]);

                // Bilgileri göster
                lblUrunBilgisi.Text = $"{urunRow["urun_adi"]} - {urunRow["urun_kodu"]}";
                lblStokMiktari.Text = $"Stok: {_mevcutStok}";
                lblProjedekiMiktar.Text = $"Projelerdeki Toplam: {_projelerdekiToplam}";

                // Projelerdeki bu ürünleri listele
                ProjedekiUrunleriListele(_secilenUrunId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürün bilgileri getirilirken hata oluştu: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ProjedekiUrunleriListele(int urunId)
        {
            try
            {
                string query = @"SELECT p.proje_kodu, p.proje_tanimi, pu.miktar
                       FROM proje_urunleri pu
                       JOIN projeler p ON pu.proje_id = p.proje_id
                       WHERE pu.urun_id = @urunId AND pu.miktar > 0"; // Sadece miktarı > 0 olanları getir

                DataTable dt = DatabaseHelper.ExecuteQuery(query,
                    new MySqlParameter("@urunId", urunId));

                dgvProjelerdekiUrunler.DataSource = dt;

                // Eğer hiç kayıt yoksa bir mesaj göster
                if (dt.Rows.Count == 0)
                {
                    lblProjedekiMiktar.Text = "Projelerde bu ürün bulunmamaktadır";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Projelerdeki ürünler listelenirken hata oluştu: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Temizle()
        {
            lblUrunBilgisi.Text = "Ürün Bilgisi:";
            lblStokMiktari.Text = "Stok:";
            lblProjedekiMiktar.Text = "Projelerdeki Toplam:";
            txtMiktar.Clear();
            txtAciklama.Clear();
            _secilenUrunId = 0;
            _mevcutStok = 0;
            _projelerdekiToplam = 0;
            dgvProjelerdekiUrunler.DataSource = null;
        }

        private void cmbProjeler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProjeler.SelectedValue != null)
            {
                // Seçilen projenin tanımını al
                int projeId = Convert.ToInt32(cmbProjeler.SelectedValue);
                string query = "SELECT proje_tanimi FROM projeler WHERE proje_id = @projeId";

                try
                {
                    DataTable dt = DatabaseHelper.ExecuteQuery(query,
                        new MySqlParameter("@projeId", projeId));

                    if (dt.Rows.Count > 0)
                    {
                        string projeTanimi = dt.Rows[0]["proje_tanimi"].ToString();

                        // Açıklama alanına ekle (varsa mevcut açıklamayı silmeden)
                        if (string.IsNullOrWhiteSpace(txtAciklama.Text))
                        {
                            txtAciklama.Text = $" {projeTanimi}";
                        }
                        else if (!txtAciklama.Text.Contains(projeTanimi))
                        {
                            txtAciklama.Text = $"Proje: {projeTanimi}\n{txtAciklama.Text}";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Proje bilgisi alınırken hata oluştu: " + ex.Message,
                        "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (_secilenUrunId == 0)
            {
                MessageBox.Show("Lütfen önce bir ürün seçiniz!",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtMiktar.Text) || cmbIslemTuru.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen tüm alanları doldurun!",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtMiktar.Text, out int miktar) || miktar <= 0)
            {
                MessageBox.Show("Geçerli bir miktar giriniz!",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int islemTuruId;
            if (!int.TryParse(cmbIslemTuru.SelectedValue?.ToString(), out islemTuruId))
            {
                MessageBox.Show("Geçersiz işlem türü seçimi!",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int? projeId = null;
            if (islemTuruId == 1) // Proje işlemi ise
            {
                if (cmbProjeler.SelectedIndex == -1)
                {
                    MessageBox.Show("Lütfen bir proje seçiniz!",
                        "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(cmbProjeler.SelectedValue?.ToString(), out int tempProjeId))
                {
                    MessageBox.Show("Geçersiz proje seçimi!",
                        "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                projeId = tempProjeId;

                // Projedeki mevcut miktarı kontrol et
                int projedekiMiktar = ProjedekiUrunMiktariniGetir(projeId.Value, _secilenUrunId);
                if (projedekiMiktar < miktar)
                {
                    MessageBox.Show($"Projede yeterli miktarda ürün yok! Projedeki miktar: {projedekiMiktar}",
                        "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else if (islemTuruId == 0 || islemTuruId == 2) // Stok veya Hurda/İade işlemi ise
            {
                if (_mevcutStok < miktar)
                {
                    MessageBox.Show($"Yetersiz stok! Mevcut stok: {_mevcutStok}",
                        "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

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
                            // Stok güncelleme (stok veya hurda/iade işlemlerinde)
                            if (islemTuruId == 0 || islemTuruId == 2) // Stok veya Hurda/İade
                            {
                                string updateQuery = "UPDATE urunler SET miktar = miktar - @miktar WHERE urun_id = @urunId";
                                var updateCmd = new MySqlCommand(updateQuery, conn, transaction);
                                updateCmd.Parameters.AddWithValue("@miktar", miktar);
                                updateCmd.Parameters.AddWithValue("@urunId", _secilenUrunId);
                                updateCmd.ExecuteNonQuery();
                            }
                            // Proje güncelleme (sadece proje işlemlerinde)
                            else if (islemTuruId == 1 && projeId.HasValue) // Proje
                            {
                                string projeUpdateQuery = @"UPDATE proje_urunleri 
                                                 SET miktar = miktar - @miktar 
                                                 WHERE proje_id = @projeId AND urun_id = @urunId";
                                var projeUpdateCmd = new MySqlCommand(projeUpdateQuery, conn, transaction);
                                projeUpdateCmd.Parameters.AddWithValue("@miktar", miktar);
                                projeUpdateCmd.Parameters.AddWithValue("@projeId", projeId.Value);
                                projeUpdateCmd.Parameters.AddWithValue("@urunId", _secilenUrunId);
                                projeUpdateCmd.ExecuteNonQuery();
                            }

                            // Hareket kaydı
                            string insertQuery = @"INSERT INTO urun_hareketleri 
                                        (urun_id, hareket_turu, miktar, kullanici_id, aciklama, islem_turu_id) 
                                        VALUES 
                                        (@urunId, 'Cikis', @miktar, @kullaniciId, @aciklama, @islemTuruId)";
                            var insertCmd = new MySqlCommand(insertQuery, conn, transaction);
                            insertCmd.Parameters.AddWithValue("@urunId", _secilenUrunId);
                            insertCmd.Parameters.AddWithValue("@miktar", miktar);
                            insertCmd.Parameters.AddWithValue("@kullaniciId", _kullaniciId);
                            insertCmd.Parameters.AddWithValue("@aciklama", aciklama);
                            insertCmd.Parameters.AddWithValue("@islemTuruId", islemTuruId);
                            insertCmd.ExecuteNonQuery();

                            transaction.Commit();
                            MessageBox.Show("Ürün çıkışı başarıyla kaydedildi!",
                                "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Temizle();
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

        private int ProjedekiUrunMiktariniGetir(int projeId, int urunId)
        {
            try
            {
                string query = @"SELECT miktar FROM proje_urunleri 
                               WHERE proje_id = @projeId AND urun_id = @urunId";
                DataTable dt = DatabaseHelper.ExecuteQuery(query,
                    new MySqlParameter("@projeId", projeId),
                    new MySqlParameter("@urunId", urunId));

                if (dt.Rows.Count > 0)
                {
                    return Convert.ToInt32(dt.Rows[0]["miktar"]);
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}


