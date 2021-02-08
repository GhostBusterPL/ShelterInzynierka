using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using ShelterInzynierka.Models;
using ShelterInzynierka.Models.DB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace ShelterInzynierka.ViewModels
{
    public class AdoptionViewModel : INotifyPropertyChanged
    {
        // viewmodels

        private StartViewModel viewModelStart= new StartViewModel();
        private inzContext _context = new inzContext();

        // return OBCol with own model of Adoption - including Dog, Adopter and Volunteer
        public ObservableCollection<AdoptionToView> GetAdoptions ()
        {
            var queryJoinAllTables = from Adoption in _context.Adoption
                                     join Dog in _context.Dog on Adoption.IdDog equals Dog.IdDog
                                     join Volunteer in _context.Volunteer on Adoption.IdVolunteer equals Volunteer.IdVolunteer
                                     join Adopter in _context.Adopter on Adoption.IdAdopter equals Adopter.IdAdopter
                                     select new AdoptionToView {
                                         IdAdoption = Adoption.IdAdoption,
                                         IdAdopter = Adoption.IdAdopter,
                                         IdDog = Adoption.IdDog,
                                         IdVolunteer = Adoption.IdVolunteer,
                                         Date = Adoption.Date,
                                         NameDog = Dog.Name,
                                         ChipNumber = Dog.ChipNumber,
                                         NameVolunteer = Volunteer.Name,
                                         SurnameVolunteer = Volunteer.Surname,
                                         NameAdopter = Adopter.Name,
                                         SurnameAdopter = Adopter.Surname
                                      };
            return new ObservableCollection<AdoptionToView>(queryJoinAllTables);
        }
        // return Adoption by idAdoption
        public Adoption GetAdoptionById (int idAdoption)
        {
            return _context.Adoption.Where(x => x.IdAdoption == idAdoption).FirstOrDefault();
        }
        // return true if adoption with this IdAdopter already exsist in DB
        public Boolean isUsedAdopter (int idAdopter)
        {
            var listAdoptionsWithIdAdopter = _context.Adoption.Where(x => x.IdAdopter == idAdopter);
            if (listAdoptionsWithIdAdopter.Count() >= 1)
            {
                return true;
            }
            else
                return false;
        }
        // return true if adoption with this IdVolunteer already exsist in DB
        public Boolean isUsedVolunteer(int idVolunteer)
        {
            var listAdoptionsWithIdVolunteer= _context.Adoption.Where(x => x.IdVolunteer == idVolunteer);
            if (listAdoptionsWithIdVolunteer.Count() >= 1)
            {
                return true;
            }
            else
                return false;
        }
        // return true if adoption with this IdDog already exsist in DB
        public Boolean isUsedDog(int idDog)
        {
            var listAdoptionsWithIdDog = _context.Adoption.Where(x => x.IdDog == idDog);
            if (listAdoptionsWithIdDog.Count() >= 1)
            {
                return true;
            }
            else
                return false;
        }
        // Adding new Adoption
        public Boolean AddAdoption (int idDog, int idVolunteer, int idAdopter)
        {
            var newAdoption = new Adoption();

            newAdoption.IdAdopter = idAdopter;
            newAdoption.IdDog = idDog;
            newAdoption.IdVolunteer = idVolunteer;
            newAdoption.Date = DateTime.Today;
            _context.Dog.Where(x => x.IdDog == idDog).FirstOrDefault().LeaveDate = DateTime.Today;

            _context.Adoption.Add(newAdoption);
            _context.SaveChanges();
            MessageBox.Show("Pomyślnie utworzyłem adopcję w systemie.");
            return true;
        }
        // Edit adoption
        internal Boolean EditAdoption (int idAdoption, int idAdopter, int idDog, int idVolunteer,
                            AdoptionToView adoptionToEdit,
                            ObservableCollection<AdoptionToView> adoptions)
        {
            _context.Adoption.Where(x => x.IdAdoption == idAdoption).FirstOrDefault().IdAdopter = idAdopter;
            _context.Adoption.Where(x => x.IdAdoption == idAdoption).FirstOrDefault().IdDog = idDog;
            _context.Adoption.Where(x => x.IdAdoption == idAdoption).FirstOrDefault().IdVolunteer = idVolunteer;
            _context.SaveChanges();

            return true;
        }
        
        // Deleting Adoptions
        public Boolean DeleteAdoptions (List<AdoptionToView> volunteersToDelete, ObservableCollection<AdoptionToView> adoptions)
        {
            string deletedAdoptions = "";
            foreach (AdoptionToView adoption in volunteersToDelete)
            {
                deletedAdoptions += adoption.NameDog + " " + adoption.ChipNumber + "\n";
                var adopterToDelete = GetAdoptionById(adoption.IdAdoption);
                _context.Adoption.Remove(adopterToDelete);
                _context.Dog.Where(x => x.IdDog == adoption.IdDog).FirstOrDefault().LeaveDate = DateTime.MinValue; // reset adoption date 
                adoptions.Remove(adoption);
            }
            MessageBox.Show("Usunięto adopcję psów: \n" + deletedAdoptions);
            _context.SaveChanges();
            return false;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChange(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    }
}
