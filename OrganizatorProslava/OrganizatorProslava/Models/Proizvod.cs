using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizatorProslava.Models
{
    public class Proizvod
    {
        public int Id { get; set; }

        public string Naziv { get; set; }

        public double Cena { get; set; }

        public string Opis { get; set; }

        public string LinkZaSliku { get; set; }

        public bool? SmeDaMenja { get; set; }

        public Saradnik Sardanik { get; set; }

    }
}
