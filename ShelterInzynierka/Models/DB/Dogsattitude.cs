using System;
using System.Collections.Generic;

namespace ShelterInzynierka.Models.DB
{
    public partial class Dogsattitude
    {
        public Dogsattitude()
        {
            Dog = new HashSet<Dog>();
        }

        public int IdDogsAttitude { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Dog> Dog { get; set; }
    }
}
