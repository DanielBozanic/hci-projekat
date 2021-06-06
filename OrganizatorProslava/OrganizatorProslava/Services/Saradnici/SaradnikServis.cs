using System.Collections.Generic;
using System.Linq;

namespace OrganizatorProslava.Services.Saradnici
{
    public class SaradnikServis
    {
        public List<Models.Saradnik> GetSaradnici()
        {
            var saradnikDal = new DataAccess.Saradnici.Saradnik();
            return saradnikDal.GetSaradnike().ToList()
                .Select(s => new Models.Saradnik
                {
                    Id = s.Saradnik.ID,
                    Naziv = s.Saradnik.Naziv,
                    Adresa = s.Saradnik.Adresa,
                    Email = s.Saradnik.Email,
                    TipSaradnikaId = s.Saradnik.TipSaradnikaID,
                    TipSaradnika = s.TipSaradnika.Naziv
                }).ToList();
        }

        public Models.Saradnik GetSaradnikaPoID(int id)
        {
            var saradnikDal = new DataAccess.Saradnici.Saradnik();
            return saradnikDal.GetSaradnike().ToList().Where(s => s.Saradnik.ID == id)
                .Select(s => new Models.Saradnik
                {
                    Id = s.Saradnik.ID,
                    Naziv = s.Saradnik.Naziv,
                    Adresa = s.Saradnik.Adresa,
                    Email = s.Saradnik.Email,
                    TipSaradnikaId = s.Saradnik.TipSaradnikaID,
                    TipSaradnika = s.TipSaradnika.Naziv
                }).ToList().FirstOrDefault();
        }

        public string BrisiSaradnika(int id)
        {
            var saradnikDal = new DataAccess.Saradnici.Saradnik();
            var saradnik = saradnikDal.GetSaradnika(id);
            if (saradnik != null)
                saradnikDal.ObrisiSaradnika(saradnik);
            else
                return $"{Poruke.NijeNadjenSaradnik}{id}";

            return string.Empty;
        }

        public int DodajSaradnika(Models.Saradnik saradnik)
        {
            var saradnikDal = new DataAccess.Saradnici.Saradnik();
            return saradnikDal.DodajSaradnika(new DataModel.Saradnik
            {
                Naziv = saradnik.Naziv,
                TipSaradnikaID = saradnik.TipSaradnikaId,
                Adresa = saradnik.Adresa,
                Email = saradnik.Email
            });
        }

        public string IzmeniSaradnika(Models.Saradnik saradnikModel)
        {
            var saradnikDal = new DataAccess.Saradnici.Saradnik();
            var saradnik = saradnikDal.GetSaradnika(saradnikModel.Id);
            if (saradnik != null)
            {
                saradnik.Naziv = saradnikModel.Naziv;
                saradnik.Adresa = saradnikModel.Adresa;
                saradnik.Email = saradnikModel.Email;

                saradnikDal.SaveChanges();

                return string.Empty;
            }
            else
            {
                return $"{Poruke.NijeNadjenSaradnik}{saradnikModel.Id}";
            }
        }
    }
}
