using OrganizatorProslava.Models;
using OrganizatorProslava.Services;
using OrganizatorProslava.Services.Nalozi;
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
                var potvrdi = MessageBox.Show($"{Poruke.PodaciCeBitiIzgubljeni}{Environment.NewLine}{Poruke.OdbaciPodatke}",
                    Poruke.Poruka, MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if (potvrdi == MessageBoxResult.Yes)
                    this.Hide();
            }
            else
            {
                this.Hide();
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

            MessageBox.Show("Registracija uspesna!");  //TODO: redirekcija na login prozor i srediti izgled MessageBox-ova
            this.Hide();
        }

        private bool Validacija()
        {
            if (txtIme.Text.Trim() == string.Empty)
            {
                MessageBox.Show(Poruke.ImeObavezno, Poruke.Poruka, MessageBoxButton.OK, MessageBoxImage.Information);
                txtIme.Focus();
                return false;
            }
            if (txtPrezime.Text.Trim() == string.Empty)
            {
                MessageBox.Show(Poruke.PrezimeObavezno, Poruke.Poruka, MessageBoxButton.OK, MessageBoxImage.Information);
                txtPrezime.Focus();
                return false;
            }
            if (txtKorisnickoIme.Text.Trim() == string.Empty)
            {
                MessageBox.Show(Poruke.KorisnickoImeObavezno, Poruke.Poruka, MessageBoxButton.OK, MessageBoxImage.Information);
                txtKorisnickoIme.Focus();
                return false;
            }
            if (txtLozinka.Password == string.Empty)
            {
                MessageBox.Show(Poruke.LozinkaObavezna, Poruke.Poruka, MessageBoxButton.OK, MessageBoxImage.Information);
                txtLozinka.Focus();
                return false;
            }
            if (txtLozinka.Password != txtPonoviteLozinku.Password)
            {
                MessageBox.Show(Poruke.LozinkeRazlicite, Poruke.Poruka, MessageBoxButton.OK, MessageBoxImage.Information);
                txtPonoviteLozinku.Focus();
                return false;
            }

            var servis = new RegistracijaServis();
            if (servis.KorisnikPostoji(txtKorisnickoIme.Text.Trim()))
            {
                MessageBox.Show(Poruke.KorisnickoImePostoji, Poruke.Poruka, MessageBoxButton.OK, MessageBoxImage.Information);
                txtKorisnickoIme.Focus();
                return false;
            }
            return true;
        }

    }
}
