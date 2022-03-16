using System.Collections.Generic;
using ParkManagment.DTOs;
using ParkManagment.Entities;

namespace ParkManagment.Interfaces
{
    public interface IDriverService
    {
        DriverResponseModel Create(DriverRequestModel _model);
        bool Delete(int id);
        DriverResponseModel Get(int id);
        DriversResponseModel GetAll();
        BaseResponse Update(Driver driver, int id);
        DriverResponseModel Login(DriverRequestModel _driverRequest);
        IList<Motor> GetCarsByDriver(int id);
    }
}