using OrganizatorProslava.Services;
using OrganizatorProslava.UI.Shared;
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
    /// Interaction logic for SpisakZelja.xaml
    /// </summary>
    public partial class SpisakZelja : Window
    {
        public SpisakZelja()
        {
            InitializeComponent();
        }

        private void sacuvajKlik(object sender, RoutedEventArgs e)
        {
            var spisakZelja = UnesenSpisakZelja.Text;
            Models.Zahtjev.DodatneZelje = spisakZelja;

            var sacuvaniPodaci = new Poruka(Poruke.SacuvaniPodaci, Poruke.Poruka, MessageBoxButton.OK);
            sacuvaniPodaci.Owner = this;
            sacuvaniPodaci.ShowDialog();

            if (sacuvaniPodaci.Rezultat == MessageBoxResult.OK)
            {
                this.Owner.Show();
                this.Hide();
            }
        }

        private void nazadKlik(object sender, RoutedEventArgs e)
        {
            if (UnesenSpisakZelja.Text != string.Empty)
            {
                var poruka = new Poruka(Poruke.OdbaciPodatke, Poruke.Poruka, MessageBoxButton.YesNo, MessageBoxResult.No);
                poruka.Owner = this;
                poruka.ShowDialog();

                if (poruka.Rezultat == MessageBoxResult.Yes)
                {
                    this.Owner.Show();
                    this.Hide();
                }
            }
            else
            {
                this.Owner.Show();
                this.Hide();
            }
        }



        private void Window_Closed(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Hide();
        }
    }
}
