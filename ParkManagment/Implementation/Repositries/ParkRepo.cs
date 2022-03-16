using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ParkManagment.Context;
using ParkManagment.Entities;
using ParkManagment.Interfaces;
namespace ParkManagment.Implemention.Repositries
{
    public class ParkRepo:IParkRepository
    {
        private ApplicationContext _context;
        public ParkRepo(ApplicationContext context)
        {
            _context = context;
        }

        public bool Create(Park park)
        {
            _context.Parks.Add(park);
            _context.SaveChanges();
            return true;
        }

        public bool DeletePark(int id)
        {
            var delete = _context.Parks.Find(id);
            _context.Parks.Remove(delete);
            _context.SaveChanges();
            return true;
        }

        public Park Get(int id)
        {
            var get = _context.Parks.Find(id);
            return get;
        }

        public List<Park> GetAll()
        {
            return _context.Parks.ToList();
        }

        public Park Update(Park park)
        {
            _context.Parks.Update(park);
            _context.SaveChanges();
            return park;
        }
    }
}