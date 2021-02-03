
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
    /// Interaction logic for VolunteerList.xaml
    /// </summary>
    public partial class VolunteerList : Window
    {
        private VolunteerViewModel viewModel = new VolunteerViewModel(); 
        private ObservableCollection<Volunteer> volunteers; // ObserveableColletion for DataGrid

        public VolunteerList()
        {
            InitializeComponent();
            volunteers = viewModel.GetVolunteers(); // load to OvservableColletion list from DB
            dgVolunteers.ItemsSource = volunteers;

        }



        // Deleting 1 or more volunteers
        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            List<Volunteer> volunteersToDelete = dgVolunteers.SelectedItems.Cast<Volunteer>().ToList();
            viewModel.DeleteVolunteer(volunteersToDelete, volunteers);        

        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            var newWindow = new StartView();
            newWindow.Show();
            Close();
        }
    }
}
