using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using OrganizatorProslava.ViewModel.Organizator;
using OrganizatorProslava.Services.Zabave;

namespace OrganizatorProslava.UI.Organizator
{
    /// <summary>
    /// Interaction logic for NovaZabava.xaml
    /// </summary>
    public partial class NovaZabava : Window
    {
        private int idOrganizatora = Models.LogovaniKorisnik.Id;
        private ServisZabave servis = new ServisZabave();

        public NovaZabava()
        {
            InitializeComponent();
            List<Models.Zabava> zabave = (from z in servis.GetZabave() where z.Status == 1 && z.Organizator?.Id == idOrganizatora select z).ToList();
            this.DataContext = new ZabaveViewModel(zabave);
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

        private void button_detalji(object sender, RoutedEventArgs e)
        {

        }

        private void zahtevi_Checked(object sender, RoutedEventArgs e)
        {
            List<Models.Zabava> zabave = (from z in servis.GetZabave() where z.Status == 1 && z.Organizator?.Id == idOrganizatora select z).ToList();
            this.DataContext = new ZabaveViewModel(zabave);
        }

        private void nedodeljene_Checked(object sender, RoutedEventArgs e)
        {
            List<Models.Zabava> zabave = (from z in servis.GetZabave() where z.Status == 1 && z.Organizator == null select z).ToList();
            this.DataContext = new ZabaveViewModel(zabave);
        }

        private void button_prihvati(object sender, RoutedEventArgs e)
        {

        }

    }
}
