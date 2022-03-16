using System.Collections.Generic;
using ParkManagment.Entities;

namespace ParkManagment.Interfaces
{
    public interface IParkRepository
    {
        bool Create(Park park);
        bool DeletePark(int id);
        Park Get(int id);
        List<Park> GetAll();
        Park Update(Park park);
    }
}