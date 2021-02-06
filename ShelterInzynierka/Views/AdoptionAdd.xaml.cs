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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ShelterInzynierka.Views
{
    /// <summary>
    /// Interaction logic for AdoptionAdd.xaml
    /// </summary>
    public partial class AdoptionAdd : Window
    {
        private AdoptionViewModel viewModelAdoption = new AdoptionViewModel();
        private AdopterViewModel viewModelAdopter = new AdopterViewModel();
        private DogViewModel viewModelDog = new DogViewModel();
        private VolunteerViewModel viewModelVolunteer = new VolunteerViewModel();

        // data to 3x datagrid
        ObservableCollection<Volunteer> volunteers;
        ObservableCollection<Volunteer> volunteersWithoutFilter; // for reseting filter
        ObservableCollection<AdopterWithAdress> adopters;
        ObservableCollection<AdopterWithAdress> adoptersWithoutFilter; // for reseting filter
        ObservableCollection<Dog> dogs;
        ObservableCollection<Dog> dogsWithoutFilter; // for reseting filter

        public AdoptionAdd()
        {
            InitializeComponent();
            volunteers = viewModelVolunteer.GetVolunteers();
            dogs = viewModelDog.GetDogsWithoutLeaveDate(); // get only free dogs - without Leave Date
            adopters = viewModelAdopter.GetJoinData();

            volunteersWithoutFilter = new ObservableCollection<Volunteer>(volunteers);
            dogsWithoutFilter = new ObservableCollection<Dog>(dogs);
            adoptersWithoutFilter = new ObservableCollection<AdopterWithAdress>(adopters);

            DataGridAdopters.ItemsSource = adopters;
            DataGridDogs.ItemsSource = dogs;
            DataGridVolunteers.ItemsSource = volunteers;
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
        private void Button_Click_Create(object sender, RoutedEventArgs e)
        {
            if(DataGridAdopters.SelectedItems.Count != 0)
            {
                if (DataGridDogs.SelectedItems.Count != 0)
                {
                    if (DataGridVolunteers.SelectedItems.Count != 0)
                    {
                        viewModelAdoption.AddAdoption(
                            ((Dog)DataGridDogs.SelectedItem).IdDog,
                            ((Volunteer)DataGridVolunteers.SelectedItem).IdVolunteer,
                            ((AdopterWithAdress)DataGridAdopters.SelectedItem).IdAdopter
                            );
                        var newWindow = new StartView();
                        Close();
                        newWindow.Show();
                    }
                }
            }
        }
        // Back
        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            var newWindow = new StartView();
            Close();
            newWindow.Show();
        }
    }
}
