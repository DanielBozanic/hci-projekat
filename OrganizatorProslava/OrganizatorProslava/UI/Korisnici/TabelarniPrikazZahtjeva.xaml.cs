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
    /// Interaction logic for TabelarniPrikazZahtjeva.xaml
    /// </summary>
    public partial class TabelarniPrikazZahtjeva : Window
    {
        public TabelarniPrikazZahtjeva()
        {
            InitializeComponent();
            //this.DataContext = new TabelaZahtjevaVM(//lista)
        }

        /*
        private List<Models.Zabava> GetZabava()
        {
            var korisnikServis = new Services.Nalozi.KorisnikServis();
            return korisnikServis.GetKorisnici().ToList();
        }*/
    }
}
