﻿using OrganizatorProslava.Models;
using System;
using System.Windows;

namespace OrganizatorProslava.UI.Administrator
{
    public partial class MeniAdmin : Window
    {
        public MeniAdmin()
        {
            InitializeComponent();
        }

        private void Window_Rendered(object sender, EventArgs e)
        {
            this.Owner.Hide();
        }

        private void btnOdjava_Click(object sender, RoutedEventArgs e)
        {
            LogovaniKorisnik.Reset();
            this.Close();
            this.Owner.Show();
        }
    }
}
