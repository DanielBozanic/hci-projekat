using OrganizatorProslava.Services.Zabave;
using OrganizatorProslava.ViewModel.Organizator;
using System;
using System.Collections.Generic;
using System.Windows;
using OrganizatorProslava.UI.Shared;

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
            Poruka poruka = new Poruka("Da li ste sigurni da želite sa sačuvate odabranu dekoraciju?", "Čuvanje cveća", MessageBoxButton.YesNo, MessageBoxResult.No);
            poruka.Owner = this;
            poruka.ShowDialog();
            if (poruka.Rezultat == MessageBoxResult.No) return;
            this.servis.Sacuvaj(this.zabavaKojuOrganizujemo.Id, this.dodatiProizvodi);
            poruka = new Poruka("Uspešno ste sačuvali dekoraciju", "Čuvanje cveća", MessageBoxButton.OK);
            poruka.Owner = this;
            poruka.ShowDialog();
            this.Close();
        }
        private void button_obrisi(object sender, RoutedEventArgs e)
        {
            Models.Proizvod selektovanoCvece = (Models.Proizvod)pregledIzabraneDekor.SelectedItem;
            Poruka poruka = null;
            if (selektovanoCvece == null)
            {
                poruka = new Poruka("Morate selektovati neko cveće pre nego što pritisnete \"obriši\".", "Obaveštenje", MessageBoxButton.OK);
                poruka.Owner = this;
                poruka.ShowDialog();
                return;
            }

            prikaz.UkloniProizvod(selektovanoCvece);
            dodatiProizvodi.Remove(selektovanoCvece);

            this.DataContext = prikaz;

        }

    }
}
