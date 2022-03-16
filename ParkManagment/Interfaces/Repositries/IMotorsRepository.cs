using ParkManagment.Entities;
using System.Collections.Generic;

namespace ParkManagment.Interfaces
{
    public interface IMotorsRepository
    {
        bool Create(Motor motor);
        bool Delete(int id);
        Motor Get(int id);
        List<Motor> GetAll();
        Motor Update(Motor motor);
    }
}