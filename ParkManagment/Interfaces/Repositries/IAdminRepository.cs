using System.Collections.Generic;
using ParkManagment.Entities;

namespace ParkManagment.Interfaces.Repositries
{
    public interface IAdminRepository
    {
        bool Create(Admin admin);
        Admin Get(int id);
        Admin GetLogin(string email);
        IList<Admin> GetAll();
    }
}