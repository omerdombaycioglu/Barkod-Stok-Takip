using System;
using System.Windows.Forms;
using StokTakipOtomasyonu.Helpers;

namespace StokTakipOtomasyonu
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Bağlantı sağlanana kadar ayar formunu göster
            while (!DatabaseHelper.TestConnection())
            {
                MessageBox.Show(
                    "Veritabanı bağlantısı kurulamadı!\nLütfen bağlantı ayarlarını kontrol edin.",
                    "Bağlantı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Kullanıcıya ayar ekranını aç
                using (var f = new Forms.SettingsForm())
                {
                    var result = f.ShowDialog();
                    if (result == DialogResult.Cancel)
                    {
                        // Kullanıcı Vazgeç'e bastıysa uygulamayı kapat
                        Application.Exit();
                        return;
                    }
                }
                // Ayarlar girildikten sonra döngü başa döner ve tekrar test edilir
            }

            // Bağlantı başarılı ise login formu açılır
            Application.Run(new Forms.LoginForm());
        }
    }
}
