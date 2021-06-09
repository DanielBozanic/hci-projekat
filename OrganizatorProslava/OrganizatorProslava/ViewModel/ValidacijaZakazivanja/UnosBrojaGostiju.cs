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
    class UnosBrojaGostiju : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string unesenBroj = (string)value;

            Regex r = new Regex("[0-9]*"); //provjeri samo da li mogu jednocifreni

            if (!r.IsMatch(unesenBroj))
            {
                return new ValidationResult(false, $"Unesite broj gostiju");
            }


            return new ValidationResult(true, null);
        }
    }
}
