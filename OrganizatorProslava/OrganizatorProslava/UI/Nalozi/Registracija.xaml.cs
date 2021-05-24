﻿using OrganizatorProslava.Models;
using OrganizatorProslava.Services;
using OrganizatorProslava.Services.Nalozi;
using OrganizatorProslava.UI.Shared;
using System;
using System.Windows;


namespace OrganizatorProslava.UI.Nalozi
{
    public partial class Registracija : Window
    {
        public Registracija()
        {
            InitializeComponent();
        }

        private void btnOdbaci_Click(object sender, RoutedEventArgs e)
        {
            if (txtIme.Text.Trim() != string.Empty ||
                txtPrezime.Text.Trim() != string.Empty ||
                txtKorisnickoIme.Text.Trim() != string.Empty ||
                txtLozinka.Password.Trim() != string.Empty ||
                txtPonoviteLozinku.Password.Trim() != string.Empty)
            {
                var potvrdi = new Poruka($"{Poruke.PodaciCeBitiIzgubljeni}{Environment.NewLine}{Poruke.OdbaciPodatke}",
                    Poruke.Poruka, MessageBoxButton.YesNo, MessageBoxResult.No);
                potvrdi.Owner = this;
                potvrdi.ShowDialog();
                if (potvrdi.Rezultat == MessageBoxResult.Yes)
                {
                    potvrdi.Close();
                    this.DialogResult = false;
                    this.Close();
                }
            }
            else
            {
                this.DialogResult = false;
                this.Close();
            }
        }

        private void btnRegistracija_Click(object sender, RoutedEventArgs e)
        {
            if (!Validacija())
                return;

            var korisnik = new Korisnik
            {
                Ime = txtIme.Text,
                Prezime = txtPrezime.Text,
                KorisnickoIme = txtKorisnickoIme.Text,
                Tip = TipKorisnika.Klijent,
                Lozinka = txtLozinka.Password
            };

            var servis = new RegistracijaServis();
            servis.DodajKorisnika(korisnik);

            this.DialogResult = true;
            this.Close();
        }

        private bool Validacija()
        {
            var greska = string.Empty;
            if (txtIme.Text.Trim() == string.Empty)
            {
                greska = Poruke.ImeObavezno;
                txtIme.Focus();
            }
            if (greska == string.Empty &&  txtPrezime.Text.Trim() == string.Empty)
            {
                greska = Poruke.PrezimeObavezno;
                txtPrezime.Focus();
            }
            if (greska == string.Empty && txtKorisnickoIme.Text.Trim() == string.Empty)
            {
                greska = Poruke.KorisnickoImeObavezno;
                txtKorisnickoIme.Focus();
            }
            if (greska == string.Empty && txtLozinka.Password == string.Empty)
            {
                greska = Poruke.LozinkaObavezna;
                txtLozinka.Focus();
            }
            if (greska == string.Empty && txtLozinka.Password != txtPonoviteLozinku.Password)
            {
                greska = Poruke.LozinkeRazlicite;
                txtPonoviteLozinku.Focus();
            }

            if (greska == string.Empty)
            {
                var servis = new RegistracijaServis();
                if (servis.KorisnikPostoji(txtKorisnickoIme.Text.Trim()))
                {
                    greska = Poruke.KorisnickoImePostoji;
                    txtKorisnickoIme.Focus();
                }
            }

            if (greska != string.Empty)
            {
                var potvrdi = new Poruka(greska, Poruke.Poruka, MessageBoxButton.OK);
                potvrdi.Owner = this;
                potvrdi.ShowDialog();
                potvrdi.Close();                                               
            }
            return greska == string.Empty;
        }
    }
}
