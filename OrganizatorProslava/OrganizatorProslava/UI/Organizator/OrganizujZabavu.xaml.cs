using System;
using System.Collections;
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

namespace OrganizatorProslava.UI.Organizator
{
    public partial class OrganizujZabavu : Window
    {
        private int tipFiltera = 0;

        public OrganizujZabavu()
        {
            InitializeComponent();
        }

        private void vracanje(object sender, EventArgs e)
        {
            this.Owner.Hide();
        }

        private void zatvaranje(object sender, EventArgs e)
        {
            this.Owner.Show();
        }

        private void button_nazad(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button_detalji(object sender, RoutedEventArgs e)
        {

        }

        private void button_organizuj(object sender, RoutedEventArgs e)
        {

        }

        private void trenutne_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void istorija_Checked(object sender, RoutedEventArgs e)
        {
            // onemoguci dugme organizuj, samo detalje
        }
    }
}
