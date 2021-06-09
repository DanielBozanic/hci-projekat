using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizatorProslava.DataAccess.Zabava
{
    class ZabavaPoruke
    {
        private readonly DataModel.OrganizatorProslavaEntities bazaPodataka;


        public ZabavaPoruke()
        {
            this.bazaPodataka = new DataModel.OrganizatorProslavaEntities();
        }

        public int DodajPoruku(DataModel.Zabava_Poruke p)
        {
            //mora ti biti popunjen id
            this.bazaPodataka.Zabava_Poruke.Add(p);
            this.bazaPodataka.SaveChanges();
            return p.ID;
            
        }


        public DataModel.Zabava_Poruke GetPorukaPoId(int id)
        {
            return bazaPodataka.Zabava_Poruke.FirstOrDefault(q => q.ID == id);
        }




        public IQueryable<DataModel.Zabava_Poruke> GetPorukEZaZabavu(int idZabava)
        {
            return (IQueryable<DataModel.Zabava_Poruke>)(from p in this.bazaPodataka.Zabava_Poruke where p.ZabavaID == idZabava select p);
        }


        public IQueryable<DataModel.Zabava_Poruke> GetSvePoruke()
        {
            return (IQueryable<DataModel.Zabava_Poruke>)(from p in this.bazaPodataka.Zabava_Poruke select p);
        }



        public void SaveChanges()
        {
            bazaPodataka.SaveChanges();
        }

    }
}
