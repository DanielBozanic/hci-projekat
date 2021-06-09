using OrganizatorProslava.ViewModel.Organizator;
using System;
using System.Collections.Generic;
using System.Windows;
using OrganizatorProslava.UI.Shared;
using OrganizatorProslava.Services.Zabave;

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
        private ServisProizvoda servis = new ServisProizvoda();
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
            Poruka poruka = new Poruka("Da li ste sigurni da želite sa sačuvate odabranu hranu?", "Čuvanje hrane", MessageBoxButton.YesNo, MessageBoxResult.No);
            poruka.Owner = this;
            poruka.ShowDialog();
            if (poruka.Rezultat == MessageBoxResult.No) return;
            this.servis.Sacuvaj(this.zabavaKojuOrganizujemo.Id, this.proizvodiDodavanje);
            poruka = new Poruka("Uspešno ste sačuvali meni", "Čuvanje menia", MessageBoxButton.OK);
            poruka.Owner = this;
            poruka.ShowDialog();
            this.Close();
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
