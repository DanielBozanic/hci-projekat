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
        private Models.Zabava zabavaZaOrganizovanje;
        public Organizacija(Models.Zabava zabavaKojuOrganizujemo)
        {
            InitializeComponent();
            zabavaZaOrganizovanje = zabavaKojuOrganizujemo;

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
            Cvecare prozorCvecare = new Cvecare(zabavaZaOrganizovanje);
            prozorCvecare.Owner = this;
            prozorCvecare.Show();
        }

        private void button_muzika_Click(object sender, RoutedEventArgs e)
        {
            Muzika prozorMuzika = new Muzika(zabavaZaOrganizovanje);
            prozorMuzika.Owner = this;
            prozorMuzika.Show();
        }

        private void button_restorani_Click(object sender, RoutedEventArgs e)
        {
            RestoranOrganizacija prozorRestorani = new RestoranOrganizacija(zabavaZaOrganizovanje);
            prozorRestorani.Owner = this;
            prozorRestorani.Show();
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
