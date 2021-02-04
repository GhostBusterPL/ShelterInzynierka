using ShelterInzynierka.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterInzynierka.ViewModels
{
    class AttitudesViewModel
    {
        private inzContext _context = new inzContext();

        public List<Catsattitude> GetCatsattitudes()
        {
            return _context.Catsattitude.ToList();
        }
        public List<Dogsattitude> GetDogsattitudes()
        {
            return _context.Dogsattitude.ToList();
        }
        public List<Kidsattitude> GetKidsattitudes()
        {
            return _context.Kidsattitude.ToList();
        }
        public Catsattitude GetCatsattitudesById(int id)
        {
            return _context.Catsattitude.FirstOrDefault(x => x.IdCatsAttitude == id);
        }
        public Dogsattitude GetDogsattitudesById(int id)
        {
            return _context.Dogsattitude.FirstOrDefault(x => x.IdDogsAttitude == id);
        }
        public Kidsattitude GetKidsattitudesById(int id)
        {
            return _context.Kidsattitude.FirstOrDefault(x => x.IdKidsAttitude == id);
        }
    }
}
