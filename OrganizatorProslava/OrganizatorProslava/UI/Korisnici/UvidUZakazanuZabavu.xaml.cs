using OrganizatorProslava.Services;
using OrganizatorProslava.UI.Shared;
﻿using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace OrganizatorProslava.UI.Korisnici
{
    public partial class UvidUZakazanuZabavu : Window
    {
        private Models.Zabava _zabava;
        private int _restoranProizvodId;

        public UvidUZakazanuZabavu(Models.Zabava prosljedjenaZabava, bool prosle, bool samoJako)
        {
            InitializeComponent();
            _zabava = prosljedjenaZabava;
            if (!samoJako)
            {
                var restoranProizvod = _zabava.OdabraniProizvodi.FirstOrDefault(q => q.SmeDaMenja != null);
                if (restoranProizvod == null || !(restoranProizvod.SmeDaMenja ?? false))
                {
                    btnSala.Visibility = Visibility.Collapsed;
                    btnGosti.Visibility = Visibility.Collapsed;
                }
                else
                {
                    _restoranProizvodId = restoranProizvod.Id;
                }
            }
            else {
                this.btnSala.IsEnabled = false;
                this.btnGosti.IsEnabled = false;
            }


            if (!prosle)
            {
                Button dugmeZahtjev = new Button();
                dugmeZahtjev.Content = "ZAHTEV";
                dugmeZahtjev.HorizontalAlignment = HorizontalAlignment.Left;
                dugmeZahtjev.VerticalAlignment = VerticalAlignment.Top;
                dugmeZahtjev.Width = 120;
                dugmeZahtjev.Margin = new Thickness(270,333, 0, 0);
                dugmeZahtjev.Height = 30;
                dugmeZahtjev.FontSize = 16;
                dugmeZahtjev.FontFamily = new FontFamily("Segoe UI");
                dugmeZahtjev.FontWeight = FontWeights.Bold;

                //dugmeZahtjev.Background = "#FF1F787D";
                dugmeZahtjev.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x1F, 0x78, 0x7D));
                dugmeZahtjev.Effect = new System.Windows.Media.Effects.DropShadowEffect()
                {
                    BlurRadius = 8,
                    ShadowDepth = 5,
                    Opacity = 0.99,
                    
                };

                dugmeZahtjev.Click += zahtjeviKlik;

                this.grid.Children.Add(dugmeZahtjev);
            }
        }

        private void MuzikaKlik(object sender, RoutedEventArgs e)
        {

            bool nasla = false;
            if (_zabava.OdabraniProizvodi == null) {
                Poruka poruka = new Poruka("Ova stavka nije uneta još uvek.", "Obaveštenje", MessageBoxButton.OK);
                poruka.Owner = this;
                poruka.ShowDialog();
                return;
            }
            foreach (Models.Proizvod p in _zabava.OdabraniProizvodi)
            {
                if(p.Sardanik.TipSaradnika == "Muzika")
                {
                    nasla = true;
                    Shared.MiniKartica mini = new Shared.MiniKartica(p);
                    mini.Owner = this;
                    mini.Show();
                    this.Hide();
                }
            }

            if (!nasla)
            {
                var porukica = new Poruka(Poruke.muzikaNijeOdredjena, Poruke.Poruka, MessageBoxButton.OK);
                porukica.Owner = this;
                porukica.ShowDialog();
            }
        }

        private void CvijeceKlik(object sender, RoutedEventArgs e)
        {
            bool nasla = false;

            if (_zabava.OdabraniProizvodi == null)
            {
                Poruka poruka = new Poruka("Ova stavka nije uneta još uvek.", "Obaveštenje", MessageBoxButton.OK);
                poruka.Owner = this;
                poruka.ShowDialog();
                return;
            }
            foreach (Models.Proizvod p in _zabava.OdabraniProizvodi)
            {
                if (p.Sardanik.TipSaradnika == "Cvecara")
                {
                    nasla = true;
                    Shared.MiniKartica mini = new Shared.MiniKartica(p);
                    mini.Owner = this;
                    mini.Show();
                    this.Hide();
                }
            }

            if (!nasla)
            {
                var porukica = new Poruka(Poruke.cvjecaraNijeOdredjena, Poruke.Poruka, MessageBoxButton.OK);
                porukica.Owner = this;
                porukica.ShowDialog();
            }
        }

        private void RestoraniKlik(object sender, RoutedEventArgs e)
        {
            bool nasla = false;

            if (_zabava.OdabraniProizvodi == null)
            {
                Poruka poruka = new Poruka("Ova stavka nije uneta još uvek.", "Obaveštenje", MessageBoxButton.OK);
                poruka.Owner = this;
                poruka.ShowDialog();
                return;
            }
            foreach (Models.Proizvod p in _zabava.OdabraniProizvodi)
            {
                if (p.Sardanik.TipSaradnika == "Restoran")
                {
                    nasla = true;
                    Shared.MiniKartica mini = new Shared.MiniKartica(p);
                    mini.Owner = this;
                    mini.Show();
                    this.Hide();
                }
            }

            if (!nasla)
            {
                var porukica = new Poruka(Poruke.restoranNijeOdredjen, Poruke.Poruka, MessageBoxButton.OK);
                porukica.Owner = this;
                porukica.ShowDialog();
            }

        }

        /*
        private void Jelo_Click(object sender, RoutedEventArgs e)
        {
            bool nasla = false;
            foreach (Models.Proizvod p in zabava.OdabraniProizvodi)
            {
                if (p.Sardanik.TipSaradnika == "Jelo")
                {
                    nasla = true;
                    Shared.MiniKartica mini = new Shared.MiniKartica(p);
                    mini.Owner = this;
                    mini.Show();
                    this.Hide();
                }
            }

            if (!nasla)
            {
                var porukica = new Poruka(Poruke.jeloNijeOrganizovano, Poruke.Poruka, MessageBoxButton.OK);
                porukica.Owner = this;
                porukica.ShowDialog();
            }
        }
        */

        private void zahtjeviKlik(object sender, RoutedEventArgs e)
        {
            Models.Zabava z = this._zabava;
            PrikaziZahtjev zahtjev = new PrikaziZahtjev(z);
            zahtjev.Owner = this;
            zahtjev.Show();
            this.Hide();
        }


        private void Poruke_Click(object sender, RoutedEventArgs e)
        {
            Models.Zabava z = this._zabava;
            PorukeOrganizacije poruke = new PorukeOrganizacije(z);
            poruke.Owner = this;
            poruke.Show();
            this.Hide();
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            this.Owner.Show();
            this.Hide();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Hide();
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            this.Owner.Hide();
        }

        private void btnSala_Click(object sender, RoutedEventArgs e)
        {
            var sala = new Sala(_zabava.Id, _restoranProizvodId);
            sala.Owner = this;
            sala.ShowDialog();
        }

        private void btnGosti_Click(object sender, RoutedEventArgs e)
        {
            var zabavaGosti = new ZabavaGosti(_zabava.Id, _restoranProizvodId);
            zabavaGosti.Owner = this;
            zabavaGosti.ShowDialog();
        }
    }
}
