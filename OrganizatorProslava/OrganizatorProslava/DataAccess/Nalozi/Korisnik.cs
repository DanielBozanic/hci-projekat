using System.Linq;

namespace OrganizatorProslava.DataAccess.Nalozi
{
    public class Korisnik
    {
        private readonly DataModel.OrganizatorProslavaEntities _db;

        public Korisnik()
        {
            _db = new DataModel.OrganizatorProslavaEntities();
        }

        public void DodajKorisnika(DataModel.Korisnik korisnik)
        {
            _db.Korisniks.Add(korisnik);
            _db.SaveChanges();
        }

        public DataModel.Korisnik NadjiKorisnikaPoKorisnickomImenu(string korisnickoIme)
        {
            return _db.Korisniks.FirstOrDefault(q => q.KorisnickoIme.ToLower() == korisnickoIme.ToLower());
        }
    }
}
