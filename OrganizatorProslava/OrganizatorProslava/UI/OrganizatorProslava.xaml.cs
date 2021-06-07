using OrganizatorProslava.Models;
using OrganizatorProslava.Services;
using OrganizatorProslava.Services.Nalozi;
using OrganizatorProslava.UI.Nalozi;
using System.Windows;

namespace OrganizatorProslava
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ProveriAdmina();
        }

        private void btnPrijava_Click(object sender, RoutedEventArgs e)
        {
            OtvoriPrijavu();
        }

        private void btnRegistracija_Click(object sender, RoutedEventArgs e)
        {
            var rego = new Registracija();
            rego.Owner = this;
            var rezultat = rego.ShowDialog();
            if (rezultat.Value)
                OtvoriPrijavu();
        }

        private void OtvoriPrijavu()
        {
            var prijava = new Prijava();
            prijava.Owner = this;
            prijava.Show();
        }

        private void btnZatvori_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ProveriAdmina()
        {
            var korisnikDal = new DataAccess.Nalozi.Korisnik();
            var korisnik = korisnikDal.NadjiKorisnikaPoKorisnickomImenu("admin");
            if (korisnik == null)
            {
                var admin = new Korisnik
                {
                    Ime = "administrator",
                    Prezime = string.Empty,
                    KorisnickoIme = "admin",
                    Tip = TipKorisnika.Admin,
                    Lozinka = "admin"
                };

                var servis = new RegistracijaServis();
                servis.DodajKorisnika(admin);
            }
        }

        private void btnSala_Click(object sender, RoutedEventArgs e)
        {
            var sala = new UI.Korisnici.Sala(13);
            sala.Owner = this;
            sala.ShowDialog();
        }
    }
}
