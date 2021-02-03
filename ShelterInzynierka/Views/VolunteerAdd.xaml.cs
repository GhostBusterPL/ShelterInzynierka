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
            string age = TextBoxAge.Text;


            if (ValidationRules.isNull(name))
            {
                ErrorName.Content = "Imię jest wymagane!";
            } 
            else
            {
                ErrorName.Content = "";
            }

            if (ValidationRules.isNull(surname))
            {
                ErrorSurname.Content = "Nazwisko jest wymagane!";
            }
            else
            {
                ErrorSurname.Content = "";
            }

            if (ValidationRules.isNull(age))
            {
                ErrorAge.Content = "Wiek jest wymagany!";
            }
            else
            {
                if (!ValidationRules.isNumber(age))
                {
                    ErrorAge.Content = "Wiek musi być liczbą";
                }
                else
                {
                    ErrorAge.Content = "";
                }
            }





        }
        private void Button_Click_Back (object sender, RoutedEventArgs e)
        {
            var newWindow = new StartView();
            newWindow.Show();
            Close();
        }
    }
}
