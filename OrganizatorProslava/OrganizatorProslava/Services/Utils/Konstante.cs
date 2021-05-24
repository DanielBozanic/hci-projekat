using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizatorProslava.Services
{
    public class TipKorisnika
    {
        public const int Admin = 1;
        public const int Organizator = 2;
        public const int Klijent = 3;
    }

    public class Pol
    {
        public const string Zenski = "Z";
        public const string Muski = "M";
    }

    public class Poruke
    {
        public const string Poruka = "Poruka";
        public const string PodaciCeBitiIzgubljeni = "Svi uneseni podaci ce biti izgubljeni.";
        public const string OdbaciPodatke = "Da li ste sigurni da zelite odbaciti podatke?";
        public const string ImeObavezno = "Ime je obavezno polje.";
        public const string PrezimeObavezno = "Prezime je obavezno polje.";
        public const string KorisnickoImeObavezno = "Korisnicko Ime je obavezno polje.";
        public const string LozinkaObavezna = "Lozinka je obavezno polje.";
        public const string LozinkeRazlicite = "Unesene lozinke se ne podudaraju";
        public const string KorisnickoImePostoji = "Korisnicko ime vec postoji. Unesite drugo korisnicko ime.";
        public const string PogresnaPrijava = "Uneto je pogresno korianicko ime ili lozinka.";
    }
}
