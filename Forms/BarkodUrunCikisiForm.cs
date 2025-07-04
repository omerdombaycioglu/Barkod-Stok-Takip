using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace StokTakipOtomasyonu.Forms
{
    public partial class BarkodUrunCikisiForm : Form
    {
        private MySqlConnection connection;
        private string connectionString = "server=localhost;database=stok_takip_otomasyonu;uid=root;pwd=;";
        private int kullaniciId;

        public BarkodUrunCikisiForm(int kullaniciId)
        {
            InitializeComponent();
            this.kullaniciId = kullaniciId;
            connection = new MySqlConnection(connectionString);
            IslemTurleriniYukle();
            ProjeleriYukle();
        }

        private void IslemTurleriniYukle()
        {
            try
            {
                connection.Open();
                string query = "SELECT islem_turu_id, tanim FROM islem_turu";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                cmbIslemTuru.DataSource = dt;
                cmbIslemTuru.DisplayMember = "tanim";
                cmbIslemTuru.ValueMember = "islem_turu_id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void ProjeleriYukle()
        {
            try
            {
                connection.Open();
                string query = "SELECT proje_id, CONCAT(proje_kodu, ' - ', proje_tanimi) AS proje_bilgisi FROM projeler WHERE aktif = TRUE";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                cmbProjeler.DataSource = dt;
                cmbProjeler.DisplayMember = "proje_bilgisi";
                cmbProjeler.ValueMember = "proje_id";
                cmbProjeler.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void cmbIslemTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbIslemTuru.SelectedValue != null)
            {
                int islemTuruId = Convert.ToInt32(cmbIslemTuru.SelectedValue);
                cmbProjeler.Enabled = (islemTuruId == 1); // Sadece proje seçeneğinde proje seçilebilir
            }
        }

        private void btnBarkodOku_Click(object sender, EventArgs e)
        {
            string barkod = txtBarkod.Text.Trim();
            if (string.IsNullOrEmpty(barkod))
            {
                MessageBox.Show("Lütfen barkod giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                connection.Open();
                string query = "SELECT urun_id, urun_adi, urun_kodu, miktar FROM urunler WHERE urun_barkod = @barkod";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@barkod", barkod);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        lblUrunAdi.Text = reader["urun_adi"].ToString();
                        lblUrunKodu.Text = reader["urun_kodu"].ToString();
                        lblMevcutMiktar.Text = reader["miktar"].ToString();
                        txtMiktar.Enabled = true;
                        btnKaydet.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Barkod ile eşleşen ürün bulunamadı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Temizle();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBarkod.Text) || string.IsNullOrEmpty(txtMiktar.Text) || cmbIslemTuru.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen tüm alanları doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtMiktar.Text, out int miktar) || miktar <= 0)
            {
                MessageBox.Show("Geçerli bir miktar giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string barkod = txtBarkod.Text.Trim();
            int islemTuruId = Convert.ToInt32(cmbIslemTuru.SelectedValue);
            int? projeId = (islemTuruId == 1 && cmbProjeler.SelectedValue != null) ?
                Convert.ToInt32(cmbProjeler.SelectedValue) : (int?)null;
            string aciklama = txtAciklama.Text;

            try
            {
                connection.Open();

                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        int urunId = 0;
                        int mevcutStok = 0;

                        // Ürünü bul ve stok kontrolü
                        string findQuery = "SELECT urun_id, miktar FROM urunler WHERE urun_barkod = @barkod FOR UPDATE";
                        MySqlCommand findCmd = new MySqlCommand(findQuery, connection, transaction);
                        findCmd.Parameters.AddWithValue("@barkod", barkod);

                        using (MySqlDataReader reader = findCmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                urunId = reader.GetInt32("urun_id");
                                mevcutStok = reader.GetInt32("miktar");
                            }
                            else
                            {
                                MessageBox.Show("Ürün bulunamadı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                transaction.Rollback();
                                return;
                            }
                        }

                        if (mevcutStok < miktar)
                        {
                            MessageBox.Show($"Yetersiz stok! Mevcut stok: {mevcutStok}", "Uyarı",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            transaction.Rollback();
                            return;
                        }

                        // Stok güncelleme
                        string updateQuery = "UPDATE urunler SET miktar = miktar - @miktar WHERE urun_barkod = @barkod";
                        MySqlCommand updateCmd = new MySqlCommand(updateQuery, connection, transaction);
                        updateCmd.Parameters.AddWithValue("@miktar", miktar);
                        updateCmd.Parameters.AddWithValue("@barkod", barkod);
                        updateCmd.ExecuteNonQuery();

                        // Hareket kaydı ekleme
                        string insertQuery = @"INSERT INTO urun_hareketleri 
                                            (urun_id, hareket_turu, miktar, kullanici_id, aciklama, islem_turu_id, referans_id) 
                                            VALUES 
                                            (@urunId, 'Cikis', @miktar, @kullaniciId, @aciklama, @islemTuruId, @referansId)";
                        MySqlCommand insertCmd = new MySqlCommand(insertQuery, connection, transaction);
                        insertCmd.Parameters.AddWithValue("@urunId", urunId);
                        insertCmd.Parameters.AddWithValue("@miktar", miktar);
                        insertCmd.Parameters.AddWithValue("@kullaniciId", kullaniciId);
                        insertCmd.Parameters.AddWithValue("@aciklama", aciklama);
                        insertCmd.Parameters.AddWithValue("@islemTuruId", islemTuruId);
                        insertCmd.Parameters.AddWithValue("@referansId", projeId ?? (object)DBNull.Value);
                        insertCmd.ExecuteNonQuery();

                        // Proje ürünleri tablosuna ekleme (eğer proje ise)
                        if (islemTuruId == 1 && projeId.HasValue)
                        {
                            string projeUrunQuery = @"INSERT INTO proje_urunleri 
                                                    (proje_id, urun_id, miktar, user_id) 
                                                    VALUES 
                                                    (@projeId, @urunId, @miktar, @userId)";
                            MySqlCommand projeUrunCmd = new MySqlCommand(projeUrunQuery, connection, transaction);
                            projeUrunCmd.Parameters.AddWithValue("@projeId", projeId.Value);
                            projeUrunCmd.Parameters.AddWithValue("@urunId", urunId);
                            projeUrunCmd.Parameters.AddWithValue("@miktar", miktar);
                            projeUrunCmd.Parameters.AddWithValue("@userId", kullaniciId);
                            projeUrunCmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show("Ürün çıkışı başarıyla kaydedildi!", "Bilgi",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Temizle();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Hata: " + ex.Message, "Hata",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void Temizle()
        {
            txtBarkod.Text = "";
            lblUrunAdi.Text = "---";
            lblUrunKodu.Text = "---";
            lblMevcutMiktar.Text = "---";
            txtMiktar.Text = "";
            txtMiktar.Enabled = false;
            txtAciklama.Text = "";
            btnKaydet.Enabled = false;
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}