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

namespace OrganizatorProslava.UI.Organizator
{
    /// <summary>
    /// Interaction logic for NovaZabava.xaml
    /// </summary>
    public partial class NovaZabava : Window
    {
        private int tipFiltera = 0;

        public NovaZabava()
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

        private void zahtevi_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void nedodeljene_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void button_prihvati(object sender, RoutedEventArgs e)
        {

        }
    }
}
