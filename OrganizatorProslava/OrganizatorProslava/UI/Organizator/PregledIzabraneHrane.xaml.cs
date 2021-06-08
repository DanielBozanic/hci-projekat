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
    /// Interaction logic for PregledIzabraneHrane.xaml
    /// </summary>
    public partial class PregledIzabraneHrane : Window
    {
        private List<Models.Proizvod> proizvodiDodavanje;
        private Models.Zabava zabavaKojuOrganizujemo;
        private Models.Proizvod selektovaniRestoran;

        private ProizvodiViewModel prikaz;


        public PregledIzabraneHrane(Models.Proizvod izabraniRestoran, Models.Zabava zabavaOrganizacija, List<Models.Proizvod> dodataHrana)
        {
            InitializeComponent();

            proizvodiDodavanje = dodataHrana;
            zabavaKojuOrganizujemo = zabavaOrganizacija;
            selektovaniRestoran = izabraniRestoran;

            //podesavanje podataka iz zahteva
            infomacije.Text = "Restoran:" + izabraniRestoran.Sardanik.Naziv + "Broj zvanica:" + zabavaKojuOrganizujemo.BrojGostiju + "\nUkupno:";
            prikaz = new ProizvodiViewModel(dodataHrana);
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
            /*MessageBoxResult rez = MessageBox.Show("Zelite li da sacuvate dodatu hranu?", "Cuvanje hrane", MessageBoxButton.YesNo, MessageBoxImage.Question);

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
            Models.Proizvod selektovanaHrana = (Models.Proizvod)pregledIzabraneHrane.SelectedItem;

            //ako nista nije selktovano a kliknuto na brisanje
            if (selektovanaHrana == null)
            {
                MessageBox.Show("Morate prvo selektovati hranu koju zelite da obrisete.", "Brisanje info", MessageBoxButton.OKCancel);

            }
            else
            {
                MessageBoxResult rez = MessageBox.Show("Da li zelite da obrisete " + selektovanaHrana.Naziv + " iz dodate hrane?", "Cuvanje hrane", MessageBoxButton.YesNo, MessageBoxImage.Question);

                switch (rez)
                {
                    case MessageBoxResult.Yes:
                        prikaz.UkloniProizvod(selektovanaHrana);
                        proizvodiDodavanje.Remove(selektovanaHrana);

                        this.DataContext = prikaz;

                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
        }
    }
}
