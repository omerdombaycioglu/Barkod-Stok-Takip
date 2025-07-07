using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

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
            DataGridViewAyarla();
            lblUyari.Visible = false;
            LoadDepoKonumlari();
        }

        private void SetupBarkodAutoComplete()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                string query = "SELECT urun_id, urun_barkod, CONCAT(urun_kodu, ' - ', urun_adi) AS urun_bilgisi FROM urunler WHERE urun_barkod IS NOT NULL ORDER BY urun_adi";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                allProducts = new DataTable();
                adapter.Fill(allProducts);

                txtBarkodArama.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtBarkodArama.AutoCompleteSource = AutoCompleteSource.CustomSource;

                AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();
                foreach (DataRow row in allProducts.Rows)
                {
                    autoComplete.Add(row["urun_barkod"].ToString());
                }
                txtBarkodArama.AutoCompleteCustomSource = autoComplete;
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

                string query = "SELECT id, CONCAT(kat, ' - ', konum) AS konum_bilgisi FROM depo_konum ORDER BY kat, konum";
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

        private void DataGridViewAyarla()
        {
            dgvDepoKonumlari.AutoGenerateColumns = false;
            dgvDepoKonumlari.Columns.Clear();

            DataGridViewTextBoxColumn urunAdiColumn = new DataGridViewTextBoxColumn();
            urunAdiColumn.DataPropertyName = "urun_bilgisi";
            urunAdiColumn.HeaderText = "Ürün";
            urunAdiColumn.Name = "colUrun";
            urunAdiColumn.ReadOnly = true;
            urunAdiColumn.Width = 200;

            DataGridViewTextBoxColumn katColumn = new DataGridViewTextBoxColumn();
            katColumn.DataPropertyName = "kat";
            katColumn.HeaderText = "Kat";
            katColumn.Name = "colKat";
            katColumn.ReadOnly = true;
            katColumn.Width = 100;

            DataGridViewTextBoxColumn konumColumn = new DataGridViewTextBoxColumn();
            konumColumn.DataPropertyName = "konum";
            konumColumn.HeaderText = "Konum";
            konumColumn.Name = "colKonum";
            konumColumn.ReadOnly = true;
            konumColumn.Width = 100;

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
                urunAdiColumn, katColumn, konumColumn, miktarColumn, guncelleColumn, silColumn, depoKonumIdColumn
            });
        }

        private void txtBarkodArama_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BarkodAraVeYukle();
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

                            if (depodakiToplamMiktar > urunToplamMiktar)
                            {
                                lblUyari.Visible = true;
                                lblUyari.Text = "UYARI: Depodaki toplam miktar ürün kaydıyla uyuşmuyor!";
                                lblUyari.ForeColor = System.Drawing.Color.Red;
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
                MessageBox.Show("Ürün bilgileri yüklenirken hata oluştu: " + ex.Message,
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
                                d.kat,
                                d.konum,
                                ud.miktar,
                                ud.depo_konum_id
                               FROM urun_depo_konum ud
                               JOIN urunler u ON ud.urun_id = u.urun_id
                               JOIN depo_konum d ON ud.depo_konum_id = d.id
                               WHERE ud.urun_id = @urunId
                               ORDER BY d.kat, d.konum";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@urunId", urunId);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvDepoKonumlari.DataSource = dt;

                    // Calculate and display sum
                    depodakiToplamMiktar = dt.AsEnumerable().Sum(row => Convert.ToInt32(row["miktar"]));
                    lblDepodakiToplam.Text = $"Depoda: {depodakiToplamMiktar}";

                    // Check if sum exceeds total
                    if (depodakiToplamMiktar > urunToplamMiktar)
                    {
                        lblUyari.Visible = true;
                        lblUyari.Text = "UYARI: Depodaki toplam miktar ürün kaydıyla uyuşmuyor!";
                        lblUyari.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        lblUyari.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürün konumları yüklenirken hata oluştu: " + ex.Message,
                              "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void dgvDepoKonumlari_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvDepoKonumlari.Rows[e.RowIndex];
            int depoKonumId = Convert.ToInt32(row.Cells["colDepoKonumId"].Value);
            int currentMiktar = Convert.ToInt32(row.Cells["colMiktar"].Value);

            if (e.ColumnIndex == dgvDepoKonumlari.Columns["colGuncelle"].Index)
            {
                // Güncelleme işlemi
                string miktarStr = row.Cells["colMiktar"].Value?.ToString();

                if (!int.TryParse(miktarStr, out int yeniMiktar) || yeniMiktar < 0)
                {
                    MessageBox.Show("Geçerli bir miktar giriniz!", "Uyarı",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Toplam miktar kontrolü
                int toplamMiktar = depodakiToplamMiktar - currentMiktar + yeniMiktar;
                if (toplamMiktar > urunToplamMiktar)
                {
                    MessageBox.Show("Stok miktarını aştınız! Depodaki toplam miktar stoktaki miktardan fazla olamaz.", "Uyarı",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    if (connection.State != ConnectionState.Open)
                        connection.Open();

                    // Update record
                    string updateQuery = @"UPDATE urun_depo_konum SET miktar = @miktar 
                                        WHERE urun_id = @urunId AND depo_konum_id = @konumId";
                    using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, connection))
                    {
                        updateCmd.Parameters.AddWithValue("@miktar", yeniMiktar);
                        updateCmd.Parameters.AddWithValue("@urunId", currentUrunId);
                        updateCmd.Parameters.AddWithValue("@konumId", depoKonumId);
                        updateCmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Depo konum bilgisi güncellendi!", "Bilgi",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Refresh data
                    UrunBilgileriniYukle(currentUrunId);
                    UrunKonumlariniYukle(currentUrunId);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Güncelleme sırasında hata oluştu: " + ex.Message,
                                  "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }
            else if (e.ColumnIndex == dgvDepoKonumlari.Columns["colSil"].Index)
            {
                // Silme işlemi
                if (MessageBox.Show("Bu depo konumunu silmek istediğinize emin misiniz?", "Onay",
                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                            connection.Open();

                        // Delete record
                        string deleteQuery = @"DELETE FROM urun_depo_konum 
                                            WHERE urun_id = @urunId AND depo_konum_id = @konumId";
                        using (MySqlCommand deleteCmd = new MySqlCommand(deleteQuery, connection))
                        {
                            deleteCmd.Parameters.AddWithValue("@urunId", currentUrunId);
                            deleteCmd.Parameters.AddWithValue("@konumId", depoKonumId);
                            deleteCmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Depo konumu başarıyla silindi!", "Bilgi",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Refresh data
                        UrunBilgileriniYukle(currentUrunId);
                        UrunKonumlariniYukle(currentUrunId);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Silme sırasında hata oluştu: " + ex.Message,
                                      "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (connection.State == ConnectionState.Open)
                            connection.Close();
                    }
                }
            }
        }

        private void btnYeniKonumEkle_Click(object sender, EventArgs e)
        {
            if (currentUrunId == -1)
            {
                MessageBox.Show("Önce bir ürün seçmelisiniz!", "Uyarı",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbKatKonum.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen bir depo konumu seçiniz!", "Uyarı",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtMiktar.Text, out int miktar) || miktar <= 0)
            {
                MessageBox.Show("Geçerli bir miktar giriniz!", "Uyarı",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Toplam miktar kontrolü
            if (depodakiToplamMiktar + miktar > urunToplamMiktar)
            {
                MessageBox.Show("Stok miktarını aştınız! Depodaki toplam miktar stoktaki miktardan fazla olamaz.", "Uyarı",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                // Get selected location ID
                int konumId = ((ComboboxItem)cmbKatKonum.SelectedItem).Value;

                // Check if product already exists in this location
                string checkQuery = "SELECT COUNT(*) FROM urun_depo_konum WHERE urun_id = @urunId AND depo_konum_id = @konumId";
                MySqlCommand checkCmd = new MySqlCommand(checkQuery, connection);
                checkCmd.Parameters.AddWithValue("@urunId", currentUrunId);
                checkCmd.Parameters.AddWithValue("@konumId", konumId);
                int exists = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (exists > 0)
                {
                    MessageBox.Show("Bu ürün zaten belirtilen depo konumunda kayıtlı!", "Uyarı",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Add product to location
                string insertQuery = @"INSERT INTO urun_depo_konum (urun_id, depo_konum_id, miktar) 
                                    VALUES (@urunId, @konumId, @miktar)";
                using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, connection))
                {
                    insertCmd.Parameters.AddWithValue("@urunId", currentUrunId);
                    insertCmd.Parameters.AddWithValue("@konumId", konumId);
                    insertCmd.Parameters.AddWithValue("@miktar", miktar);
                    insertCmd.ExecuteNonQuery();
                }

                MessageBox.Show("Yeni depo konumu başarıyla eklendi!", "Bilgi",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refresh data
                UrunBilgileriniYukle(currentUrunId);
                UrunKonumlariniYukle(currentUrunId);

                // Clear inputs
                txtMiktar.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kayıt sırasında hata oluştu: " + ex.Message,
                              "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (connection != null)
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
                connection.Dispose();
            }
            base.OnFormClosing(e);
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