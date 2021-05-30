using OrganizatorProslava.Models;

namespace OrganizatorProslava.Services.Nalozi
{
    public class RegistracijaServis
    {
        public int DodajKorisnika(Korisnik korisnik)
        {
            var korisnikDal = new DataAccess.Nalozi.Korisnik();
            return korisnikDal.DodajKorisnika(new DataModel.Korisnik
            {
                Ime = korisnik.Ime,
                Prezime = korisnik.Prezime,
                Tip = korisnik.Tip,
                KorisnickoIme = korisnik.KorisnickoIme,
                Lozinka = korisnik.Lozinka
            });
        }

        public string IzmeniKorisnika(Korisnik korisnikModel)
        {
            var korisnikDal = new DataAccess.Nalozi.Korisnik();
            var korisnik = korisnikDal.GetKorisnika(korisnikModel.Id);
            if (korisnik != null)
            {
                korisnik.Ime = korisnikModel.Ime;
                korisnik.Prezime = korisnikModel.Prezime;
                korisnik.Lozinka = korisnikModel.Lozinka;

                korisnikDal.SaveChanges();

                return string.Empty;
            }
            else
            {
                return $"{Poruke.NijeNadjenKorisnik}{korisnikModel.Id}";
            }
        }

        public bool KorisnikPostoji(string korisnickoIme)
        {
            var korisnikDal = new DataAccess.Nalozi.Korisnik();
            var korisnik = korisnikDal.NadjiKorisnikaPoKorisnickomImenu(korisnickoIme);
            return (korisnik != null);
        }
    }
}
