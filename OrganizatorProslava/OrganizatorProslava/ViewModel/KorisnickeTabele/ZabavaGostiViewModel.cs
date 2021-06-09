using OrganizatorProslava.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace OrganizatorProslava.ViewModel.Administrator
{
	public class ZabavaGostiViewModel : INotifyPropertyChanged
	{
		private ObservableCollection<ZabavaGosti> _zabavaGosti;
		private ObservableCollection<Sto> _stolovi;

		public ZabavaGostiViewModel(List<ZabavaGosti> zabavaGosti, List<Sto> stolovi)
		{
			ZabavaGosti = new ObservableCollection<ZabavaGosti>();
			foreach (var gost in zabavaGosti)
			{
				ZabavaGosti.Add(gost);
			}

			Stolovi = new ObservableCollection<Sto>();
			foreach (var sto in stolovi)
			{
				Stolovi.Add(sto);
			}
		}

		public ObservableCollection<ZabavaGosti> ZabavaGosti
		{
			get { return _zabavaGosti; }
			set
			{
				_zabavaGosti = value;
				RaisePropertyChanged("ZabavaGosti");
			}
		}

		public ObservableCollection<Sto> Stolovi
		{
			get { return _stolovi; }
			set
			{
				_stolovi = value;
				RaisePropertyChanged("Stolovi");
			}
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
