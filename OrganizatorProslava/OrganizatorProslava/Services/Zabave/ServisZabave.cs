using System.Collections.Generic;
using System.Linq;
using OrganizatorProslava.Services;


namespace OrganizatorProslava.Services.Zabave
{
    public class ServisZabave
    {
        public List<Models.Zabava> GetZabave()
        {
            var zabavaa = new DataAccess.Zabava.ZabavaZabava();
            var korServis = new Nalozi.KorisnikServis();
            return zabavaa.GetSveZabave().ToList()
                .Select(z => new Models.Zabava
                {
                    Id = z.ID,
                    Tip = z.Tip,
                    DatumProslave = z.DatumProslave,
                    Trajanje = z.Trajanje,
                    Grad = z.Grad,
                    Tema = z.Tema,
                    BrojGostiju = z.BrojGostiju,
                    TipBudzeta = z.VrstaBudzeta,
                    Budzet = z.Budzet,
                    SpisakGostiju = z.SpisakGostiju,
                    Status = z.Status,
                    DodatneZelje = z.DodatneZelje,
                    Organizator = korServis.GetKorisnikPoId(z.Organizator).FirstOrDefault(),
                    Kreator = korServis.GetKorisnikPoId(z.Kreator).FirstOrDefault()
                }).ToList();
        }

        public DataModel.Zabava GetZabavuDataModel(int id)
        {
            var zabavaa = new DataAccess.Zabava.ZabavaZabava();
            return zabavaa.GetSveZabave().ToList().Where(z => z.ID == id).FirstOrDefault();
        }

        public string IzbrisiZabavu(int id)
        {
            var zabavice = new DataAccess.Zabava.ZabavaZabava();
            var zab = zabavice.GetZabavu(id);
            if (zab != null)
                zabavice.ObrisiZabavu(zab);
            else
                return $"Nije nadjena zabava";

            return string.Empty;
        }

        public int DodajZabavu(Models.Zabava zabava)
        {
            var zabavice = new DataAccess.Zabava.ZabavaZabava();
            var korisnicii = new DataAccess.Nalozi.Korisnik();
            return zabavice.DodajZabavu(new DataModel.Zabava
            {
                ID = zabava.Id,
                Tip = zabava.Tip,
                DatumProslave = zabava.DatumProslave,
                Trajanje = zabava.Trajanje,
                Grad = zabava.Grad,
                Tema = zabava.Tema,
                BrojGostiju = zabava.BrojGostiju,
                VrstaBudzeta = zabava.TipBudzeta,
                Budzet = zabava.Budzet,
                SpisakGostiju = zabava.SpisakGostiju,
                Status = (zabava.Status.Equals(StatusZabave.Napravljena) ? 1 : (zabava.Status.Equals(StatusZabave.UProcesu)
                ? 2 : (zabava.Status.Equals(StatusZabave.Izbrisana) ? 3 : 4))),
                DodatneZelje = zabava.DodatneZelje,
                Organizator = (zabava.Organizator?.Id),
                Kreator = zabava.Kreator.Id
            });
        }

        public string IzmeniZabavu(Models.Zabava zabava)
        {
            var zabavice = new DataAccess.Zabava.ZabavaZabava();
            var zab = zabavice.GetZabavu(zabava.Id);
            if (zab != null)
            {
                zab.Tip = zabava.Tip;
                zab.Tema = zabava.Tema;
                zab.Status = (zabava.Status.Equals(StatusZabave.Napravljena) ? 1 : (zabava.Status.Equals(StatusZabave.UProcesu)
                    ? 2 : (zabava.Status.Equals(StatusZabave.Izbrisana) ? 3 : 4)));
                zab.SpisakGostiju = zabava.SpisakGostiju;
                zab.Organizator = zabava.Organizator?.Id;
                zab.DatumProslave = zabava.DatumProslave;
                zab.Trajanje = zabava.Trajanje;
                zab.Grad = zabava.Grad;
                zab.BrojGostiju = zabava.BrojGostiju;
                zab.VrstaBudzeta = zabava.TipBudzeta;
                zab.Budzet = zabava.Budzet;
                zab.DodatneZelje = zabava.DodatneZelje;

                zabavice.SaveChanges();

                return string.Empty;
            }
            else
            {
                return $"Zabava nije pronadjena";
            }
        }



        //Zahtjevi za korisnika
        public List<Models.Zabava> GetKorisnickeZahtjeveNaCekanju(int idKorisnika)
        {
            var zabavaa = new DataAccess.Zabava.ZabavaZabava();
            var korServis = new Nalozi.KorisnikServis();
            return zabavaa.GetKorisnickeZahtjeveNaCekanju(idKorisnika).ToList()
                .Select(z => new Models.Zabava
                {
                    Id = z.ID,
                    Tip = z.Tip,
                    DatumProslave = z.DatumProslave,
                    Trajanje = z.Trajanje,
                    Grad = z.Grad,
                    Tema = z.Tema,
                    BrojGostiju = z.BrojGostiju,
                    TipBudzeta = z.VrstaBudzeta,
                    Budzet = z.Budzet,
                    SpisakGostiju = z.SpisakGostiju,
                    Status = z.Status,
                    DodatneZelje = z.DodatneZelje,
                    Organizator = korServis.GetKorisnikPoId(z.Organizator).FirstOrDefault(),
                    Kreator = korServis.GetKorisnikPoId(z.Kreator).FirstOrDefault()
                }).ToList();
        }


