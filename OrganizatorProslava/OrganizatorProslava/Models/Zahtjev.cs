using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizatorProslava.Models
{
    public static class Zahtjev
    {
        public static int Id { get; set; }
        public static string Tip { get; set; }

        public static Korisnik Kreator { get; set; }       // cija je proslava

        public static DateTime DatumProslave { get; set; }

        public static int Trajanje { get; set; }

        public static string Grad { get; set; }

        public static string Tema { get; set; }

        public static int BrojGostiju { get; set; }

        public static bool TipBudzeta { get; set; }

        public static double Budzet { get; set; }

        public static string SpisakGostiju { get; set; }       // mozda i drugacije

        public static Korisnik Organizator { get; set; }

        public static string DodatneZelje { get; set; }

        public static List<Saradnik> OdabraniSaradnici { get; set; }

        public static int Status { get; set; }


        public static string Vrijeme { get; set; }



        public static void Reset()
        {

            Zahtjev.Id = -1;
            Zahtjev.Tip = "";
            Zahtjev.Kreator = null;
            Zahtjev.DatumProslave = DateTime.Now;
            Zahtjev.Trajanje = -1;
            Zahtjev.Grad = "";
            Zahtjev.Tema = "";
            Zahtjev.BrojGostiju = -1;
            Zahtjev.TipBudzeta = false;
            Zahtjev.Budzet = -1;
            Zahtjev.SpisakGostiju = "";
            Zahtjev.Organizator = null;
            Zahtjev.DodatneZelje = "";
            Zahtjev.Status = -1;
            Zahtjev.Vrijeme = "";

        }
    }

}
