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
    /// Interaction logic for Zahtevi.xaml
    /// </summary>
    public partial class Zahtevi : Window
    {
        public Zahtevi()
        {
            InitializeComponent();
        }

        
        private void ZahtjeviNaCekanjuKlik(object sender, RoutedEventArgs e)
        {
            TabelarniPrikazZahtjeva tabela = new TabelarniPrikazZahtjeva(1);
            tabela.Owner = this;
            tabela.Show();
            this.Hide();
            
        }

        private void OdobreniZahtjeviKlik(object sender, RoutedEventArgs e)
        {
            TabelarniPrikazZahtjeva tabela = new TabelarniPrikazZahtjeva(2);
            tabela.Owner = this;
            tabela.Show();
            this.Hide();

        }

        private void OdbijeniZahtjeviKlik(object sender, RoutedEventArgs e)
        {
            TabelarniPrikazZahtjeva tabela = new TabelarniPrikazZahtjeva(3);
            tabela.Owner = this;
            tabela.Show();
            this.Hide();

        }

        private void NazadKlik(object sender, RoutedEventArgs e)
        {
            this.Owner.Show();
            this.Hide();
        }


        private void Window_Closed(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Hide();
        }
    }
}
