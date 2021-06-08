using OrganizatorProslava.DataModel;
using System.Linq;
namespace OrganizatorProslava.DataAccess.Klijenti
{
    public class ZabavaSto
    {
        private readonly OrganizatorProslavaEntities _db;

        public ZabavaSto()
        {
            _db = new OrganizatorProslavaEntities();
        }

        public IQueryable<SalaStoDetail> GetStoloveSaleZaZabavu(int zabavaId, int proizvodId)
        {
            return from ss in _db.SalaStoes.Where(q => q.ProizvodID == proizvodId)
                   join zss in _db.ZabavaSalaStoes.Where(q => q.ZabavaID == zabavaId) on ss.ID equals zss.SalaStoID into zssLeft
                   from zss in zssLeft.DefaultIfEmpty()
                   select new SalaStoDetail
                   {
                       StoSale = ss,
                       StoZabave = zss
                   };
        }

        public ZabavaSalaSto PronadjiStoZabave(int zabavaId, int salaStoId)
        {
            return _db.ZabavaSalaStoes.FirstOrDefault(q => q.ZabavaID == zabavaId && q.SalaStoID == salaStoId);
        }

        public void UkloniStoloveZabave(int zabavaId, int proizvodId)
        {
            var stoloviSale = _db.SalaStoes.Where(q => q.ProizvodID == proizvodId).
                Select(s => s.ID).ToList();

            var stoloviZabave = _db.ZabavaSalaStoes.Where(q => stoloviSale.Contains(q.SalaStoID)).ToList();
            if (stoloviZabave.Any())
            {
                _db.ZabavaSalaStoes.RemoveRange(stoloviZabave);

                _db.SaveChanges();
            }

        }

        public void AddStoZabave(ZabavaSalaSto sto)
        {
            _db.ZabavaSalaStoes.Add(sto);

            SaveChanges();
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }

    public class SalaStoDetail
    {
        public SalaSto StoSale { get; set;  }
        public ZabavaSalaSto StoZabave { get; set; }
    }
}
