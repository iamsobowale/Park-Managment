using System.Collections.Generic;
using ParkManagment.DTOs;
using ParkManagment.DTOs.Staff;
using ParkManagment.Entities;

namespace ParkManagment.Interfaces
{
    public interface IStaffService
    {
        StaffResponseModel Create(StaffRequestModel _model);
        bool Delete(int id);
        StaffResponseModel Get(int id);
        StaffsResponseModel GetAll();
        StaffResponseModel Login(StaffRequestModel _staffRequestModel);
        StaffResponseModel Update(StaffRequestModel _staffRequestModel, int id);
    }
}