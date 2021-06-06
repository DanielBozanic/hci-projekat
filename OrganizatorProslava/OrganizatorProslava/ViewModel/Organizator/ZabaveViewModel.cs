using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using OrganizatorProslava.Models;
using System.Collections.ObjectModel;

namespace OrganizatorProslava.ViewModel.Organizator
{
    public class ZabaveViewModel : INotifyPropertyChanged
	{
		private ObservableCollection<Zabava> _zabave;

		public ZabaveViewModel(List<Zabava> zabave)
		{
			Zabave = new ObservableCollection<Zabava>();
			foreach (var z in zabave)
			{
				Zabave.Add(z);
			}
		}

		public ObservableCollection<Zabava> Zabave
		{
			get { return _zabave; }
			set
			{
				_zabave = value;
				RaisePropertyChanged("Zabave");
			}
		}

		public void DodajZabavu(Zabava z)
		{
			if (Zabave.FirstOrDefault(q => q.Id == z.Id) == null)
				Zabave.Add(z);
		}

		public void IzmeniZabavu(Zabava z)
		{
			var zabavica = Zabave.FirstOrDefault(q => q.Id == z.Id);
			if (zabavica != null)
			{
				var index = Zabave.IndexOf(zabavica);
				Zabave.RemoveAt(index);
				Zabave.Insert(index, z);
			}
		}

		public void UkloniZabavu(Zabava z)
		{
			if (Zabave.FirstOrDefault(q => q.Id == z.Id) != null)
				Zabave.Remove(z);
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
