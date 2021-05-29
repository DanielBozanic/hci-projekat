using OrganizatorProslava.DataModel;
using System.Linq;

namespace OrganizatorProslava.DataAccess.Nalozi
{
    public class Korisnik
    {
        private readonly DataModel.OrganizatorProslavaEntities _db;

        public Korisnik()
        {
            _db = new OrganizatorProslavaEntities();
        }

        public int DodajKorisnika(DataModel.Korisnik korisnik)
        {
            _db.Korisniks.Add(korisnik);
            _db.SaveChanges();
            return korisnik.ID;
        }

        public void ObrisiKorisnika(DataModel.Korisnik korisnik)
        {
            korisnik.Obrisan = true;
            _db.SaveChanges();
        }

        public DataModel.Korisnik NadjiKorisnikaPoKorisnickomImenu(string korisnickoIme)
        {
            return _db.Korisniks.FirstOrDefault(q => q.KorisnickoIme.ToLower() == korisnickoIme.ToLower());
        }

        public IQueryable<DataModel.Korisnik> GetKorisnike()
        {
            return _db.Korisniks.Where(q => !q.Obrisan);
        }

        public DataModel.Korisnik GetKorisnika(int id)
        {
            return _db.Korisniks.FirstOrDefault(q => q.ID == id);
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
