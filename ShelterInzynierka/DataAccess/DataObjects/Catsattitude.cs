using System;
using System.Collections.Generic;

namespace ShelterInzynierka.DataAccess.DataObjects
{
    public partial class Catsattitude
    {
        public Catsattitude()
        {
            Dog = new HashSet<Dog>();
        }

        public int IdCatsAttitude { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Dog> Dog { get; set; }
    }
}
