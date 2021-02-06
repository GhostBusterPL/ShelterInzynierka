using ShelterInzynierka.Models.DB;
using ShelterInzynierka.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
    /// Interaction logic for DogDetails.xaml
    /// </summary>
    public partial class DogDetails : Window
    {
        DogViewModel viewModelDog = new DogViewModel();
        AttitudesViewModel viewModelAttitudes = new AttitudesViewModel();
        public DogDetails(Dog dog)
        {
            InitializeComponent();

            IList<Models.DB.Color> dogColors = viewModelDog.GetColors(dog); // get colors used for dog in window
            // get all attitudes names 
            string catsAttitude = viewModelAttitudes.GetCatsattitudesById(dog.IdCatsAttitude).Name;
            string dogsAttitude = viewModelAttitudes.GetDogsattitudesById(dog.IdDogsAttitude).Name;
            string kidsAttitude = viewModelAttitudes.GetKidsattitudesById(dog.IdKidsAttitude).Name;

            // setting all info about dog to window
            LabelName.Content = dog.Name;
            LabelChipNumber.Content += " " + dog.ChipNumber;
            ListBoxColors.ItemsSource = dogColors;
            ListBoxColors.DisplayMemberPath = "Name";
            TextBoxDescription.Text = dog.Description;
            LabelCats.Content = catsAttitude;
            LabelDogs.Content = dogsAttitude;
            LabelKids.Content = kidsAttitude;
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
