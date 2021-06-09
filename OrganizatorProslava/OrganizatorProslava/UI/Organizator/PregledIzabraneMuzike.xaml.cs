using OrganizatorProslava.ViewModel.Organizator;
using System;
using System.Collections.Generic;
using System.Windows;
using OrganizatorProslava.UI.Shared;
using OrganizatorProslava.Services.Zabave;

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

        private ServisProizvoda servis = new ServisProizvoda();

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
            Poruka poruka = new Poruka("Da li ste sigurni da želite sa sačuvate odabranu muziku?", "Čuvanje muzike", MessageBoxButton.YesNo, MessageBoxResult.No);
            poruka.Owner = this;
            poruka.ShowDialog();
            if (poruka.Rezultat == MessageBoxResult.No) return;
            this.servis.Sacuvaj(this.zabavaKojuOrganizujemo.Id, this.izabraneMuzickeGrupe);
            poruka = new Poruka("Uspešno ste sačuvali odabranu muziku", "Čuvanje muzike", MessageBoxButton.OK);
            poruka.Owner = this;
            poruka.ShowDialog();
            this.Close();
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
