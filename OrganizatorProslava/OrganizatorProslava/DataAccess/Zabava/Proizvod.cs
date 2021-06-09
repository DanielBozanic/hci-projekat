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
            this.bazaPodataka.Proizvods.Remove(p);
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
            return (IQueryable<DataModel.Proizvod>)(from p in this.bazaPodataka.Proizvods where p.Zabava_Proizvod.Any(z => z.ZabavaID == zabavaId) select p);
        }

        public void DodajProizvodZaZabavu(DataModel.Zabava_Proizvod p)
        {
            this.bazaPodataka.Zabava_Proizvod.Add(p);
            this.bazaPodataka.SaveChanges();
        }

        public void ObrisiProizvodZaZabavu(DataModel.Zabava_Proizvod p)
        {
            this.bazaPodataka.Zabava_Proizvod.Remove(p);
            this.bazaPodataka.SaveChanges();
        }

        public DataModel.Zabava_Proizvod GetZabava_ProizvodPoID(int zabavaId, int proizvodId)
        {
            return ((IQueryable<DataModel.Zabava_Proizvod>)(from z in this.bazaPodataka.Zabava_Proizvod where z.ZabavaID == zabavaId && z.ProizvodID == proizvodId select z)).ToList().FirstOrDefault();
        }


        public DataModel.Proizvod GetProizvodSaluPoID(int saradnikId)
        {
            return ((IQueryable<DataModel.Proizvod>)(from p in this.bazaPodataka.Proizvods where p.SaradnikID == saradnikId && p.Naziv.Equals("Sala") select p)).ToList().FirstOrDefault();
        }

    }
}
