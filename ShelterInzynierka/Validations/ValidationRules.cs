using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace ShelterInzynierka.Validations
{
    public class ValidationRules
    {
        static public Boolean isNull (String property) {
            if (String.IsNullOrWhiteSpace(property))
            {
                return true;
            }
            return false;
        }

        static public Boolean isNumber (String property)
        {
            if (property.All(char.IsDigit)) {
                return true;
            }
            return false;
        }
        static public Boolean isAgeOk (String property, int maxAge)
        {
            if(Int32.Parse(property) <= maxAge)
            {
                return true;
            }
            return false;
        }
    }
}
