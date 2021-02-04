using ShelterInzynierka.Models.DB;
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
        private ObservableCollection<Dog> dogs; // ObserveableColletion for DataGrid
        public DogList()
        {
            InitializeComponent();
            dogs = viewModel.GetDogs(); // load to OvservableColletion list from DB
            dgDogs.ItemsSource = dogs;
        }

        // Deleting 1 or more Dogs
        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            List<Dog> dogsToDelete = dgDogs.SelectedItems.Cast<Dog>().ToList();
            viewModel.DeleteDogs(dogsToDelete, dogs);
        }

        private void Button_Click_Edit(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            var newWindow = new StartView();
            Close();
            newWindow.Show();
        }
    }
}
