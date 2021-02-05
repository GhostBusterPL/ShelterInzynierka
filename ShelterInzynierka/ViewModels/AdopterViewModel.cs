using ShelterInzynierka.Models.DB;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShelterInzynierka.ViewModels
{
    class AdopterViewModel
    {
        private inzContext _context = new inzContext();

        // return data for DataGrid - observable colletion with Table Adopter + Adress in 1 class
        public ObservableCollection<AdopterWithAdress> GetJoinData ()
        {
            var query = from Adopter in _context.Adopter
                        join Adress in _context.Adress on Adopter.IdAdress equals Adress.IdAdress
                        select new AdopterWithAdress 
                        { 
                            IdAdopter = Adopter.IdAdopter,
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

        // Deleting 1 or more Adopters
        public Boolean DeleteDog (List<AdopterWithAdress> adoptersToDelete, ObservableCollection<AdopterWithAdress> adoptersWithAdress)
        {
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
    }
}
