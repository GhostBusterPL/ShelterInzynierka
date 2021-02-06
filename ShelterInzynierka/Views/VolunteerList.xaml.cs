
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
    /// Interaction logic for VolunteerList.xaml
    /// </summary>
    public partial class VolunteerList : Window
    {
        private VolunteerViewModel viewModel = new VolunteerViewModel();
        private AdoptionViewModel viewModelAdoption = new AdoptionViewModel();

        private ObservableCollection<Volunteer> volunteers; // ObserveableColletion for DataGrid
        private ObservableCollection<Volunteer> volunteersWithoutFilter; // Save ObserveableColletion for DataGrid

        public VolunteerList()
        {
            InitializeComponent();
            volunteers = viewModel.GetVolunteers(); // load to OvservableColletion list from DB
            volunteersWithoutFilter = new ObservableCollection<Volunteer>(volunteers); // copy for reseting filtering
            dgVolunteers.ItemsSource = volunteers;

            TextBoxSearch.Focus();
        }
        private void Button_Click_Edit(object sender, RoutedEventArgs e)
        {
            if (dgVolunteers.SelectedItems.Count != 0)
            {
                var volunteerToEdit = (Volunteer)dgVolunteers.SelectedItem;
                var editWindow = new VolunteerEdit(volunteerToEdit, volunteers);
                editWindow.Show();
            }
        }
        // Deleting 1 or more volunteers
        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            if (dgVolunteers.SelectedItems.Count != 0)
            {
                List<Volunteer> volunteersToDelete = dgVolunteers.SelectedItems.Cast<Volunteer>().ToList();
                viewModel.DeleteVolunteer(volunteersToDelete, volunteers);
                volunteersWithoutFilter = new ObservableCollection<Volunteer>(volunteers);
            }
        }
        // Search by surname
        private void Button_Click_Search(object sender, RoutedEventArgs e)
        {
            string searchValue = TextBoxSearch.Text;

            var _itemSourceList = new CollectionViewSource() { Source = volunteers };
            ICollectionView FilteredItemsList = _itemSourceList.View;

            var filter = new Predicate<object>(x => ((Volunteer)x).Surname.ToLower().Contains(searchValue.ToLower()));
            FilteredItemsList.Filter = filter;
            dgVolunteers.ItemsSource = FilteredItemsList;
        }
        // Reset filtering 
        private void Button_Click_Reset(object sender, RoutedEventArgs e)
        {
            dgVolunteers.ItemsSource = volunteersWithoutFilter;
        }
        // Back to Main Window
        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            var newWindow = new StartView();
            newWindow.Show();
            Close();
        }


    }
}
