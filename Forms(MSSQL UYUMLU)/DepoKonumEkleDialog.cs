using System;
using System.Windows.Forms;

namespace StokTakipOtomasyonu.Forms
{
    public partial class DepoKonumEkleDialog : Form
    {
        public string Harf => txtHarf.Text.Trim();
        public string Numara => txtNumara.Text.Trim();

        public DepoKonumEkleDialog()
        {
            InitializeComponent();
            this.AutoValidate = AutoValidate.Disable;
        }
    }
}
