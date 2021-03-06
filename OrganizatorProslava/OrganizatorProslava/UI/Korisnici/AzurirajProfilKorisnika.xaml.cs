using OrganizatorProslava.Models;
using OrganizatorProslava.Services;
using OrganizatorProslava.UI.Shared;
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
    /// Interaction logic for AzurirajProfilKorisnika.xaml
    /// </summary>
    public partial class AzurirajProfilKorisnika : Window
    {
        private bool noviProzor = false;
        public AzurirajProfilKorisnika(bool da_otvara)
        {
            InitializeComponent();
            this.noviProzor = da_otvara;
        }

        public void podesiPodatke(string ime, string prezime) {
            this.ime.Text = ime;
            this.prezime.Text = prezime;
        }



        private void azuriraj(object sender, RoutedEventArgs e)
        {
            var servis = new Services.Nalozi.KorisnikServis();

            string promjenjenoIme = ime.Text;
            string promjenjenoPrezime = prezime.Text;

            string[] razdvajanjePunogImena = LogovaniKorisnik.PunoIme.Split(' ');

            if ((promjenjenoIme == string.Empty || promjenjenoPrezime == string.Empty) && !this.noviProzor) {
                var poruka = new Poruka("Morate uneti i ime i prezime.", "Obaveštenje", MessageBoxButton.OK);
                poruka.Owner = this;
                poruka.ShowDialog();
                return;
            }

            if (promjenjenoIme == string.Empty)
            {
                promjenjenoIme = razdvajanjePunogImena[0];
            }

            if (promjenjenoPrezime == string.Empty)
            {
                promjenjenoPrezime = razdvajanjePunogImena[1];
            }

            bool uspjelo = servis.AzurirajPodatke(LogovaniKorisnik.KorisnickoIme, promjenjenoIme, promjenjenoPrezime);



            if (uspjelo)
            {
                LogovaniKorisnik.PunoIme = promjenjenoIme + " " + promjenjenoPrezime;

                var azuriraniPodaciPoruka = new Poruka(Poruke.AzuriraniPodaci, Poruke.Poruka, MessageBoxButton.OK);
                azuriraniPodaciPoruka.Owner = this;
                azuriraniPodaciPoruka.ShowDialog();

                if (azuriraniPodaciPoruka.Rezultat == MessageBoxResult.OK)
                {
                    if (this.noviProzor)
                    {
                        var noviProfil = new ProfilKorisnika();
                        noviProfil.Owner = this;
                        noviProfil.Show();
                        this.Hide();
                    }
                    else this.Close();
                }

            }

        }



        private void odustani(object sender, RoutedEventArgs e)
        {
            string promjenjenoIme = ime.Text;
            string promjenjenoPrezime = prezime.Text;

            if (promjenjenoIme != string.Empty || promjenjenoPrezime != string.Empty)
            {
                var poruka = new Poruka(Poruke.OdbaciPodatke, Poruke.Poruka, MessageBoxButton.YesNo, MessageBoxResult.No);
                poruka.Owner = this;
                poruka.ShowDialog();

                if (poruka.Rezultat == MessageBoxResult.Yes)
                {

                    this.Owner.Show();
                    this.Hide();
                }
            }
            else
            {
                this.Owner.Show();
                this.Hide();
            }
        }




        private void Window_Closed(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Hide();
        }
    }
}
