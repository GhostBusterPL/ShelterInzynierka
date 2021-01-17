using System;
using System.Collections.Generic;

namespace ShelterInzynierka.DataAccess.DataObjects
{
    public partial class Adopter
    {
        public Adopter()
        {
            Adoption = new HashSet<Adoption>();
        }

        public int IdAdopter { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public int IdAdress { get; set; }

        public virtual Adress IdAdressNavigation { get; set; }
        public virtual ICollection<Adoption> Adoption { get; set; }
    }
}
