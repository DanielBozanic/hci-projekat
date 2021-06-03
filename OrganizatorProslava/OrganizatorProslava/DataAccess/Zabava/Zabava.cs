using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrganizatorProslava.Services;

namespace OrganizatorProslava.DataAccess.Zabava
{
    public class Zabava
    {
        private readonly DataModel.OrganizatorProslavaEntities bazaPodataka;

        public Zabava() {
            this.bazaPodataka = new DataModel.OrganizatorProslavaEntities();
        }

        public int DodajZabavu(DataModel.Zabava zabava)
        {
            this.bazaPodataka.Zabavas.Add(zabava);
            this.bazaPodataka.SaveChanges();
            return zabava.ID;
        }

        public void ObrisiZabavu(DataModel.Zabava zabava)
        {
            zabava.Status = 3;
            this.bazaPodataka.SaveChanges();
        }

        public void OrganizujZabavu(DataModel.Zabava zabava)
        {
            zabava.Status = 2;
            this.bazaPodataka.SaveChanges();
        }

        public void ZavrsiZabavu(DataModel.Zabava zabava)
        {
            zabava.Status = 4;
            this.bazaPodataka.SaveChanges();
        }

        public DataModel.Zabava GetZabavu(int id)
        {
            return this.bazaPodataka.Zabavas.FirstOrDefault(q => q.ID == id);
        }

        public void SaveChanges()
        {
            this.bazaPodataka.SaveChanges();
        }

        public IQueryable<Zabava> GetSveZabave()
        {
            return (IQueryable<Zabava>)(from z in this.bazaPodataka.Zabavas where z.Status != StatusZabave.Izbrisana select z);
        }

        public IQueryable<Zabava> GetZabaveZaKreatora(int idKreatora)
        {
            return (IQueryable<Zabava>)(from z in this.bazaPodataka.Zabavas where z.Status != StatusZabave.Izbrisana && z.Kreator == idKreatora select z);
        }

        public IQueryable<Zabava> GetZabaveZaOrganizatora(int idOrganizatora)
        {
            return (IQueryable<Zabava>)(from z in this.bazaPodataka.Zabavas where z.Status != StatusZabave.Izbrisana && z.Organizator == idOrganizatora select z);
        }

    }
}
