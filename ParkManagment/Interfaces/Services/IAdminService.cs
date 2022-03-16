using ParkManagment.DTOs;
using ParkManagment.DTOs.Admin;
using ParkManagment.Entities;

namespace ParkManagment.Interfaces
{
    public interface IAdminService
    {
        AdminResponseModel Create(AdminRequestModel _adminRequest);
        AdminResponseModel Login(Admin admin);
        AdminResponseModel Get(int id);
        AdminsResponseModel GetAll();
    }
}