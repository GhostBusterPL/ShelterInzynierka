﻿using ShelterInzynierka.Models.DB;
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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ShelterInzynierka.Views
{
    /// <summary>
    /// Interaction logic for AdopterEdit.xaml
    /// </summary>
    public partial class AdopterEdit : Window
    {
        private AdopterViewModel viewmodel = new AdopterViewModel();
        private AdopterWithAdress adopterToEdit;
        private ObservableCollection<AdopterWithAdress> adoptersWithAdress;
        private ObservableCollection<Adress> addresses;
        private ObservableCollection<Adress> addressesWithoutFilter;

        public AdopterEdit(AdopterWithAdress adopterToEdit, ObservableCollection<AdopterWithAdress> adoptersWithAdress)
        {
            this.adopterToEdit = adopterToEdit;
            this.adoptersWithAdress = adoptersWithAdress;
            var getAdresses = new ObservableCollection<Adress>(viewmodel.GetAdresses());
            this.addresses = getAdresses;
            this.addressesWithoutFilter = new ObservableCollection<Adress>(addresses);
            InitializeComponent();

            TextBoxName.Text = adopterToEdit.Name;
            TextBoxSurname.Text = adopterToEdit.Surname;
            TextBoxPhone.Text = adopterToEdit.PhoneNumber;
            TextBoxStreet.Text = adopterToEdit.Street;
            TextBoxHouseNumber.Text = adopterToEdit.HouseNumber;

            DataGridCity.ItemsSource = viewmodel.GetAdresses();
            DataGridCity.SelectedItem = viewmodel.GetAdressById(adopterToEdit.IdAdress);
            DataGridCity.ScrollIntoView(DataGridCity.Items[DataGridCity.Items.Count-1]);
            DataGridCity.ScrollIntoView(DataGridCity.SelectedItem);
        }

        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            // Validate
            string name = TextBoxName.Text;
            string surname = TextBoxSurname.Text;
            string phoneNumber = TextBoxPhone.Text;
            string street = TextBoxStreet.Text;
            string houseNumber = TextBoxHouseNumber.Text;
            Adress adress = (Adress)DataGridCity.SelectedItem;

            // flags to check if we have all true to add Adopter
            Boolean nameFlag = nameValidation(name);
            Boolean surnameFlag = surnameValidation(surname);
            Boolean phoneNumberFlag = phoneNumberValidation(phoneNumber);
            Boolean streetFlag = streetValidation(street);
            Boolean houseNumberFlag = houseNumberValidation(houseNumber);
            Boolean cityFlag = cityValidation(ValidationRules.isSelectedDataGrid(DataGridCity));

            // if 5 validation methods are TRUE, pass new Adopter to ViewModel
            if (nameFlag == true &&
                surnameFlag == true &&
                phoneNumberFlag == true &&
                streetFlag == true &&
                houseNumberFlag == true &&
                cityFlag == true)
            {
                // set fields for new Adopter
                adopterToEdit.Name = name;
                adopterToEdit.Surname = surname;
                adopterToEdit.PhoneNumber = phoneNumber;
                adopterToEdit.Street = street;
                adopterToEdit.HouseNumber = houseNumber;
                adopterToEdit.IdAdress = adress.IdAdress;
                adopterToEdit.City = adress.City;
                adopterToEdit.PostCode = adress.PostCode;
                // pass to view model
                viewmodel.EditAdopter(adopterToEdit, adoptersWithAdress);
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
        // Street Validation
        private Boolean streetValidation(string street)
        {
            if (!ValidationRules.isLetters(street))
            {
                ErrorStreet.Content = "Nazwa ulicy składa się tylko z Dużych i małych liter.";
            }
            else
            {
                if (ValidationRules.isOverMaxLengthOrEqual(street, 64))
                {
                    ErrorStreet.Content = "Ulica może mieć maksymalnie 64 litery.";
                }
                else
                {
                    ErrorStreet.Content = "";
                    return true;
                }
            }
            return false;
        }
        // House Number Validation
        private Boolean houseNumberValidation(string houseNumber)
        {
            if (ValidationRules.isNull(houseNumber))
            {
                ErrorHouseNumber.Content = "Pełny numer domu jest wymagany!";
            }
            else
            {
                if (!ValidationRules.isLettersOrDigitOrSlash(houseNumber))
                {
                    ErrorHouseNumber.Content = "Numer składa się tylko z Dużych i małych liter oraz cyfr.";
                }
                else
                {
                    if (ValidationRules.isOverMaxLengthOrEqual(houseNumber, 10))
                    {
                        ErrorHouseNumber.Content = "Numer może mieć maksymalnie 10 znaków.";
                    }
                    else
                    {
                        ErrorHouseNumber.Content = "";
                        return true;
                    }
                }
            }
            return false;
        }
        private Boolean cityValidation(Boolean isCitySelected)
        {
            if (isCitySelected == false)
            {
                ErrorCitySelected.Content = "Musisz wybrać miasto.";
                return false;
            }
            return true;
        }
        // Find PostCode from TextBox
        private void Button_Click_SearchPostCode(object sender, RoutedEventArgs e)
        {
            string searchValue = WatermarkTextBoxSearch.Text;

            var _itemSourceList = new CollectionViewSource() { Source = addresses };
            ICollectionView FilteredItemsList = _itemSourceList.View;

            var filter = new Predicate<object>(x => ((Adress)x).PostCode.ToLower().Contains(searchValue.ToLower()));
            FilteredItemsList.Filter = filter;
            DataGridCity.ItemsSource = FilteredItemsList;
        }

        private void Button_Click_ResetSearchPostCode(object sender, RoutedEventArgs e)
        {
            DataGridCity.ItemsSource = addressesWithoutFilter;

        }
    }
}
