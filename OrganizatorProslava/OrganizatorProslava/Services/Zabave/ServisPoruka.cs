using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizatorProslava.Services.Zabave
{
    class ServisPoruka
    {
        public List<Models.ZabavaPoruka> GetPorukaZabave(int idZabava)
        {
            var poruka = new DataAccess.Zabava.ZabavaPoruke();
            return poruka.GetPorukEZaZabavu(idZabava).ToList()
                .Select(p => new Models.ZabavaPoruka
                {
                    Id = p.ID,
                    ZabavaId = p.ZabavaID,
                    Poruka = p.Poruka,
                    KreatorId = p.PosiljalacID

                }).ToList();
        }


        public List<Models.ZabavaPoruka> GetSvePoruke()
        {
            var poruka = new DataAccess.Zabava.ZabavaPoruke();
            return poruka.GetSvePoruke().ToList()
                .Select(p => new Models.ZabavaPoruka
                {
                    Id = p.ID,
                    ZabavaId = p.ZabavaID,
                    Poruka = p.Poruka,
                    KreatorId = p.PosiljalacID

                }).ToList();
        }


        public int DodajPoruku(Models.ZabavaPoruka poruka)
        {
            var porukeBaza = new DataAccess.Zabava.ZabavaPoruke();
            return porukeBaza.DodajPoruku(new DataModel.Zabava_Poruke
            {
                ID = poruka.Id,
                ZabavaID = poruka.ZabavaId,
                PosiljalacID = poruka.KreatorId,
                Poruka = poruka.Poruka
            });
        }

    }
}
