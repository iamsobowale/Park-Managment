using System.Collections.Generic;
using System.Linq;
using ParkManagment.Context;
using ParkManagment.Entities;
using ParkManagment.Interfaces.Repositries;

namespace ParkManagment.Implementation.Repositries
{
    public class AdminRepo:IAdminRepository
    {
        ApplicationContext _context;

        public AdminRepo(ApplicationContext context)
        {
            _context = context;
        }

        public bool Create(Admin admin)
        {
            _context.Admins.Add(admin);
            _context.SaveChanges();
            return true;
        }

        public Admin Get(int id)
        {
            var get =_context.Admins.Find(id);
            return get;
        }

        public Admin GetLogin(string email)
        {
            var gt = _context.Admins.SingleOrDefault(c => c.Email == email);
            return gt;
        }

        public IList<Admin> GetAll()
        {
            return _context.Admins.ToList();
        }
    }
}