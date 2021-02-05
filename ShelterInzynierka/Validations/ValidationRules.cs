using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ShelterInzynierka.Validations
{
    public class ValidationRules
    {
        static public Boolean isSelectedDataGrid (DataGrid dataGrid)
        {
            if(dataGrid.SelectedItems.Count == 1)
            {
                return true;
            }
            return false;
        }
        static public Boolean isNull (String property) 
        {
            if (String.IsNullOrWhiteSpace(property))
            {
                return true;
            }
            return false;
        }

        static public Boolean isLetters (String property)
        {
            if(property.All(char.IsLetter))
            {
                return true;
            }
            return false;
        }
        static public Boolean isLettersOrDigitOrSlash(String property)
        {
            if (property.All(x => (isCharSlashOrIsLetterOrIsDigit(x))))
            {
                return true;
            }
            return false;
        }
        static Boolean isCharSlashOrIsLetterOrIsDigit (char c)
        {
            if (c == '/' || char.IsLetterOrDigit(c))
                return true;
            else
                return false;
            
        }
        static public Boolean isNumberWithoutZero (String property)
        {
            if (property.All(char.IsDigit))
            {
                if (property.Length == 1)
                {
                    int number = Int32.Parse(property);
                    if (number == 0)
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
        static public Boolean isOverMaxNumber (String property, int maxNumber)
        {
            int number = Int32.Parse(property);
            if ( number <= maxNumber)
            {
                return true;
            }
            return false;
        }
        static public Boolean isOverMaxLengthOrEqual(String property, int maxLenght) 
        {
            if (property.Length > maxLenght)
            {
                return true;
            }
            return false;
        }
        static public Boolean isOverMinLengthOrEqual(String property, int minLenght)
        {
            if (property.Length >= minLenght)
            {
                return true;
            }
            return false;
        }
        static public Boolean isExactLength(String property, int exactLenght)
        {
            if (property.Length == exactLenght)
            {
                return true;
            }
            return false;
        }
    }
}
