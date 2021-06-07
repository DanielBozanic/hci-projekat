using OrganizatorProslava.Help;
using OrganizatorProslava.Models;
using OrganizatorProslava.Services;
using OrganizatorProslava.Services.Nalozi;
using OrganizatorProslava.UI.Shared;
using System;
using System.Windows;
using System.Windows.Input;

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
            this.DialogResult = false;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            txtIme.Focus();
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            IInputElement focusedControl = FocusManager.GetFocusedElement(this);
            if (focusedControl is DependencyObject)
            {
                string str = HelpProvider.GetHelpKey((DependencyObject)focusedControl);
                HelpProvider.ShowHelp(str, this);
            }
        }

        private void btnRegistracija_Click(object sender, RoutedEventArgs e)
        {
            if (!Validacija())
                return;

            var korisnik = new Korisnik
            {
                Ime = txtIme.Text.Trim(),
                Prezime = txtPrezime.Text.Trim(),
                KorisnickoIme = txtKorisnickoIme.Text.Trim(),
                Tip = TipKorisnika.Klijent,
                Lozinka = txtLozinka.Password
            };

            var servis = new RegistracijaServis();
            servis.DodajKorisnika(korisnik);

            this.DialogResult = true;
        }

        private bool Validacija()
        {
            var greska = string.Empty;
            if (txtIme.Text.Trim() == string.Empty)
            {
                greska = Poruke.ImeObavezno;
                txtIme.Focus();
            }
            if (greska == string.Empty && txtPrezime.Text.Trim() == string.Empty)
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

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.DialogResult != true)
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
                    if (potvrdi.Rezultat != MessageBoxResult.Yes)
                        e.Cancel = true;
                }
            }
        }
    }
}
