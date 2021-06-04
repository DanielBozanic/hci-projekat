using OrganizatorProslava.Models;

namespace OrganizatorProslava.Services.Nalozi
{
    public class PrijavaServis
    {
        public string PrijaviMe(string korisnickoIme, string lozinka)
        {
            var korisnikDal = new DataAccess.Nalozi.Korisnik();
            var korisnik = korisnikDal.NadjiKorisnikaPoKorisnickomImenu(korisnickoIme);
            if (korisnik == null || korisnik.Lozinka != lozinka)
                return Poruke.PogresnaPrijava;

            LogovaniKorisnik.Id = korisnik.ID;
            LogovaniKorisnik.PunoIme = $"{korisnik.Ime} {korisnik.Prezime}".Trim();
            LogovaniKorisnik.Tip = korisnik.Tip;
            LogovaniKorisnik.KorisnickoIme = korisnik.KorisnickoIme;
            LogovaniKorisnik.Lozinka = korisnik.Lozinka;
            return string.Empty;
        }
    }
}
