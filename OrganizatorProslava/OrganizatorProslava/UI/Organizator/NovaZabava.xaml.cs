using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using OrganizatorProslava.ViewModel.Organizator;
using OrganizatorProslava.Services.Zabave;
using OrganizatorProslava.Services.Nalozi;
using OrganizatorProslava.UI.Korisnici;
using OrganizatorProslava.UI.Shared;

namespace OrganizatorProslava.UI.Organizator
{
    /// <summary>
    /// Interaction logic for NovaZabava.xaml
    /// </summary>
    public partial class NovaZabava : Window
    {
        private int idOrganizatora = Models.LogovaniKorisnik.Id;
        private ServisZabave servis = new ServisZabave();
        private bool trenutne = false;

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

            Models.Zabava selektovanaZabava = (Models.Zabava)zabave.SelectedItem;
            Poruka poruka = null;
            if (selektovanaZabava == null)
            {
                poruka = new Poruka("Morate selektovati zabavu pre nego što pritisnete \"detalji\".", "Obaveštenje", MessageBoxButton.OK);
                poruka.Owner = this;
                poruka.ShowDialog();
                return;
            }

            var detalji = new UvidUZakazanuZabavu(selektovanaZabava, true, true);
            detalji.Owner = this;
            detalji.Show();
            this.Hide();
        }

        private void zahtevi_Checked(object sender, RoutedEventArgs e)
        {
            List<Models.Zabava> zabave = (from z in servis.GetZabave() where z.Status == 1 && z.Organizator?.Id == idOrganizatora select z).ToList();
            this.DataContext = new ZabaveViewModel(zabave);
            this.trenutne = false;
            this.buttonOdbij.IsEnabled = true;
        }

        private void nedodeljene_Checked(object sender, RoutedEventArgs e)
        {
            List<Models.Zabava> zabave = (from z in servis.GetZabave() where (z.Status == 1 && z.Organizator == null) || z.Status == 5 select z).ToList();
            this.DataContext = new ZabaveViewModel(zabave);
            this.trenutne = true;
            this.buttonOdbij.IsEnabled = false;
        }

        private void button_prihvati(object sender, RoutedEventArgs e)
        {
            Models.Zabava selektovana = (Models.Zabava)zabave.SelectedItem;
            Poruka poruka = null;
            if (selektovana == null) {
                poruka = new Poruka("Morate selektovati zabavu pre nego što pritisnete \"prihvati\".", "Obaveštenje", MessageBoxButton.OK);
                poruka.Owner = this;
                poruka.ShowDialog();
                return;
            }

            selektovana.Status = 2;
            KorisnikServis korSrevis = new KorisnikServis();
            selektovana.Organizator = korSrevis.GetKorisnikPoId(this.idOrganizatora).FirstOrDefault();
            ServisZabave servis = new ServisZabave();
            servis.IzmeniZabavu(selektovana);
            poruka = new Poruka("Uspešno ste prihvatili zabavu.", "Obaveštenje", MessageBoxButton.OK);
            poruka.Owner = this;
            poruka.ShowDialog();

            // azuriranje podataka
            List<Models.Zabava> zabavice = null;
            if (this.trenutne) zabavice = (from z in servis.GetZabave() where (z.Status == 1 && z.Organizator == null) || z.Status == 5 select z).ToList();
            else (from z in servis.GetZabave() where z.Status == 1 && z.Organizator?.Id == idOrganizatora select z).ToList();
            this.DataContext = new ZabaveViewModel(zabavice);
        }

        private void buttonOdbij_Click(object sender, RoutedEventArgs e)
        {
            Models.Zabava selektovana = (Models.Zabava)zabave.SelectedItem;
            Poruka poruka = null;
            if (selektovana == null)
            {
                poruka = new Poruka("Morate selektovati zabavu pre nego što pritisnete \"odbij\".", "Obaveštenje", MessageBoxButton.OK);
                poruka.Owner = this;
                poruka.ShowDialog();
                return;
            }

            selektovana.Status = 5;
            ServisZabave servis = new ServisZabave();
            servis.IzmeniZabavu(selektovana);
            poruka = new Poruka("Uspešno ste prihvatili zabavu.", "Obaveštenje", MessageBoxButton.OK);
            poruka.Owner = this;
            poruka.ShowDialog();

            // azuriranje podataka
            List<Models.Zabava> zabavice = (from z in servis.GetZabave() where z.Status == 1 && z.Organizator?.Id == idOrganizatora select z).ToList();
            this.DataContext = new ZabaveViewModel(zabavice);
        }
    }
}
