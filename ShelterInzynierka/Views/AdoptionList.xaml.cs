using ShelterInzynierka.Models;
using ShelterInzynierka.Models.DB;
using ShelterInzynierka.ViewModels;
using System;
using System.Collections;
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
    /// Interaction logic for AdoptionList.xaml
    /// </summary>
    public partial class AdoptionList : Window
    {
        private ObservableCollection<AdoptionToView> adoptions; // ObserveableColletion for DataGrid
        private ObservableCollection<AdoptionToView> adoptionsWithoutFilter; // ObserveableColletion for DataGrid - without filtering

        private AdoptionViewModel adoptionViewModel = new AdoptionViewModel();
        public AdoptionList()
        {
            InitializeComponent();
            adoptions = adoptionViewModel.GetAdoptions(); // load own class model to field
            adoptionsWithoutFilter = new ObservableCollection<AdoptionToView>(adoptions); // load own class model to field - clean for search filter
            DataGridAdoptions.ItemsSource = adoptions;

            TextBoxSearch.Focus();
        }
        // Deleting 1 or more Dogs
        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            if(DataGridAdoptions.SelectedItems.Count != 0 )
            {
                List <AdoptionToView> adoptionsToDelete = DataGridAdoptions.SelectedItems.Cast<AdoptionToView>().ToList();
                adoptionViewModel.DeleteAdoptions(adoptionsToDelete, adoptions);
            }
        }
        // Editing Dog
        private void Button_Click_Edit(object sender, RoutedEventArgs e)
        {
            if (DataGridAdoptions.SelectedItems.Count != 0)
            {
                AdoptionToView adoptionToEdit = (AdoptionToView)DataGridAdoptions.SelectedItem;
                var newWindow = new AdoptionEdit(adoptionToEdit, adoptions);
                newWindow.Show();
            }
        }
        // Search by name dog
        private void Button_Click_Search(object sender, RoutedEventArgs e)
        {
            string searchValue = TextBoxSearch.Text;

            var _itemSourceList = new CollectionViewSource() { Source =  adoptions};
            ICollectionView FilteredItemsList = _itemSourceList.View;

            var filter = new Predicate<object>(x => ((AdoptionToView)x).SurnameAdopter.ToLower().Contains(searchValue.ToLower()));
            FilteredItemsList.Filter = filter;
            DataGridAdoptions.ItemsSource = FilteredItemsList;
        }
        // Reset filtering 
        private void Button_Click_Reset(object sender, RoutedEventArgs e)
        {
            DataGridAdoptions.ItemsSource = adoptionsWithoutFilter;
        }
        // Back to Main Window
        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            var newWindow = new StartView();
            Close();
            newWindow.Show();
        }
    }
}
