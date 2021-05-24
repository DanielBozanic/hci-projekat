using System.Windows;

namespace OrganizatorProslava.UI.Shared
{
    public partial class Poruka : Window
    {
        public MessageBoxResult Rezultat { get; set; } = MessageBoxResult.OK;

        public Poruka(string tekst, string naslov, MessageBoxButton dugme, MessageBoxResult defaultRezultat = MessageBoxResult.OK)
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(naslov))
                this.Title = naslov;
            this.txtMessage.Text = tekst;
            if (dugme ==  MessageBoxButton.OK)
            {
                this.btnDa.Content = "Ok";
                this.btnDa.Margin = new Thickness(this.btnDa.Margin.Left + this.btnDa.Width / 2,
                    this.btnDa.Margin.Top,
                    this.btnDa.Margin.Right,
                    this.btnDa.Margin.Bottom);
                this.btnNe.Visibility = Visibility.Collapsed;
                this.btnDa.IsDefault = true;
                this.btnNe.IsDefault = false;
            }
            else
            {
                this.btnDa.IsDefault = defaultRezultat != MessageBoxResult.No;
                this.btnNe.IsDefault = defaultRezultat == MessageBoxResult.No;
            }
        }

        private void btnDa_Click(object sender, RoutedEventArgs e)
        {
            Rezultat = this.btnNe.Visibility != Visibility.Collapsed ? MessageBoxResult.Yes : MessageBoxResult.OK;
            this.Hide();
        }

        private void btnNe_Click(object sender, RoutedEventArgs e)
        {
            Rezultat = MessageBoxResult.No;
            this.Hide();
        }
    }
}
