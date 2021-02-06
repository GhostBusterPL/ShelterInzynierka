using ShelterInzynierka.Models.DB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShelterInzynierka.ViewModels
{
    class StartViewModel
    {
        private inzContext _context = new inzContext();
        public bool CheckConnection()
        {
            try
            {
                _context.Database.CanConnect();
            }
            catch (SqlException)
            {
                MessageBox.Show("Nieoczekiwany błąd podczas zapytania do bazy danych. uruchom program ponownie bądż skontaktuj się z administratorem", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            catch (Exception)
            {
                MessageBox.Show("Brak połączenia z bazą danych. Napraw swoje połączenie i uruchom ponownie.", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
    }
}
