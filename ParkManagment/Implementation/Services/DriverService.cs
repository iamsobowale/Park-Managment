using System;
using ParkManagment.Entities;
using System.Collections.Generic;
using System.Linq;
using ParkManagment.DTOs;
using ParkManagment.Implementions.Service;
using ParkManagment.Interfaces;

namespace ParkManagment.Implemention.DriverService
{
    public class DriverService:IDriverService
    {
        public readonly IDriverRepository _DriverRepository;
        public DriverService(IDriverRepository driverRepository)
        {
            _DriverRepository = driverRepository;
        }
        public DriverResponseModel Create(DriverRequestModel _model)
        {
            Driver drivers = new Driver()
            {
                FirstName = _model.FirstName,
                LastName = _model.LastName,
                PhoneNumber = _model.PhoneNumber,
                Dob = _model.Dob,
                ParkId = _model.ParkId,
                Password = _model.Password
            };
            _DriverRepository.Create(drivers);
            return new DriverResponseModel()
            {
                Status = true,
                Message = "Account Created Sucessfully",
                Data = new DriverDto()
                {
                    Dob = _model.Dob,
                    FirstName = _model.FirstName,
                    LastName = _model.LastName,
                    PhoneNumber = _model.PhoneNumber,
                }
            };
        }

        public bool Delete(int id)
        {
            var delete = _DriverRepository.Get(id);
            if (delete==null)
            {
                 throw new Exception($"Driver with Id{id} does not exist");
            }

            _DriverRepository.Delete(id);
            return true;
        }

        public DriverResponseModel Get(int id)
        {
            var find = _DriverRepository.Get(id);
            if (find==null)
            {
                return new DriverResponseModel()
                {
                    Message = $"Driver Does not Exist",
                    Status = false
                };
            }

            return new DriverResponseModel()
            {
                Message = $"Driver Successfully Found",
                Data = new DriverDto()
                {
                    Id = find.Id,
                    FirstName = find.FirstName,
                    LastName = find.LastName,
                    Dob = find.Dob,
                    PhoneNumber = find.PhoneNumber,
                    ParkName = find.Park.Name
                },
                Status = true
            };
        }

        public DriversResponseModel GetAll()
        {
           var drivers = _DriverRepository.GetAll();
           var driverDto = drivers.Select(d => new DriverDto
           {
               Id = d.Id,
               FirstName = d.FirstName,
               LastName = d.LastName,
           }).ToList();
           return new DriversResponseModel
           {
               Message = $"Successfully Found",
               Data = driverDto,
               Status = true
           };
        }

        public DriverResponseModel Update(DriverRequestModel driver, int id)
        {
            var find = _DriverRepository.Get(id);
            if (find==null)
            {
               throw new Exception($"Driver With Id{id} does not exist");
            }

            find.FirstName = driver.FirstName;
            find.LastName = driver.LastName;
            find.PhoneNumber = driver.PhoneNumber;
            find.Dob = driver.Dob;
            find.Password = driver.Password;
            _DriverRepository.Update(find);
            return new DriverResponseModel()
            {
                Message =$"Driver Updated",
                Status = true,
            };
        }

        public DriverResponseModel Login(DriverRequestModel _driverRequest)
        {
            var get = _DriverRepository.GetLogin(_driverRequest.FirstName);
            if (get!=null && get.Password==_driverRequest.Password)
            {
                return new DriverResponseModel()
                {
                    Message = $"Login Found",
                    Status = true,
                    Data = new DriverDto()
                    {
                        Id = get.Id,
                        FirstName = get.FirstName,
                        LastName = get.LastName
                    }
                };
            }

            return new DriverResponseModel()
            {
                Message = $"Login Not Found",
                Status = false
            };
        }

        public IList<Motor> GetCarsByDriver(int id)
        {
            return _DriverRepository.GetCarsByDriver(id);
        }
    }
}