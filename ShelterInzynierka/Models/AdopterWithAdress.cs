using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ShelterInzynierka.Models.DB
{
    public class AdopterWithAdress : INotifyPropertyChanged
    {
        public AdopterWithAdress()
        {
            adopterWithAdress = new HashSet<AdopterWithAdress>();
        }
        public int IdAdopter { get; set; }
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
        private string street;
        public string Street
        {
            get { return street; }
            set
            {
                street = value;
                OnPropertyChanged();
            }
        }
        private string houseNumber;
        public string HouseNumber
        {
            get { return houseNumber; }
            set
            {
                houseNumber = value;
                OnPropertyChanged();
            }
        }
        public int IdAdress { get; set; }
        // Fields From Adress
        private string city;
        public string City
        {
            get { return city; }
            set
            {
                city = value;
                OnPropertyChanged();
            }
        }
        private string postCode;
        public string PostCode
        {
            get { return postCode; }
            set
            {
                postCode = value;
                OnPropertyChanged();
            }
        }
        public HashSet<AdopterWithAdress> adopterWithAdress { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }   
}
