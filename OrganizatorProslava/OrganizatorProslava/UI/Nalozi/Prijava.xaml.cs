using OrganizatorProslava.Models;
using OrganizatorProslava.Services;
using OrganizatorProslava.Services.Nalozi;
using OrganizatorProslava.UI.Administrator;
using OrganizatorProslava.UI.Shared;
using System;
using System.Windows;

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
                    break;
                default:
                    break;
            }
        }

        private void btnNazad_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            this.Owner.Show();
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
    }
}
