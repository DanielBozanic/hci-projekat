using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizatorProslava.DataAccess.Zabava
{
    public class Zabava
    {
        private readonly DataModel.OrganizatorProslavaEntities bazaPodataka;

        public Zabava() {
            this.bazaPodataka = new DataModel.OrganizatorProslavaEntities();
        }

        //dodaj
        //obrisi
        //nadji po statusu
        //nadji po korisniku

    }
}
