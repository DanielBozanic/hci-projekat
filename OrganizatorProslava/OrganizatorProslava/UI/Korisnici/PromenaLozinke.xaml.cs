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
    /// Interaction logic for PromenaLozinke.xaml
    /// </summary>
    public partial class PromenaLozinke : Window
    {
        public PromenaLozinke()
        {
            InitializeComponent();
        }


        private void PromijeniLozinku(object sender, RoutedEventArgs e)
        {

            var korisnickoIme = KorisnickoIme.Text;
            var lozinka = Lozinka.Text;
            var potrvdaLozinke = PotvrdaLozinke.Text;

            var servis = new Services.Nalozi.KorisnikServis();

            if (korisnickoIme == string.Empty || lozinka == string.Empty || potrvdaLozinke == string.Empty)
            {
                var porukaObavezanUnos = new Poruka(Poruke.ObavezanJeUnosSvihPodataka, Poruke.Poruka, MessageBoxButton.OK);
                porukaObavezanUnos.Owner = this;
                porukaObavezanUnos.ShowDialog();
            }
            else
            {
                //provjeri postojanje korisnika, provjerom postojanja korisnickog imena
                bool postoji = servis.KorisnikPostojiUBazi(korisnickoIme);
                if (postoji)
                {
                    if (lozinka.Equals(potrvdaLozinke))
                    {

                        bool odradjeno = servis.PromjenaLozinke(korisnickoIme, lozinka);

                        if (odradjeno)
                        {
                            var porukaPromjenjenaLozinka = new Poruka(Poruke.LozinkaPromjenjena, Poruke.Poruka, MessageBoxButton.OK);
                            porukaPromjenjenaLozinka.Owner = this;
                            porukaPromjenjenaLozinka.ShowDialog();
                            if (porukaPromjenjenaLozinka.Rezultat == MessageBoxResult.OK)
                            {
                                this.Owner.Show();
                                this.Hide();
                            }

                        }
                        else
                        {
                            var porukaNestoNeValja = new Poruka(Poruke.NestoNeValja, Poruke.Poruka, MessageBoxButton.OK);
                            porukaNestoNeValja.Owner = this;
                            porukaNestoNeValja.ShowDialog();
                        }

                    }
                    else
                    {
                        var porukaNepodudarnosti = new Poruka(Poruke.LozinkeRazlicite, Poruke.Poruka, MessageBoxButton.OK);
                        porukaNepodudarnosti.Owner = this;
                        porukaNepodudarnosti.ShowDialog();

                    }
                }
                else
                {
                    var nemaKorisnikaUBazi = new Poruka(Poruke.KorisnickoImeNePostoji, Poruke.Poruka, MessageBoxButton.OK);
                    nemaKorisnikaUBazi.Owner = this;
                    nemaKorisnikaUBazi.ShowDialog();
                }
            }
        }



        private void Odbaci(object sender, RoutedEventArgs e)
        {
            var korisnickoIme = KorisnickoIme.Text;
            var lozinka = Lozinka.Text;
            var potvrdaLozinke = PotvrdaLozinke.Text;

            if (korisnickoIme != string.Empty || lozinka != string.Empty || potvrdaLozinke != string.Empty)
            {
                var poruka = new Poruka(Poruke.OdbaciPodatke, Poruke.Poruka, MessageBoxButton.YesNo, MessageBoxResult.No);
                poruka.Owner = this;
                poruka.ShowDialog();

                if (poruka.Rezultat == MessageBoxResult.Yes)
                {
                    KorisnickoIme.Text = "";
                    Lozinka.Text = "";
                    PotvrdaLozinke.Text = "";

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
