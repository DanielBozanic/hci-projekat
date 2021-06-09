using OrganizatorProslava.Help;
using OrganizatorProslava.Services;
using OrganizatorProslava.UI.Shared;
using OrganizatorProslava.ViewModel.Administrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace OrganizatorProslava.UI.Administrator
{
    public partial class Saradnici : Window
    {
        private int _tipFiltera = 0;

        public Saradnici()
        {
            InitializeComponent();
            this.DataContext = new SaradniciViewModel(GetSaradnici());
        }

        private void Window_Rendered(object sender, EventArgs e)
        {
            this.Owner.Hide();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.Owner.Show();
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                btnNazad_Click(null, null);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl) && e.Key == Key.D)
                btnDodaj_Click(null, null);
            if (Keyboard.IsKeyDown(Key.LeftCtrl) && e.Key == Key.I)
                btnIzmeni_Click(null, null);
            if (Keyboard.IsKeyDown(Key.LeftCtrl) && e.Key == Key.O)
                btnObrisi_Click(null, null);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var tipSaradnikaServis = new Services.Nalozi.TipSaradnikaServis();
            var tipoviSaradnika = tipSaradnikaServis.GetTipoveSaradnika();
            tipoviSaradnika.Add(new Models.TipSaradnika
            {
                Id = 0,
                Naziv = "Svi"
            });
            comboFilter.ItemsSource = tipoviSaradnika;
            comboFilter.DisplayMemberPath = "Naziv";
            comboFilter.SelectedValuePath = "Id";
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            IInputElement focusedControl = FocusManager.GetFocusedElement(this);
            if (focusedControl is DependencyObject)
            {
                string str = HelpProvider.GetHelpKey((DependencyObject)focusedControl);
                HelpProvider.ShowHelp(str, this);
            }
        }

        private List<Models.Saradnik> GetSaradnici()
        {
            var saradnikServis = new Services.Saradnici.SaradnikServis();
            return saradnikServis.GetSaradnici().ToList();
        }

        private List<Models.Saradnik> GetSaradnici(int tip, string pretrazi)
        {
            var saradnikServis = new Services.Saradnici.SaradnikServis();
            pretrazi = pretrazi.ToLower();
            return saradnikServis.GetSaradnici()
                .Where(q => (tip == 0 || q.TipSaradnikaId == tip) &&
                    (pretrazi == string.Empty ||
                    q.Naziv.ToLower().Contains(pretrazi) ||
                    q.Adresa.ToLower().Contains(pretrazi) ||
                    q.Email.ToLower().Contains(pretrazi) ||
                    q.TipSaradnika.ToLower().Contains(pretrazi))).ToList();
        }

        private void btnNazad_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void comboFilter_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var id = (int)comboFilter.SelectedValue;
            if (_tipFiltera != id)
            {
                _tipFiltera = id;
                Filter();
            }
        }

        private void Filter()
        {
            if (txtPretraga != null)
                this.DataContext = new SaradniciViewModel(GetSaradnici(_tipFiltera, txtPretraga.Text.Length >= 3 ? txtPretraga.Text : string.Empty));
        }

        private void txtPretraga_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (txtPretraga.Text.Length >= 3)
                this.DataContext = new SaradniciViewModel(GetSaradnici(_tipFiltera, txtPretraga.Text));
            else if (txtPretraga.Text.Length == 0)
                this.DataContext = new SaradniciViewModel(GetSaradnici(_tipFiltera, string.Empty));

        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (dgSaradnici.SelectedItem != null)
            {
                var potvrdi = new Poruka(Poruke.BrisiSaradnika, Poruke.Poruka, MessageBoxButton.YesNo, MessageBoxResult.No);
                potvrdi.Owner = this;
                potvrdi.ShowDialog();
                if (potvrdi.Rezultat == MessageBoxResult.Yes)
                {
                    var saradnik = (Models.Saradnik)dgSaradnici.SelectedItem;
                    var saradnikServis = new Services.Saradnici.SaradnikServis();
                    var msg = saradnikServis.BrisiSaradnika(saradnik.Id);
                    if (msg == string.Empty)
                    {
                        ((SaradniciViewModel)this.DataContext).UkloniSaradnika(saradnik);
                        var poruka = new Poruka(string.Format(Poruke.SaradnikObrisan, saradnik.Naziv), Poruke.Poruka, MessageBoxButton.OK);
                        poruka.Owner = this;
                        poruka.ShowDialog();
                    }
                    else
                    {
                        var poruka = new Poruka(msg, Poruke.Poruka, MessageBoxButton.OK);
                        poruka.Owner = this;
                        poruka.ShowDialog();
                    }
                }
            }
            else
            {
                var poruka = new Poruka(Poruke.BrisanjeZapisNijeSelektovan, Poruke.Poruka, MessageBoxButton.OK);
                poruka.Owner = this;
                poruka.ShowDialog();
            }
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            var izmena = new IzmeniSaradnika(null);
            izmena.Owner = this;
            izmena.ShowDialog();
            if (izmena.Rezultat == MessageBoxResult.OK)
                ((SaradniciViewModel)this.DataContext).DodajSaradnika(izmena.Saradnik);
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            if (dgSaradnici.SelectedItem != null)
            {
                var saradnik = (Models.Saradnik)dgSaradnici.SelectedItem;
                var izmena = new IzmeniSaradnika(saradnik);
                izmena.Owner = this;
                izmena.ShowDialog();
                if (izmena.Rezultat == MessageBoxResult.OK)
                    ((SaradniciViewModel)this.DataContext).IzmeniSaradnika(izmena.Saradnik);
            }
            else
            {
                var poruka = new Poruka(Poruke.IzmenaZapisNijeSelektovan, Poruke.Poruka, MessageBoxButton.OK);
                poruka.Owner = this;
                poruka.ShowDialog();
            }
        }
    }
}
