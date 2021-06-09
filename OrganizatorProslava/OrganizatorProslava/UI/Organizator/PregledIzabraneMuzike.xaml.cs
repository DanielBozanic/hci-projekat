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
    /// Interaction logic for PregledIzabraneMuzike.xaml
    /// </summary>
    public partial class PregledIzabraneMuzike : Window
    {
        private List<Models.Proizvod> izabraneMuzickeGrupe;

        private Models.Zabava zabavaKojuOrganizujemo;

        private ProizvodiViewModel prikaz;

        public PregledIzabraneMuzike(Models.Zabava zabavaZaOrganizovanje, List<Models.Proizvod> izabranaMuzika)
        {
            InitializeComponent();
            zabavaKojuOrganizujemo = zabavaZaOrganizovanje;
            izabraneMuzickeGrupe = izabranaMuzika;

            //podaci iz zahteva
            infomacije.Text = "Zelja klijenta:" + zabavaKojuOrganizujemo.DodatneZelje + "\nUkupno:";


            prikaz = new ProizvodiViewModel(izabraneMuzickeGrupe);
            this.DataContext = prikaz;

        }

        private void vracanje(object sender, EventArgs e)
        {

        }

        private void zatvaranje(object sender, EventArgs e)
        {
            this.Owner.Show();
        }

        private void button_nazad(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void button_sacuvaj(object sender, RoutedEventArgs e)
        {
            //ako nista nije ubaceno u listu za dodavanje izbaciti upozorenje (prazna lista)..

            /*MessageBoxResult rez = MessageBox.Show("Zelite li da sacuvate dodate muzicke grupe?", "Cuvanje muzike", MessageBoxButton.YesNo, MessageBoxImage.Question);

            switch (rez)
            {
                case MessageBoxResult.Yes:


                    break;
                case MessageBoxResult.No:
                    break;
            }*/
        }
        private void button_obrisi(object sender, RoutedEventArgs e)
        {
            Models.Proizvod selektovanaMuzika = (Models.Proizvod)pregledIzabraneMuzike.SelectedItem;

            //ako nista nije selktovano a kliknuto na brisanje
            if (selektovanaMuzika == null)
            {
                MessageBox.Show("Morate prvo selektovati muzicku grupu koju zelite da obrisete.", "Brisanje info", MessageBoxButton.OKCancel);

            }
            else
            {
                MessageBoxResult rez = MessageBox.Show("Da li zelite da obrisete " + selektovanaMuzika.Naziv + " iz liste dodatih muzickih grupa?", "Brisanje muzika", MessageBoxButton.YesNo, MessageBoxImage.Question);

                switch (rez)
                {
                    case MessageBoxResult.Yes:
                        prikaz.UkloniProizvod(selektovanaMuzika);
                        izabraneMuzickeGrupe.Remove(selektovanaMuzika);

                        this.DataContext = prikaz;

                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
        }
    }
}
