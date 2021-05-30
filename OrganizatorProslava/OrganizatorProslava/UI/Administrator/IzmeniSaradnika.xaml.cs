using OrganizatorProslava.Models;
using OrganizatorProslava.Services;
using OrganizatorProslava.Services.Saradnici;
using OrganizatorProslava.UI.Shared;
using System.Text.RegularExpressions;
using System.Windows;
using System.Linq;
using System.Windows.Input;

namespace OrganizatorProslava.UI.Administrator
{
    public partial class IzmeniSaradnika : Window
    {
        public MessageBoxResult Rezultat { get; set; } = MessageBoxResult.Cancel;
        public Saradnik Saradnik { get; set; }

        public IzmeniSaradnika(Saradnik saradnik)
        {
            InitializeComponent();
            Saradnik = saradnik;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var tipSaradnikaServis = new Services.Nalozi.TipSaradnikaServis();
            var tipoviSaradnika = tipSaradnikaServis.GetTipoveSaradnika();
            cmbTipSaradnika.ItemsSource = tipoviSaradnika;
            cmbTipSaradnika.DisplayMemberPath = "Naziv";
            cmbTipSaradnika.SelectedValuePath = "Id";

            if (Saradnik != null)
            {
                txtNaziv.Text = Saradnik.Naziv;
                txtAdresa.Text = Saradnik.Adresa;
                txtEmail.Text = Saradnik.Email;
                cmbTipSaradnika.SelectedValue = Saradnik.TipSaradnikaId;
            }
            else
            {
                this.Title = "Dodaj saradnika";
            }
            cmbTipSaradnika.IsEnabled = Saradnik == null;
            txtNaziv.Focus();
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                btnOdbaci_Click(null, null);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl) && e.Key == Key.S)
                btnSacuvaj_Click(null, null);
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            if (!Validacija())
                return;

            var servis = new SaradnikServis();
            if (Saradnik == null)
            {
                Saradnik = new Saradnik
                {
                    Naziv = txtNaziv.Text.Trim(),
                    Adresa = txtAdresa.Text.Trim(),
                    Email = txtEmail.Text.ToLower(),
                    TipSaradnikaId = ((Models.TipSaradnika)cmbTipSaradnika.SelectedItem).Id,
                    TipSaradnika = ((Models.TipSaradnika)cmbTipSaradnika.SelectedItem).Naziv
                };

                Saradnik.Id = servis.DodajSaradnika(Saradnik);

                Rezultat = MessageBoxResult.OK;
                this.Close();
            }
            else
            {
                Saradnik.Naziv = txtNaziv.Text.Trim();
                Saradnik.Adresa = txtAdresa.Text.Trim();
                Saradnik.Email = txtEmail.Text.Trim().ToLower();

                var msg = servis.IzmeniSaradnika(Saradnik);
                if (msg == string.Empty)
                {
                    Rezultat = MessageBoxResult.OK;
                    this.Close();
                }
                else
                {
                    var poruka = new Poruka(msg, Poruke.Poruka, MessageBoxButton.OK);
                    poruka.Owner = this;
                    poruka.ShowDialog();
                }
            }
        }

        private void btnOdbaci_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool Validacija()
        {
            var greska = string.Empty;
            if (txtNaziv.Text.Trim() == string.Empty)
            {
                greska = Poruke.NazivObavezan;
                txtNaziv.Focus();
            }
            if (greska == string.Empty && txtEmail.Text.Trim() == string.Empty)
            {
                greska = Poruke.EmailObavezan;
                txtEmail.Focus();
            }
            Regex r = new Regex("^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$");
            if (greska == string.Empty && !r.IsMatch(txtEmail.Text.ToLower()))
            {
                greska = Poruke.EmailPogresanFormat;
                txtEmail.Focus();
            }
            if (greska == string.Empty && cmbTipSaradnika.SelectedItem == null)
            {
                greska = Poruke.TipSaradnikaObavezan;
                cmbTipSaradnika.Focus();
            }
            if (greska == string.Empty)
            {
                var servis = new SaradnikServis();
                var saradnici = servis.GetSaradnici().ToList()
                    .Where(q => (Saradnik == null || q.Id != Saradnik.Id) && q.Email == txtEmail.Text.Trim().ToLower());
                if (saradnici.Any())
                {
                    greska = Poruke.EmailMoraBitiJedinstven;
                    txtEmail.Focus();
                }
            }

            if (greska != string.Empty)
            {
                var potvrdi = new Poruka(greska, Poruke.Poruka, MessageBoxButton.OK);
                potvrdi.Owner = this;
                potvrdi.ShowDialog();
                potvrdi.Close();
            }
            return greska == string.Empty;
        }
    }
}
