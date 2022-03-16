using System.Linq;
using ParkManagment.DTOs;
using ParkManagment.DTOs.Admin;
using ParkManagment.Entities;
using ParkManagment.Interfaces;
using ParkManagment.Interfaces.Repositries;

namespace ParkManagment.Implementation.Services
{
    public class AdminService : IAdminService
    {
        private IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public AdminResponseModel Create(AdminRequestModel _adminRequest)
        {
            Admin admins = new Admin()
            {
                Password = _adminRequest.Password,
                Email = _adminRequest.Email
            };
            _adminRepository.Create(admins);
            return new AdminResponseModel()
            {
                Data = new AdminDto()
                {
                    Email = _adminRequest.Email,
                }
            };
        }
        public AdminResponseModel Login(Admin admin)
        {
            var get = _adminRepository.GetLogin(admin.Email);
            if (get != null && get.Password == admin.Password)
            {
                return new AdminResponseModel()
                {
                    Message = $"Found",
                    Status = true,
                    Data = new AdminDto()
                    {
                        Email = get.Email,
                        Id = get.Id,
                    }
                };
            }

            return new AdminResponseModel()
            {
                Message = $"Not Found",
                Status = false
            };
        }

        public AdminResponseModel Get(int id)
        {
            var get = _adminRepository.Get(id);
            return new AdminResponseModel()
            {
                Message = $"Found",
                Status = true,
                Data = new AdminDto()
                {
                    Email = get.Email,
                    Id = get.Id,
                }
            };
        }

        public AdminsResponseModel GetAll()
        {
            var getall = _adminRepository.GetAll().Select(d => new AdminDto()
            {
              Email  = d.Email,
              Id = d.Id
            }).ToList();
            return new AdminsResponseModel()
            {
                Data = getall,
                Message = $"Found",
                Status = true
            };
        }
    }
}
      