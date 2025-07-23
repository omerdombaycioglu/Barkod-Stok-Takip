using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace StokTakipOtomasyonu.Forms
{
    public partial class DepoKonumSilDialog : Form
    {
        public int? SeciliKonumId => cmbKonumlar.SelectedItem is ComboboxItem ci ? ci.Value : (int?)null;

        public DepoKonumSilDialog(List<ComboboxItem> konumlar)
        {
            InitializeComponent();
            cmbKonumlar.DataSource = konumlar;
            cmbKonumlar.DisplayMember = "Text";
            cmbKonumlar.ValueMember = "Value";
        }
    }
}
