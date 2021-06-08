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

namespace OrganizatorProslava.UI.Korisnici
{
    /// <summary>
    /// Interaction logic for PrikaziZahtjev.xaml
    /// </summary>
    public partial class PrikaziZahtjev : Window
    {
        Models.Zabava zahtjev;
        public PrikaziZahtjev(Models.Zabava izabraniZahtjev)
        {
            InitializeComponent();
            this.tipZabave.Text = izabraniZahtjev.Tip;
            this.IzabranDatum.Text = $"{izabraniZahtjev.DatumProslave.Month}/{izabraniZahtjev.DatumProslave.Day}/{izabraniZahtjev.DatumProslave.Year}";
            this.vremenskoTrajanje.Text = izabraniZahtjev.Trajanje.ToString();
            this.zakazanoVrijeme.Text = $"{izabraniZahtjev.DatumProslave.Hour}:{izabraniZahtjev.DatumProslave.Minute}";
            this.grad.Text = izabraniZahtjev.Grad;
            this.tema.Text = izabraniZahtjev.Tema;
            this.budzettb.Text = izabraniZahtjev.Budzet.ToString();
            this.brojGostiju.Text = izabraniZahtjev.BrojGostiju.ToString();

            if (izabraniZahtjev.TipBudzeta)
            {
                this.fiksanB.Text = "DA";
            }
            else
            {
                this.fiksanB.Text = "NE";
            }

            this.org.Text = $"{izabraniZahtjev.Organizator.Ime} {izabraniZahtjev.Organizator.Prezime}";
            zahtjev = izabraniZahtjev;
        }



        private void Window_Closed(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Hide();
        }

        private void spisakZvanicaKlik(object sender, RoutedEventArgs e)
        {
            PrikaziSpisakZvanica zelje = new PrikaziSpisakZvanica(zahtjev);
            zelje.Owner = this;
            zelje.Show();
            this.Hide();
        }

        private void dodatneZeljeKlik(object sender, RoutedEventArgs e)
        {
            PrikaziSpisakZelja zelje = new PrikaziSpisakZelja(zahtjev);
            zelje.Owner = this;
            zelje.Show();
            this.Hide();

        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            this.Owner.Show();
            this.Hide();
        }
    }
}
