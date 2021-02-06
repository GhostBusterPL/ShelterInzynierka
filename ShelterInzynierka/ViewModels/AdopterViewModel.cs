using ShelterInzynierka.Models.DB;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;

namespace ShelterInzynierka.ViewModels
{
    class AdopterViewModel
    {
        private inzContext _context = new inzContext();

        private AdoptionViewModel viewModelAdoption = new AdoptionViewModel();
        // return data for DataGrid - observable colletion with Table Adopter + Adress in 1 class
        public ObservableCollection<AdopterWithAdress> GetJoinData ()
        {
            var query = from Adopter in _context.Adopter
                        join Adress in _context.Adress on Adopter.IdAdress equals Adress.IdAdress
                        select new AdopterWithAdress 
                        { 
                            IdAdopter = Adopter.IdAdopter,
                            IdAdress = Adopter.IdAdress,
                            Name = Adopter.Name,
                            Surname = Adopter.Surname,
                            PhoneNumber = Adopter.PhoneNumber,
                            Street = Adopter.Street,
                            HouseNumber = Adopter.HouseNumber,
                            City = Adress.City,
                            PostCode = Adress.PostCode
                        };
            ObservableCollection<AdopterWithAdress> adopterWithAdresses = new ObservableCollection<AdopterWithAdress>(query.ToList());
            return adopterWithAdresses;
        }
        // return adopter by ID from table Adopter
        public Adopter GetAdopterById (int idAdopter)
        {
            return _context.Adopter.Where(x => x.IdAdopter == idAdopter).FirstOrDefault();
        }
        // return all Adress - Cities with PostCodes
        public List<Adress> GetAdresses () 
        {
            return _context.Adress.ToList();
        }

        //return Adress by Specified ID
        public Adress GetAdressById(int idAdress)
        {
            return _context.Adress.Where(x => x.IdAdress == idAdress).FirstOrDefault();
        }

        // Deleting 1 or more Adopters
        public Boolean DeleteAdopters (List<AdopterWithAdress> adoptersToDelete, ObservableCollection<AdopterWithAdress> adoptersWithAdress)
        {
            foreach (AdopterWithAdress usedAdopter in adoptersToDelete)
            {
                if (viewModelAdoption.isUsedAdopter(usedAdopter.IdAdopter) == true)
                {
                    MessageBox.Show("Ten adoptujący:\n" + usedAdopter.Name + " " + usedAdopter.Surname +
                        "\n\nBrał już udział w adopcji.\nNajpierw usuń adopcję, jeśli chcesz usunąć tego adoptującego.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }

            if (adoptersToDelete.Count == 1)
            {
                var adopterToDelete = GetAdopterById(adoptersToDelete.FirstOrDefault().IdAdopter); // adopter to delete
                var adopterWithAdressToDelete = adoptersToDelete.OfType<AdopterWithAdress>().FirstOrDefault(); // adopterWithAdress to delete

                _context.Adopter.Remove(adopterToDelete);
                adoptersWithAdress.Remove(adopterWithAdressToDelete);
                _context.SaveChanges();
                MessageBox.Show("Usunięto osobę adoptującą:\n" + adopterToDelete.Name + " " + adopterToDelete.Surname);
            }
            else if (adoptersToDelete.Count > 1)
            {
                String deletedAdoptersNames = ""; // for storage name + surname each deleted Adopter

                foreach (AdopterWithAdress adopter in adoptersToDelete)
                {
                    var adopterToDelete = GetAdopterById(adopter.IdAdopter); // adopter to delete
                    var adopterWithAdressToDelete = adoptersWithAdress.Where(x => x.IdAdopter == adopter.IdAdopter); // adopterWithAdress to delete
                    _context.Adopter.Remove(adopterToDelete);
                    _context.SaveChanges();
                    deletedAdoptersNames += adopter.Name + " " + adopter.Surname + "\n";
                    adoptersWithAdress.Remove(adopter);

                }
                MessageBox.Show("Usunięto osoby adoptujące: \n" + deletedAdoptersNames);
            }
            return false;
        }

        internal void AddNewAdopter(Adopter newAdopter)
        {
            _context.Adopter.Add(newAdopter);
            MessageBox.Show($"Poprawnie dodałem osobe adoptującą: \n{newAdopter.Name} {newAdopter.Surname}");
            _context.SaveChanges();
        }

        internal void EditAdopter (AdopterWithAdress editAdopter, ObservableCollection<AdopterWithAdress> adoptersWithAdress)
        {
            // Find the same object in DB
            var adopterFromDb = GetAdopterById(editAdopter.IdAdopter);
            var adopterFromView = adoptersWithAdress.FirstOrDefault(x => x.IdAdopter == editAdopter.IdAdopter);

            // change properties in DB object
            adopterFromDb.Name = editAdopter.Name;
            adopterFromDb.Surname = editAdopter.Surname;
            adopterFromDb.PhoneNumber = editAdopter.PhoneNumber;
            adopterFromDb.Street = editAdopter.Street;
            adopterFromDb.HouseNumber = editAdopter.HouseNumber;
            adopterFromDb.IdAdress = editAdopter.IdAdress;

            // change properties in ObservableColletion for View
            adopterFromView.Name = editAdopter.Name;
            adopterFromView.Surname = editAdopter.Surname;
            adopterFromView.PhoneNumber = editAdopter.PhoneNumber;
            adopterFromView.Street = editAdopter.Street;
            adopterFromView.HouseNumber = editAdopter.HouseNumber;
            adopterFromView.IdAdress = editAdopter.IdAdress;
            adopterFromView.City = editAdopter.City;
            adopterFromView.PostCode = editAdopter.PostCode;


            _context.SaveChanges();
            MessageBox.Show("Pomyślnie zmieniłem dane.");
        }
    }
}
