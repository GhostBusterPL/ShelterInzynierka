
using ShelterInzynierka.Models.DB;
using ShelterInzynierka.ViewModels;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for StartView.xaml
    /// </summary>
    public partial class StartView : Window
    {
        private StartViewModel startViewModel = new StartViewModel();
        private DogViewModel dogViewModel = new DogViewModel();
        public StartView()
        {
            if (startViewModel.CheckConnection() == false)
            {
                Close();
            }
            else {
                InitializeComponent();

                // Set information to dashboard's controls
                LabelAllAvailableDogsNumber.Content = dogViewModel.GetDogsWithoutLeaveDate().Count.ToString();
                LabelAllAvailableMenNumber.Content = dogViewModel.GetMenDogsWithoutLeaveDate().Count.ToString();
                LabelAllAvailableWomenNumber.Content = dogViewModel.GetWomenDogsWithoutLeaveDate().Count.ToString();
                LabelAdoptionsInLast30DaysNumber.Content = dogViewModel.GetDogsFromThirtyDaysInShelter().Count.ToString();
                dgDogs.ItemsSource = dogViewModel.GetSixLastDogsInShelter();
            }
        }

        private void Button_Click_Add_Adoption(object sender, RoutedEventArgs e)
        {
            var newWindow = new AdoptionAdd();
            newWindow.Show();
            Close();
        }

        private void Button_Click_View_Adoptions(object sender, RoutedEventArgs e)
        {
            var newWindow = new AdoptionList();
            newWindow.Show();
            Close();
        }

        private void Button_Click_Add_Volunteer(object sender, RoutedEventArgs e)
        {
            var newWindow = new VolunteerAdd();
            newWindow.Show();
            Close();
        }

        private void Button_Click_View_Volunteers(object sender, RoutedEventArgs e)
        {
            var newWindow = new VolunteerList();
            newWindow.Show();
            Close();
        }


        private void Button_Click_Add_Dog(object sender, RoutedEventArgs e)
        {
            var newWindow = new DogAdd();
            newWindow.Show();
            Close();
        }

        private void Button_Click_View_Dogs(object sender, RoutedEventArgs e)
        {
            var newWindow = new DogList();
            newWindow.Show();
            Close();
        }

        private void Button_Click_Add_Adopter(object sender, RoutedEventArgs e)
        {
            var newWindow = new AdopterAdd();
            newWindow.Show();
            Close();
        }

        private void Button_Click_View_Adopters(object sender, RoutedEventArgs e)
        {
            var newWindow = new AdopterList();
            newWindow.Show();
            Close();
        }
        private void MouseDoubleClickEvent(object sender, MouseButtonEventArgs e)
        {
            var newWindow = new DogDetails((Dog)dgDogs.SelectedItem);
            newWindow.Show();
        }
        private void Menu_Click_Exit (object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
