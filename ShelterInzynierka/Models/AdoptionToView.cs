using ShelterInzynierka.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ShelterInzynierka.Models
{
    public class AdoptionToView : INotifyPropertyChanged { 
    public int IdAdoption { get; set; }
    public int IdAdopter { get; set; }
    public int IdDog { get; set; }
    public DateTime Date { get; set; }
    public int IdVolunteer { get; set; }
    // Dog
    private string chipNumber;
    public string ChipNumber
    {
        get { return chipNumber; }
        set
        {
            chipNumber = value;
            OnPropertyChanged();
        }
    }
    private string nameDog;
    public string NameDog
    {
        get { return nameDog; }
        set
        {
            nameDog = value;
            OnPropertyChanged();
        }
    }
    // Volunteer
    private string nameVolunteer;
    public string NameVolunteer
    {
        get { return nameVolunteer; }
        set
        {
            nameVolunteer = value;
            OnPropertyChanged();
        }
    }
    private string surnameVolunteer;
    public string SurnameVolunteer
    {
        get { return surnameVolunteer; }
        set
        {
            surnameVolunteer = value;
            OnPropertyChanged();
        }
    }
    // Adopter
    private string nameAdopter;
    public string NameAdopter
    {
        get { return nameAdopter; }
        set
        {
            nameAdopter = value;
            OnPropertyChanged();
        }
    }
    private string surnameAdopter;
    public string SurnameAdopter
    {
        get { return surnameAdopter; }
        set
        {
            surnameAdopter = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
}