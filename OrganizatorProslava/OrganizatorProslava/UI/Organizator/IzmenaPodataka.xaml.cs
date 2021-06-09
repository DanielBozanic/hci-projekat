using System;
using OrganizatorProslava.UI.Korisnici;
using System.Windows;

namespace OrganizatorProslava.UI.Organizator
{
    /// <summary>
    /// Interaction logic for IzmenaPodataka.xaml
    /// </summary>
    public partial class IzmenaPodataka : Window
    {
        public IzmenaPodataka()
        {
            InitializeComponent();
        }

        private void vracanje(object sender, EventArgs e)
        {
            this.Owner.Hide();
        }

        private void zatvaranje(object sender, EventArgs e)
        {
            this.Owner.Show();
        }

        private void button_nazad(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void azuriranjePodataka_Click(object sender, RoutedEventArgs e)
        {
            var azurirajProfil = new AzurirajProfilKorisnika(false);
            string[] lista = Models.LogovaniKorisnik.PunoIme.Split(' ');
            azurirajProfil.podesiPodatke(lista[0], lista[1]);
            azurirajProfil.Owner = this;
            azurirajProfil.Show();
            this.Hide();
        }

        private void izmenaLozinke_Click(object sender, RoutedEventArgs e)
        {
            var promeniLozinku = new UI.Korisnici.PromenaLozinke();
            promeniLozinku.Owner = this;
            promeniLozinku.Show();
            this.Hide();
        }
    }
}
