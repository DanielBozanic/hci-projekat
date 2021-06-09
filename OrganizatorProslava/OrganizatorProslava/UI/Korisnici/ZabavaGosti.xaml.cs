using OrganizatorProslava.Services;
using OrganizatorProslava.UI.Shared;
using OrganizatorProslava.ViewModel.Administrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace OrganizatorProslava.UI.Korisnici
{
    public partial class ZabavaGosti : Window
    {
        private readonly int _zabavaId;
        private readonly int _proizvodId;

        public ZabavaGosti(int zabavaId, int  proizvodId)
        {
            InitializeComponent();

            _zabavaId = zabavaId;
            _proizvodId = proizvodId;

            this.DataContext = new ZabavaGostiViewModel(GetZabavaGosti(), GetZabavaStolovi());
        }

        private void btnCuvaj_Click(object sender, RoutedEventArgs e)
        {
            var zabavaGostiServis = new Services.Klijenti.ZabavaGostiServis();
            var msg = zabavaGostiServis.SacuvajZabavaGosti(((ZabavaGostiViewModel)this.DataContext).ZabavaGosti.ToList(), _zabavaId, _proizvodId);
            if (msg != string.Empty)
            {
                var poruka = new Poruka(msg, Poruke.Poruka, MessageBoxButton.OK);
                poruka.Owner = this;
                poruka.ShowDialog();
                return;
            }

            this.DialogResult = true;
        }

        private void btnOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.DialogResult != true)
            {

                var potvrdi = new Poruka($"{Poruke.PodaciCeBitiIzgubljeni}{Environment.NewLine}{Poruke.OdbaciPodatke}",
                    Poruke.Poruka, MessageBoxButton.YesNo, MessageBoxResult.No);
                potvrdi.Owner = this;
                potvrdi.ShowDialog();
                if (potvrdi.Rezultat != MessageBoxResult.Yes)
                    e.Cancel = true;
            }
        }

        private List<Models.ZabavaGosti> GetZabavaGosti()
        {
            var zabavaGostiServis = new Services.Klijenti.ZabavaGostiServis();
            return zabavaGostiServis.GetZabavaGosti(_zabavaId, _proizvodId);
        }

        private List<Models.Sto> GetZabavaStolovi()
        {
            var zabavaGostiServis = new Services.Klijenti.ZabavaGostiServis();
            return zabavaGostiServis.GetZabavaStolovi(_zabavaId, _proizvodId);
        }
    }
}
