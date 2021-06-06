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
            return korisnikDal.GetKorisnike().OrderBy(o => o.KorisnickoIme).ToList()
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


        public string AzurirajPodatke(string korisnickoIme, string ime, string prezime)
        {
            string poruka = "";

            var pristupBazi = new DataAccess.Nalozi.Korisnik();
            var korisnik = pristupBazi.NadjiKorisnikaPoKorisnickomImenu(korisnickoIme);

            if(korisnik != null)
            {
                korisnik.Ime = ime;
                korisnik.Prezime = prezime;
                pristupBazi.SaveChanges();
            }
            else
            {
                poruka = "Ne postoji korisnik sa tim korisničkim imenom";
            }

            return poruka ;
        }



        public string PromjenaLozinke(string korisnickoIme, string novaLozinka)
        {
            string poruka = "";
            var pristupBazi = new DataAccess.Nalozi.Korisnik();
            var korisnik = pristupBazi.NadjiKorisnikaPoKorisnickomImenu(korisnickoIme);

            if (korisnik != null)
            {
                korisnik.Lozinka = novaLozinka;
                pristupBazi.SaveChanges();
            }
            else
            {
                poruka = "Ne postoji korisnik sa tim korisničkim imenom";
            }

            return poruka;
        }


        public Models.Korisnik dobaviKorisnika(string korisnickoIme)
        {
            var pristupBazi = new DataAccess.Nalozi.Korisnik();
            var korisnikIzBaze = pristupBazi.NadjiKorisnikaPoKorisnickomImenu(korisnickoIme);

            if (korisnikIzBaze != null)
            {
                Models.Korisnik korisnik = new Models.Korisnik();
                korisnik.Id = korisnikIzBaze.ID;
                korisnik.Ime = korisnikIzBaze.Ime;
                korisnik.Prezime = korisnikIzBaze.Prezime;
                korisnik.KorisnickoIme = korisnikIzBaze.KorisnickoIme;
                korisnik.Lozinka = korisnikIzBaze.Lozinka;
                korisnik.Mobilni = korisnikIzBaze.Mobilni;
                korisnik.Pol = korisnikIzBaze.Pol;
                korisnik.Tip = korisnikIzBaze.Tip;
                return korisnik;
            }

            return null;
        }



        public List<Models.Korisnik> dobaviSveOrganizatore()
        {
            var korisnikDal = new DataAccess.Nalozi.Korisnik();
            return korisnikDal.getOrganizatore().OrderBy(o => o.KorisnickoIme).ToList()
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



        public List<Models.Zabava> GetZahtjeveKorisnika()
        {
            /*
            var korisnikDal = new DataAccess.Nalozi.Korisnik();
            return korisnikDal.GetKorisnike().OrderBy(o => o.KorisnickoIme).ToList()
                .Select(s => new Models.Korisnik
                {
                    Id = s.ID,
                    Ime = s.Ime,
                    Prezime = s.Prezime,
                    KorisnickoIme = s.KorisnickoIme,
                    Tip = s.Tip,
                    Lozinka = s.Lozinka
                }).ToList();
            */


            return null;
        }

    }


    
}
