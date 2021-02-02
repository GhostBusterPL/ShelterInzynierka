using System;
using System.Collections.Generic;

namespace ShelterInzynierka.Models.DB
{
    public partial class Dogcolor
    {
        public int IdDogColor { get; set; }
        public int IdDog { get; set; }
        public int IdColor { get; set; }

        public virtual Color IdColorNavigation { get; set; }
        public virtual Dog IdDogNavigation { get; set; }
    }
}
