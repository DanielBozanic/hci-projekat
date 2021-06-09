using OrganizatorProslava.Services.Saradnici;
using OrganizatorProslava.Services.Zabave;
using OrganizatorProslava.ViewModel.Administrator;
using OrganizatorProslava.ViewModel.Organizator;
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
    /// Interaction logic for PregledPonudeCvecare.xaml
    /// </summary>
    public partial class PregledPonudeCvecare : Window
    {
        private ServisProizvoda servis = new ServisProizvoda();
        private Models.Saradnik izabranaCvecara;

        public List<Models.Proizvod> izabraniProizvodi = new List<Models.Proizvod>();

        private Models.Zabava zabavaKojuOrganizujemo;

        // kao parametar konstruktora prosledicu konkretno selektovanu cvecaru iz koje trebam da iscitam podatke..
        public PregledPonudeCvecare(Models.Saradnik selektovanaCvecara, Models.Zabava zabavaOrganizacija)
        {
            InitializeComponent();
            izabranaCvecara = selektovanaCvecara;
            zabavaKojuOrganizujemo = zabavaOrganizacija;

            infomacije.Text = "Zelja klijenta:" + zabavaKojuOrganizujemo.DodatneZelje + "\nUkupno:";


            //treba pronaci za tu selektovanu cvecaru konkretne proizvode i iscitati ih iz baze podataka.
            List<Models.Proizvod> proizvodiCvecare = (from proizvod in servis.GetProizvodeZaSaradnika(selektovanaCvecara.Id) select proizvod).ToList();
            /*string vrednosti = "";
            foreach (var el in proizvodiCvecare)
            {
                vrednosti += el.Naziv;
            }
            MessageBox.Show(vrednosti);*/

            this.DataContext = new ProizvodiViewModel(proizvodiCvecare);


            //this.DataContext = new SaradniciViewModel(cvecare);
        }

        private void vracanje(object sender, EventArgs e)
        {
            ///////////////////////////////
            this.Owner.Hide();
            List<Models.Proizvod> proizvodiCvecare = (from proizvod in servis.GetProizvodeZaSaradnika(izabranaCvecara.Id) select proizvod).ToList();

            this.DataContext = new ProizvodiViewModel(proizvodiCvecare);
        }

        private void zatvaranje(object sender, EventArgs e)
        {
            this.Owner.Show();
        }

        private void button_nazad(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void button_dodaj(object sender, RoutedEventArgs e)
        {
            //preuzmemo selektovani proizvod
            Models.Proizvod proizvodDodavanje = (Models.Proizvod)pregledPonudeCvecare.SelectedItem;


            if (proizvodDodavanje == null)
            {
                MessageBox.Show("Molimo vas prvo izaberite proizvod za koji zelite da dodate.", "Info cvecare", MessageBoxButton.OKCancel);

            }
            else
            {
                MessageBoxResult rezultat = MessageBox.Show("Da li zelite da dodate " + proizvodDodavanje.Naziv + " u izabranu dekoraciju?", "Dodavanje prozivoda", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

                switch (rezultat)
                {
                    case MessageBoxResult.Yes:
                        izabraniProizvodi.Add(proizvodDodavanje);

                        MessageBox.Show("Proizvod je dodat u izabrane dekoracije.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;
                    case MessageBoxResult.No:
                        break;
                    case MessageBoxResult.Cancel:
                        break;

                }
            }
        }
        private void button_pregled_izabrane_dekoracije(object sender, RoutedEventArgs e)
        {
            PregledIzabraneDekoracije pregled = new PregledIzabraneDekoracije(izabraniProizvodi, izabranaCvecara, zabavaKojuOrganizujemo);
            pregled.Owner = this;
            pregled.Show();
        }


        private void OnKeyDownHandler(object sender, RoutedEventArgs e)
        {
            // pretraga cveca za izabranu cvecaru..

            string nazivCveca = pretragaCveca.Text;

            //MessageBox.Show(nazivCveca);
            List<Models.Proizvod> pronadjenoCvece = (from proizvod in servis.GetProizvodeZaSaradnika(izabranaCvecara.Id) where proizvod.Naziv.ToUpper() == nazivCveca.ToUpper() select proizvod).ToList();
            this.DataContext = new ProizvodiViewModel(pronadjenoCvece);

            if (nazivCveca == "")
            {
                pronadjenoCvece = (from proizvod in servis.GetProizvodeZaSaradnika(izabranaCvecara.Id) select proizvod).ToList();
                this.DataContext = new ProizvodiViewModel(pronadjenoCvece);
            }
            //doraditi ovu pretragu... da baca greske ako je prazan unos
        }
    }
}
