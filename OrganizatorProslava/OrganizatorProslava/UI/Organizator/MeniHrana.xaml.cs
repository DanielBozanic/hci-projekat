using OrganizatorProslava.Services.Zabave;
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
    /// Interaction logic for MeniHrana.xaml
    /// </summary>
    public partial class MeniHrana : Window
    {
        private List<Models.Proizvod> listaIzabraneHrane = new List<Models.Proizvod>();

        private Models.Proizvod selektovaniRestoran;
        private Models.Zabava zabavaZaOrganizaciju;
        private ServisProizvoda servisProizvoda = new ServisProizvoda();

        public MeniHrana(Models.Proizvod izabraniRestoran, Models.Zabava zabavaKojuOrganizujemo)
        {
            InitializeComponent();
            selektovaniRestoran = izabraniRestoran;
            zabavaZaOrganizaciju = zabavaKojuOrganizujemo;

            //podesavanje zahteva korisnika
            infomacije.Text = "Lokacija:" + zabavaZaOrganizaciju.Grad + "\nBrojZvanica:" + zabavaKojuOrganizujemo.BrojGostiju + "\nUkupno:";



            //ucitavanje hrane za selektovani restoran
            List<Models.Proizvod> hranaSva = (from hrana in servisProizvoda.GetProizvodeZaSaradnika(selektovaniRestoran.Sardanik.Id) where hrana.Naziv != "Sala" select hrana).ToList();
            this.DataContext = new ProizvodiViewModel(hranaSva);


        }
        private void vracanje(object sender, EventArgs e)
        {
            ///////////////////////////////
            /* this.Owner.Hide();
             List<Models.Proizvod> proizvodiCvecare = (from proizvod in servis.GetProizvodeZaSaradnika(izabranaCvecara.Id) select proizvod).ToList();

             this.DataContext = new ProizvodiViewModel(proizvodiCvecare);
             */
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
            Models.Proizvod proizvodDodavanje = (Models.Proizvod)meniHranaPrikaz.SelectedItem;

            //ako nije selektovana hrana a kliknuto dodavanje
            if (proizvodDodavanje == null)
            {
                MessageBox.Show("Molimo vas prvo selektujte hranu koju zelite da dodate u meni.", "Dodavanje hrane info", MessageBoxButton.OKCancel);
            }
            else
            {
                MessageBoxResult rezultat = MessageBox.Show("Da li zelite da dodate " + proizvodDodavanje.Naziv + "?", "Dodavanje hrane", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

                switch (rezultat)
                {
                    case MessageBoxResult.Yes:
                        listaIzabraneHrane.Add(proizvodDodavanje);

                        MessageBox.Show("Izabrana hrana je dodata u meni za zabavu.", "Info", MessageBoxButton.OK);
                        break;
                    case MessageBoxResult.No:
                        break;
                    case MessageBoxResult.Cancel:
                        break;

                }
            }
        }
        private void button_pregled_izabrane_hrane(object sender, RoutedEventArgs e)
        {
            PregledIzabraneHrane pregled = new PregledIzabraneHrane(selektovaniRestoran, zabavaZaOrganizaciju, listaIzabraneHrane);
            pregled.Owner = this;
            pregled.Show();
        }


        private void OnKeyDownHandler(object sender, RoutedEventArgs e)
        {
            // pretraga hrane za izabrani restoran..

            string nazivPretraga = pretragaHrane.Text;


            List<Models.Proizvod> pronadjenaHrana = (from hrana in servisProizvoda.GetProizvodeZaSaradnika(selektovaniRestoran.Sardanik.Id) where hrana.Naziv.ToUpper() == nazivPretraga.ToUpper() select hrana).ToList();
            this.DataContext = new ProizvodiViewModel(pronadjenaHrana);

            if (nazivPretraga == "")
            {
                List<Models.Proizvod> hranaSva = (from hrana in servisProizvoda.GetProizvodeZaSaradnika(selektovaniRestoran.Sardanik.Id) where hrana.Naziv != "Sala" select hrana).ToList();
                this.DataContext = new ProizvodiViewModel(hranaSva);
            }
            //doraditi ovu pretragu... da baca greske ako je prazan unos*/
        }
    }
}
