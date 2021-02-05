using ShelterInzynierka.Models.DB;
using System;
using System.Collections;
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

        // Get all Dogs in Dog Table
        public ObservableCollection<Dog> GetDogs()
        {
            var dogs = new ObservableCollection<Dog>(_context.Dog.ToList());
            return dogs;
        }
        // Get all used Colors in table Color for specified dog 
        public IList<Models.DB.Color> GetColors(Dog dog)
        {
            var getDogColors = _context.Dogcolor.ToList().Where(x => x.IdDog == dog.IdDog);
            IList<Models.DB.Color> colorsToReturn = new List<Models.DB.Color>();
            foreach (Dogcolor dogcolor in getDogColors)
            {
                colorsToReturn.Add(_context.Color.Where(x => x.IdColor == dogcolor.IdColor).FirstOrDefault());
            }
            return colorsToReturn;
        } 
        // Get latest id in table Dog
        public int GetLatestDogId()
        {
            return _context.Dog.OrderByDescending(x => x.IdDog).FirstOrDefault().IdDog;
        }
        // Get all DogColors in table DogColor
        public IEnumerable<Dogcolor> GetDogColorsForIdDog(int dogId)
        {
            return _context.Dogcolor.ToList().Where(x => x.IdDog == dogId);
        }
        public bool DeleteDogs(List<Dog> dogsToDelete, ObservableCollection<Dog> dogs)
        {
            if (dogsToDelete.Count == 1)
            {
                var dogTodelete = dogsToDelete.OfType<Dog>().FirstOrDefault(); // dog to be deleted
                IEnumerable<Dogcolor> usedColorDog = GetDogColorsForIdDog(dogTodelete.IdDog); // records in table DogColor for deleting dog in method
                if (usedColorDog.Count() > 0)
                {
                    _context.Dogcolor.RemoveRange(usedColorDog);
                    _context.SaveChanges();
                }

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
                    IEnumerable<Dogcolor> usedColorDog = GetDogColorsForIdDog(dog.IdDog); // records in table DogColor for deleting dog in method
                    if (usedColorDog.Count() > 0)
                    {
                        _context.Dogcolor.RemoveRange(usedColorDog);
                        _context.SaveChanges();
                    }
                    _context.Dog.Remove(dog);
                    _context.SaveChanges();
                    deletedDogsNames += dog.Name + " " + dog.ChipNumber + "\n";
                    dogs.Remove(dog);

                }
                MessageBox.Show("Usunięto psy: \n" + deletedDogsNames);
            }
            return false;
        }

        internal void AddNewDog(Dog dogToAdd, IList chosenColors)
        {
            _context.Add(dogToAdd);
            _context.SaveChanges();

            int addedDogId = GetLatestDogId(); // get latest dog id after adding dog to DB
            foreach (Models.DB.Color color in chosenColors)
            {
                var newDogColor = new Dogcolor();
                newDogColor.IdColor = color.IdColor;
                newDogColor.IdDog = addedDogId;
                _context.Dogcolor.Add(newDogColor);
            }
            _context.SaveChanges();

            MessageBox.Show($"Poprawnie dodałem psa: \n{dogToAdd.Name} {dogToAdd.ChipNumber}");
        }

        internal void EditNewDog(Dog dogToEdit, ObservableCollection<Dog> dogs, IList chosenColors)
        {
            // Find the same object in DB
            var dogFromDb = _context.Dog.FirstOrDefault(x => x.IdDog == dogToEdit.IdDog);
            var dogFromView = dogs.FirstOrDefault(x => x.IdDog== dogToEdit.IdDog);

            // change properties in DB object
            dogFromDb.Name = dogToEdit.Name;
            dogFromDb.ChipNumber = dogToEdit.ChipNumber;
            dogFromDb.BornDate = dogToEdit.BornDate;
            dogFromDb.Description = dogToEdit.Description;
            dogFromDb.HaveCastration = dogToEdit.HaveCastration;
            dogFromDb.Height = dogToEdit.Height;
            dogFromDb.Weight = dogToEdit.Weight;
            dogFromDb.Sex = dogToEdit.Sex;
            dogFromDb.IdCatsAttitude = dogToEdit.IdCatsAttitude;
            dogFromDb.IdDogsAttitude = dogToEdit.IdDogsAttitude;
            dogFromDb.IdKidsAttitude = dogToEdit.IdKidsAttitude;

            // change properties in ObservableColletion for View
            dogFromView.Name = dogToEdit.Name;
            dogFromView.ChipNumber = dogToEdit.ChipNumber;
            dogFromView.BornDate = dogToEdit.BornDate;
            dogFromView.Description = dogToEdit.Description;
            dogFromView.HaveCastration = dogToEdit.HaveCastration;
            dogFromView.Height = dogToEdit.Height;
            dogFromView.Weight = dogToEdit.Weight;
            dogFromView.Sex = dogToEdit.Sex;
            dogFromView.IdCatsAttitude = dogToEdit.IdCatsAttitude;
            dogFromView.IdDogsAttitude = dogToEdit.IdDogsAttitude;
            dogFromView.IdKidsAttitude = dogToEdit.IdKidsAttitude;

            //change colors for this edit dog
            IEnumerable<Dogcolor> usedColorDog = GetDogColorsForIdDog(dogToEdit.IdDog); // which dogcolor are using by edited dog
            _context.Dogcolor.RemoveRange(usedColorDog); // remove all dogcolor in DogColor table
            _context.SaveChanges();
            foreach (Models.DB.Color color in chosenColors)
            {
                var newDogColor = new Dogcolor();
                newDogColor.IdColor = color.IdColor;
                newDogColor.IdDog = dogToEdit.IdDog;
                _context.Dogcolor.Add(newDogColor);
            }

            _context.SaveChanges();
            MessageBox.Show("Pomyślnie zmieniłem dane.");
        }
    }
}
