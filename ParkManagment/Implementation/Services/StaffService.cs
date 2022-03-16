using System;
using System.Collections.Generic;
using System.Linq;
using ParkManagment.DTOs;
using ParkManagment.DTOs.Staff;
using ParkManagment.Entities;
using ParkManagment.Interfaces;
namespace ParkManagment.Implementions
{
    public class StaffService:IStaffService
    {
        private IStaffRepository _staff;
        public StaffService(IStaffRepository staff)
        {
            _staff = staff;
        }

        public StaffResponseModel Create(StaffRequestModel _model)
        {
            Staff staffs = new Staff()
            {
                FirstName = _model.FirstName,
                LastName = _model.LastName,
                PhoneNumber = _model.PhoneNumber,
                Dob = _model.Dob,
                Reg = $"Staff/{Guid.NewGuid().ToString().Substring(0, 5)}",
                ParkId = _model.ParkId,
                Password = _model.Password
            };
            _staff.Create(staffs);
            return new StaffResponseModel()
            {
                Data = new StaffDto()
                {
                    FirstName = _model.FirstName,
                    Dob = _model.Dob,
                    Reg = $"Staff/{Guid.NewGuid().ToString().Substring(0, 5)}",
                }
            };
        }

        public bool Delete(int id)
        {
            var delete = _staff.Get(id);
            if (delete==null)
            {
                throw new Exception($"Staff with Id{id} does not exist");
            }

            _staff.Delete(id);
            return true;
        }

        public StaffResponseModel Get(int id)
        {
            var find = _staff.Get(id);
            if (find==null)
            {
                throw new Exception($"Staff with Id{id} does not exist");
            }

            return new StaffResponseModel()
            {
                Data = new StaffDto()
                {
                    Dob = find.Dob,
                    Id = find.Id,
                    Reg = find.Reg,
                    FirstName = find.FirstName,
                    LastName = find.LastName,
                    PhoneNumber = find.PhoneNumber,
                    ParkName = find.Park.Name
                }
            };
        }

        public StaffsResponseModel GetAll()
        {
            var getall = _staff.GetAll();
            var get = getall.Select(d => new StaffDto()
            {
                Dob = d.Dob,
                Id = d.Id,
                FirstName = d.FirstName,
                LastName = d.LastName,
                Reg = d.Reg,
                PhoneNumber = d.PhoneNumber
            }).ToList();
            return new StaffsResponseModel()
            {
                Data = get,
                Message = $"Staffs Found",
                Status = true,
            };
        }

        public StaffResponseModel Login(StaffRequestModel _staffRequestModel)
        {
            var get = _staff.GetLogin(_staffRequestModel.FirstName);
            if (get!=null && get.Password==_staffRequestModel.Password)
            {
                return new StaffResponseModel()
                {
                    Message = $"Login Found",
                    Status = true,
                    Data = new StaffDto()
                    {
                        Id = get.Id,
                        FirstName = get.FirstName,
                        LastName = get.LastName
                    }
                };
            }

            return new StaffResponseModel()
            {
                Message = $"Login Not Found",
                Status = false
            };
        }

        public StaffResponseModel Update(StaffRequestModel _staffRequestModel, int id)
        {
            var find = _staff.Get(id);
            if (find==null)
            {
                throw new Exception($"Driver With Id{id} does not exist");
            }
            find.FirstName = _staffRequestModel.FirstName;
            find.LastName = _staffRequestModel.LastName;
            find.PhoneNumber = _staffRequestModel.PhoneNumber;
            find.Dob = _staffRequestModel.Dob;
            find.Password = _staffRequestModel.Password;
            _staff.Update(find);
            return new StaffResponseModel()
            {
                Data = new StaffDto()
                {
                    Dob = find.Dob,
                    FirstName = find.FirstName,
                    LastName = find.LastName,
                    PhoneNumber = find.PhoneNumber,
                    Password = find.Password
                }
            };
        }
    }
}