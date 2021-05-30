using OrganizatorProslava.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace OrganizatorProslava.ViewModel.Administrator
{
    public class SaradniciViewModel : INotifyPropertyChanged
	{
		private ObservableCollection<Saradnik> _saradnici;

		public SaradniciViewModel(List<Saradnik> saradnici)
		{
			Saradnici = new ObservableCollection<Saradnik>();
			foreach (var saradnik in saradnici)
			{
				Saradnici.Add(saradnik);
			}
		}

		public ObservableCollection<Saradnik> Saradnici
		{
			get { return _saradnici; }
			set
			{
				_saradnici = value;
				RaisePropertyChanged("Saradnici");
			}
		}

		public void DodajSaradnika(Saradnik saradnik)
		{
			if (Saradnici.FirstOrDefault(q => q.Id == saradnik.Id) == null)
				Saradnici.Add(saradnik);
		}

		public void IzmeniSaradnika(Saradnik saradnik)
		{
			var korisnikItem = Saradnici.FirstOrDefault(q => q.Id == saradnik.Id);
			if (korisnikItem != null)
			{
				var index = Saradnici.IndexOf(korisnikItem);
				Saradnici.RemoveAt(index);
				Saradnici.Insert(index, saradnik);
			}
		}

		public void UkloniSaradnika(Saradnik saradnik)
		{
			if (Saradnici.FirstOrDefault(q => q.Id == saradnik.Id) != null)
				Saradnici.Remove(saradnik);
		}

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
    }
}
