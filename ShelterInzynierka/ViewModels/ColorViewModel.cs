using ShelterInzynierka.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterInzynierka.ViewModels
{
    class ColorViewModel
    {
        private inzContext _context = new inzContext();
        
        public List<Color> GetColors () 
        {
            return _context.Color.ToList();
        }
    }
}
