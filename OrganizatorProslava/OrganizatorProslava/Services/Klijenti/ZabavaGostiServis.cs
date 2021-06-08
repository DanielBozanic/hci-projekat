using OrganizatorProslava.DataAccess.Klijenti;
using OrganizatorProslava.DataAccess.Zabava;
using OrganizatorProslava.Models;
using System.Collections.Generic;
using System.Linq;

namespace OrganizatorProslava.Services.Klijenti
{
    public class ZabavaGostiServis
    {
        public List<ZabavaGosti> GetZabavaGosti(int zabavaId, int proizvodId)
        {
            var zabavaDal = new ZabavaZabava();
            var zabava = zabavaDal.GetZabavu(zabavaId);
            if (zabava != null)
            {
                var gosti = zabava.SpisakGostiju.Split(new[] { ',' }, System.StringSplitOptions.RemoveEmptyEntries);

                var zabavaStoDal = new ZabavaSto();
                var rezervisaniStolovi = zabavaStoDal.GetZabavaSalaStoGosti(zabavaId, proizvodId).ToList();

                return (from g in gosti
                       join rs in rezervisaniStolovi on g equals rs.StoZabaveGost.ImeGosta into rsLeft
                       from rs in rsLeft.DefaultIfEmpty()
                       select new ZabavaGosti
                       {
                           ImeGosta = g,
                           StoId = rs != null ? rs.StoZabave.ID : 0
                       }).ToList();
            }

            return new List<ZabavaGosti>();
        }

        public List<Sto> GetZabavaStolovi(int zabavaId, int proizvodId)
        {

            var zabavaStoDal = new ZabavaSto();
            return zabavaStoDal.GetStoloveSaleZaZabavu(zabavaId, proizvodId).ToList()
                .Where(q => q.StoZabave != null)
                .Select(s => new Sto
                {
                    Id = s.StoZabave.ID,
                    Opis = s.StoSale.Opis

                }).ToList();
        }

        public void SacuvajZabavaGosti(List<ZabavaGosti> zabavaGosti, int zabavaId, int proizvodId)
        {
            var zabavaStoDal = new ZabavaSto();
            zabavaStoDal.UknoniZabavaSalaStoGosti(zabavaId, proizvodId);

            if (zabavaGosti.Any())
            {
                zabavaStoDal.DodajZabavaSalaStoGosti(zabavaGosti
                    .Where(q => q.StoId > 0)
                    .Select(s => new DataModel.ZabavaSalaStoGost
                    {
                        ImeGosta = s.ImeGosta,
                        ZabavaSalaStoID = s.StoId
                    }).ToList());
            }
        }
    }
}
