using Renci.SshNet.Messages;
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
    /// Interaction logic for AdopterList.xaml
    /// </summary>
    public partial class AdopterList : Window
    {
        private AdopterViewModel viewModelAdopter = new AdopterViewModel();
        private ObservableCollection<AdopterWithAdress> adoptersWithAdress; // ObserveableColletion for DataGrid
        private ObservableCollection<AdopterWithAdress> adoptersWithAdressWithoutFilter; // ObserveableColletion for DataGrid - clean without filter
        public AdopterList()
        {
            InitializeComponent();
            adoptersWithAdress = viewModelAdopter.GetJoinData();
            adoptersWithAdressWithoutFilter = new ObservableCollection<AdopterWithAdress>(adoptersWithAdress);
            DataGridAdopters.ItemsSource = adoptersWithAdress;

            TextBoxSearch.Focus();
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            var newWindow = new StartView();
            Close();
            newWindow.Show();
        }
        // Edit selected adopter
        private void Button_Click_Edit(object sender, RoutedEventArgs e)
        {
            if (DataGridAdopters.SelectedItems.Count != 0)
            {
                var adopterToEdit = (AdopterWithAdress)DataGridAdopters.SelectedItem;
                var editWindow = new AdopterEdit(adopterToEdit, adoptersWithAdress);
                editWindow.Show();
            }
        }
        // Deleting 1 or more Adopters
        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            if (DataGridAdopters.SelectedItems.Count != 0)
            {
                List<AdopterWithAdress> adoptersToDelete = DataGridAdopters.SelectedItems.Cast<AdopterWithAdress>().ToList();
                viewModelAdopter.DeleteAdopters(adoptersToDelete, adoptersWithAdress);
                adoptersWithAdressWithoutFilter = new ObservableCollection<AdopterWithAdress>(adoptersWithAdress);
            }
        }
        // Search by surname
        private void Button_Click_Search(object sender, RoutedEventArgs e)
        {
            string searchValue = TextBoxSearch.Text;

            var _itemSourceList = new CollectionViewSource() { Source = adoptersWithAdress };
            ICollectionView FilteredItemsList = _itemSourceList.View;

            var filter = new Predicate<object>(x => ((AdopterWithAdress)x).Surname.ToLower().Contains(searchValue.ToLower()));
            FilteredItemsList.Filter = filter;
            DataGridAdopters.ItemsSource = FilteredItemsList;
        }
        // Reset filtering 
        private void Button_Click_Reset(object sender, RoutedEventArgs e)
        {
            DataGridAdopters.ItemsSource = adoptersWithAdressWithoutFilter;
        }
    }
}
