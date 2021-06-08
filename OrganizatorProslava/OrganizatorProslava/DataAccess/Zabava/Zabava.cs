using System.Linq;
using OrganizatorProslava.Services;

namespace OrganizatorProslava.DataAccess.Zabava
{
    public class ZabavaZabava : DataModel.Zabava
    {
        private readonly DataModel.OrganizatorProslavaEntities bazaPodataka;

        public ZabavaZabava() {
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

        public IQueryable<DataModel.Zabava> GetSveZabave()
        {
            return (IQueryable<DataModel.Zabava>)(from z in this.bazaPodataka.Zabavas where z.Status != 3 select z);
        }

        public IQueryable<DataModel.Zabava> GetZabaveZaKreatora(int idKreatora)
        {
            return (IQueryable<DataModel.Zabava>)(from z in this.bazaPodataka.Zabavas where z.Status != 3 && z.Kreator == idKreatora select z);
        }

        public IQueryable<DataModel.Zabava> GetZabaveZaOrganizatora(int idOrganizatora)
        {
            return (IQueryable<DataModel.Zabava>)(from z in this.bazaPodataka.Zabavas where z.Status != 3 && z.Organizator == idOrganizatora select z);
        }

        public IQueryable<DataModel.Zabava> GetZahteveZaZabave(int idOrganizatora)
        {
            return (IQueryable<DataModel.Zabava>)(from z in this.bazaPodataka.Zabavas where z.Status == 1 && z.Organizator == idOrganizatora select z);
        }

        public IQueryable<DataModel.Zabava> GetNedodeljeneZabave()
        {
            return (IQueryable<DataModel.Zabava>)(from z in this.bazaPodataka.Zabavas where z.Status == 1 && z.Organizator == null select z);
        }

        public IQueryable<DataModel.Zabava> GetZavrseneZabave(int idOrganizatora)
        {
            return (IQueryable<DataModel.Zabava>)(from z in this.bazaPodataka.Zabavas where z.Status == 4 && z.Organizator == idOrganizatora select z);
        }

        public IQueryable<DataModel.Zabava> GetZabaveUToku(int idOrganizatora)
        {
            return (IQueryable<DataModel.Zabava>)(from z in this.bazaPodataka.Zabavas where z.Status == 2 && z.Organizator == idOrganizatora select z);
        }


        //za korisnika
        public IQueryable<DataModel.Zabava> GetKorisnickeZahtjeveNaCekanju(int idKorisnika)
        {
            return (IQueryable<DataModel.Zabava>)(from z in this.bazaPodataka.Zabavas where z.Status == 1 && z.Kreator == idKorisnika select z);
        }
        public IQueryable<DataModel.Zabava> GetOdobreneKorisnickeZahtjeve(int idKorisnika)
        {
            return (IQueryable<DataModel.Zabava>)(from z in this.bazaPodataka.Zabavas where z.Status == 2 && z.Kreator == idKorisnika select z);
        }
        public IQueryable<DataModel.Zabava> GetOdbijeneKorisnickeZahtjeve(int idKorisnika)
        {
            return (IQueryable<DataModel.Zabava>)(from z in this.bazaPodataka.Zabavas where z.Status == 5 && z.Kreator == idKorisnika select z);
        }

    }
}
