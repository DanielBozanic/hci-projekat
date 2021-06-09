using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace OrganizatorProslava.UI.Korisnici
{
    class ObavezanUnosPodataka : ValidationRule
    {
        public int MinimumKaraktera { get; set; }


        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string uneseniTekst = value as string;

            if (uneseniTekst.Length < MinimumKaraktera)
                return new ValidationResult(false, $"Obavezan unos polja.");

            return new ValidationResult(true, null);
        }
    }
}
