using OrganizatorProslava.Models;
using OrganizatorProslava.Services.Klijenti;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Linq;
using System;
using System.Windows.Controls;
using System.Windows.Media;
using OrganizatorProslava.UI.Shared;
using OrganizatorProslava.Services;
using System.Windows.Media.Imaging;

namespace OrganizatorProslava.UI.Korisnici
{
    public partial class Sala : Window
    {
        Point pocetnaTacka = new Point();

        private const int VELICINA_IKONE = 48;
        private const int RAZMAK = VELICINA_IKONE / 2;

        public ObservableCollection<Sto> StoloviSale { get; set; }
        public ObservableCollection<Sto> StoloviNaMapi { get; set; }

        public Sala(int proizvodId)
        {
            InitializeComponent();

            StoloviSale = new ObservableCollection<Sto>();
            StoloviNaMapi = new ObservableCollection<Sto>();

            var salaServis = new SalaServis();
            var stolovi = salaServis.GetStoloviSale(proizvodId);

            ListaStolova.ItemsSource = stolovi;

            foreach (var sto in stolovi)
            {
                StoloviSale.Add(sto);
            }

            stolovi = stolovi.Where(q => q.NaMapi).ToList();
            foreach (var sto in stolovi)
            {
                StoloviNaMapi.Add(sto);
                DodajStoNaMapuSale(sto);
            }
        }

        private void MapaSale_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            pocetnaTacka = e.GetPosition(null);

            var mapaSale = sender as Canvas;

            Sto sto = null;
            Point trenutnaPozicija = e.GetPosition(mapaSale);

            sto = PronadjiStoNaMapiSale((int)trenutnaPozicija.X, (int)trenutnaPozicija.Y);

            if (sto != null)
            {
                var pomeriSto = new DataObject("PomeranjeStolaUnutarMapeSale", sto);
                DragDrop.DoDragDrop(mapaSale, pomeriSto, DragDropEffects.Move);
            }
        }

        private void MapaSale_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("StoNaMapuSale") || sender == e.Source)
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void MapaSale_Drop(object sender, DragEventArgs e)
        {
            var pozicija = e.GetPosition(MapaSale);

            Sto res = PronadjiStoNaMapiSale((int)pozicija.X, (int)pozicija.Y);
            if (res != null)
            {
                var poruka = new Poruka(Poruke.ZauzetaPozicija, Poruke.Poruka, MessageBoxButton.OK);
                poruka.Owner = this;
                poruka.ShowDialog();
                return;
            }


            if (!e.Data.GetDataPresent("StoNaMapuSale") || sender == e.Source)
            {
                e.Effects = DragDropEffects.None;

                Sto sto = e.Data.GetData("StoNaMapuSale") as Sto;

                if (sto == null)
                {
                    sto = e.Data.GetData("PomeranjeStolaUnutarMapeSale") as Sto;

                    UIElement ukloniSto = null;

                    foreach (UIElement element in MapaSale.Children)
                    {
                        if (element.Uid == sto.Id.ToString())
                        {
                            ukloniSto = element;
                            break;
                        }
                    }

                    MapaSale.Children.Remove(ukloniSto);
                }
                else
                {
                    if (sto.NaMapi)
                    {
                        var poruka = new Poruka(string.Format(Poruke.StoImaPozicijuNaMapi, sto.Id, sto.Opis), Poruke.Poruka, MessageBoxButton.OK);
                        poruka.Owner = this;
                        poruka.ShowDialog();
                        return;
                    }

                    StoloviNaMapi.Add(sto);
                }

                sto.XPos = (int)pozicija.X;
                sto.YPos = (int)pozicija.Y;

                var salaServis = new SalaServis();
                // TODO: Cuvanje

                DodajStoNaMapuSale(sto);
            }
        }

        private void ListaStolova_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            pocetnaTacka = e.GetPosition(null);
        }

        private void ListaStolova_MouseMove(object sender, MouseEventArgs e)
        {
            var pozicija = e.GetPosition(null);
            var razlika = pocetnaTacka - pozicija;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(razlika.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(razlika.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                var listView = sender as ListView;
                var stoListItem = NadjiRoditelja<ListViewItem>((DependencyObject)e.OriginalSource);

                if (stoListItem == null)
                    return;

                Sto sto = (Sto)listView.ItemContainerGenerator.ItemFromContainer(stoListItem);

                DataObject dragData = new DataObject("StoNaMapuSale", sto);
                DragDrop.DoDragDrop(stoListItem, dragData, DragDropEffects.Move);
            }
        }

        private static T NadjiRoditelja<T>(DependencyObject item) where T : DependencyObject
        {
            do
            {
                if (item is T)
                {
                    return (T)item;
                }
                item = VisualTreeHelper.GetParent(item);
            }
            while (item != null);
            return null;
        }

        private Sto PronadjiStoNaMapiSale(int x, int y)
        {
            foreach (Sto sto in StoloviNaMapi)
            {
                if (Math.Sqrt(Math.Pow((x - sto.XPos.Value - RAZMAK), 2) + Math.Pow((y - sto.YPos.Value - RAZMAK), 2)) < RAZMAK)
                    return sto;
            }

            return null;
        }

        private void DodajStoNaMapuSale(Sto sto)
        {
            Image ikona = new Image
            {
                Width = VELICINA_IKONE,
                Height = VELICINA_IKONE,
                Uid = sto.Id.ToString(),
                Source = new BitmapImage(new Uri(@"/Content/sto.png", UriKind.Relative))
            };

            ikona.ToolTip = "Id stola: " + sto.Id.ToString() + "\nNaziv: " + sto.Naziv;

            MapaSale.Children.Add(ikona);
            Canvas.SetLeft(ikona, sto.XPos.Value);
            Canvas.SetTop(ikona, sto.YPos.Value);
        }
    }
}
