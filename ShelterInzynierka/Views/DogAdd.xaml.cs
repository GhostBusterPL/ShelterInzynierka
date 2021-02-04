using ShelterInzynierka.Validations;
using ShelterInzynierka.ViewModels;
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
    /// Interaction logic for DogAdd.xaml
    /// </summary>
    public partial class DogAdd : Window
    {
        private DogViewModel viewModel = new DogViewModel();
        public DogAdd()
        {
            InitializeComponent();
            // Binding ComboBoxes with Attutudes from ViewModel
            ComboBoxDogs.ItemsSource = viewModel.GetAttitudesDogs();
            ComboBoxDogs.DisplayMemberPath = "Name"; 
            ComboBoxCats.ItemsSource = viewModel.GetAttitudesCats();
            ComboBoxCats.DisplayMemberPath = "Name";
            ComboBoxKids.ItemsSource = viewModel.GetAttitudesKids();
            ComboBoxKids.DisplayMemberPath = "Name";
        }

        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            // from TextBox to validate
            string name = TextBoxName.Text;
            string chipNumber = TextBoxChipNumber.Text;

            Boolean flagName = nameValidation(name);
            Boolean flagChipNumber = chipNumberValidation(chipNumber);

            if (flagName == true && flagChipNumber == true)
            {

            }
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            var newWindow = new StartView();
            Close();
            newWindow.Show();
        }

        // Name Validation
        private Boolean nameValidation(string name)
        {
            if (ValidationRules.isNull(name))
            {
                ErrorName.Content = "Imię jest wymagane!";
            }
            else
            {
                if (!ValidationRules.isLetters(name))
                {
                    ErrorName.Content = "Imię składa się tylko z Dużych i małych liter.";
                }
                else
                {
                    if (ValidationRules.isOverMaxLengthOrEqual(name, 16))
                    {
                        ErrorName.Content = "Imię może mieć maksymalnie 16 liter.";
                    }
                    else
                    {
                        ErrorName.Content = "";
                        return true;
                    }
                }
            }
            return false;
        }

        // Chip Number Validation
        private Boolean chipNumberValidation(string name)
        {
            if (ValidationRules.isNull(name))
            {
                ErrorChipNumber.Content = "Numer chipu jest wymagany!";
            }
            else
            {
                if (!ValidationRules.isExactLength(name, 15))
                {
                    ErrorChipNumber.Content = "Chip musi mieć 15 cyfr.";
                }
                else
                {
                    if (!ValidationRules.isNumberWithoutZero(name))
                    {
                        ErrorChipNumber.Content = "Numer chipu składa się tylko z cyfr naturalnych.";
                    } else
                    {
                        ErrorChipNumber.Content = "";
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
