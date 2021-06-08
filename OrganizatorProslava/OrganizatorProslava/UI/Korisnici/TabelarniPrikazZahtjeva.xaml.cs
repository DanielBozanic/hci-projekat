using OrganizatorProslava.Models;
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
        /*
         1 --> zahtjevi na cekanju
         2 --> odobreni zahtjevi
         3 --> otkazani zahtjevi
         */
        public int Prozor { get; set; }



        public TabelarniPrikazZahtjeva(int kojiProzor)
        {
            InitializeComponent();
            if (kojiProzor == 1)
            {
                this.Title = "Zahtjevi na čekanju";
                this.DataContext = new TabelaZahtjevaVM(GetKorisnickeZahtjeveNaCekanju());
            }
            else if (kojiProzor == 2)
            {
                this.Title = "Odobreni zahtjevi";
                this.DataContext = new TabelaZahtjevaVM(GetOdobreneKorisnickeZahtjeve());
            }
            else
            {
                this.Title = "Odbijeni zahtjevi";
                this.DataContext = new TabelaZahtjevaVM(GetOdbijeneKorisnickeZahtjeve());
            }

        }


        private List<Models.Zabava> GetKorisnickeZahtjeveNaCekanju()
        {
            var zabavaServis = new Services.Zabave.ServisZabave();
            return zabavaServis.GetKorisnickeZahtjeveNaCekanju(LogovaniKorisnik.Id).ToList();
        }


        private List<Models.Zabava> GetOdobreneKorisnickeZahtjeve()
        {
            var zabavaServis = new Services.Zabave.ServisZabave();
            return zabavaServis.GetOdobreneKorisnickeZahtjeve(LogovaniKorisnik.Id).ToList();
        }


        private List<Models.Zabava> GetOdbijeneKorisnickeZahtjeve()
        {
            var zabavaServis = new Services.Zabave.ServisZabave();
            return zabavaServis.GetOdbijeneKorisnickeZahtjeve(LogovaniKorisnik.Id).ToList();
        }

    }
}
