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
    class UnosBudzeta : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string unosBudzeta = (string)value;
            double budzet = 0;

            if (Double.TryParse(unosBudzeta, out budzet))
            {
                budzet = Double.Parse(unosBudzeta);
                if (budzet < 2000)
                {
                    return new ValidationResult(false, $"Budzet veci od 2000");
                }
                else
                {
                    return new ValidationResult(true, null);
                }

            }
            else
            {
                return new ValidationResult(false, $"Unesite brojčanu vrednost");
            }


        }
    }
}
