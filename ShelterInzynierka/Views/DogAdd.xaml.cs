using ShelterInzynierka.Models.DB;
using ShelterInzynierka.Validations;
using ShelterInzynierka.ViewModels;
using System;
using System.Collections;
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
        private ColorViewModel viewModelColors = new ColorViewModel();
        private AttitudesViewModel viewModelAttitudes = new AttitudesViewModel();
        public DogAdd()
        {
            InitializeComponent();
            // Binding ComboBoxes with Attutudes from ViewModel
            ComboBoxDogs.ItemsSource = viewModelAttitudes.GetDogsattitudes();
            ComboBoxDogs.DisplayMemberPath = "Name"; 
            ComboBoxCats.ItemsSource = viewModelAttitudes.GetCatsattitudes();
            ComboBoxCats.DisplayMemberPath = "Name";
            ComboBoxKids.ItemsSource = viewModelAttitudes.GetKidsattitudes();
            ComboBoxKids.DisplayMemberPath = "Name";

            // Set all available colors
            ListBoxColors.ItemsSource = viewModelColors.GetColors();
            ListBoxColors.DisplayMemberPath = "Name";

            // Set minimum and maxiumum Date born
            DateTime maxYear = DateTime.Today.AddYears(-1);
            DatePickerBornDate.Value = maxYear;
            DatePickerBornDate.Maximum = maxYear;
            DatePickerBornDate.Minimum = DateTime.Today.AddYears(-200);
        }

        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            // from TextBox to validate
            string name = TextBoxName.Text;
            string chipNumber = TextBoxChipNumber.Text;

            // dog to add to DB
            Dog dogToAdd = new Dog();

            Boolean flagName = nameValidation(name);
            Boolean flagChipNumber = chipNumberValidation(chipNumber);

            if (flagName == true && flagChipNumber == true)
            {
                // Setting SEX 
                var whichSex = radioButtonsPanel.Children.OfType<RadioButton>()
                 .FirstOrDefault(r => r.IsChecked.HasValue && r.IsChecked.Value);
                if (whichSex == RadioButtonMale)
                    dogToAdd.Sex = "M";
                else
                    dogToAdd.Sex = "K";

                // Setting BornDate, JoinDate, LeaveDate
                dogToAdd.BornDate = DatePickerBornDate.Value;
                dogToAdd.JoinDate = DateTime.Today;

                // Setting Name, ChipNumber, Description
                dogToAdd.Name = TextBoxName.Text;
                dogToAdd.ChipNumber = TextBoxChipNumber.Text;
                dogToAdd.Description = TextBoxDescription.Text;

                // Setting 3x Attitudes
                Catsattitude catsattitude = (Catsattitude)ComboBoxCats.SelectedItem;
                dogToAdd.IdCatsAttitude = catsattitude.IdCatsAttitude;
                Dogsattitude dogssattitude = (Dogsattitude)ComboBoxDogs.SelectedItem;
                dogToAdd.IdDogsAttitude = dogssattitude.IdDogsAttitude;
                Kidsattitude kidsattitude = (Kidsattitude)ComboBoxKids.SelectedItem;
                dogToAdd.IdKidsAttitude = kidsattitude.IdKidsAttitude;

                // Setting Weight and Height
                dogToAdd.Weight = (Double)DoubleUpDownWeight.Value;
                dogToAdd.Height = (int)DoubleUpDownHeight.Value;

                // Setting Have Castration
                dogToAdd.HaveCastration = CheckBoxCastration.IsChecked;

                // COLORS - setting colors
                IList chosenColors = ListBoxColors.SelectedItems;

                // pass to viewmodel
                viewModel.AddNewDog(dogToAdd, chosenColors);

                var newWindow = new StartView(); 
                Close();
                newWindow.Show();
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
                        ErrorChipNumber.Content = "Numer chipu składa się tylko z liczb naturalnych.";
                    } else
                    {
                        if (!(viewModel.GetDogByChipNumber(name) == null))
                        {
                            ErrorChipNumber.Content = "W systemie jest już pies z tym numerem chipu.";
                        }
                        else
                        {
                            ErrorChipNumber.Content = "";
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
