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

            if (!DatabaseHelper.TestConnection())
            {
                MessageBox.Show("Veritabanı bağlantısı kurulamadı!", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application.Run(new Forms.LoginForm());
        }
    }
}