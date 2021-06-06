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
    class VremenskiOpsegTrajanja : ValidationRule
    {
        
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string unesenoTrajanje = (string) value;

            Regex r = new Regex("[0-9]+");

            if (!r.IsMatch(unesenoTrajanje))
            {
                return new ValidationResult(false, $"Unesite broj sati trajanja");
            }

            int unesenoTrajanjeInt = Int32.Parse(unesenoTrajanje);

           if(unesenoTrajanjeInt<1 || unesenoTrajanjeInt > 72)
            {
                return new ValidationResult(false, $"Broj sati u intervalu od 1 do 72");
            }


            return new ValidationResult(true, null);
        }
    }
}
