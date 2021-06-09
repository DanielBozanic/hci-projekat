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

namespace OrganizatorProslava.UI.Korisnici
{
    /// <summary>
    /// Interaction logic for PrikaziSpisakZvanica.xaml
    /// </summary>
    public partial class PrikaziSpisakZvanica : Window
    {
        public PrikaziSpisakZvanica(Models.Zabava izabraniZahtjev)
        {
            InitializeComponent();
            UneseniSpisak.Text = izabraniZahtjev.SpisakGostiju;
        }

        private void nazadKlik(object sender, RoutedEventArgs e)
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