        public List<Models.Zabava> GetOdobreneKorisnickeZahtjeve(int idKorisnika)
        {
            var zabavaa = new DataAccess.Zabava.ZabavaZabava();
            var korServis = new Nalozi.KorisnikServis();
            return zabavaa.GetOdobreneKorisnickeZahtjeve(idKorisnika).ToList()
                .Select(z => new Models.Zabava
                {
                    Id = z.ID,
                    Tip = z.Tip,
                    DatumProslave = z.DatumProslave,
                    Trajanje = z.Trajanje,
                    Grad = z.Grad,
                    Tema = z.Tema,
                    BrojGostiju = z.BrojGostiju,
                    TipBudzeta = z.VrstaBudzeta,
                    Budzet = z.Budzet,
                    SpisakGostiju = z.SpisakGostiju,
                    Status = z.Status,
                    DodatneZelje = z.DodatneZelje,
                    Organizator = korServis.GetKorisnikPoId(z.Organizator).FirstOrDefault(),
                    Kreator = korServis.GetKorisnikPoId(z.Kreator).FirstOrDefault()
                }).ToList();
        }


        public List<Models.Zabava> GetOdbijeneKorisnickeZahtjeve(int idKorisnika)
        {
            var zabavaa = new DataAccess.Zabava.ZabavaZabava();
            var korServis = new Nalozi.KorisnikServis();
            return zabavaa.GetOdbijeneKorisnickeZahtjeve(idKorisnika).ToList()
                .Select(z => new Models.Zabava
                {
                    Id = z.ID,
                    Tip = z.Tip,
                    DatumProslave = z.DatumProslave,
                    Trajanje = z.Trajanje,
                    Grad = z.Grad,
                    Tema = z.Tema,
                    BrojGostiju = z.BrojGostiju,
                    TipBudzeta = z.VrstaBudzeta,
                    Budzet = z.Budzet,
                    SpisakGostiju = z.SpisakGostiju,
                    Status = z.Status,
                    DodatneZelje = z.DodatneZelje,
                    Organizator = korServis.GetKorisnikPoId(z.Organizator).FirstOrDefault(),
                    Kreator = korServis.GetKorisnikPoId(z.Kreator).FirstOrDefault()
                }).ToList();
        }



        //NOVI KOD

        public List<Models.Zabava> GetTrenutnoOrganizovaneZabave(int idKorisnika)
        {
            var zabavaa = new DataAccess.Zabava.ZabavaZabava();
            var korServis = new Nalozi.KorisnikServis();
            var servisProizvoda = new Zabave.ServisProizvoda();
            return zabavaa.GetTrenutnoOrganizovaneZabave(idKorisnika).ToList()
                .Select(z => new Models.Zabava
                {
                    Id = z.ID,
                    Tip = z.Tip,
                    DatumProslave = z.DatumProslave,
                    Trajanje = z.Trajanje,
                    Grad = z.Grad,
                    Tema = z.Tema,
                    BrojGostiju = z.BrojGostiju,
                    TipBudzeta = z.VrstaBudzeta,
                    Budzet = z.Budzet,
                    SpisakGostiju = z.SpisakGostiju,
                    Status = z.Status,
                    DodatneZelje = z.DodatneZelje,
                    Organizator = korServis.GetKorisnikPoId(z.Organizator).FirstOrDefault(),
                    Kreator = korServis.GetKorisnikPoId(z.Kreator).FirstOrDefault(),
                    OdabraniProizvodi = servisProizvoda.GetProizvodeZaZabavu(z.ID).ToList()
                }).ToList();
        }



        public List<Models.Zabava> GetProsleZabave(int idKorisnika)
        {
            var zabavaa = new DataAccess.Zabava.ZabavaZabava();
            var korServis = new Nalozi.KorisnikServis();
            var servisProizvoda = new Zabave.ServisProizvoda();
            return zabavaa.GetProsleZabave(idKorisnika).ToList()
                .Select(z => new Models.Zabava
                {
                    Id = z.ID,
                    Tip = z.Tip,
                    DatumProslave = z.DatumProslave,
                    Trajanje = z.Trajanje,
                    Grad = z.Grad,
                    Tema = z.Tema,
                    BrojGostiju = z.BrojGostiju,
                    TipBudzeta = z.VrstaBudzeta,
                    Budzet = z.Budzet,
                    SpisakGostiju = z.SpisakGostiju,
                    Status = z.Status,
                    DodatneZelje = z.DodatneZelje,
                    Organizator = korServis.GetKorisnikPoId(z.Organizator).FirstOrDefault(),
                    Kreator = korServis.GetKorisnikPoId(z.Kreator).FirstOrDefault(),
                    OdabraniProizvodi = servisProizvoda.GetProizvodeZaZabavu(z.ID).ToList()
                }).ToList();
        }
    }
}
