using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrganizatorProslava.Models;

namespace OrganizatorProslava.UI.Korisnici
{
    class TabelaZahtjevaVM : INotifyPropertyChanged
    {
		#region INotifyPropertyChanged

		public event PropertyChangedEventHandler PropertyChanged;
		public void RaisePropertyChanged(string propertyName)
		{
			if (null != PropertyChanged)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		#endregion


		private ObservableCollection<Zabava> _zahtevi;

		public ObservableCollection<Zabava> Zahtevi
		{
			get { return _zahtevi; }
			set
			{
				_zahtevi = value;
				RaisePropertyChanged("Zahtevi");
			}
		}



		public TabelaZahtjevaVM(List<Zabava> zahtevi)
		{
			Zahtevi = new ObservableCollection<Zabava>();
			foreach (var zahtev in zahtevi)
			{
				Zahtevi.Add(zahtev);
			}
		}
	}
}
