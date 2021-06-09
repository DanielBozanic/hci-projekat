using OrganizatorProslava.DataAccess.Klijenti;
using System.Collections.Generic;
using System.Linq;

namespace OrganizatorProslava.Services.Klijenti
{
    public class SalaServis
    {
        public List<Models.Sto> GetStoloviSaleZaZabavu(int zabavaId, int proizvodId)
        {
            var zabavaStoDal = new ZabavaSto();
            return zabavaStoDal.GetStoloveSaleZaZabavu(zabavaId, proizvodId).ToList()
                .OrderBy(o => o.StoSale.ID).ThenBy(o => o.StoSale.Opis)
                .Select(s => new Models.Sto
                {
                    Id = s.StoSale.ID,
                    BrojMesta = s.StoSale.BrojMesta,
                    Opis = s.StoSale.Opis,
                    XPos = s.StoZabave?.X,
                    YPos = s.StoZabave?.Y
                }).ToList();
        }

        public void SacuvajStoZabave(int zabavaId, int proizvodId, Models.Sto sto)
        {
            var zabavaStoDal = new ZabavaSto();
            var stoZabave = zabavaStoDal.PronadjiStoZabave(zabavaId, sto.Id);
            if (stoZabave == null)
            {
                stoZabave = new DataModel.ZabavaSalaSto
                {
                    ZabavaID = zabavaId,
                    SalaStoID = sto.Id,
                    X = sto.XPos.Value,
                    Y = sto.YPos.Value
                };

                zabavaStoDal.AddStoZabave(stoZabave);
            }
            else
            {
                stoZabave.X = sto.XPos.Value;
                stoZabave.Y = sto.YPos.Value;

                zabavaStoDal.SaveChanges();
            }
        }

        public void UkloniStoloveZabave(int zabavaId, int proizvodId)
        {
            var zabavaStoDal = new ZabavaSto();
            zabavaStoDal.UkloniStoloveZabave(zabavaId, proizvodId);
        }
    }
}
