using OrganizatorProslava.Services.Saradnici;
using OrganizatorProslava.ViewModel.Administrator;
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


namespace OrganizatorProslava.UI.Organizator
{
    /// <summary>
    /// Interaction logic for Cvecare.xaml
    /// </summary>
    public partial class Cvecare : Window
    {
        private SaradnikServis servis = new SaradnikServis();

        private Models.Zabava zabavaKojuOrganizujemo;

        public Cvecare(Models.Zabava zabavaOrganizacija)
        {
            InitializeComponent();
            this.zabavaKojuOrganizujemo = zabavaOrganizacija;

            List<Models.Saradnik> cvecare = (from cvecara in servis.GetSaradnici() where cvecara.TipSaradnikaId == 1 select cvecara).ToList();
            this.DataContext = new SaradniciViewModel(cvecare);

            infomacije.Text = "Zelja klijenta:" + zabavaKojuOrganizujemo.DodatneZelje + "\nUkupno:";

        }

        private void vracanje(object sender, EventArgs e)
        {
            this.Owner.Hide();
            List<Models.Saradnik> cvecare = (from cvecara in servis.GetSaradnici() where cvecara.TipSaradnikaId == 1 select cvecara).ToList();

            this.DataContext = new SaradniciViewModel(cvecare);
        }

        private void zatvaranje(object sender, EventArgs e)
        {
            this.Owner.Show();
        }

        private void button_nazad(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button_pregledaj(object sender, RoutedEventArgs e)
        {
            //treba da preuzmemo taj sto je selektovan red njegove podatke
            //var s = (Models.Saradnik)cvecare.SelectedItem;

            //sad ovde treba da se ucita prozor sa podacima za specificnu cvecaru..
            //MessageBox.Show(s.Naziv + "adresa je: " + s.Adresa);

            if ((Models.Saradnik)cvecare.SelectedItem == null)
            {
                MessageBox.Show("Morate prvo selektovati cvecaru za koju zelite da pregledate proizvode.", "Informacija",
                    MessageBoxButton.OKCancel, MessageBoxImage.Information);
            }
            else
            {
                PregledPonudeCvecare pregled = new PregledPonudeCvecare((Models.Saradnik)cvecare.SelectedItem, zabavaKojuOrganizujemo);
                pregled.Owner = this;
                pregled.Show();
            }


            //dodati da ako nije selektovana cvecara kaze morate prvo selektovati cvecaru.

        }

        private void OnKeyDownHandler(object sender, RoutedEventArgs e)
        {
            String nazivCvecarePretraga = pretragaCvecara.Text;

            List<Models.Saradnik> cvecare = (from cvecara in servis.GetSaradnici() where cvecara.Naziv.ToUpper() == nazivCvecarePretraga.ToUpper() select cvecara).ToList();
            this.DataContext = new SaradniciViewModel(cvecare);

            if (pretragaCvecara.Text == "")
            {
                List<Models.Saradnik> cvecare2 = (from cvecara in servis.GetSaradnici() where cvecara.TipSaradnikaId == 1 select cvecara).ToList();
                this.DataContext = new SaradniciViewModel(cvecare2);
            }
        }
    }
}
