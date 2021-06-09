using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OrganizatorProslava.UI.Korisnici
{
    class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

       
        /// obavijesti da se promijenilo polje
        /// <param name="propertyName">ime polja koje se mijenja</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

      
        /// obavijest da se polje mijenja pozivom atributa CallerMemerName
        /// <typeparam name="T"></typeparam>
        /// <param name="backingField">pozadina polja</param>
        /// <param name="value">vrijednost koja se daje pozadini polja</param>
        /// <param name="propertyName"></param>
        protected virtual bool OnPropertyChanged<T>(ref T backingField, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(backingField, value))
                return false;

            backingField = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
