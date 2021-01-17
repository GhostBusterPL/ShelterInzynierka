using System;
using System.Collections.Generic;

namespace ShelterInzynierka.DataAccess.DataObjects
{
    public partial class Adoption
    {
        public int IdAdoption { get; set; }
        public int IdAdopter { get; set; }
        public int IdDog { get; set; }
        public DateTime Date { get; set; }
        public int IdVolunteer { get; set; }

        public virtual Adopter IdAdopterNavigation { get; set; }
        public virtual Dog IdDogNavigation { get; set; }
        public virtual Volunteer IdVolunteerNavigation { get; set; }
    }
}
