using ShelterInzynierka.Models.DB;
using ShelterInzynierka.Validations;
using ShelterInzynierka.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Xceed.Wpf.Toolkit;
using RadioButton = System.Windows.Controls.RadioButton;

namespace ShelterInzynierka.Views
{
    /// <summary>
    /// Interaction logic for DogEdit.xaml
    /// </summary>
    public partial class DogEdit : Window
    {
        private DogViewModel viewModel = new DogViewModel();
        private AttitudesViewModel viewModelAttitudes = new AttitudesViewModel();
        private ObservableCollection<Dog> dogs; //from List View
        private Dog dogToEdit; // selected dog from dog List

        public DogEdit(Dog dogToEdit, ObservableCollection<Dog> dogs)
        {
            InitializeComponent();
            this.dogs = dogs;
            this.dogToEdit = dogToEdit;

            // set all properties to window
            TextBoxName.Text = dogToEdit.Name;
            TextBoxChipNumber.Text = dogToEdit.ChipNumber;
            DoubleUpDownHeight.Value = dogToEdit.Height;
            DoubleUpDownWeight.Value = dogToEdit.Weight;
            CheckBoxCastration.IsChecked = dogToEdit.HaveCastration;

            // Set all colors
            ListBoxColors.ItemsSource = viewModel.GetColors(dogToEdit);
            ListBoxColors.DisplayMemberPath = "Name";

            if (dogToEdit.Sex == "K")
            {
                RadioButtonFemale.IsChecked = true;
            } else
            {
                RadioButtonMale.IsChecked = true;
            }
            // set cats combobox
            ComboBoxCats.ItemsSource = viewModelAttitudes.GetCatsattitudes();
            ComboBoxCats.SelectedItem = viewModelAttitudes.GetCatsattitudesById(dogToEdit.IdCatsAttitude);
            ComboBoxCats.DisplayMemberPath = "Name";
            // set dogs combobox
            ComboBoxDogs.ItemsSource = viewModelAttitudes.GetDogsattitudes();
            ComboBoxDogs.SelectedItem = viewModelAttitudes.GetDogsattitudesById(dogToEdit.IdDogsAttitude);
            ComboBoxDogs.DisplayMemberPath = "Name";
            // set kidscombobox
            ComboBoxKids.ItemsSource = viewModelAttitudes.GetKidsattitudes();
            ComboBoxKids.SelectedItem = viewModelAttitudes.GetKidsattitudesById(dogToEdit.IdKidsAttitude);
            ComboBoxKids.DisplayMemberPath = "Name";

            DatePickerBornDate.Value = dogToEdit.BornDate;
            TextBoxDescription.Text = dogToEdit.Description;
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
                // Setting SEX 
                var whichSex = radioButtonsPanel.Children.OfType<RadioButton>()
                 .FirstOrDefault(r => r.IsChecked.HasValue && r.IsChecked.Value);
                if (whichSex == RadioButtonMale)
                    dogToEdit.Sex = "M";
                else
                    dogToEdit.Sex = "K";

                // Setting BornDate, JoinDate, LeaveDate
                dogToEdit.BornDate = DatePickerBornDate.Value;
                dogToEdit.JoinDate = DateTime.Today;

                // Setting Name, ChipNumber, Description
                dogToEdit.Name = TextBoxName.Text;
                dogToEdit.ChipNumber = TextBoxChipNumber.Text;
                dogToEdit.Description = TextBoxDescription.Text;

                // Setting 3x Attitudes
                Catsattitude catsattitude = (Catsattitude)ComboBoxCats.SelectedItem;
                dogToEdit.IdCatsAttitude = catsattitude.IdCatsAttitude;
                Dogsattitude dogssattitude = (Dogsattitude)ComboBoxDogs.SelectedItem;
                dogToEdit.IdDogsAttitude = dogssattitude.IdDogsAttitude;
                Kidsattitude kidsattitude = (Kidsattitude)ComboBoxKids.SelectedItem;
                dogToEdit.IdKidsAttitude = kidsattitude.IdKidsAttitude;

                // Setting Weight and Height
                dogToEdit.Weight = (Double)DoubleUpDownWeight.Value;
                dogToEdit.Height = (int)DoubleUpDownHeight.Value;

                // Setting Have Castration
                dogToEdit.HaveCastration = CheckBoxCastration.IsChecked;

                // pass to viewmodel
                viewModel.EditNewDog(dogToEdit, dogs);
                Close();
            }
        }
        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            Close();
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
                    }
                    else
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
