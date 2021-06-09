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
    /// Interaction logic for PregledIzabraneDekoracije.xaml
    /// </summary>
    public partial class PregledIzabraneDekoracije : Window
    {
        private ServisProizvoda servis = new ServisProizvoda();

        private List<Models.Proizvod> dodatiProizvodi = new List<Models.Proizvod>();

        private ProizvodiViewModel prikaz;

        private Models.Zabava zabavaKojuOrganizujemo;

        public PregledIzabraneDekoracije(List<Models.Proizvod> izabraniProizvodiCvecare, Models.Saradnik cvecaraIzabrana, Models.Zabava zabavaOrganizacija)
        {
            InitializeComponent();

            dodatiProizvodi = izabraniProizvodiCvecare;
            zabavaKojuOrganizujemo = zabavaOrganizacija;

            //prepisivanje zelja iz zahteva za organizaciju korisnika
            infomacije.Text = "Zelja klijenta:" + zabavaKojuOrganizujemo.DodatneZelje + "\nUkupno:";

            //treba pronaci izabrane proizvode iz baze i prikazati ih...
            prikaz = new ProizvodiViewModel(izabraniProizvodiCvecare);
            this.DataContext = prikaz;

        }

        private void vracanje(object sender, EventArgs e)
        {
            /*this.Owner.Hide();
            List<Models.Proizvod> vecDodatiProizvodi = dodatiProizvodi;

            this.DataContext = new ProizvodiViewModel(vecDodatiProizvodi);*/
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
            MessageBoxResult rez = MessageBox.Show("Zelite li da sacuvate dodato cvece?", "Cuvanje cveca", MessageBoxButton.YesNo, MessageBoxImage.Question);

            switch (rez)
            {
                case MessageBoxResult.Yes:


                    break;
                case MessageBoxResult.No:
                    break;
            }
        }
        private void button_obrisi(object sender, RoutedEventArgs e)
        {
            Models.Proizvod selektovanoCvece = (Models.Proizvod)pregledIzabraneDekor.SelectedItem;

            prikaz.UkloniProizvod(selektovanoCvece);
            dodatiProizvodi.Remove(selektovanoCvece);

            this.DataContext = prikaz;

        }

    }
}
