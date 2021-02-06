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
    /// Interaction logic for DogList.xaml
    /// </summary>
    public partial class DogList : Window
    {
        private DogViewModel viewModel = new DogViewModel();
        private AdoptionViewModel viewModelAdoption = new AdoptionViewModel();

        private ObservableCollection<Dog> dogs; // ObserveableColletion for DataGrid
        private ObservableCollection<Dog> dogsWithoutFilter; // ObserveableColletion for DataGrid - without filtering
        public DogList()
        {
            InitializeComponent();
            dogs = viewModel.GetDogs(); // load to ObservableColletion list from DB
            dogsWithoutFilter = new ObservableCollection<Dog>(dogs); // copy ObservableColletion
            dgDogs.ItemsSource = dogs;

            TextBoxSearch.Focus();
        }

        // Deleting 1 or more Dogs
        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            if (dgDogs.SelectedItems.Count != 0)
            {
                List<Dog> dogsToDelete = dgDogs.SelectedItems.Cast<Dog>().ToList();
                viewModel.DeleteDogs(dogsToDelete, dogs);
                dogsWithoutFilter = new ObservableCollection<Dog>(dogs);
            }
        }
        // Editing Dog
        private void Button_Click_Edit(object sender, RoutedEventArgs e)
        {
            if (dgDogs.SelectedItems.Count != 0)
            {
                var dogToEdit = (Dog)dgDogs.SelectedItem;
                var editWindow = new DogEdit(dogToEdit, dogs);
                editWindow.Show();
            }
        }
        // Search by name dog
        private void Button_Click_Search(object sender, RoutedEventArgs e)
        {
            string searchValue = TextBoxSearch.Text;

            var _itemSourceList = new CollectionViewSource() { Source = dogs };
            ICollectionView FilteredItemsList = _itemSourceList.View;

            var filter = new Predicate<object>(x => ((Dog)x).ChipNumber.ToLower().Contains(searchValue.ToLower()));
            FilteredItemsList.Filter = filter;
            dgDogs.ItemsSource = FilteredItemsList;
        }
        // Reset filtering 
        private void Button_Click_Reset(object sender, RoutedEventArgs e)
        {
            dgDogs.ItemsSource = dogsWithoutFilter;
        }
        // Back to Main Window
        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            var newWindow = new StartView();
            newWindow.Show();
            Close();
        }

        private void MouseDoubleClickEvent(object sender, MouseButtonEventArgs e)
        {           
            var newWindow = new DogDetails((Dog)dgDogs.SelectedItem);
            newWindow.Show();
        }
    }
}
