using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using OrganizatorProslava.Services;
using OrganizatorProslava.UI.Shared;

namespace OrganizatorProslava.UI.Korisnici
{
    /// <summary>
    /// Interaction logic for Zakazivanje.xaml
    /// </summary>
    public partial class Zakazivanje : Window
    {
        //Zabava Zabava { get; set; }



        public Zakazivanje()
        {
            InitializeComponent();

            //Zabava = new Zabava();

            DateTime danas = DateTime.Now;
            IzabranDatum.BlackoutDates.Add(new CalendarDateRange(new DateTime(2015, 1, 1), danas));
            IzabranDatum.FirstDayOfWeek = DayOfWeek.Monday;
            IzabranDatum.IsTodayHighlighted = true;
        }



        private void dalje(object sender, RoutedEventArgs e)
        {
            bool sveDobro = true;

            //radi provjere
            //prvo provjeri da li su svi podaci uneseni
            sveDobro = sviPodaciUneseniProvjera();

            if (sveDobro)
            {
                //provjeri vrijeme ii trajanje da li je adekvatan format
                if (validacijaVremena())
                {
                    if (validacijaTrajanja())
                    {
                        //prosle su sve validacije, unos je dobar idemo dalje
                        /*
                        Zabava.Tip = tipZabave.Text;

                        Zabava.Vrijeme = zakazanoVrijeme.Text;
                        string[] parsirajVrijeme = zakazanoVrijeme.Text.Split(':');
                        double sati = Double.Parse(parsirajVrijeme[0]);
                        double minute = Double.Parse(parsirajVrijeme[1]);
                        Zabava.DatumProslave.AddHours(sati);
                        Zabava.DatumProslave.AddMinutes(minute);


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
                        */
                        Zahtjev.Tip = tipZabave.Text;

                        Zahtjev.Vrijeme = zakazanoVrijeme.Text;
                        string[] parsirajVrijeme = zakazanoVrijeme.Text.Split(':');
                        double sati = Double.Parse(parsirajVrijeme[0]);
                        double minute = Double.Parse(parsirajVrijeme[1]);
                        DateTime d1 = Zahtjev.DatumProslave.AddHours(sati);
                        DateTime d2 = d1.AddMinutes(minute);
                        DateTime d3 = d2.AddSeconds(0);
                        Zahtjev.DatumProslave = d3;


                        Zahtjev.Trajanje = Int32.Parse(vremenskoTrajanje.Text);
                        Zahtjev.Grad = grad.Text;
                        Zahtjev.Tema = tema.Text;

                        //ovdje pozivamo zakazivanje 2 tj. sljedecu stranu
                        var servis = new Services.Nalozi.KorisnikServis();
                        Zahtjev.Kreator = servis.dobaviKorisnika(LogovaniKorisnik.KorisnickoIme);
                        var daljeProzor = new Zakazivanje2();
                        daljeProzor.Owner = this;
                        daljeProzor.Show();
                        this.Hide();


                    }
                    else
                    {
                        var pogresanFormatVremena = new Poruka(Poruke.pogresanFormatTrajanja, Poruke.Poruka, MessageBoxButton.OK);
                        pogresanFormatVremena.Owner = this;
                        pogresanFormatVremena.ShowDialog();
                    }

                }
                else
                {
                    var pogresanFormatVremena = new Poruka(Poruke.pogresanFormatVremena, Poruke.Poruka, MessageBoxButton.OK);
                    pogresanFormatVremena.Owner = this;
                    pogresanFormatVremena.ShowDialog();
                }


            }
            else
            {
                var obavezanUnosPoruka = new Poruka(Poruke.ObavezanJeUnosSvihPodataka, Poruke.Poruka, MessageBoxButton.OK);
                obavezanUnosPoruka.Owner = this;
                obavezanUnosPoruka.ShowDialog();
            }




        }




        private void odustani(object sender, RoutedEventArgs e)
        {
            if (popunjenoBarJednoPolje())
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





        private void izabranDatum(object sender, SelectionChangedEventArgs e)
        {
            if (IzabranDatum.SelectedDate.HasValue)
            {
                int godina = IzabranDatum.SelectedDate.Value.Year;
                int mjesec = IzabranDatum.SelectedDate.Value.Month;
                int dan = IzabranDatum.SelectedDate.Value.Day;

                //Zabava.DatumProslave = new DateTime(godina, mjesec, dan);
                Zahtjev.DatumProslave = new DateTime(godina, mjesec, dan);
            }

        }




        //PROVJERE
        public bool sviPodaciUneseniProvjera()
        {
            bool sviPodaciUneseni = true;

            if (tipZabave.Text == string.Empty)
            {
                sviPodaciUneseni = false;

            }
            else if (zakazanoVrijeme.Text == string.Empty)
            {
                sviPodaciUneseni = false;

            }
            else if (vremenskoTrajanje.Text == string.Empty)
            {
                sviPodaciUneseni = false;

            }
            else if (grad.Text == string.Empty)
            {
                sviPodaciUneseni = false;

            }
            else if (!IzabranDatum.SelectedDate.HasValue)
            {
                sviPodaciUneseni = false;

            }
            //tema nije obavezna za unos

            return sviPodaciUneseni;
        }



        public bool validacijaVremena()
        {
            Regex r = new Regex("^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$");
            string unesenoVrijeme = zakazanoVrijeme.Text;

            if (!r.IsMatch(unesenoVrijeme))
            {
                return false;
            }

            return true;
        }



        public bool validacijaTrajanja()
        {
            string unesenoTrajanje = vremenskoTrajanje.Text;

            Regex r = new Regex("[0-9]+");

            if (!r.IsMatch(unesenoTrajanje))
            {
                return false;
            }

            int unesenoTrajanjeInt = Int32.Parse(unesenoTrajanje);

            if (unesenoTrajanjeInt < 1 || unesenoTrajanjeInt > 72)
            {
                return false;
            }

            return true;

        }


        public bool popunjenoBarJednoPolje()
        {
            bool nekiPodatakUnesen = false;

            if (tipZabave.Text != string.Empty)
            {
                nekiPodatakUnesen = true;

            }
            else if (zakazanoVrijeme.Text != string.Empty)
            {
                nekiPodatakUnesen = true;

            }
            else if (vremenskoTrajanje.Text != string.Empty)
            {
                nekiPodatakUnesen = true;

            }
            else if (grad.Text != string.Empty)
            {
                nekiPodatakUnesen = true;

            }
            else if (IzabranDatum.SelectedDate.HasValue)
            {
                nekiPodatakUnesen = true;

            }
            else if (tema.Text != string.Empty)
            {
                nekiPodatakUnesen = true;
            }


            return nekiPodatakUnesen;
        }


        private void Window_Closed(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Hide();
        }

    }
}
