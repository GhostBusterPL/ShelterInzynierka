using ShelterInzynierka.Models.DB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShelterInzynierka.ViewModels
{
    class DogViewModel 
    {
        private inzContext _context = new inzContext();

        public ObservableCollection<Dog> GetDogs()
        {
            var dogs = new ObservableCollection<Dog>(_context.Dog.ToList());
            return dogs;
        }

        public List<Dogsattitude> GetAttitudesDogs() {
            List<Dogsattitude> dogsAttitudes = _context.Dogsattitude.ToList();
            return dogsAttitudes;
        }     
        public List<Catsattitude> GetAttitudesCats() {
            List<Catsattitude> catsAttitudes = _context.Catsattitude.ToList();
            return catsAttitudes;
        }        
        public List<Kidsattitude> GetAttitudesKids() {
            List<Kidsattitude> kidsAttitudes = _context.Kidsattitude.ToList();
            return kidsAttitudes;
        }
        public bool DeleteDogs(List<Dog> dogsToDelete, ObservableCollection<Dog> dogs)
        {
            if (dogsToDelete.Count == 1)
            {
                var dogTodelete = dogsToDelete.OfType<Dog>().FirstOrDefault(); // dog to be deleted

                _context.Dog.Remove(dogTodelete);
                _context.SaveChanges();
                dogs.Remove(dogTodelete);
                MessageBox.Show("Usunięto psa:\n" + dogTodelete.Name + " " + dogTodelete.ChipNumber);
            }
            else if (dogsToDelete.Count > 1)
            {
                String deletedDogsNames = ""; // for storage name + CHIP number of each dog

                foreach (Dog dog in dogsToDelete)
                {
                    _context.Dog.Remove(dog);
                    _context.SaveChanges();
                    deletedDogsNames += dog.Name + " " + dog.ChipNumber + "\n";
                    dogs.Remove(dog);

                }
                MessageBox.Show("Usunięto psy: \n" + deletedDogsNames);
            }
            return false;
        }

        internal void AddNewDog(Dog dogToAdd)
        {
            _context.Add(dogToAdd);
            _context.SaveChanges();
            MessageBox.Show($"Poprawnie dodałem psa: \n{dogToAdd.Name} {dogToAdd.ChipNumber}");
        }
    }
}
