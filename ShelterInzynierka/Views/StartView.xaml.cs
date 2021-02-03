using ShelterInzynierka.Models.DB;
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
        public StartView()
        {
            InitializeComponent();
        }

        private void Button_Click_Add_Adoption(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_View_Adoptions(object sender, RoutedEventArgs e)
        {

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
    }
}
