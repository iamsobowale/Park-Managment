using ParkManagment.Entities;
using System.Collections.Generic;
using ParkManagment.DTOs;

namespace ParkManagment.Interfaces
{
    public interface IMotorService
    {
        MotorResponseModel Create(DTOs.MotorRequestModel _model);
        bool Delete(int id);
        MotorDto Get(int id);
        MotorsResponseModel GetAll();
        MotorResponseModel Update(MotorRequestModel motor, int id);
        
    }
}