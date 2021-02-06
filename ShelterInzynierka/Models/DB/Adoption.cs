using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ShelterInzynierka.Models.DB
{
    public partial class Adoption : INotifyPropertyChanged
    {
        public int IdAdoption { get; set; }
        public int IdAdopter { get; set; }
        public int IdDog { get; set; }
        public DateTime Date { get; set; }
        public int IdVolunteer { get; set; }
        public virtual Adopter IdAdopterNavigation { get; set; }
        public virtual Dog IdDogNavigation { get; set; }
        public virtual Volunteer IdVolunteerNavigation { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
