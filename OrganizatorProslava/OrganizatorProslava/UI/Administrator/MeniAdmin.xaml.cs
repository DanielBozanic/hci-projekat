using OrganizatorProslava.Models;
using System;
using System.Windows;
using System.Windows.Input;

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

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                btnOdjava_Click(null, null);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl) && e.Key == Key.K)
                btnKorisnici_Click(null, null);
            if (Keyboard.IsKeyDown(Key.LeftCtrl) && e.Key == Key.S)
                btnSaradnici_Click(null, null);
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

        private void btnSaradnici_Click(object sender, RoutedEventArgs e)
        {
            var saradnici = new Saradnici();
            saradnici.Owner = this;
            saradnici.Show();
        }
    }
}
