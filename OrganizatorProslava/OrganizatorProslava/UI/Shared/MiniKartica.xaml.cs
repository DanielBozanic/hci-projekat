using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OrganizatorProslava.UI.Shared
{
    /// <summary>
    /// Interaction logic for MiniKartica.xaml
    /// </summary>
    public partial class MiniKartica : Window
    {
        Models.Proizvod proizvod;
        public MiniKartica(Models.Proizvod prosljedjenProizvod)
        {
            InitializeComponent();
            proizvod = prosljedjenProizvod;
            imeProizvoda.Text = prosljedjenProizvod.Naziv;
            OpisProizvoda.Text = prosljedjenProizvod.Opis;
            CenaProizvod.Text = prosljedjenProizvod.Cena.ToString();
            ImeSaradnika.Text = prosljedjenProizvod.Sardanik.Naziv;
            AdresaSaradnika.Text = prosljedjenProizvod.Sardanik.Adresa;
            EmailSaradnika.Text = prosljedjenProizvod.Sardanik.Email;
            Link.Text = prosljedjenProizvod.LinkZaSliku;
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            this.Owner.Show();
            this.Hide();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Hide();
        }
    }
}
