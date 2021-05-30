using OrganizatorProslava.DataModel;
using System.Linq;

namespace OrganizatorProslava.DataAccess.Saradnici
{
    public class TipSaradnika
    {
        private readonly OrganizatorProslavaEntities _db;

        public TipSaradnika()
        {
            _db = new OrganizatorProslavaEntities();
        }

        public IQueryable<DataModel.TipSaradnika> GetTipoveSaradnika()
        {
            return _db.TipSaradnikas;
        }
    }
}
