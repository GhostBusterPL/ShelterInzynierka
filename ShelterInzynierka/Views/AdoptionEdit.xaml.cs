using ShelterInzynierka.Models;
using ShelterInzynierka.Models.DB;
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
    /// Interaction logic for AdoptionEdit.xaml
    /// </summary>
    public partial class AdoptionEdit : Window
    {
        private AdoptionViewModel viewModelAdoption = new AdoptionViewModel();
        private AdopterViewModel viewModelAdopter = new AdopterViewModel();
        private DogViewModel viewModelDog = new DogViewModel();
        private VolunteerViewModel viewModelVolunteer = new VolunteerViewModel();
        private AdoptionToView adoptionToEdit;
        private ObservableCollection<AdoptionToView> adoptions;

        // data to 3x datagrid
        private ObservableCollection<Volunteer> volunteers;
        private ObservableCollection<Volunteer> volunteersWithoutFilter; // for reseting filter
        private ObservableCollection<AdopterWithAdress> adopters;
        private ObservableCollection<AdopterWithAdress> adoptersWithoutFilter; // for reseting filter
        private ObservableCollection<Dog> dogs;
        private ObservableCollection<Dog> dogsWithoutFilter; // for reseting filter
        public AdoptionEdit(AdoptionToView adoptionToEdit, ObservableCollection<AdoptionToView> adoptions)
        {
            InitializeComponent();
            this.adoptionToEdit = adoptionToEdit;
            this.adoptions = adoptions;
            volunteers = viewModelVolunteer.GetVolunteers();
            dogs = viewModelDog.GetDogs();
            adopters = viewModelAdopter.GetJoinData();

            volunteersWithoutFilter = new ObservableCollection<Volunteer>(volunteers);
            dogsWithoutFilter = new ObservableCollection<Dog>(dogs);
            adoptersWithoutFilter = new ObservableCollection<AdopterWithAdress>(adopters);

            DataGridAdopters.ItemsSource = adopters;
            DataGridDogs.ItemsSource = dogs;
            DataGridVolunteers.ItemsSource = volunteers;

            DataGridAdopters.SelectedItem = adopters.Where(x => x.IdAdopter == adoptionToEdit.IdAdopter).FirstOrDefault(); ;
            DataGridDogs.SelectedItem = viewModelDog.GetDogById(adoptionToEdit.IdDog);
            DataGridVolunteers.SelectedItem = viewModelVolunteer.GetVolunteerById(adoptionToEdit.IdVolunteer);
        }
        // Search Volunteer
        private void Button_Click_SearchVolunteer(object sender, RoutedEventArgs e)
        {
            string searchValue = TextBoxSearchVolunteer.Text;

            var _itemSourceList = new CollectionViewSource() { Source = volunteers };
            ICollectionView FilteredItemsList = _itemSourceList.View;

            var filter = new Predicate<object>(x => ((Volunteer)x).Surname.ToLower().Contains(searchValue.ToLower()));
            FilteredItemsList.Filter = filter;
            DataGridVolunteers.ItemsSource = FilteredItemsList;
        }

        private void Button_Click_ResetVolunteer(object sender, RoutedEventArgs e)
        {
            DataGridVolunteers.ItemsSource = volunteersWithoutFilter;
        }
        // Search Dog
        private void Button_Click_SearchDog(object sender, RoutedEventArgs e)
        {
            string searchValue = TextBoxSearchDog.Text;

            var _itemSourceList = new CollectionViewSource() { Source = dogs };
            ICollectionView FilteredItemsList = _itemSourceList.View;

            var filter = new Predicate<object>(x => ((Dog)x).Name.ToLower().Contains(searchValue.ToLower()));
            FilteredItemsList.Filter = filter;
            DataGridDogs.ItemsSource = FilteredItemsList;
        }

        private void Button_Click_ResetDog(object sender, RoutedEventArgs e)
        {
            DataGridDogs.ItemsSource = dogsWithoutFilter;
        }
        // Search Adopter
        private void Button_Click_ResetAdopter(object sender, RoutedEventArgs e)
        {
            string searchValue = TextBoxSearchAdopter.Text;

            var _itemSourceList = new CollectionViewSource() { Source = adopters };
            ICollectionView FilteredItemsList = _itemSourceList.View;

            var filter = new Predicate<object>(x => ((Adopter)x).Surname.ToLower().Contains(searchValue.ToLower()));
            FilteredItemsList.Filter = filter;
            DataGridVolunteers.ItemsSource = FilteredItemsList;
        }

        private void Button_Click_SearchAdopter(object sender, RoutedEventArgs e)
        {
            DataGridVolunteers.ItemsSource = adoptersWithoutFilter;
        }

        // Creating new Adoption
        private void Button_Click_Edit(object sender, RoutedEventArgs e)
        {
            if (DataGridAdopters.SelectedItems.Count != 0)
            {
                if (DataGridDogs.SelectedItems.Count != 0)
                {
                    if (DataGridVolunteers.SelectedItems.Count != 0)
                    {
                        var selectedAdopter = (AdopterWithAdress)DataGridAdopters.SelectedItem;
                        var selectedDog = (Dog)DataGridDogs.SelectedItem;
                        var selectedVolunteer = (Volunteer)DataGridVolunteers.SelectedItem;
                        adoptionToEdit.NameAdopter = selectedAdopter.Name;
                        adoptionToEdit.SurnameAdopter = selectedAdopter.Surname;
                        adoptionToEdit.NameDog = selectedDog.Name;
                        adoptionToEdit.ChipNumber = selectedDog.ChipNumber;
                        adoptionToEdit.NameVolunteer = selectedVolunteer.Name;
                        adoptionToEdit.SurnameVolunteer = selectedVolunteer.Surname;

                        viewModelAdoption.EditAdoption(
                            adoptionToEdit.IdAdoption,
                            selectedAdopter.IdAdopter,
                            selectedDog.IdDog,
                            selectedVolunteer.IdVolunteer,
                            adoptionToEdit,
                            adoptions
                            );
                        Close();
                    }
                }
            }
        }
        // Back
        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
