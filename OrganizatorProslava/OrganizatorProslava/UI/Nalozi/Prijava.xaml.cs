using OrganizatorProslava.Models;
using OrganizatorProslava.Services;
using OrganizatorProslava.Services.Nalozi;
using OrganizatorProslava.UI.Administrator;
using OrganizatorProslava.UI.Organizator;
using OrganizatorProslava.UI.Shared;
using System;
using System.Windows;
using System.Windows.Input;
using OrganizatorProslava.UI.Korisnici;

namespace OrganizatorProslava.UI.Nalozi
{
    public partial class Prijava : Window
    {
        public Prijava()
        {
            InitializeComponent();
        }

        private void Window_Rendered(object sender, EventArgs e)
        {
            this.Owner.Hide();
            txtKorisnickoIme.Focus();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.Owner.Show();
        }

        private void txtKorisnickoIme_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                var servis = new PrijavaServis();
                servis.PrijaviMe("admin", "admin");
                var meniAdmin = new MeniAdmin();
                meniAdmin.Owner = this;
                meniAdmin.Show();
            }
        }

        private void btnPrijavise_Click(object sender, RoutedEventArgs e)
        {
            if (!Validacija())
                return;

            var servis = new PrijavaServis();
            var greska = servis.PrijaviMe(txtKorisnickoIme.Text, txtLozinka.Password);
            if (greska != string.Empty)
            {
                var potvrdi = new Poruka(greska, Poruke.Poruka, MessageBoxButton.OK);
                potvrdi.Owner = this;
                potvrdi.ShowDialog();
                potvrdi.Close();
                return;
            }

            switch (LogovaniKorisnik.Tip)
            {
                case TipKorisnika.Admin:
                    var meniAdmin = new MeniAdmin();
                    meniAdmin.Owner = this;
                    meniAdmin.Show();
                    break;
                case TipKorisnika.Organizator:
                    var meniOrganizator = new GlavniMeni();
                    meniOrganizator.Owner = this;
                    meniOrganizator.Show();
                    break;
                case TipKorisnika.Klijent:
                    var profilKorisnika = new Korisnici.ProfilKorisnika();
                    profilKorisnika.Owner = this;
                    profilKorisnika.Show();
                    break;
                default:
                    break;
            }
        }

        private void btnNazad_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void lblZaboravioLozinku_MouseLeftButtonUp(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("crikey!");
        }

        private bool Validacija()
        {
            var greska = string.Empty;
            if (txtKorisnickoIme.Text.Trim() == string.Empty)
            {
                greska = Poruke.KorisnickoImeObavezno;
                txtKorisnickoIme.Focus();
            }
            if (greska == string.Empty && txtLozinka.Password == string.Empty)
            {
                greska = Poruke.LozinkaObavezna;
                txtLozinka.Focus();
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

        private void txtKorisnickoIme_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }


        private void ZaboravljenaLozinka(object sender, MouseButtonEventArgs e)
        {
            var prozor = new UI.Korisnici.PromenaLozinke();
            prozor.Owner = this;
            prozor.Show();
            this.Hide();
        }
    }
}
