using OrganizatorProslava.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizatorProslava.DataAccess.Klijenti
{
    public class Sala
    {
        private readonly DataModel.OrganizatorProslavaEntities _db;

        public Sala()
        {
            _db = new OrganizatorProslavaEntities();
        }

        public IQueryable<SalaSto> GetStoloveZaSalu(int proizvodId)
        {
            return _db.SalaStoes.Where(q => q.ProizvodID == proizvodId);
        }
    }
}
