// Bu dosya, "kat" ve "konum" kolonlarının "harf" ve "numara" olarak değiştirildiği yeni sürüme uyarlanmış tam halidir.
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace StokTakipOtomasyonu.Forms
{
    public partial class DepoDuzenleForm : Form
    {
        private MySqlConnection connection;
        private string connectionString = "server=localhost;database=stok_takip_otomasyonu;uid=root;pwd=;";
        private DataTable allProducts;
        private int currentUrunId = -1;
        private int urunToplamMiktar = 0;
        private int depodakiToplamMiktar = 0;

        public DepoDuzenleForm()
        {
            InitializeComponent();
            connection = new MySqlConnection(connectionString);
            SetupBarkodAutoComplete();
            lblUyari.Visible = false;
            lblUyari2.Visible = false;

            lblUyari.AutoSize = true;
            lblUyari2.AutoSize = true;

            LoadDepoKonumlari();

            dgvDepoKonumlari.AllowUserToAddRows = false;
            dgvDepoKonumlari.DataSource = new DataTable();
            dgvDepoKonumlari.CellClick += dgvDepoKonumlari_CellClick;
            txtBarkodArama.TextChanged += txtBarkodArama_TextChanged;

        }



        private void SetupBarkodAutoComplete()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                string query = @"SELECT urun_id, urun_barkod, urun_kodu, urun_adi, urun_marka,
                         CONCAT(urun_kodu, ' - ', urun_adi) AS urun_bilgisi 
                         FROM urunler 
                         ORDER BY urun_adi";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                allProducts = new DataTable();
                adapter.Fill(allProducts);

                txtBarkodArama.AutoCompleteMode = AutoCompleteMode.None;
                txtBarkodArama.AutoCompleteSource = AutoCompleteSource.None;
                txtBarkodArama.AutoCompleteCustomSource = null;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Barkod bilgileri yüklenirken hata oluştu: " + ex.Message,
                              "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }


        private void LoadDepoKonumlari()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                string query = "SELECT id, CONCAT(harf, ' - ', numara) AS konum_bilgisi FROM depo_konum ORDER BY harf, numara";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                cmbKatKonum.Items.Clear();
                while (reader.Read())
                {
                    cmbKatKonum.Items.Add(new ComboboxItem(
                        reader["konum_bilgisi"].ToString(),
                        Convert.ToInt32(reader["id"])));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Depo konumları yüklenirken hata oluştu: " + ex.Message,
                              "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void dgvDepoKonumlari_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Negatif değer varsa hiçbir işlem yapma
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            // Grid boşsa veya sütun yoksa işlem yapma
            if (dgvDepoKonumlari.Columns.Count == 0) return;

            var columnName = dgvDepoKonumlari.Columns[e.ColumnIndex].Name;

            if (columnName == "colGuncelle")
            {
                DepoKonumuGuncelle(e.RowIndex);
            }
            else if (columnName == "colSil")
            {
                DepoKonumuSil(e.RowIndex);
            }
        }



        private void DataGridViewAyarla()
        {
            dgvDepoKonumlari.AllowUserToAddRows = false;
            dgvDepoKonumlari.AutoGenerateColumns = false;
            dgvDepoKonumlari.Columns.Clear();

            DataGridViewTextBoxColumn urunAdiColumn = new DataGridViewTextBoxColumn();
            urunAdiColumn.DataPropertyName = "urun_bilgisi";
            urunAdiColumn.HeaderText = "Ürün";
            urunAdiColumn.Name = "colUrun";
            urunAdiColumn.ReadOnly = true;
            urunAdiColumn.Width = 200;

            DataGridViewTextBoxColumn harfColumn = new DataGridViewTextBoxColumn();
            harfColumn.DataPropertyName = "harf";
            harfColumn.HeaderText = "Harf";
            harfColumn.Name = "colHarf";
            harfColumn.ReadOnly = true;
            harfColumn.Width = 100;

            DataGridViewTextBoxColumn numaraColumn = new DataGridViewTextBoxColumn();
            numaraColumn.DataPropertyName = "numara";
            numaraColumn.HeaderText = "Numara";
            numaraColumn.Name = "colNumara";
            numaraColumn.ReadOnly = true;
            numaraColumn.Width = 100;

            DataGridViewTextBoxColumn miktarColumn = new DataGridViewTextBoxColumn();
            miktarColumn.DataPropertyName = "miktar";
            miktarColumn.HeaderText = "Miktar";
            miktarColumn.Name = "colMiktar";
            miktarColumn.Width = 80;

            DataGridViewButtonColumn guncelleColumn = new DataGridViewButtonColumn();
            guncelleColumn.HeaderText = "İşlem";
            guncelleColumn.Name = "colGuncelle";
            guncelleColumn.Text = "Güncelle";
            guncelleColumn.UseColumnTextForButtonValue = true;
            guncelleColumn.Width = 80;

            DataGridViewButtonColumn silColumn = new DataGridViewButtonColumn();
            silColumn.HeaderText = "";
            silColumn.Name = "colSil";
            silColumn.Text = "Sil";
            silColumn.UseColumnTextForButtonValue = true;
            silColumn.Width = 60;

            DataGridViewTextBoxColumn depoKonumIdColumn = new DataGridViewTextBoxColumn();
            depoKonumIdColumn.DataPropertyName = "depo_konum_id";
            depoKonumIdColumn.HeaderText = "DepoKonumID";
            depoKonumIdColumn.Name = "colDepoKonumId";
            depoKonumIdColumn.Visible = false;

            dgvDepoKonumlari.Columns.AddRange(new DataGridViewColumn[] {
                urunAdiColumn, harfColumn, numaraColumn, miktarColumn, guncelleColumn, silColumn, depoKonumIdColumn
            });
        }

        private void UrunBilgileriniYukle(int urunId)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                string query = @"SELECT u.urun_id, u.urun_adi, u.urun_kodu, u.urun_barkod, u.miktar AS toplam_miktar,
               (SELECT SUM(ud.miktar) FROM urun_depo_konum ud WHERE ud.urun_id = u.urun_id) AS depodaki_toplam
               FROM urunler u WHERE u.urun_id = @urunId";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@urunId", urunId);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lblUrunBilgi.Text = $"{reader["urun_kodu"]} - {reader["urun_adi"]} (Barkod: {reader["urun_barkod"]})";
                            urunToplamMiktar = Convert.ToInt32(reader["toplam_miktar"]);
                            lblToplamMiktar.Text = $"Toplam: {urunToplamMiktar}";

                            depodakiToplamMiktar = reader["depodaki_toplam"] != DBNull.Value ?
                                                Convert.ToInt32(reader["depodaki_toplam"]) : 0;
                            lblDepodakiToplam.Text = $"Depoda: {depodakiToplamMiktar}";

                            lblUyari.Visible = false;
                            lblUyari2.Visible = false;

                            if (urunToplamMiktar > depodakiToplamMiktar)
                            {
                                int fark = urunToplamMiktar - depodakiToplamMiktar;
                                lblUyari2.Visible = true;
                                lblUyari2.Text = $"UYARI: {fark} adet ürünün depo konumu belirtilmemiş!";
                                lblUyari2.ForeColor = Color.Red;
                            }
                            else
                            {
                                lblUyari2.Visible = false;
                            }


                            if (depodakiToplamMiktar > urunToplamMiktar)
                            {
                                lblUyari.Visible = true;
                                lblUyari.Text = "UYARI: Depodaki toplam miktar ürün kaydıyla uyuşmuyor!";
                                lblUyari.ForeColor = Color.Red;
                            }
                            else
                            {
                                lblUyari.Visible = false;
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürün bilgileri yüklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void txtBarkodArama_TextChanged(object sender, EventArgs e)
        {
            string arama = txtBarkodArama.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(arama))
            {
                currentUrunId = -1;
                lblUrunBilgi.Text = "";
                dgvDepoKonumlari.DataSource = new DataTable();
                lblToplamMiktar.Text = "Toplam: 0";
                lblDepodakiToplam.Text = "Depoda: 0";
                lblUyari.Visible = false;
                lblUyari2.Visible = false;
                return;
            }

            var eslesenler = allProducts.AsEnumerable()
                .Where(row =>
                    row["urun_barkod"].ToString().ToLower().Contains(arama) ||
                    row["urun_kodu"].ToString().ToLower().Contains(arama) ||
                    row["urun_adi"].ToString().ToLower().Contains(arama) ||
                    row["urun_marka"].ToString().ToLower().Contains(arama))
                .Select(row => Convert.ToInt32(row["urun_id"]))
                .Distinct()
                .ToList();

            if (eslesenler.Count == 0)
            {
                dgvDepoKonumlari.DataSource = new DataTable();
                lblUrunBilgi.Text = "Ürün bulunamadı";
                lblToplamMiktar.Text = "Toplam: 0";
                lblDepodakiToplam.Text = "Depoda: 0";
                return;
            }

            currentUrunId = -1; // Çoklu modda spesifik ürün seçilmiyor

            // Tüm eşleşen ürünlerin depo konumlarını getir
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                string idListesi = string.Join(",", eslesenler);

                string query = $@"
            SELECT 
                CONCAT(u.urun_kodu, ' - ', u.urun_adi) AS urun_bilgisi,
                d.harf,
                d.numara,
                ud.miktar,
                ud.depo_konum_id
            FROM urun_depo_konum ud
            JOIN urunler u ON ud.urun_id = u.urun_id
            JOIN depo_konum d ON ud.depo_konum_id = d.id
            WHERE ud.urun_id IN ({idListesi})
            ORDER BY u.urun_kodu, d.harf, d.numara";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    DataGridViewAyarla();
                    dgvDepoKonumlari.DataSource = dt;

                    int toplamDepo = dt.AsEnumerable().Sum(r => Convert.ToInt32(r["miktar"]));
                    lblUrunBilgi.Text = $"Eşleşen {eslesenler.Count} ürün gösteriliyor";
                    lblToplamMiktar.Text = "";
                    lblDepodakiToplam.Text = $"Toplam Depoda: {toplamDepo}";
                    lblUyari.Visible = false;
                    lblUyari2.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri getirilirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }



        private void DepoKonumuGuncelle(int rowIndex)
        {
            int depoKonumId = Convert.ToInt32(dgvDepoKonumlari.Rows[rowIndex].Cells["colDepoKonumId"].Value);
            int yeniMiktar = Convert.ToInt32(dgvDepoKonumlari.Rows[rowIndex].Cells["colMiktar"].Value);

            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                string query = "UPDATE urun_depo_konum SET miktar = @miktar WHERE depo_konum_id = @id";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@miktar", yeniMiktar);
                cmd.Parameters.AddWithValue("@id", depoKonumId);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Miktar güncellendi.", "Başarılı");

                // Refresh ekran
                UrunBilgileriniYukle(currentUrunId);
                UrunKonumlariniYukle(currentUrunId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }



        private void DepoKonumuSil(int rowIndex)
        {
            int depoKonumId = Convert.ToInt32(dgvDepoKonumlari.Rows[rowIndex].Cells["colDepoKonumId"].Value);
            var onay = MessageBox.Show("Bu konumu silmek istediğinize emin misiniz?", "Onay",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (onay == DialogResult.Yes)
            {
                try
                {
                    if (connection.State != ConnectionState.Open)
                        connection.Open();

                    string query = "DELETE FROM urun_depo_konum WHERE depo_konum_id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@id", depoKonumId);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Konum silindi.", "Bilgi");
                    UrunKonumlariniYukle(currentUrunId);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }
        }




        private void BarkodAraVeYukle()
        {
            if (string.IsNullOrWhiteSpace(txtBarkodArama.Text))
            {
                MessageBox.Show("Lütfen bir barkod giriniz!", "Uyarı",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                string query = "SELECT urun_id FROM urunler WHERE urun_barkod = @barkod";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@barkod", txtBarkodArama.Text);
                object result = cmd.ExecuteScalar();

                if (result == null)
                {
                    MessageBox.Show("Belirtilen barkoda sahip ürün bulunamadı!", "Uyarı",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                currentUrunId = Convert.ToInt32(result);
                UrunBilgileriniYukle(currentUrunId);
                UrunKonumlariniYukle(currentUrunId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Barkod aranırken hata oluştu: " + ex.Message,
                              "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
        private void UrunKonumlariniYukle(int urunId)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                string query = @"SELECT 
                CONCAT(u.urun_kodu, ' - ', u.urun_adi) AS urun_bilgisi,
                d.harf,
                d.numara,
                ud.miktar,
                ud.depo_konum_id
               FROM urun_depo_konum ud
               JOIN urunler u ON ud.urun_id = u.urun_id
               JOIN depo_konum d ON ud.depo_konum_id = d.id
               WHERE ud.urun_id = @urunId
               ORDER BY d.harf, d.numara";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@urunId", urunId);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    DataGridViewAyarla(); // ← SADECE ÜRÜN VARSA
                    dgvDepoKonumlari.DataSource = dt;

                    depodakiToplamMiktar = dt.AsEnumerable().Sum(row => Convert.ToInt32(row["miktar"]));
                    lblDepodakiToplam.Text = $"Depoda: {depodakiToplamMiktar}";

                    if (depodakiToplamMiktar > urunToplamMiktar)
                    {
                        lblUyari.Visible = true;
                        lblUyari.Text = "UYARI: Depodaki toplam miktar ürün kaydıyla uyuşmuyor!";
                        lblUyari.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblUyari.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürün konumları yüklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }




        private void btnYeniKonumEkle_Click(object sender, EventArgs e)
        {
            if (currentUrunId <= 0)
            {
                MessageBox.Show("Lütfen önce barkod ile bir ürün arayın.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbKatKonum.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir depo konumu seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtMiktar.Text.Trim(), out int miktar) || miktar <= 0)
            {
                MessageBox.Show("Geçerli bir miktar giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int secilenKonumId = ((ComboboxItem)cmbKatKonum.SelectedItem).Value;

            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                // Aynı ürün ve konum daha önce eklenmiş mi?
                string kontrolQuery = "SELECT COUNT(*) FROM urun_depo_konum WHERE urun_id = @urunId AND depo_konum_id = @konumId";
                MySqlCommand kontrolCmd = new MySqlCommand(kontrolQuery, connection);
                kontrolCmd.Parameters.AddWithValue("@urunId", currentUrunId);
                kontrolCmd.Parameters.AddWithValue("@konumId", secilenKonumId);
                int kayitVar = Convert.ToInt32(kontrolCmd.ExecuteScalar());

                if (kayitVar > 0)
                {
                    // Güncelle
                    string guncelleQuery = "UPDATE urun_depo_konum SET miktar = miktar + @miktar WHERE urun_id = @urunId AND depo_konum_id = @konumId";
                    MySqlCommand guncelleCmd = new MySqlCommand(guncelleQuery, connection);
                    guncelleCmd.Parameters.AddWithValue("@miktar", miktar);
                    guncelleCmd.Parameters.AddWithValue("@urunId", currentUrunId);
                    guncelleCmd.Parameters.AddWithValue("@konumId", secilenKonumId);
                    guncelleCmd.ExecuteNonQuery();
                }
                else
                {
                    // Yeni ekle
                    string ekleQuery = "INSERT INTO urun_depo_konum (urun_id, depo_konum_id, miktar) VALUES (@urunId, @konumId, @miktar)";
                    MySqlCommand ekleCmd = new MySqlCommand(ekleQuery, connection);
                    ekleCmd.Parameters.AddWithValue("@urunId", currentUrunId);
                    ekleCmd.Parameters.AddWithValue("@konumId", secilenKonumId);
                    ekleCmd.Parameters.AddWithValue("@miktar", miktar);
                    ekleCmd.ExecuteNonQuery();
                }

                MessageBox.Show("Konum eklendi/güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Formu yenile
                UrunKonumlariniYukle(currentUrunId);
                txtMiktar.Clear();
                cmbKatKonum.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Konum eklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

    public class ComboboxItem
    {
        public string Text { get; set; }
        public int Value { get; set; }

        public ComboboxItem(string text, int value)
        {
            Text = text;
            Value = value;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}