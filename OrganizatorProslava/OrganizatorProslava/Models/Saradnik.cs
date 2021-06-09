namespace OrganizatorProslava.Models
{
    public class Saradnik
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public int TipSaradnikaId { get; set; }
        public string Adresa { get; set; }
        public string Email { get; set; }
        public bool Obrisan { get; set; }
        public string TipSaradnika { get; set; }
    }
}
