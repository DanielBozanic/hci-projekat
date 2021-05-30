using System.Collections.Generic;
using System.Linq;

namespace OrganizatorProslava.Services.Nalozi
{
    public class TipSaradnikaServis
    {
        public List<Models.TipSaradnika> GetTipoveSaradnika()
        {
            var tipSaradnikaDal = new DataAccess.Saradnici.TipSaradnika();
            return tipSaradnikaDal.GetTipoveSaradnika().OrderBy(o => o.Naziv).ToList()
                .Select(s => new Models.TipSaradnika
                {
                    Id = s.ID,
                    Naziv = s.Naziv
                }).ToList();
        }
    }
}
