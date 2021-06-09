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
    /// Interaction logic for TabelaTrenutnihZabava.xaml
    /// </summary>
    public partial class TabelaTrenutnihZabava : Window
    {
        //1 trenutne zabave
        //2 istorija
        int kojiProzor = 0;
        public TabelaTrenutnihZabava(int prozor)
        {
            InitializeComponent();
            kojiProzor = prozor;
            if (kojiProzor == 1)
            {
                this.Title = "Trenutne zabave";
                //this.DataContext = new TabelaZahtjevaVM(GetTrenutneZabave());

                List<Models.Zabava> zahtjevi = GetTrenutneZabave();
                if (zahtjevi.Count() == 0)
                {
                    TextBox nemaZahtjeva = new TextBox();
                    nemaZahtjeva.Name = "NemaZahtjeva";
                    nemaZahtjeva.HorizontalAlignment = HorizontalAlignment.Left;
                    nemaZahtjeva.VerticalAlignment = VerticalAlignment.Top;
                    nemaZahtjeva.Height = 40;
                    nemaZahtjeva.TextWrapping = TextWrapping.Wrap;
                    nemaZahtjeva.Text = " NEMA ZABAVA.";
                    nemaZahtjeva.Width = 180;
                    nemaZahtjeva.Margin = new Thickness(280, 140, 0, 0);
                    nemaZahtjeva.FontSize = 20;
                    nemaZahtjeva.FontWeight = FontWeights.Bold;
                    this.grid.Children.Add(nemaZahtjeva);
                }
                else
                {
                    this.DataContext = new TabelaZahtjevaVM(GetTrenutneZabave());
                }
            }
            else if (kojiProzor == 2)
            {
                this.Title = "Odrađene zabave";
                //this.DataContext = new TabelaZahtjevaVM(GetProsleZabave());

                List<Models.Zabava> zahtjevi = GetProsleZabave();
                if (zahtjevi.Count() == 0)
                {
                    TextBox nemaZahtjeva = new TextBox();
                    nemaZahtjeva.Name = "NemaZahtjeva";
                    nemaZahtjeva.HorizontalAlignment = HorizontalAlignment.Left;
                    nemaZahtjeva.VerticalAlignment = VerticalAlignment.Top;
                    nemaZahtjeva.Height = 40;
                    nemaZahtjeva.TextWrapping = TextWrapping.Wrap;
                    nemaZahtjeva.Text = " NEMA ZABAVA.";
                    nemaZahtjeva.Width = 180;
                    nemaZahtjeva.Margin = new Thickness(280, 140, 0, 0);
                    nemaZahtjeva.FontSize = 20;
                    nemaZahtjeva.FontWeight = FontWeights.Bold;
                    this.grid.Children.Add(nemaZahtjeva);
                }
                else
                {
                    this.DataContext = new TabelaZahtjevaVM(GetProsleZabave());
                }
            }
        }

       

        private List<Models.Zabava> GetTrenutneZabave()
        {
            var zabavaServis = new Services.Zabave.ServisZabave();

            List<Models.Zabava> lista = zabavaServis.GetTrenutnoOrganizovaneZabave(LogovaniKorisnik.Id).ToList();
            int a = lista.Count();
            return lista;
        }

        
       private List<Models.Zabava> GetProsleZabave()
       {
           var zabavaServis = new Services.Zabave.ServisZabave();
            List<Models.Zabava> lista = zabavaServis.GetProsleZabave(LogovaniKorisnik.Id).ToList();
            int a = lista.Count();
            return lista;
        }





        private void Row_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Ensure row was clicked and not empty space
            var red = ItemsControl.ContainerFromElement((DataGrid)sender,
                                                e.OriginalSource as DependencyObject) as DataGridRow;
            if (red == null) return;
            Models.Zabava izabraniZahtjev = (Models.Zabava)red.Item;


            if(this.kojiProzor == 1)
            {
                UvidUZakazanuZabavu uvid = new UvidUZakazanuZabavu(izabraniZahtjev, false, false);
                uvid.Owner = this;
                uvid.Show();
                this.Hide();
            }
            else
            {
                UvidUZakazanuZabavu uvid = new UvidUZakazanuZabavu(izabraniZahtjev, true, false);
                uvid.Owner = this;
                uvid.Show();
                this.Hide();
            }
            

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
