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
    /// Interaction logic for PromenaLozinke.xaml
    /// </summary>
    public partial class PromenaLozinke : Window
    {
        public PromenaLozinke()
        {
            InitializeComponent();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        

        private void PromijeniLozinku(object sender, RoutedEventArgs e)
        {
            string poruka = "";
            var korisnickoIme = KorisnickoIme.Text;
            var lozinka = Lozinka.Text;
            var potrvdaLozinke = PotvrdaLozinke.Text;


            if (lozinka.Equals(potrvdaLozinke))
            {
                var servis = new Services.Nalozi.KorisnikServis();
                poruka = servis.PromjenaLozinke(korisnickoIme, lozinka);
                this.Owner.Show();
                this.Hide();
            }
            else
            {
                //ovdje ide ona poruka
                poruka = "Nisu lozinke jednake";
            }
        }

        private void Odbaci(object sender, RoutedEventArgs e)
        {

        }
    }
}
