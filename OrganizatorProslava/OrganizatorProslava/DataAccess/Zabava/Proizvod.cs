using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizatorProslava.DataAccess.Zabava 
{
    public class ProizvodProizvod
    {
        private readonly DataModel.OrganizatorProslavaEntities bazaPodataka;

        public ProizvodProizvod()
        {
            this.bazaPodataka = new DataModel.OrganizatorProslavaEntities();
        }

        public int DodajProizvod(DataModel.Proizvod p)
        {
            this.bazaPodataka.Proizvods.Add(p);
            this.bazaPodataka.SaveChanges();
            return p.ID;
        }

        public void ObrisiProizvod(DataModel.Proizvod p)
        {
            //dodaj kod
            this.bazaPodataka.SaveChanges();
        }

        public DataModel.Proizvod GetProizvod(int id)
        {
            return this.bazaPodataka.Proizvods.FirstOrDefault(q => q.ID == id);
        }

        public void SaveChanges()
        {
            this.bazaPodataka.SaveChanges();
        }

        public IQueryable<DataModel.Proizvod> GetProizvodeZaSaradnika(int idSaradnika)
        {
            return (IQueryable<DataModel.Proizvod>)(from p in this.bazaPodataka.Proizvods where p.SaradnikID == idSaradnika select p);
        }

        public IQueryable<DataModel.Proizvod> GetSveProizvode()
        {
        return (IQueryable<DataModel.Proizvod>)(from p in this.bazaPodataka.Proizvods select p);
        }

        
        public IQueryable<DataModel.Proizvod> GetSveProizvodeZaZabavu(int zabavaId)
        {
            return (IQueryable<DataModel.Proizvod>)(from p in this.bazaPodataka.Proizvods where p.Zabavas.Any(z => z.ID == zabavaId)  select p);
        }

    }
}
