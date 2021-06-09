using System;
using System.Windows;
using OrganizatorProslava.UI.Shared;
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
            Poruka poruka = new Poruka("Da li ste sigurni da želite da završite organizaciju?\nOvo je nepovratno.", "Završetak organizacije", MessageBoxButton.YesNo, MessageBoxResult.No);
            poruka.Owner = this;
            poruka.ShowDialog();
            if (poruka.Rezultat == MessageBoxResult.Yes)
            {
                this.zabavaZaOrganizovanje.Status = 4;
                Services.Zabave.ServisZabave servis = new Services.Zabave.ServisZabave();
                servis.IzmeniZabavu(this.zabavaZaOrganizovanje);
                poruka = new Poruka("Uspešno ste završili organizaciju.", "Završetak organizacije", MessageBoxButton.OK);
                poruka.Owner = this;
                poruka.ShowDialog();
                this.Close();
            }

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
