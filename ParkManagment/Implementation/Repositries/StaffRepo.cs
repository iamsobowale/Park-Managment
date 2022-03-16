using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ParkManagment.Context;
using ParkManagment.Entities;
using ParkManagment.Interfaces;


namespace ParkManagment.Implementions
{
    public class StaffRepo:IStaffRepository
    {
        private readonly ApplicationContext _context;
        public StaffRepo(ApplicationContext context)
        {
            _context = context;
        }

        public bool Create(Staff staff)
        {
            _context.Staves.Add(staff);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var delete = _context.Staves.Find(id);
            _context.Staves.Remove(delete);
            _context.SaveChanges();
            return true;
        }

        public Staff Get(int id)
        {
            var get = _context.Staves.Include(c=>c.Park).SingleOrDefault(i => i.Id==id);
            return get;
        }

        public List<Staff> GetAll()
        {
            return _context.Staves.ToList();
        }

        public Staff Update(Staff staff)
        {
            _context.Staves.Update(staff);
            _context.SaveChanges();
            return staff;
        }
        public Staff GetLogin(string firstName)
        {
            var gt = _context.Staves.SingleOrDefault(c => c.FirstName == firstName);
            return gt;
        }
    }
}