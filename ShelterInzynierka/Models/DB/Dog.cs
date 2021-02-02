using System;
using System.Collections.Generic;

namespace ShelterInzynierka.Models.DB
{
    public partial class Dog
    {
        public Dog()
        {
            Adoption = new HashSet<Adoption>();
            Dogcolor = new HashSet<Dogcolor>();
        }

        public int IdDog { get; set; }
        public string ChipNumber { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public bool? HaveCastration { get; set; }
        public int IdKidsAttitude { get; set; }
        public int IdCatsAttitude { get; set; }
        public int IdDogsAttitude { get; set; }
        public string Sex { get; set; }
        public string Description { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime LeaveDate { get; set; }

        public virtual Catsattitude IdCatsAttitudeNavigation { get; set; }
        public virtual Dogsattitude IdDogsAttitudeNavigation { get; set; }
        public virtual Kidsattitude IdKidsAttitudeNavigation { get; set; }
        public virtual ICollection<Adoption> Adoption { get; set; }
        public virtual ICollection<Dogcolor> Dogcolor { get; set; }
    }
}
