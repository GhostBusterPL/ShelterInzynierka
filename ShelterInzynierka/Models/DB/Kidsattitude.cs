using System;
using System.Collections.Generic;

namespace ShelterInzynierka.Models.DB
{
    public partial class Kidsattitude
    {
        public Kidsattitude()
        {
            Dog = new HashSet<Dog>();
        }

        public int IdKidsAttitude { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Dog> Dog { get; set; }
    }
}
