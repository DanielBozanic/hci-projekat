using OrganizatorProslava.DataAccess.Klijenti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizatorProslava.Services.Klijenti
{
    public class SalaServis
    {
        public List<Models.Sto> GetStoloviSale(int proizvodId)
        {
            var salaDal = new Sala();
            return salaDal.GetStoloveZaSalu(proizvodId).ToList()
                .OrderBy(o => o.ID).ThenBy(o => o.Opis)
                .Select(s => new Models.Sto
                {
                    Id = s.ID,
                    ProizvodId = s.ProizvodID,
                    BrojMesta = s.BrojMesta,
                    Opis = s.Opis,
                    XPos = s.X,
                    YPos = s.Y
                }).ToList();
        }
    }
}
