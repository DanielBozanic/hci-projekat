using OrganizatorProslava.Models;
using System;
using System.Windows;

namespace OrganizatorProslava.UI.Administrator
{
    public partial class MeniAdmin : Window
    {
        public MeniAdmin()
        {
            InitializeComponent();
        }

        private void Window_Rendered(object sender, EventArgs e)
        {
            this.Owner.Hide();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            LogovaniKorisnik.Reset();
            this.Owner.Show();
        }

        private void btnOdjava_Click(object sender, RoutedEventArgs e)
        {
            
            this.Close();
        }

        private void btnKorisnici_Click(object sender, RoutedEventArgs e)
        {
            var korisnici = new Korisnici();
            korisnici.Owner = this;
            korisnici.Show();
        }
    }
}
