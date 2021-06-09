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
    /// Interaction logic for PorukeOrganizacije.xaml
    /// </summary>
    public partial class PorukeOrganizacije : Window
    {

        Models.Zabava zabava;
        public PorukeOrganizacije(Models.Zabava prosljedjeno)
        {
            InitializeComponent();
            zabava = prosljedjeno;
            this.DataContext = new PorukiceVM(GetPorukeZabave());
        }

        private void Posalji_poruku(object sender, RoutedEventArgs e)
        {
            if(this.textBox.Text != string.Empty || this.textBox.Text != "")
            {
                Services.Zabave.ServisPoruka servis = new Services.Zabave.ServisPoruka();
                Models.ZabavaPoruka novaPoruka = new Models.ZabavaPoruka();

                List<Models.ZabavaPoruka> sveZabave = servis.GetSvePoruke();
                novaPoruka.Id = sveZabave.Count() + 1;
                novaPoruka.KreatorId = this.zabava.Kreator.Id;
                novaPoruka.ZabavaId = this.zabava.Id;
                novaPoruka.Poruka = this.textBox.Text;

                
                servis.DodajPoruku(novaPoruka);

                this.textBox.Text = " ";
                this.DataContext = new PorukiceVM(GetPorukeZabave());

            }
        }

      

        private void nazadKlik(object sender, RoutedEventArgs e)
        {
            this.Owner.Show();
            this.Hide();
        }


        private void Window_Closed(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Hide();
        }


        private List<Models.ZabavaPoruka> GetPorukeZabave()
        {
            var porukaServis = new Services.Zabave.ServisPoruka();

            List<Models.ZabavaPoruka> lista = porukaServis.GetPorukaZabave(this.zabava.Id);
            int a = lista.Count();
            return lista;
        }
    }
}
