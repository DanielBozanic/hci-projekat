using OrganizatorProslava.UI.Korisnici;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizatorProslava.UI.Korisnici
{
    class ZakazivanjeViewModel : ObservableObject
    {
        
        private string _tipZabave;
        private string _grad;
        private string _trajanje;
        private string _vrijeme;
        private string _brojGostiju;
        private string _budzet;

        public string TipZabave
        {
            get { return _tipZabave; }
            set
            {
                OnPropertyChanged(ref _tipZabave, value);
            }
        }

        public string Grad
        {
            get { return _grad; }
            set
            {
                OnPropertyChanged(ref _grad, value);
            }
        }


        public string Trajanje
        {
            get { return _trajanje; }
            set
            {
                OnPropertyChanged(ref _trajanje, value);
            }
        }


        public string Vrijeme
        {
            get { return _vrijeme; }
            set
            {
                OnPropertyChanged(ref _vrijeme, value);
            }
        }


        public string BrojGostiju
        {
            get { return _brojGostiju; }
            set
            {
                OnPropertyChanged(ref _brojGostiju, value);
            }
        }


        public string Budzet
        {
            get { return _budzet; }
            set
            {
                OnPropertyChanged(ref _budzet, value);
            }
        }



    }
}
