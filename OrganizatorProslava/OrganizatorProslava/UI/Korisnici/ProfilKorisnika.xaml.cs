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
            Ime.FontSize = 20;
            Ime.FontFamily = new FontFamily("Arial Black");
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
            this.Close();
            var uvidUZakazanuZabavu = new UvidUZakazanuZabavu();
            uvidUZakazanuZabavu.Owner = this;
            uvidUZakazanuZabavu.Show();
        }





        private void IstorijaZabava(object sender, RoutedEventArgs e)
        {
            this.Close();
            var istorijaZabava = new Istorija();
            istorijaZabava.Owner = this;
            istorijaZabava.Show();
        }





        private void vasiZahtevi(object sender, RoutedEventArgs e)
        {
            this.Close();
            var zahtjevi = new Zahtevi();
            zahtjevi.Owner = this;
            zahtjevi.Show();
        }





        private void OdjaviSe(object sender, RoutedEventArgs e)
        {
            LogovaniKorisnik.Reset();
            this.Close();
            var prijava = new UI.Nalozi.Prijava();
            prijava.Show();

        }

       
    }
}
