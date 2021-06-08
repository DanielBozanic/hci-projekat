using OrganizatorProslava.DataModel;

namespace OrganizatorProslava.DataAccess.Klijenti
{
    public class Sala
    {
        private readonly OrganizatorProslavaEntities _db;

        public Sala()
        {
            _db = new OrganizatorProslavaEntities();
        }
        public void AddStoZabave(SalaSto sto)
        {
            _db.SalaStoes.Add(sto);

            SaveChanges();
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
