using OrganizatorProslava.Models;
using OrganizatorProslava.Services;
using OrganizatorProslava.Services.Nalozi;
using OrganizatorProslava.UI.Shared;
using System.Windows;
using System.Windows.Input;

namespace OrganizatorProslava.UI.Administrator
{
    public partial class IzmeniKorisnika : Window
    {
        public MessageBoxResult Rezultat { get; set; } = MessageBoxResult.Cancel;
        public Korisnik Korisnik { get; set; }

        public IzmeniKorisnika(Korisnik korisnik)
        {
            InitializeComponent();
            Korisnik = korisnik;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Korisnik != null)
            {
                txtIme.Text = Korisnik.Ime;
                txtPrezime.Text = Korisnik.Prezime;
                txtKorisnickoIme.Text = Korisnik.KorisnickoIme;
                txtLozinka.Password = Korisnik.Lozinka;
                txtPonoviteLozinku.Password = Korisnik.Lozinka;
                radioAdmin.IsChecked = Korisnik.Tip == TipKorisnika.Admin;
                radioOrganizator.IsChecked = Korisnik.Tip == TipKorisnika.Organizator;
                radioKlijent.IsChecked = Korisnik.Tip == TipKorisnika.Klijent;
            }
            else
            {
                radioKlijent.IsChecked = true;
                this.Title = "Dodaj Korisnika";
            }
            txtKorisnickoIme.IsEnabled = Korisnik == null;
            radioAdmin.IsEnabled = Korisnik == null;
            radioOrganizator.IsEnabled = Korisnik == null;
            radioKlijent.IsEnabled = Korisnik == null;
            txtIme.Focus();
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                btnOdbaci_Click(null, null);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl) && e.Key == Key.S)
                btnSacuvaj_Click(null, null);
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            if (!Validacija())
                return;

            var servis = new RegistracijaServis();
            if (Korisnik == null)
            {
                Korisnik = new Korisnik
                {
                    Ime = txtIme.Text.Trim(),
                    Prezime = txtPrezime.Text.Trim(),
                    KorisnickoIme = txtKorisnickoIme.Text.Trim(),
                    Tip = TipKorisnika.Klijent,
                    Lozinka = txtLozinka.Password
                };

                Korisnik.Id = servis.DodajKorisnika(Korisnik);

                Rezultat = MessageBoxResult.OK;
                this.Close();
            }
            else
            {
                Korisnik.Ime = txtIme.Text.Trim();
                Korisnik.Prezime = txtPrezime.Text.Trim();
                Korisnik.Lozinka = txtLozinka.Password;

                var msg = servis.IzmeniKorisnika(Korisnik);
                if (msg == string.Empty)
                {
                    Rezultat = MessageBoxResult.OK;
                    this.Close();
                }
                else
                {
                    var poruka = new Poruka(msg, Poruke.Poruka, MessageBoxButton.OK);
                    poruka.Owner = this;
                    poruka.ShowDialog();
                }
            }
        }

        private void btnOdbaci_Click(object sender, RoutedEventArgs e)
        {
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

            if (greska == string.Empty && Korisnik == null)
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
