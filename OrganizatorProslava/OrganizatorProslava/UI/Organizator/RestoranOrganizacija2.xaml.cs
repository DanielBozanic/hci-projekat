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
    /// Interaction logic for RestoranOrganizacija2.xaml
    /// </summary>
    public partial class RestoranOrganizacija2 : Window
    {
        private Models.Zabava zabavaZaOrganizaciju;
        private Models.Proizvod izabraniRestoran;

        public RestoranOrganizacija2(Models.Zabava zabavaKojuOrganizujemo, Models.Proizvod selektovaniRestoran)
        {
            InitializeComponent();
            izabraniRestoran = selektovaniRestoran;

            //automatsko prepisivanje podatka iz zahteva
            zabavaZaOrganizaciju = zabavaKojuOrganizujemo;

            brojZvanica.Text = zabavaZaOrganizaciju.BrojGostiju.ToString();
            mestoRestorana.Text = zabavaZaOrganizaciju.Grad;

            //automatsko ucitavanje restorana koji su na toj lokaciji u combo box.. --moze da se promeni neki restoran
            //???????????????????????????????????????????????????????????
            nazivRestorana.Text = selektovaniRestoran.Sardanik.Naziv;
        }
        private void vracanje(object sender, EventArgs e)
        {
            ///////////////////////////////
            /*this.Owner.Hide();
            List<Models.Proizvod> proizvodiCvecare = (from proizvod in servis.GetProizvodeZaSaradnika(izabranaCvecara.Id) select proizvod).ToList();

            this.DataContext = new ProizvodiViewModel(proizvodiCvecare);*/
        }

        private void zatvaranje(object sender, EventArgs e)
        {
            this.Owner.Show();
        }

        private void button_nazad(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void button_sacuvaj_restoran(object sender, RoutedEventArgs e)
        {
            //preuzmemo selektovani proizvod
            /*
            MessageBoxResult rezultat = MessageBox.Show("Da li zelite da sacuvate izabrani restoran?", "Cuvanje restorana", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

            switch (rezultat)
            {
                case MessageBoxResult.Yes:

                    MessageBox.Show("Restoran za zabavu je sacuvan.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
                case MessageBoxResult.No:
                    break;
                case MessageBoxResult.Cancel:
                    break;

            }*/
        }
        private void button_pregledaj_meni_hrana(object sender, RoutedEventArgs e)
        {
            MeniHrana pregled = new MeniHrana(izabraniRestoran, zabavaZaOrganizaciju);
            pregled.Owner = this;
            pregled.Show();
        }
    }
}
