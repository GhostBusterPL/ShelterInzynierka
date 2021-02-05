using ShelterInzynierka.Models.DB;
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
    /// Interaction logic for AdopterEdit.xaml
    /// </summary>
    public partial class AdopterEdit : Window
    {
        AdopterWithAdress viewmodel = new AdopterWithAdress();
        private AdopterWithAdress adopterToEdit;
        private ObservableCollection<AdopterWithAdress> adoptersWithAdress;

        public AdopterEdit(AdopterWithAdress adopterToEdit, ObservableCollection<AdopterWithAdress> adoptersWithAdress)
        {
            this.adopterToEdit = adopterToEdit;
            this.adoptersWithAdress = adoptersWithAdress;
            InitializeComponent();

            TextBoxName.Text = adopterToEdit.Name;
            TextBoxSurname.Text = adopterToEdit.Surname;
            TextBoxPhone.Text = adopterToEdit.PhoneNumber;
            TextBoxStreet.Text = adopterToEdit.Street;
            TextBoxHouseNumber.Text = adopterToEdit.HouseNumber;
        }

        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
