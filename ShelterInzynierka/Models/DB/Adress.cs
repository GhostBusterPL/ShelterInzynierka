using System;
using System.Collections.Generic;

namespace ShelterInzynierka.Models.DB
{
    public partial class Adress
    {
        public Adress()
        {
            Adopter = new HashSet<Adopter>();
        }

        public int IdAdress { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }

        public virtual ICollection<Adopter> Adopter { get; set; }
    }
}
