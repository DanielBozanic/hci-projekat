using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizatorProslava.Services.Nalozi
{
    public class KorisnikServis
    {
        public List<Models.Korisnik> GetKorisnici()
        {
            var korisnikDal = new DataAccess.Nalozi.Korisnik();
            return korisnikDal.GetKorisnike().ToList()
                .Select(s => new Models.Korisnik
                {
                    Id = s.ID,
                    Ime = s.Ime,
                    Prezime = s.Prezime,
                    KorisnickoIme = s.KorisnickoIme,
                    Tip = s.Tip,
                    Lozinka = s.Lozinka
                }).ToList();
        }

        public string BrisiKorisnika(int id)
        {
            var korisnikDal = new DataAccess.Nalozi.Korisnik();
            var korisnik = korisnikDal.GetKorisnika(id);
            if (korisnik != null)
                korisnikDal.ObrisiKorisnika(korisnik);
            else
                return $"{Poruke.NijeNadjenKorisnik}{id}";

            return string.Empty;
        }
    }
}
