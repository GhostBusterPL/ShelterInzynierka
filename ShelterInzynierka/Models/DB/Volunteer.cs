using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ShelterInzynierka.Models.DB
{
    public partial class Volunteer : INotifyPropertyChanged
    {
        public Volunteer()
        {
            Adoption = new HashSet<Adoption>();
        }

        public int IdVolunteer { get; set; }
        private string name;
        public string Name 
        {  
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
        private string surname;
        public string Surname
        {
            get { return surname; }
            set
            {
                surname = value;
                OnPropertyChanged();
            }
        }
        private string phoneNumber;
        public string PhoneNumber 
        {
            get { return phoneNumber; }
            set
            {
                phoneNumber = value;
                OnPropertyChanged();
            }
        }

        public virtual ICollection<Adoption> Adoption { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
