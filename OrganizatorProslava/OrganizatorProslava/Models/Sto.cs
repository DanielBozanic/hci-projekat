using System.ComponentModel;

namespace OrganizatorProslava.Models
{
    public class Sto :  INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private string _opis;
        private int? _brojMesta;
        private int? _x;
        private int? _y;
        private bool _naMapi;

        public int Id { get; set;  }
        public string Opis 
        {
            get { return _opis;  }
            set
            {
                _opis = value;
                Naziv = $"{_opis}{(_brojMesta.HasValue ? $" (Broj mesta: {_brojMesta.Value})" : string.Empty)}";
            } 
        }
        public int? BrojMesta 
        { 
            get { return _brojMesta;  }
            set
            {
                _brojMesta = value;
                Naziv = $"{_opis}{(_brojMesta.HasValue ? $" (Broj mesta: {_brojMesta.Value})" : string.Empty)}";
            }
        }
        public int? XPos 
        {
            get { return _x;  }
            set
            {
                if (value != _x)
                {
                    _x = value;
                    NaMapi = _x.HasValue && _y.HasValue;
                    OnPropertyChanged("XPos");
                }
            }
        }
        public int? YPos
        {
            get { return _y; }
            set
            {
                if (value != _y)
                {
                    _y = value;
                    NaMapi = _x.HasValue && _y.HasValue;
                    OnPropertyChanged("YPos");
                }
            }
        }
        public string Naziv { get; set; }
        public bool NaMapi
        {
            get { return _naMapi;  }
            set
            {
                if (_naMapi != value)
                {
                    _naMapi = value;
                    OnPropertyChanged("NaMapi");
                }
            }
        }
    }
}
