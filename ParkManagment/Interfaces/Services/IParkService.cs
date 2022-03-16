using System.Collections.Generic;
using ParkManagment.DTOs.Park;
using ParkManagment.Entities;
using Park = ParkManagment.DTOs.Park;

namespace ParkManagment.Interfaces
{
    public interface IParkService
    {
        ParkResponseModel Create(Entities.Park park);
        bool Delete(int id);
        ParkResponseModel Get(int id);
        ParksResponseModel GetAll();
        ParkResponseModel Update(ParkResquestModel park, int id);
    }
}