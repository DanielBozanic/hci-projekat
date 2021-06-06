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
using OrganizatorProslava.Models;

namespace OrganizatorProslava.UI.Korisnici
{
    /// <summary>
    /// Interaction logic for Zakazivanje.xaml
    /// </summary>
    public partial class Zakazivanje : Window
    {
        Zabava Zabava { get; set; }


        public Zakazivanje()
        {
            InitializeComponent();

            Zabava = new Zabava();

            DateTime danas = DateTime.Now;
            IzabranDatum.BlackoutDates.Add(new CalendarDateRange(new DateTime(2015, 1, 1), danas));
            IzabranDatum.FirstDayOfWeek = DayOfWeek.Monday;
            IzabranDatum.IsTodayHighlighted = true;
        }

        

        private void dalje(object sender, RoutedEventArgs e)
        {
           

            bool neValjaUnos = false;

            if(tipZabave.Text == string.Empty)
            {
                neValjaUnos = true;
            }else if(Zabava.DatumProslave == null)
            {
                neValjaUnos = true;
            }else if(zakazanoVrijeme.Text == string.Empty)
            {
                neValjaUnos = true;
            }else if(vremenskoTrajanje.Text == string.Empty)
            {
                neValjaUnos = true;
            }else if(grad.Text == string.Empty)
            {
                neValjaUnos = true;
            }

            if (neValjaUnos)
            {
                //ovdje poruka box onaj da treba sve da se popuni
            }
            else
            {
                Zabava.Tip = tipZabave.Text;
                Zabava.Vrijeme = zakazanoVrijeme.Text;
                Zabava.Trajanje = Int32.Parse(vremenskoTrajanje.Text);
                Zabava.Grad = grad.Text;
                Zabava.Tema = tema.Text;

                //ovdje pozivamo zakazivanje 2 tj. sljedecu stranu
                var servis = new Services.Nalozi.KorisnikServis();
                Zabava.Kreator = servis.dobaviKorisnika(LogovaniKorisnik.KorisnickoIme);
                var daljeProzor = new Zakazivanje2();
                Zakazivanje2.zabava = Zabava;
                daljeProzor.Owner = this;
                daljeProzor.Show();
                this.Hide();
            }

        }




        private void odustani(object sender, RoutedEventArgs e)
        {

        }


        private void izabranDatum(object sender, SelectionChangedEventArgs e)
        {
            if (IzabranDatum.SelectedDate.HasValue)
            {
                int godina = IzabranDatum.SelectedDate.Value.Year;
                int mjesec = IzabranDatum.SelectedDate.Value.Month;
                int dan = IzabranDatum.SelectedDate.Value.Day;

                Zabava.DatumProslave = new DateTime(godina, mjesec, dan);
            }
            
        }
    }
}
