using OrganizatorProslava.DataModel;
using System.Linq;

namespace OrganizatorProslava.DataAccess.Saradnici
{
    public class Saradnik
    {
        private readonly OrganizatorProslavaEntities _db;

        public Saradnik()
        {
            _db = new OrganizatorProslavaEntities();
        }

        public int DodajSaradnika(DataModel.Saradnik saradnik)
        {
            _db.Saradniks.Add(saradnik);
            _db.SaveChanges();
            return saradnik.ID;
        }

        public void ObrisiSaradnika(DataModel.Saradnik saradnik)
        {
            saradnik.Obrisan = true;
            _db.SaveChanges();
        }

        public IQueryable<SaradnikDetail> GetSaradnike()
        {
            return from s in _db.Saradniks.Where(q => !q.Obrisan)
                   join ts in _db.TipSaradnikas on s.TipSaradnikaID equals ts.ID
                   select new SaradnikDetail
                   {
                       Saradnik = s,
                       TipSaradnika = ts
                   };
        }

        public DataModel.Saradnik GetSaradnika(int id)
        {
            return _db.Saradniks.FirstOrDefault(q => q.ID == id);
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }

    }

    public class SaradnikDetail
    {
        public DataModel.Saradnik Saradnik { get; set; }
        public DataModel.TipSaradnika TipSaradnika  { get; set; }
    }
}
