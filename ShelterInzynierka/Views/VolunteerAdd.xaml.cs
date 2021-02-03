using ShelterInzynierka.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ShelterInzynierka.Views
{
    /// <summary>
    /// Interaction logic for VolunteerAdd.xaml
    /// </summary>
    public partial class VolunteerAdd : Window
    {
        public VolunteerAdd()
        {
            InitializeComponent();
        }
        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            // Validate
            string name = TextBoxName.Text;
            string surname = TextBoxSurname.Text;
            string phoneNumber = TextBoxPhone.Text;


            #region Name Validation
            // Name
            if (ValidationRules.isNull(name))
            {
                ErrorName.Content = "Imię jest wymagane!";
            } 
            else
            {
                if(!ValidationRules.isLetters(name))
                {
                    ErrorName.Content = "Imię składa się tylko z Dużych i małych liter.";
                } 
                else
                {
                    if(ValidationRules.isOverMaxLength(name, 32))
                    {
                        ErrorName.Content = "Imię może mieć maksymalnie 32 litery.";
                    } else
                    {
                        ErrorName.Content = "";
                    }
                }
            }
            #endregion

            #region Surname Validation
            // Surname
            if (ValidationRules.isNull(surname))
            {
                ErrorSurname.Content = "Nazwisko jest wymagane!";
            }
            else
            {
                if (!ValidationRules.isLetters(surname))
                {
                    ErrorSurname.Content = "Nazwisko składa się tylko z Dużych i małych liter.";
                }
                else
                {
                    if (ValidationRules.isOverMaxLength(surname, 32))
                    {
                        ErrorSurname.Content = "Nazwisko może mieć maksymalnie 64 litery.";
                    }
                    else
                    {
                        ErrorSurname.Content = "";
                    }
                }
            }
            #endregion

            #region Phone Number Validation
            // Phone Number
            if (ValidationRules.isNull(phoneNumber))
            {
                ErrorAge.Content = "Numer telefonu jest wymagany!";
            }
            else
            {
                if (!ValidationRules.isNumberWithoutZero(phoneNumber))
                {
                    ErrorAge.Content = "Numer telefonu składa się z cyfr naturalnych.";
                }
                else
                {
                    if(ValidationRules.isOverMaxLength(phoneNumber, 15))
                    {
                        ErrorAge.Content = "Maksymalna liczba cyfr w numerze: 15.";
                    } 
                    else
                    {
                        if (!ValidationRules.isOverMinLength(phoneNumber, 8))
                        {
                            ErrorAge.Content = "Minimalna liczba cyfr w numerze: 8.";
                        }
                        else
                            ErrorAge.Content = "";
                    }
                }
            }
            #endregion


        }
        private void Button_Click_Back (object sender, RoutedEventArgs e)
        {
            var newWindow = new StartView();
            newWindow.Show();
            Close();
        }
    }
}
