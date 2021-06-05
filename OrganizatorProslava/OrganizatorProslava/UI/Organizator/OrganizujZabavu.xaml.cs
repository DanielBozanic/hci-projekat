using System;
using System.Windows;
using OrganizatorProslava.Services.Zabave;
using System.Collections.Generic;
using System.Linq;
using OrganizatorProslava.ViewModel.Organizator;

namespace OrganizatorProslava.UI.Organizator
{
    public partial class OrganizujZabavu : Window
    {
        private int idOrganizatora = Models.LogovaniKorisnik.Id;
        private ServisZabave servis = new ServisZabave();

        public OrganizujZabavu()
        {
            InitializeComponent();
            List<Models.Zabava> zabave = (from z in servis.GetZabave() where z.Status == 2 && z.Organizator?.Id == idOrganizatora select z).ToList();
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

        private void button_organizuj(object sender, RoutedEventArgs e)
        {
            // onemoguci ako nije selektovano nista u tabeli
            var organizacija = new Organizacija();
            organizacija.Owner = this;
            organizacija.Show();
        }

        private void trenutne_Checked(object sender, RoutedEventArgs e)
        {
            List<Models.Zabava> zabave = (from z in servis.GetZabave() where z.Status == 2 && z.Organizator?.Id == idOrganizatora select z).ToList();
            this.DataContext = new ZabaveViewModel(zabave);
        }

        private void istorija_Checked(object sender, RoutedEventArgs e)
        {

            List<Models.Zabava> zabave = (from z in servis.GetZabave() where z.Status == 4 && z.Organizator?.Id == idOrganizatora select z).ToList();
            this.DataContext = new ZabaveViewModel(zabave);
        }

    }
}
