using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace OrganizatorProslava.UI.Korisnici
{
    class ValidacijaVremena : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            Regex r = new Regex("^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$");
            string unesenoVrijeme = (string)value;

            if (!r.IsMatch(unesenoVrijeme))
            {
                return new ValidationResult(false, $"Format početka HH:MM ");
            }

            return new ValidationResult(true, null);
        }
    }
}
