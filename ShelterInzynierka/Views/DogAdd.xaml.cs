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
    /// Interaction logic for DogAdd.xaml
    /// </summary>
    public partial class DogAdd : Window
    {
        public DogAdd()
        {
            InitializeComponent();
        }

        private void Button_Click_Save(object sender, RoutedEventArgs e)
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
