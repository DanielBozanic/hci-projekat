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
using OrganizatorProslava.Models;

namespace OrganizatorProslava.UI.Korisnici
{
    /// <summary>
    /// Interaction logic for Zakazivanje2.xaml
    /// </summary>
    public partial class Zakazivanje2 : Window
    {
        public static Zabava zabava = new Zabava();


        public Zakazivanje2()
        {
            InitializeComponent();
            

            fiksanBudzet.Items.Add("DA");
            fiksanBudzet.Items.Add("NE");

            var servis = new Services.Nalozi.KorisnikServis();
            var listaOrganizatora = servis.dobaviSveOrganizatore();

            System.Collections.IList list = listaOrganizatora;
            for (int i = 0; i < list.Count; i++)
            {
                Korisnik organizatorItem = (Korisnik)list[i];
                organizator.Items.Add(organizatorItem.Ime + " " + organizatorItem.Prezime);
            }
        }

        private void spisakZvanicaKlik(object sender, RoutedEventArgs e)
        {

        }

        private void dodatneZeljeKlik(object sender, RoutedEventArgs e)
        {

        }

        private void zakaziKlik(object sender, RoutedEventArgs e)
        {

        }

        private void odustaniKlik(object sender, RoutedEventArgs e)
        {

        }

        private void nazadKlik(object sender, RoutedEventArgs e)
        {

        }
    }
}
