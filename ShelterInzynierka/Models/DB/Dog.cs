using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ShelterInzynierka.Models.DB
{
    public partial class Dog : INotifyPropertyChanged
    {
        public Dog()
        {
            Adoption = new HashSet<Adoption>();
            Dogcolor = new HashSet<Dogcolor>();
        }

        public int IdDog { get; set; }
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
        private DateTime? bornDate;
        public DateTime? BornDate
        {
            get { return bornDate; }
            set
            {
                bornDate = value;
                OnPropertyChanged();
            }
        }
        private Double weight;
        public Double Weight
        {
            get { return weight; }
            set
            {
                weight = value;
                OnPropertyChanged();
            }
        }
        private int height;
        public int Height
        {
            get { return height; }
            set
            {
                height = value;
                OnPropertyChanged();
            }
        }
        private bool? haveCastration;
        public bool? HaveCastration
        {
            get { return haveCastration; }
            set
            {
                haveCastration = value;
                OnPropertyChanged();
            }
        }
        private int idKidsAttitude;
        public int IdKidsAttitude
        {
            get { return idKidsAttitude; }
            set
            {
                idKidsAttitude = value;
                OnPropertyChanged();
            }
        }
        private int idCatsAttitude;
        public int IdCatsAttitude
        {
            get { return idCatsAttitude; }
            set
            {
                idCatsAttitude = value;
                OnPropertyChanged();
            }
        }
        private int idDogsAttitude;
        public int IdDogsAttitude
        {
            get { return idDogsAttitude; }
            set
            {
                idDogsAttitude = value;
                OnPropertyChanged();
            }
        }
        private string sex;
        public string Sex
        {
            get { return sex; }
            set
            {
                sex = value;
                OnPropertyChanged();
            }
        }
        private string description;
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged();
            }
        }
        private DateTime joinDate;
        public DateTime JoinDate
        {
            get { return joinDate; }
            set
            {
                joinDate = value;
                OnPropertyChanged();
            }
        }
        private DateTime leaveDate;
        public DateTime LeaveDate
        {
            get { return leaveDate; }
            set
            {
                leaveDate = value;
                OnPropertyChanged();
            }
        }

        public virtual Catsattitude IdCatsAttitudeNavigation { get; set; }
        public virtual Dogsattitude IdDogsAttitudeNavigation { get; set; }
        public virtual Kidsattitude IdKidsAttitudeNavigation { get; set; }
        public virtual ICollection<Adoption> Adoption { get; set; }
        public virtual ICollection<Dogcolor> Dogcolor { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
