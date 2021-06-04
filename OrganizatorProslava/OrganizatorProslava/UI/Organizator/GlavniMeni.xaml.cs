using OrganizatorProslava.Models;
using System;
using System.Windows;

namespace OrganizatorProslava.UI.Organizator
{
    public partial class GlavniMeni : Window
    {
        public GlavniMeni()
        {
            InitializeComponent();
        }

        private void vracanje(object sender, EventArgs e)
        {
            this.Owner.Hide();
        }

        private void zatvaranje(object sender, EventArgs e)
        {
            LogovaniKorisnik.Reset();
            this.Owner.Show();
        }

        private void button_novaProslava(object sender, RoutedEventArgs e)
        {
            var nova = new NovaZabava();
            nova.Owner = this;
            nova.Show();
        }

        private void button_organizacija(object sender, RoutedEventArgs e)
        {
            var organizaija = new OrganizujZabavu();
            organizaija.Owner = this;
            organizaija.Show();
        }

        private void button_profil(object sender, RoutedEventArgs e)
        {

        }

        private void button_odjava(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
