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

            Regex r = new Regex("[0-9]+"); 

            if (!r.IsMatch(unosBudzeta))
            {
                return new ValidationResult(false, $"Unesite brojčanu vrednost");
            }

            double budzet = Double.Parse(unosBudzeta);

            if(budzet < 2000)
            {
                return new ValidationResult(false, $"Budzet veci od 2000");
            }

            return new ValidationResult(true, null);
        }
    }
}
