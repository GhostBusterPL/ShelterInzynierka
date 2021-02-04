
using ShelterInzynierka.Models.DB;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace ShelterInzynierka.ViewModels
{
    class VolunteerViewModel : INotifyPropertyChanged
    {
        private inzContext _context = new inzContext();

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChange(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        public ObservableCollection<Volunteer> GetVolunteers()
        {
            var volunteers = new ObservableCollection<Volunteer>(_context.Volunteer.ToList());
            return volunteers;
        }

        // Method: Add new Volunteer to DB
        public void AddNewVolunteer (Volunteer newVolunteer)
        {
            _context.Add(newVolunteer);
            _context.SaveChanges();
            MessageBox.Show($"Poprawnie dodałem wolontariusza: \n{newVolunteer.Name} {newVolunteer.Surname}");
        }

        // Method: Deleting 1 or more Volonteers
        public bool DeleteVolunteer(List<Volunteer> volunteersToDelete, ObservableCollection<Volunteer> volunteers)
        {
            if (volunteersToDelete.Count == 1)
            {
                var volunteerToDelete = volunteersToDelete.OfType<Volunteer>().FirstOrDefault(); // volunteer to delete

                _context.Volunteer.Remove(volunteerToDelete);
                _context.SaveChanges();
                volunteers.Remove(volunteerToDelete);
                MessageBox.Show("Usunięto wolontariusza:\n" + volunteerToDelete.Name + " " + volunteerToDelete.Surname);
            }
            else if (volunteersToDelete.Count > 1)
            {
                String deletedVolunteersNames = ""; // for storage name + surname each deleted Volunteer

                foreach (Volunteer volunteer in volunteersToDelete)
                {
                    _context.Volunteer.Remove(volunteer);
                    _context.SaveChanges();
                    deletedVolunteersNames += volunteer.Name + " " + volunteer.Surname + "\n";
                    volunteers.Remove(volunteer);

                }
                MessageBox.Show("Usunięto wolontariuszy: \n" + deletedVolunteersNames);
            }
            return false;
        }

        internal void EditVolunteer(Volunteer newVolunteer, ObservableCollection<Volunteer> volunteers)
        {
            // Find the same object in DB
            var userFromDb = _context.Volunteer.FirstOrDefault(x => x.IdVolunteer == newVolunteer.IdVolunteer);
            var userFromView = volunteers.FirstOrDefault(x => x.IdVolunteer == newVolunteer.IdVolunteer);

            // change properties in DB object
            userFromDb.Name = newVolunteer.Name;
            userFromDb.Surname = newVolunteer.Surname;
            userFromDb.PhoneNumber = newVolunteer.PhoneNumber;

            // change properties in ObservableColletion for View
            userFromView.Name = newVolunteer.Name;
            userFromView.Surname = newVolunteer.Surname;
            userFromView.PhoneNumber = newVolunteer.PhoneNumber;

            _context.SaveChanges();
            MessageBox.Show("Pomyślnie zmieniłem dane.");
        }
    }
}
