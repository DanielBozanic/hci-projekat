﻿using OrganizatorProslava.Models;
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
        public AzurirajProfilKorisnika()
        {
            InitializeComponent();
        }




        private void azuriraj(object sender, RoutedEventArgs e)
        {
            var servis = new Services.Nalozi.KorisnikServis();

            string promjenjenoIme = ime.Text;
            string promjenjenoPrezime = prezime.Text;

            string[] razdvajanjePunogImena = LogovaniKorisnik.PunoIme.Split(' ');

            if(promjenjenoIme == string.Empty)
            {
                promjenjenoIme = razdvajanjePunogImena[0];
            }

            if(promjenjenoPrezime == string.Empty)
            {
                promjenjenoPrezime = razdvajanjePunogImena[1];
            }

            string poruka = servis.AzurirajPodatke(LogovaniKorisnik.KorisnickoIme, promjenjenoIme, promjenjenoPrezime);

            if(poruka == string.Empty)
            {
                LogovaniKorisnik.PunoIme = promjenjenoIme + " " + promjenjenoPrezime;
                var noviProfil = new ProfilKorisnika();
                noviProfil.Owner = this;
                noviProfil.Show();
                this.Hide();
            }

        }

        private void odustani(object sender, RoutedEventArgs e)
        {

        }
    }
}