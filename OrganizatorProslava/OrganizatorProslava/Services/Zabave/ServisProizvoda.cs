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



        public List<Models.Proizvod> GetProizvodeZaZabavuZaSaradnika(int id_zabave, int id_sardnika)
        {
            var proiz = new DataAccess.Zabava.ProizvodProizvod();
            var sarServis = new Saradnici.SaradnikServis();
            return proiz.GetSveProizvodeZaZabavu(id_zabave).ToList().Where(s => s.SaradnikID == id_sardnika)
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


        public bool RestoranJeDostupan(int id_zabave, int id_sardnika)
        {
            var proiz = new DataAccess.Zabava.ProizvodProizvod();
            List<DataModel.Proizvod> proizvodi = proiz.GetSveProizvodeZaZabavu(id_zabave).ToList()
                .Select(p => p).ToList();
            if (proizvodi.Count() == 0) return true;
            foreach (DataModel.Proizvod p in proizvodi)
            {
                if (p.Saradnik.TipSaradnikaID == 2 && p.SaradnikID != id_sardnika) return false;
            }
            return true;
        }


        public List<Models.Proizvod> GetProizvodeZaZabavuZaMuziku(int id_zabave)
        {
            var proiz = new DataAccess.Zabava.ProizvodProizvod();
            var sarServis = new Saradnici.SaradnikServis();
            return proiz.GetSveProizvodeZaZabavu(id_zabave).ToList().Where(p => p.Saradnik.TipSaradnikaID == 2)
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


        public void Sacuvaj(int zabavaID, List<Models.Proizvod> lista)
        {
            var bazaProizvoda = new DataAccess.Zabava.ProizvodProizvod();
            DataModel.Zabava zabavica = (new ServisZabave()).GetZabavuDataModel(zabavaID);
            List<Models.Proizvod> staraLista = GetProizvodeZaZabavu(zabavaID);
            foreach (var novi in lista)
            {
                Models.Proizvod nadjen = null;
                foreach (var stari in staraLista)
                {
                    if (novi.Id == stari.Id)
                    {
                        nadjen = stari;
                        break;
                    }
                }
                if (nadjen != null)
                {
                    staraLista.Remove(nadjen);
                    break;
                }
                DataModel.Zabava_Proizvod zaDodavanje = new DataModel.Zabava_Proizvod
                {
                    Kolicina = 1,
                    Zabava = zabavica,
                    Proizvod = bazaProizvoda.GetProizvod(novi.Id)
                };
                bazaProizvoda.DodajProizvodZaZabavu(zaDodavanje);
            }
            if (staraLista.Count() == 0)
            {
                DataModel.Zabava_Proizvod zaDodavanje = new DataModel.Zabava_Proizvod
                {
                    Kolicina = 1,
                    Zabava = zabavica,
                    Proizvod = bazaProizvoda.GetProizvodSaluPoID(lista[0].Id)
                };
                bazaProizvoda.DodajProizvodZaZabavu(zaDodavanje);
            }
            foreach (var stari in staraLista)
            {
                if (stari.Naziv.Equals("Sala")) continue;
                bazaProizvoda.DodajProizvodZaZabavu(bazaProizvoda.GetZabava_ProizvodPoID(zabavaID, stari.Id));
            }
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
