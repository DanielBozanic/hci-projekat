using OrganizatorProslava.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizatorProslava.Models
{
    public class Korisnik
    {
        private int _tip;
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public int Tip 
        {
            get
            {
                return _tip;
            }
            
            set 
            {
                _tip = value;
                switch (_tip)
                {
                    case Services.TipKorisnika.Admin:
                        TipKorisnika = TipKorisnikaOpis.Admin;
                        break;
                    case Services.TipKorisnika.Organizator:
                        TipKorisnika = TipKorisnikaOpis.Organizator;
                        break;
                    default:
                        TipKorisnika = TipKorisnikaOpis.Klijent;
                        break;
                }
            } 
        }
        public string Pol { get; set; }
        public string Mobilni { get; set; }
        public bool Obrisan { get; set; }
        public string TipKorisnika { get; set; }
    }
}
