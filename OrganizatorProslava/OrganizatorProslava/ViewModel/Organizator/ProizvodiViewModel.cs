using OrganizatorProslava.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizatorProslava.ViewModel.Organizator
{
	public class ProizvodiViewModel : INotifyPropertyChanged
	{
		private ObservableCollection<Proizvod> _proizvodi;

		public ProizvodiViewModel(List<Proizvod> proizvodi)
		{
			Proizvodi = new ObservableCollection<Proizvod>();
			foreach (var p in proizvodi)
			{
				Proizvodi.Add(p);
			}
		}
		public ObservableCollection<Proizvod> Proizvodi
		{
			get { return _proizvodi; }
			set
			{
				_proizvodi = value;
				RaisePropertyChanged("Proizvodi");
			}
		}

		public void DodajProizvod(Proizvod p)
		{
			if (Proizvodi.FirstOrDefault(q => q.Id == p.Id) == null)
				Proizvodi.Add(p);
		}

		public void IzmeniProizvod(Proizvod p)
		{
			var proizvodP = Proizvodi.FirstOrDefault(q => q.Id == p.Id);
			if (proizvodP != null)
			{
				var index = Proizvodi.IndexOf(proizvodP);
				Proizvodi.RemoveAt(index);
				Proizvodi.Insert(index, p);
			}
		}

		public void UkloniProizvod(Proizvod p)
		{
			if (Proizvodi.FirstOrDefault(q => q.Id == p.Id) != null)
				Proizvodi.Remove(p);
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
