using OrganizatorProslava.Services.Zabave;
using OrganizatorProslava.ViewModel.Organizator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using OrganizatorProslava.UI.Shared;

namespace OrganizatorProslava.UI.Organizator
{
    /// <summary>
    /// Interaction logic for RestoranOrganizacija.xaml
    /// </summary>
    public partial class RestoranOrganizacija : Window
    {

        private ServisProizvoda servisProizvoda = new ServisProizvoda();

        private Models.Zabava zabavaZaOrganizaciju;

        private Models.Proizvod selektovaniRestoran;

        public RestoranOrganizacija(Models.Zabava zabavaKojuOrganizujemo)
        {
            InitializeComponent();

            zabavaZaOrganizaciju = zabavaKojuOrganizujemo;
            //postavljanje podataka iz zahteva za organizaciju zabave
            infomacije.Text = "Lokacija:" + zabavaZaOrganizaciju.Grad + "\nBrojZvanica:" + zabavaKojuOrganizujemo.BrojGostiju + "\nUkupno:";

            //mora pisati sala u proizvodima za naziv 
            List<Models.Proizvod> restorani = (from res in servisProizvoda.GetProizvode() where res.Sardanik.TipSaradnikaId == 3 && res.Naziv == "Sala" select res).ToList();
            this.DataContext = new ProizvodiViewModel(restorani);

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

        private void button_pregledaj(object sender, RoutedEventArgs e)
        {
            selektovaniRestoran = (Models.Proizvod)restoran1.SelectedItem;


            if (selektovaniRestoran != null)
            {
                if (!this.servisProizvoda.RestoranJeDostupan(this.zabavaZaOrganizaciju.Id, selektovaniRestoran.Id))
                {
                    Poruka poruka = new Poruka("Ovaj restoran Vam nije dostupan jer ste već odbrali stvari iy nekog drugog.", "Obaveštenje", MessageBoxButton.OK);
                    poruka.Owner = this;
                    poruka.ShowDialog();
                    return;
                }

                RestoranOrganizacija2 pregled = new RestoranOrganizacija2(zabavaZaOrganizaciju, selektovaniRestoran);
                pregled.Owner = this;
                pregled.Show();
            }
            else
            {
                MessageBox.Show("Molimo vas prvo izaberite restoran za koji zelite da izvrsite pregled.", "Info restorani", MessageBoxButton.OKCancel);
            }
        }

        private void OnKeyDownHandler(object sender, RoutedEventArgs e)
        {
            //pretraga restorana po nazivu..
            string trazenje = pretragaRestorana.Text;

            List<Models.Proizvod> restorani = (from res in servisProizvoda.GetProizvode() where res.Sardanik.TipSaradnikaId == 3 && res.Naziv == "Sala" && (res.Sardanik.Naziv).ToUpper() == trazenje.ToUpper() select res).ToList();

            this.DataContext = new ProizvodiViewModel(restorani);

            if (pretragaRestorana.Text == "")
            {
                restorani = (from res in servisProizvoda.GetProizvode() where res.Sardanik.TipSaradnikaId == 3 && res.Naziv == "Sala" select res).ToList();
                this.DataContext = new ProizvodiViewModel(restorani);
            }

        }

        private void filtriranje_odgovarajucih_restorana_Checked(object sender, RoutedEventArgs e)
        {
            List<Models.Proizvod> restorani = (from res in servisProizvoda.GetProizvode() where res.Sardanik.TipSaradnikaId == 3 && res.Naziv == "Sala" select res).ToList();
            this.DataContext = new ProizvodiViewModel(restorani);

            List<Models.Proizvod> odgovarajuciRestorani = new List<Models.Proizvod>();

            foreach (var res in restorani)
            {

                int brojZvanica = Int32.Parse(res.Opis);

                if ((res.Sardanik.Adresa.ToUpper()).Contains(zabavaZaOrganizaciju.Grad.ToUpper()) &&
                    (brojZvanica >= zabavaZaOrganizaciju.BrojGostiju))
                {

                    odgovarajuciRestorani.Add(res);
                }
            }

            this.DataContext = new ProizvodiViewModel(odgovarajuciRestorani);

        }
        private void prikaz_svih_Checked(object sender, EventArgs e)
        {
            {
                List<Models.Proizvod> restorSvi = (from res in servisProizvoda.GetProizvode() where res.Sardanik.TipSaradnikaId == 3 && res.Naziv == "Sala" select res).ToList();
                this.DataContext = new ProizvodiViewModel(restorSvi);
            }
        }
    }
}
