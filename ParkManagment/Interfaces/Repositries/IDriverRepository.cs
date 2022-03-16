using System.Collections.Generic;
using ParkManagment.Entities;


namespace ParkManagment.Interfaces
{
    public interface IDriverRepository
    {
        Driver Create(Driver driver);
        bool Delete(int id);
        Driver Get(int id);
        List<Driver> GetAll();
        Driver Update(Driver driver);
        Driver GetLogin(string firstName);
        IList<Motor> GetCarsByDriver(int id);
    }
}