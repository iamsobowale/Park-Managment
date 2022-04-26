using ParkManagment.Entities;
using System.Collections.Generic;
using ParkManagment.DTOs;

namespace ParkManagment.Interfaces
{
    public interface IMotorService
    {
        MotorResponseModel Create(DTOs.MotorRequestModel _model, int userId);
        bool Delete(int id);
        MotorDto Get(int id);
        MotorsResponseModel GetAll();
        MotorResponseModel Update(MotorRequestModel motor, int id);
        IList<Payment> GetPaymentByMotor (int id);
        IList<Payment> GetAllCarPaymentOfADriver(int id);


    }
}