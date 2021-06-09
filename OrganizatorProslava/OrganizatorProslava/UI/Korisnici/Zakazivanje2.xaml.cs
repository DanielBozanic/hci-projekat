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
    /// Interaction logic for Zakazivanje2.xaml
    /// </summary>
    public partial class Zakazivanje2 : Window
    {
        //public Zabava zabava = new Zabava();


        public Zakazivanje2()
        {
            InitializeComponent();


            fiksanBudzet.Items.Add("DA");
            fiksanBudzet.Items.Add("NE");

            var servis = new Services.Nalozi.KorisnikServis();
            var listaOrganizatora = servis.dobaviSveOrganizatore();

            System.Collections.IList list = listaOrganizatora;
            for (int i = 0; i < list.Count; i++)
            {
                Korisnik organizatorItem = (Korisnik)list[i];

                organizator.Items.Add(organizatorItem.Id + " " + organizatorItem.Ime + " " + organizatorItem.Prezime);
            }
            organizator.Items.Add("Bilo koji organizator");
        }

        private void spisakZvanicaKlik(object sender, RoutedEventArgs e)
        {
            SpisakZvanica spisakZvanica = new SpisakZvanica();
            //spisakZvanica.zabava = zabava;
            spisakZvanica.Owner = this;
            spisakZvanica.Show();
            this.Hide();
        }


        private void dodatneZeljeKlik(object sender, RoutedEventArgs e)
        {
            SpisakZelja spisakZelja = new SpisakZelja();
            spisakZelja.Owner = this;
            spisakZelja.Show();
            this.Hide();
        }



        private void zakaziKlik(object sender, RoutedEventArgs e)
        {
            //KAD SVE BUDE GOTOVO PROVJERI DA LI SU UNESENE ZVANICE, DODATNE ZELJE NE TREBA II RASPORED GOSTIJU
            if (Zahtjev.SpisakGostiju != string.Empty)
            {
                //provjera unesenih svih polja
                if (provjeraUnesenihSvihPolja())
                {
                    //provjera unosa budzeta i gostiju
                    if (provjeraBudzetaFormat())
                    {
                        if (provjeraBrojaZvanica())
                        {
                            //ovjde popuni i posalji zahtjev
                            Zahtjev.Budzet = Double.Parse(this.budzet.Text);
                            Zahtjev.BrojGostiju = Int32.Parse(this.brojGostiju.Text);

                            string izabranoFB = this.fiksanBudzet.Text;
                            if (izabranoFB == "DA")
                            {
                                Zahtjev.TipBudzeta = true;
                            }
                            else
                            {
                                Zahtjev.TipBudzeta = false;
                            }


                            string izabraniOrganizator = this.organizator.Text;
                            string[] parsirajOrganizatora = izabraniOrganizator.Split(' ');
                            var servis = new Services.Nalozi.KorisnikServis();
                            List<Models.Korisnik> korisnik = servis.GetKorisnikPoId(Int32.Parse(parsirajOrganizatora[0]));

                            if (korisnik.Count != 0)
                            {
                                Zahtjev.Organizator = korisnik[0];
                            }

                            Zahtjev.Status = 1;



                            var porukaSacuvajUpitnik = new Poruka(Poruke.daLiSteSigurni, Poruke.Poruka, MessageBoxButton.YesNo, MessageBoxResult.No);
                            porukaSacuvajUpitnik.Owner = this;
                            porukaSacuvajUpitnik.ShowDialog();

                            if (porukaSacuvajUpitnik.Rezultat == MessageBoxResult.Yes)
                            {
                                //dodaj u bazu
                                sacuvajZabavu();

                                var gotovoo = new Poruka(Poruke.zakazanaZabava, Poruke.Poruka, MessageBoxButton.OK);
                                gotovoo.Owner = this;
                                gotovoo.ShowDialog();

                                if (gotovoo.Rezultat == MessageBoxResult.OK)
                                {
                                    this.Owner.Owner.Show();
                                    this.Hide();
                                }

                            }


                        }
                        else
                        {
                            var BudzetPoruka = new Poruka(Poruke.formatGostiju, Poruke.Poruka, MessageBoxButton.OK);
                            BudzetPoruka.Owner = this;
                            BudzetPoruka.ShowDialog();
                        }

                    }
                    else
                    {
                        var BudzetPoruka = new Poruka(Poruke.formatBudzeta, Poruke.Poruka, MessageBoxButton.OK);
                        BudzetPoruka.Owner = this;
                        BudzetPoruka.ShowDialog();
                    }

                }
                else
                {
                    var obavezanUnosPoruka = new Poruka(Poruke.ObavezanJeUnosSvihPodataka, Poruke.Poruka, MessageBoxButton.OK);
                    obavezanUnosPoruka.Owner = this;
                    obavezanUnosPoruka.ShowDialog();
                }
            }
            else
            {
                var obavezanUnosPoruka = new Poruka(Poruke.unesiteSveZvanice, Poruke.Poruka, MessageBoxButton.OK);
                obavezanUnosPoruka.Owner = this;
                obavezanUnosPoruka.ShowDialog();
            }



        }



        private void odustaniKlik(object sender, RoutedEventArgs e)
        {
            if (popunjenoBarJednoPolje())
            {
                var poruka = new Poruka(Poruke.OdbaciPodatke, Poruke.Poruka, MessageBoxButton.YesNo, MessageBoxResult.No);
                poruka.Owner = this;
                poruka.ShowDialog();

                if (poruka.Rezultat == MessageBoxResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        private void nazadKlik(object sender, RoutedEventArgs e)
        {
            this.Owner.Show();
            this.Hide();
        }

        //PROVJERE
        public bool provjeraUnesenihSvihPolja()
        {
            bool sveUneseno = true;

            if (budzet.Text == string.Empty)
            {
                sveUneseno = false;
            }
            else if (fiksanBudzet.SelectedIndex == -1)
            {
                sveUneseno = false;
            }
            else if (organizator.SelectedIndex == -1)
            {
                sveUneseno = false;
            }
            else if (brojGostiju.Text == string.Empty)
            {
                sveUneseno = false;
            }

            if (Zahtjev.Tema == string.Empty)
            {
                Zahtjev.Tema = "Zabava nema temu";
            }

            return sveUneseno;
        }


        public bool provjeraBudzetaFormat()
        {
            string unosBudzeta = this.budzet.Text;
            double budzet = 0;
            /*Regex r = new Regex("[0-9]+");

            if (!r.IsMatch(unosBudzeta))
            {
                return false;
            }

            double budzet = Double.Parse(unosBudzeta);

            if (budzet < 2000)
            {
                return false;
            }

            return true;*/
            if (Double.TryParse(unosBudzeta, out budzet))
            {
                budzet = Double.Parse(unosBudzeta);
                if (budzet < 2000)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }


        public bool provjeraBrojaZvanica()
        {
            string unesenBroj = this.brojGostiju.Text;

            Regex r = new Regex("[0-9]*"); //provjeri samo da li mogu jednocifreni *

            if (!r.IsMatch(unesenBroj))
            {
                return false;
            }
            else if (unesenBroj == "0")
            {
                return false;
            }


            return true;
        }



        //SACUVAJ ZABAVU U BAZU
        public void sacuvajZabavu()
        {
            Services.Zabave.ServisZabave servisZabave = new Services.Zabave.ServisZabave();
            List<Zabava> zabave = servisZabave.GetZabave();
            Zahtjev.Id = zabave.Count() + 1;

            Console.WriteLine(zabave.Count() + 1);

            Zabava zabava = new Zabava();
            zabava.Id = Zahtjev.Id;

            Console.WriteLine(zabava.Id);
            zabava.Tip = Zahtjev.Tip;
            zabava.Kreator = Zahtjev.Kreator;
            zabava.DatumProslave = Zahtjev.DatumProslave;
            zabava.Trajanje = Zahtjev.Trajanje;
            zabava.Grad = Zahtjev.Grad;
            zabava.Tema = Zahtjev.Tema;
            zabava.BrojGostiju = Zahtjev.BrojGostiju;
            zabava.TipBudzeta = Zahtjev.TipBudzeta;
            zabava.Budzet = Zahtjev.Budzet;
            zabava.SpisakGostiju = Zahtjev.SpisakGostiju;
            zabava.Organizator = Zahtjev.Organizator;
            zabava.DodatneZelje = Zahtjev.DodatneZelje;
            zabava.Status = Zahtjev.Status;
            zabava.Vrijeme = Zahtjev.Vrijeme;

            Zahtjev.Reset();
            servisZabave.DodajZabavu(zabava);

        }



        public bool popunjenoBarJednoPolje()
        {
            bool nekiPodatakUnesen = false;

            if (budzet.Text != string.Empty)
            {
                nekiPodatakUnesen = true;

            }
            else if (budzet.Text != string.Empty)
            {
                nekiPodatakUnesen = true;

            }
            else if (fiksanBudzet.SelectedIndex > -1)
            {
                nekiPodatakUnesen = true;

            }
            else if (organizator.SelectedIndex > -1)
            {
                nekiPodatakUnesen = true;

            }


            return nekiPodatakUnesen;
        }



        private void Window_Closed(object sender, EventArgs e)
        {
            this.Owner.Owner.Show();
        }
    }
}
