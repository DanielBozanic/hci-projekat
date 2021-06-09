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
    /// Interaction logic for Muzika.xaml
    /// </summary>
    public partial class Muzika : Window
    {
        private ServisProizvoda servis = new ServisProizvoda();
        private List<Models.Proizvod> dodatiMuzicari = new List<Models.Proizvod>();
        private Models.Zabava zabavaZaOrganizovanje;

        public Muzika(Models.Zabava zabavaOrganizovanje)
        {
            InitializeComponent();
            zabavaZaOrganizovanje = zabavaOrganizovanje;

            //podaci iz zahteva za organizaciju
            infomacije.Text = "Zelja klijenta:" + zabavaOrganizovanje.DodatneZelje + "\nUkupno:";

            List<Models.Proizvod> listaMuzicara = (from muzika in servis.GetProizvode() where muzika.Sardanik.TipSaradnikaId == 2 select muzika).ToList();

            this.DataContext = new ProizvodiViewModel(listaMuzicara);
        }
        private void vracanje(object sender, EventArgs e)
        {
            this.Owner.Hide();
        }

        private void zatvaranje(object sender, EventArgs e)
        {
            this.Owner.Show();
        }


        private void dugme_izaberi(object sender, EventArgs e)
        {
            Models.Proizvod proizvodDodavanje = (Models.Proizvod)muzika.SelectedItem;

            Poruka poruka = null;
            if (proizvodDodavanje == null)
            {
                poruka = new Poruka("Morate selektovati grupu pre nego što pritisnete \"izaberi\".", "Obaveštenje", MessageBoxButton.OK);
                poruka.Owner = this;
                poruka.ShowDialog();
                return;
            }

            MessageBoxResult rezultat = MessageBox.Show("Da li zelite da dodate muzicku grupu sa nazivom" + proizvodDodavanje.Naziv + "?", "Dodavanje prozivoda", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

            switch (rezultat)
            {
                case MessageBoxResult.Yes:
                    dodatiMuzicari.Add(proizvodDodavanje);

                    //MessageBox.Show("Izabrana muzicka grupa je dodata kao izvodjac na zabavi.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
                case MessageBoxResult.No:
                    break;
                case MessageBoxResult.Cancel:
                    break;
            }
        }

        private void dugme_nazad(object sender, EventArgs e)
        {
            this.Close();
        }
        private void OnKeyDownHandler(object sender, RoutedEventArgs e)
        {
            String nazivMuzickeGrupe = pretragaMuzike.Text;
            List<Models.Proizvod> muzickeGrupe = (from muzika in servis.GetProizvode() where muzika.Sardanik.TipSaradnikaId == 2 && muzika.Naziv.ToUpper() == pretragaMuzike.Text.ToUpper() select muzika).ToList();
            this.DataContext = new ProizvodiViewModel(muzickeGrupe);

            if (pretragaMuzike.Text == "")
            {
                List<Models.Proizvod> muzika2 = (from muzika in servis.GetProizvode() where muzika.Sardanik.TipSaradnikaId == 2 select muzika).ToList();
                this.DataContext = new ProizvodiViewModel(muzika2);
            }
        }

        private void dugme_pregled_izabranih_grupa(object sender, RoutedEventArgs e)
        {
            PregledIzabraneMuzike muz = new PregledIzabraneMuzike(zabavaZaOrganizovanje, dodatiMuzicari);
            muz.Owner = this;
            muz.Show();
        }
    }
}
