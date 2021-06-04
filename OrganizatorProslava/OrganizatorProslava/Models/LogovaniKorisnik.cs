namespace OrganizatorProslava.Models
{
    public static class LogovaniKorisnik
    {
        public static int Id { get; set; }
        public static string PunoIme { get; set; }
        public static int Tip { get; set; }
        public static string KorisnickoIme { get; set; }
        public static string Lozinka { get; set; }


        public static void Reset()
        {
            Id = 0;
            PunoIme = string.Empty;
            Tip = 0;
        }
    }
}
