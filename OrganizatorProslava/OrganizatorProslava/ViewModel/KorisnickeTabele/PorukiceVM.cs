using OrganizatorProslava.DataModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizatorProslava.UI.Korisnici
{
    class PorukiceVM : INotifyPropertyChanged
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

		
		private ObservableCollection<Models.ZabavaPoruka> _poruke;

		public ObservableCollection<Models.ZabavaPoruka> Poruka
		{
			get { return _poruke; }
			set
			{
				_poruke = value;
				RaisePropertyChanged("Poruke");
			}
		}



		public PorukiceVM(List<Models.ZabavaPoruka> poruke)
		{
			Poruka = new ObservableCollection<Models.ZabavaPoruka>();
			foreach (var poruka in poruke)
			{
				Poruka.Add(poruka);
			}
		}


	}
}
