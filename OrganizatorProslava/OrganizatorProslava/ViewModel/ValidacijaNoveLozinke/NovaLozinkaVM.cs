using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizatorProslava.UI.Korisnici
{
    class NovaLozinkaVM : ObservableObject
    {
        private string _korisnickoIme;
        private string _lozinka;
        private string _potvrdaLozinki;


        public string KorisnickoImeVM
        {
            get { return _korisnickoIme; }
            set
            {
                OnPropertyChanged(ref _korisnickoIme, value);
            }
        }


        public string LozinkaVM
        {
            get { return _lozinka; }
            set
            {
                OnPropertyChanged(ref _lozinka, value);
            }
        }


        public string PotvrdaLozinkeVM
        {
            get { return _potvrdaLozinki; }
            set
            {
                OnPropertyChanged(ref _potvrdaLozinki, value);
            }
        }

    }
}
