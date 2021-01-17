using System;
using System.Collections.Generic;

namespace ShelterInzynierka.DataAccess.DataObjects
{
    public partial class Color
    {
        public Color()
        {
            Dogcolor = new HashSet<Dogcolor>();
        }

        public int IdColor { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Dogcolor> Dogcolor { get; set; }
    }
}
