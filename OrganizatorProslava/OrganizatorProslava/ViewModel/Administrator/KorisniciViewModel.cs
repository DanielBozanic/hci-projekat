using OrganizatorProslava.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace OrganizatorProslava.ViewModel.Administrator
{
    public class KorisniciViewModel : INotifyPropertyChanged
    {
		private ObservableCollection<Korisnik> _korisnici;

		public KorisniciViewModel(List<Korisnik> korisnici)
        {
			Korisnici = new ObservableCollection<Korisnik>();
			foreach (var korisnik in korisnici)
            {
				Korisnici.Add(korisnik);
			}
		}

		public ObservableCollection<Korisnik> Korisnici
		{
			get { return _korisnici; }
			set
			{
				_korisnici = value;
				RaisePropertyChanged("Korisnici");
			}
		}

		public void DodajKorisnika(Korisnik korisnik)
		{
			if (Korisnici.FirstOrDefault(q => q.Id == korisnik.Id) == null)
				Korisnici.Add(korisnik);
		}

		public void IzmeniKorisnika(Korisnik korisnik)
		{
			var korisnikItem = Korisnici.FirstOrDefault(q => q.Id == korisnik.Id);
			if (korisnikItem != null)
            {
				var index = Korisnici.IndexOf(korisnikItem);
				Korisnici.RemoveAt(index);
				Korisnici.Insert(index, korisnik);
			}
		}

		public void UkloniKorisnika(Korisnik korisnik)
        {
			if (Korisnici.FirstOrDefault(q => q.Id == korisnik.Id) != null)
				Korisnici.Remove(korisnik);
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
