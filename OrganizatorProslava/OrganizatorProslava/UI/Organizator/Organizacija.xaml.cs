using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using OrganizatorProslava.UI.Administrator;

namespace OrganizatorProslava.UI.Organizator
{
    /// <summary>
    /// Interaction logic for Organizacija.xaml
    /// </summary>
    public partial class Organizacija : Window
    {
        public Organizacija()
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

        private void button_cvecare_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_muzika_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_restorani_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_novi_saradnik_Click(object sender, RoutedEventArgs e)
        {
            var dodaj = new IzmeniSaradnika(null);
            dodaj.Owner = this;
            dodaj.ShowDialog();
        }

        private void button_posalji_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_nazad_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void infomacije_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}
