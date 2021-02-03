using System;
using System.Collections.Generic;

namespace ShelterInzynierka.Models.DB
{
    public partial class Volunteer
    {
        public Volunteer()
        {
            Adoption = new HashSet<Adoption>();
        }

        public int IdVolunteer { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<Adoption> Adoption { get; set; }
    }
}
