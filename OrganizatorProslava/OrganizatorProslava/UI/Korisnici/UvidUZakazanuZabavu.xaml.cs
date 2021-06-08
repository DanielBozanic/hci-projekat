using System;
using System.Windows;

namespace OrganizatorProslava.UI.Korisnici
{
    public partial class UvidUZakazanuZabavu : Window
    {
        public UvidUZakazanuZabavu()
        {
            InitializeComponent();
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            this.Owner.Hide();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.Owner.Show();
        }

        private void btnSala_Click(object sender, RoutedEventArgs e)
        {
            var sala = new Sala(5, 14);
            sala.Owner = this;
            sala.ShowDialog();
        }

        private void btnGosti_Click(object sender, RoutedEventArgs e)
        {
            var zabavaGosti = new ZabavaGosti(5, 14);
            zabavaGosti.Owner = this;
            zabavaGosti.ShowDialog();
        }
    }
}
