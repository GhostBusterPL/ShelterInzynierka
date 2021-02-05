using Renci.SshNet.Messages;
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
    /// Interaction logic for AdopterList.xaml
    /// </summary>
    public partial class AdopterList : Window
    {
        private AdopterViewModel viewModelAdopter = new AdopterViewModel();
        private ObservableCollection<AdopterWithAdress> adoptersWithAdress; // ObserveableColletion for DataGrid
        public AdopterList()
        {
            InitializeComponent();
            adoptersWithAdress = viewModelAdopter.GetJoinData();
            DataGridAdopters.ItemsSource = adoptersWithAdress;

        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            var newWindow = new StartView();
            Close();
            newWindow.Show();
        }

        private void Button_Click_Edit(object sender, RoutedEventArgs e)
        {
            var adopterToEdit = (AdopterWithAdress)DataGridAdopters.SelectedItem;
            var editWindow = new AdopterEdit(adopterToEdit, adoptersWithAdress);
            editWindow.Show();
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            List<AdopterWithAdress> adoptersToDelete = DataGridAdopters.SelectedItems.Cast<AdopterWithAdress>().ToList();
            viewModelAdopter.DeleteDog(adoptersToDelete, adoptersWithAdress);
        }
    }
}
