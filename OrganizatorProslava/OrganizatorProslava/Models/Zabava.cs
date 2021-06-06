using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrganizatorProslava.Services;

namespace OrganizatorProslava.Models
{
    public class Zabava
    {
        public int Id { get; set; }
        public string Tip { get; set; }

        public Korisnik Kreator { get; set; }       // cija je proslava

        public DateTime DatumProslave { get; set; }

        public int Trajanje { get; set; }

        public string Grad { get; set; }

        public string Tema { get; set; }

        public int BrojGostiju { get; set; }

        public bool TipBudzeta { get; set; }

        public double Budzet { get; set; }

        public string SpisakGostiju { get; set; }       // mozda i drugacije

        public Korisnik Organizator { get; set; }

        public string DodatneZelje { get; set; }

        public List<Saradnik> OdabraniSaradnici { get; set; }

        public int Status { get; set; }


        public string Vrijeme { get; set; }

    }
}
