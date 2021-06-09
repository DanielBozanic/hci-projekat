using System;
using System.Windows;
using OrganizatorProslava.Services.Zabave;
using System.Collections.Generic;
using System.Linq;
using OrganizatorProslava.ViewModel.Organizator;
using OrganizatorProslava.UI.Korisnici;
using OrganizatorProslava.UI.Shared;

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
            Models.Zabava selektovanaZabava = (Models.Zabava)zabave.SelectedItem;
            Poruka poruka = null;
            if (selektovanaZabava == null)
            {
                poruka = new Poruka("Morate selektovati zabavu pre nego što pritisnete \"detalji\".", "Obaveštenje", MessageBoxButton.OK);
                poruka.Owner = this;
                poruka.ShowDialog();
                return;
            }

            var detalji = new UvidUZakazanuZabavu(selektovanaZabava, selektovanaZabava.Status != 4, true);
            detalji.Owner = this;
            detalji.Show();
            this.Hide();
        }

        private void button_organizuj(object sender, RoutedEventArgs e)
        {
            Models.Zabava selektovanaZabava = (Models.Zabava)zabave.SelectedItem;
            Poruka poruka = null;
            if (selektovanaZabava == null)
            {
                poruka = new Poruka("Morate selektovati zabavu pre nego što pritisnete \"organizuj\".", "Obaveštenje", MessageBoxButton.OK);
                poruka.Owner = this;
                poruka.ShowDialog();
                return;
            }

            var organizacija = new Organizacija(selektovanaZabava);
            organizacija.Owner = this;
            organizacija.Show();
        }

        private void trenutne_Checked(object sender, RoutedEventArgs e)
        {
            List<Models.Zabava> zabave = (from z in servis.GetZabave() where z.Status == 2 && z.Organizator?.Id == idOrganizatora select z).ToList();
            this.DataContext = new ZabaveViewModel(zabave);
            this.buttonOrganizuj.IsEnabled = true;
        }

        private void istorija_Checked(object sender, RoutedEventArgs e)
        {

            List<Models.Zabava> zabave = (from z in servis.GetZabave() where z.Status == 4 && z.Organizator?.Id == idOrganizatora select z).ToList();
            this.DataContext = new ZabaveViewModel(zabave);
            this.buttonOrganizuj.IsEnabled = false;
        }

    }
}
