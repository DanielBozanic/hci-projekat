using OrganizatorProslava.Models;
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
    /// Interaction logic for ProfilKorisnika.xaml
    /// </summary>
    public partial class ProfilKorisnika : Window
    {

        public ProfilKorisnika()
        {
            InitializeComponent();
            string[] razvdvajanjePunogImena = LogovaniKorisnik.PunoIme.Split(' ');


            //2 nacina kako mozete manipulisati 
            TextBlock Ime = new TextBlock();
            Ime.HorizontalAlignment = HorizontalAlignment.Left;
            Ime.TextWrapping = TextWrapping.Wrap;
            Ime.VerticalAlignment = VerticalAlignment.Top;
            Ime.Margin = new Thickness(105, 167, 0, 0);
            Ime.Width = 180;
            Ime.Height = 30;
            Ime.FontSize = 25;
            Ime.FontFamily = new FontFamily("Segoe UI");
            Ime.FontWeight = FontWeights.Bold;
            Ime.Text = razvdvajanjePunogImena[0];
            grid.Children.Add(Ime);


            Prezime.Text = razvdvajanjePunogImena[1];

        }





        private void azurirajProfil(object sender, RoutedEventArgs e)
        {

            var azurirajProfil = new AzurirajProfilKorisnika();
            azurirajProfil.Owner = this;
            azurirajProfil.Show();
            this.Hide();
        }





        private void zakaziZabavu(object sender, RoutedEventArgs e)
        {
            var zakazi = new Zakazivanje();
            zakazi.Owner = this;
            zakazi.Show();
            this.Hide();
        }





        private void uvidUZakazanuZabavu(object sender, RoutedEventArgs e)
        {
            var uvidUZakazanuZabavu = new UvidUZakazanuZabavu();
            uvidUZakazanuZabavu.Owner = this;
            uvidUZakazanuZabavu.Show();
            this.Hide();
        }


        private void IstorijaZabava(object sender, RoutedEventArgs e)
        {
            var istorijaZabava = new Istorija();
            istorijaZabava.Owner = this;
            istorijaZabava.Show();
            this.Hide();
        }





        private void vasiZahtevi(object sender, RoutedEventArgs e)
        {
            var zahtjevi = new Zahtevi();
            zahtjevi.Owner = this;
            zahtjevi.Show();
            this.Hide();
        }



        private void OdjaviSe(object sender, RoutedEventArgs e)
        {
            LogovaniKorisnik.Reset();
            this.Owner.Show();
            this.Hide();

        }

        private void PromjenaLozinke(object sender, RoutedEventArgs e)
        {
            var promjenaLozinke = new UI.Korisnici.PromenaLozinke();
            promjenaLozinke.Show();
            this.Hide();
        }


        private void Window_Closed(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Hide();
        }
    }
}
