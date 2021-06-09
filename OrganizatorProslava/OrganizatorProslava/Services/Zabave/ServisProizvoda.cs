using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizatorProslava.Services.Zabave
{
    public class ServisProizvoda
    {

        public List<Models.Proizvod> GetProizvode()
        {
            var proiz = new DataAccess.Zabava.ProizvodProizvod();
            var sarServis = new Saradnici.SaradnikServis();
            return proiz.GetSveProizvode().ToList()
                .Select(p => new Models.Proizvod
                {
                    Id = p.ID,
                    Naziv = p.Naziv,
                    Cena = p.Cena,
                    Opis = p.Opis,
                    LinkZaSliku = p.LinkSlike,
                    SmeDaMenja = p.SmeDaMenja,
                    Sardanik = sarServis.GetSaradnikaPoID(p.SaradnikID)
                }).ToList();
        }

        public List<Models.Proizvod> GetProizvodeZaSaradnika(int idSaradnika)
        {
            var proiz = new DataAccess.Zabava.ProizvodProizvod();
            var sarServis = new Saradnici.SaradnikServis();
            return proiz.GetProizvodeZaSaradnika(idSaradnika).ToList()
                .Select(p => new Models.Proizvod
                {
                    Id = p.ID,
                    Naziv = p.Naziv,
                    Cena = p.Cena,
                    Opis = p.Opis,
                    LinkZaSliku = p.LinkSlike,
                    SmeDaMenja = p.SmeDaMenja,
                    Sardanik = sarServis.GetSaradnikaPoID(p.SaradnikID)
                }).ToList();
        }

        public string IzbrisiProizvod(int id)
        {
            // implementirati
            return "";
        }

        public int DodajProizvod(Models.Proizvod proizvod)
        {
            var proiz = new DataAccess.Zabava.ProizvodProizvod();
            //dodati kod
            return 0;
        }

        public string IzmeniProizvod(Models.Proizvod p)
        {
            //dodati kod
            return "";
        }




        public List<Models.Proizvod> GetProizvodeZaZabavu(int id_zabave)
        {
            var proiz = new DataAccess.Zabava.ProizvodProizvod();
            var sarServis = new Saradnici.SaradnikServis();
            return proiz.GetSveProizvodeZaZabavu(id_zabave).ToList()
                .Select(p => new Models.Proizvod
                {
                    Id = p.ID,
                    Naziv = p.Naziv,
                    Cena = p.Cena,
                    Opis = p.Opis,
                    LinkZaSliku = p.LinkSlike,
                    SmeDaMenja = p.SmeDaMenja,
                    Sardanik = sarServis.GetSaradnikaPoID(p.SaradnikID)
                }).ToList();
        }

    }
}
