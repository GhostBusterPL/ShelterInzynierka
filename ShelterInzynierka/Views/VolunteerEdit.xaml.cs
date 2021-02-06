using ShelterInzynierka.Models.DB;
using ShelterInzynierka.Validations;
using ShelterInzynierka.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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


namespace ShelterInzynierka.Views
{
    /// <summary>
    /// Interaction logic for VolunteerEdit.xaml
    /// </summary>
    public partial class VolunteerEdit : Window, INotifyPropertyChanged
    {
        VolunteerViewModel viewModel = new VolunteerViewModel();
        private Volunteer volunteerToEdit;
        private ObservableCollection<Volunteer> volunteers; //from List View


        public event PropertyChangedEventHandler PropertyChanged;

        public VolunteerEdit(Volunteer volunteerToEdit, ObservableCollection<Volunteer> volunteers)
        {
            InitializeComponent();
            this.volunteerToEdit = volunteerToEdit;
            this.volunteers = volunteers;

            // set properties in edit view with existing properties 
            TextBoxName.Text = volunteerToEdit.Name;
            TextBoxSurname.Text = volunteerToEdit.Surname;
            TextBoxPhone.Text = volunteerToEdit.PhoneNumber;
        }

        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            // Validate
            string name = TextBoxName.Text;
            string surname = TextBoxSurname.Text;
            string phoneNumber = TextBoxPhone.Text;


            // flags to check if we have all true to add Volunteer
            Boolean nameFlag = nameValidation(name);
            Boolean surnameFlag = surnameValidation(surname);
            Boolean phoneNumberFlag = phoneNumberValidation(phoneNumber);

            // if 3 validation methods are TRUE, pass Volunteer to ViewModel
            if (nameFlag == true &&
                surnameFlag == true &&
                phoneNumberFlag == true)
            {
                // set fields for new Volunteer

                volunteerToEdit.Name = name;
                volunteerToEdit.Surname = surname;
                volunteerToEdit.PhoneNumber = phoneNumber;
                // pass to view model
                viewModel.EditVolunteer(volunteerToEdit, volunteers);
                Close();
            }

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
                    if (ValidationRules.isOverMaxLengthOrEqual(name, 32))
                    {
                        ErrorName.Content = "Imię może mieć maksymalnie 32 litery.";
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
        // Surname Validation
        private Boolean surnameValidation(string surname)
        {
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
                    if (ValidationRules.isOverMaxLengthOrEqual(surname, 32))
                    {
                        ErrorSurname.Content = "Nazwisko może mieć maksymalnie 64 litery.";
                    }
                    else
                    {
                        ErrorSurname.Content = "";
                        return true;
                    }
                }
            }
            return false;
        }
        // Phone Number Validation
        private Boolean phoneNumberValidation(string phoneNumber)
        {
            if (ValidationRules.isNull(phoneNumber))
            {
                ErrorPhoneNumber.Content = "Numer telefonu jest wymagany!";
            }
            else
            {
                if (!ValidationRules.isNumberWithoutZero(phoneNumber))
                {
                    ErrorPhoneNumber.Content = "Numer telefonu składa się tylko z cyfr naturalnych.";
                }
                else
                {
                    if (ValidationRules.isOverMaxLengthOrEqual(phoneNumber, 15))
                    {
                        ErrorPhoneNumber.Content = "Maksymalna liczba cyfr w numerze: 15.";
                    }
                    else
                    {
                        if (!ValidationRules.isOverMinLengthOrEqual(phoneNumber, 8))
                        {
                            ErrorPhoneNumber.Content = "Minimalna liczba cyfr w numerze: 8.";
                        }
                        else
                        {
                            ErrorPhoneNumber.Content = "";
                            return true;
                        }

                    }
                }
            }
            return false;
        }

    private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
