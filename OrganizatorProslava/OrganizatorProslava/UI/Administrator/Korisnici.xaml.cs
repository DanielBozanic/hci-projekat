using OrganizatorProslava.Services;
using OrganizatorProslava.UI.Shared;
using OrganizatorProslava.ViewModel.Administrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace OrganizatorProslava.UI.Administrator
{
    public partial class Korisnici : Window
    {
        private int _tipFiltera = 0;

        public Korisnici()
        {
            InitializeComponent();
            this.DataContext = new KorisniciViewModel(GetKorisnici());
        }

        private void Window_Rendered(object sender, EventArgs e)
        {
            this.Owner.Hide();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.Owner.Show();
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                btnNazad_Click(null, null);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl) && e.Key == Key.D)
                btnDodaj_Click(null, null);
            if (Keyboard.IsKeyDown(Key.LeftCtrl) && e.Key == Key.I)
                btnIzmeni_Click(null, null);
            if (Keyboard.IsKeyDown(Key.LeftCtrl) && e.Key == Key.O)
                btnObrisi_Click(null, null);
        }

        private List<Models.Korisnik> GetKorisnici()
        {
            var korisnikServis = new Services.Nalozi.KorisnikServis();
            return korisnikServis.GetKorisnici().ToList();
        }

        private List<Models.Korisnik> GetKorisnici(int tip, string pretrazi)
        {
            var korisnikServis = new Services.Nalozi.KorisnikServis();
            pretrazi = pretrazi.ToLower();
            return korisnikServis.GetKorisnici()
                .Where(q => (tip == 0 || q.Tip == tip) &&
                    (pretrazi == string.Empty ||
                    q.Ime.ToLower().Contains(pretrazi) ||
                    q.Prezime.ToLower().Contains(pretrazi) ||
                    q.KorisnickoIme.ToLower().Contains(pretrazi) ||
                    q.TipKorisnika.ToLower().Contains(pretrazi))).ToList();
        }

        private void btnNazad_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void radioAdmin_Checked(object sender, RoutedEventArgs e)
        {
            if (_tipFiltera != TipKorisnika.Admin)
            {
                _tipFiltera = TipKorisnika.Admin;
                Filter();
            }
        }

        private void radioOrganizator_Checked(object sender, RoutedEventArgs e)
        {
            if (_tipFiltera != TipKorisnika.Organizator)
            {
                _tipFiltera = TipKorisnika.Organizator;
                Filter();
            }
        }

        private void radioKlijent_Checked(object sender, RoutedEventArgs e)
        {
            if (_tipFiltera != TipKorisnika.Klijent)
            {
                _tipFiltera = TipKorisnika.Klijent;
                Filter();
            }
        }

        private void radioSveUloge_Checked(object sender, RoutedEventArgs e)
        {
            if (_tipFiltera != 0)
            {
                _tipFiltera = 0;
                Filter();
            }
        }

        private void Filter()
        {
            if (txtPretraga != null)
                this.DataContext = new KorisniciViewModel(GetKorisnici(_tipFiltera, txtPretraga.Text.Length >= 3 ? txtPretraga.Text : string.Empty));
        }

        private void txtPretraga_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (txtPretraga.Text.Length >= 3)
                this.DataContext = new KorisniciViewModel(GetKorisnici(_tipFiltera, txtPretraga.Text));
            else if (txtPretraga.Text.Length == 0)
                this.DataContext = new KorisniciViewModel(GetKorisnici(_tipFiltera, string.Empty));

        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (dgKorisnici.SelectedItem != null)
            {
                var potvrdi = new Poruka(Poruke.BrisiKorisnika, Poruke.Poruka, MessageBoxButton.YesNo, MessageBoxResult.No);
                potvrdi.Owner = this;
                potvrdi.ShowDialog();
                if (potvrdi.Rezultat == MessageBoxResult.Yes)
                {
                    var korisnik = (Models.Korisnik)dgKorisnici.SelectedItem;
                    var korisnikServis = new Services.Nalozi.KorisnikServis();
                    var msg = korisnikServis.BrisiKorisnika(korisnik.Id);
                    if (msg == string.Empty)
                    {
                        ((KorisniciViewModel)this.DataContext).UkloniKorisnika(korisnik);
                        var poruka = new Poruka(string.Format(Poruke.KorisnikObrisan, korisnik.KorisnickoIme), Poruke.Poruka, MessageBoxButton.OK);
                        poruka.Owner = this;
                        poruka.ShowDialog();
                    }
                    else
                    {
                        var poruka = new Poruka(msg, Poruke.Poruka, MessageBoxButton.OK);
                        poruka.Owner = this;
                        poruka.ShowDialog();
                    }
                }
            }
            else
            {
                var poruka = new Poruka(Poruke.BrisanjeZapisNijeSelektovan, Poruke.Poruka, MessageBoxButton.OK);
                poruka.Owner = this;
                poruka.ShowDialog();
            }
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            var izmena = new IzmeniKorisnika(null);
            izmena.Owner = this;
            izmena.ShowDialog();
            if (izmena.Rezultat == MessageBoxResult.OK)
                ((KorisniciViewModel)this.DataContext).DodajKorisnika(izmena.Korisnik);
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            if (dgKorisnici.SelectedItem != null)
            {
                var korisnik = (Models.Korisnik)dgKorisnici.SelectedItem;
                var izmena = new IzmeniKorisnika(korisnik);
                izmena.Owner = this;
                izmena.ShowDialog();
                if (izmena.Rezultat == MessageBoxResult.OK)
                    ((KorisniciViewModel)this.DataContext).IzmeniKorisnika(izmena.Korisnik);
            }
            else
            {
                var poruka = new Poruka(Poruke.IzmenaZapisNijeSelektovan, Poruke.Poruka, MessageBoxButton.OK);
                poruka.Owner = this;
                poruka.ShowDialog();
            }
        }

    }
}
