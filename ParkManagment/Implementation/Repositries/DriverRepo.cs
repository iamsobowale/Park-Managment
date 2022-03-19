using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder.Extensions;
using Microsoft.EntityFrameworkCore;
using ParkManagment.Entities;
using ParkManagment.Interfaces;
using ParkManagment.Context;
using ParkManagment.DTOs;
using ParkManagment.Interfaces;

namespace ParkManagment.Implemention.Repositries
{
    public class DriverRepo:IDriverRepository
    {
        private readonly ApplicationContext _context;
        private IDriverRepository _driverRepositoryImplementation;

        public DriverRepo(ApplicationContext context)
        {
            _context = context;
        }
        public Driver Create(Driver driver)
        {
            _context.Drivers.Add(driver);
            _context.SaveChanges();
            return driver;
        }

        public bool Delete(int id)
        {
            var delete = _context.Drivers.Find(id);
            _context.Drivers.Remove(delete);
            _context.SaveChanges();
            return true;
        }

        public Driver Get(int id)
        {
            var get = _context.Drivers.Include(c=>c.Park).SingleOrDefault(d=>d.Id==id);
            return get;
        }

        public List<Driver> GetAll()
        {
            return _context.Drivers.ToList();
        }

        public Driver Update(Driver driver)
        {
            _context.Drivers.Update(driver);
            _context.SaveChanges();
            return driver;
        }
        public Driver GetLogin(string firstName)
        {
            var gt = _context.Drivers.SingleOrDefault(c => c.FirstName == firstName);
           return gt;
        }

        public IList<Motor> GetCarsByDriver(int id)
        {
            var driver = _context.Motors.Include(x => x.Driver).Where(x => x.Driver.Id == id).ToList();
            return driver;
        }
        
    }
}