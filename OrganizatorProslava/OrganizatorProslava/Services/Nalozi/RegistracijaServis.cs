using OrganizatorProslava.Models;

namespace OrganizatorProslava.Services.Nalozi
{
    public class RegistracijaServis
    {
        public void DodajKorisnika(Korisnik korisnik)
        {
            var korisnikDal = new DataAccess.Nalozi.Korisnik();
            korisnikDal.DodajKorisnika(new DataModel.Korisnik
            {
                ID = korisnik.Id,
                Ime = korisnik.Ime,
                Prezime = korisnik.Prezime,
                Tip = korisnik.Tip,
                KorisnickoIme = korisnik.KorisnickoIme,
                Lozinka = korisnik.Lozinka
            });
        }

        public bool KorisnikPostoji(string korisnickoIme)
        {
            var korisnikDal = new DataAccess.Nalozi.Korisnik();
            var korisnik = korisnikDal.NadjiKorisnikaPoKorisnickomImenu(korisnickoIme);
            return (korisnik != null);
        }
    }
}
