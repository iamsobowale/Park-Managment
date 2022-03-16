using System.Collections.Generic;
using ParkManagment.Entities;

namespace ParkManagment.Interfaces
{
    public interface IStaffRepository
    {
        bool Create(Staff staff);
        bool Delete(int id);
        Staff Get(int id);
        List<Staff> GetAll();
        Staff GetLogin(string firstName);
        Staff Update(Staff staff);
    }
}