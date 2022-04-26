using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using ParkManagment.DTOs;
using ParkManagment.Entities;
using ParkManagment.Interfaces;

namespace ParkManagment.Implementions.Service
{
    public class MotorService:IMotorService
    {
        public readonly IMotorsRepository _Motors;
        private IDriverRepository _driver;
        public MotorService(IMotorsRepository motors, IDriverRepository driver)
        {
            _Motors = motors;
            _driver = driver;
        }

        public MotorResponseModel Create(DTOs.MotorRequestModel _model, int userId)
        {
            Motor motors = new Motor()
            {
                Name = _model.Name,
                RegNumber = $"Car/{Guid.NewGuid().ToString().Substring(0, 5)}",
                DriverId = userId,
                ParkId = _model.ParkId,
                NumberOfSit = _model.NumberOfSit,
            };
            _Motors.Create(motors);
            return new MotorResponseModel()
            {
                Data = new MotorDto()
                {
                    Name = _model.Name,
                    RegNumber = $"Car/{Guid.NewGuid().ToString().Substring(0, 5)}", 
                }
            };
        }
        public bool Delete(int id)
        {
            var delete = _Motors.Delete(id);
            if (delete==null)
            {
                throw new Exception($"Motor with Id{id} does not exist");
            }

            _Motors.Delete(id);
            return true;
        }

        public MotorDto Get(int id)
        {
            
            var find = _Motors.Get(id);
            if (find==null)
            {
                throw new Exception($"Car Not Found");
            }

            return new MotorDto()
            {
                Id = find.Id,
                Name = find.Name,
                RegNumber = find.RegNumber,
                NumberOfSit = find.NumberOfSit,
                DriverName = find.Driver.FirstName + " " + find.Driver.LastName,
                ParkName = find.Park.Name,
                DriverPhoneNumber = find.Driver.PhoneNumber
            };

            
        }

        public MotorsResponseModel GetAll()
        {
            var motor = _Motors.GetAll();
            var getall = motor.Select(d => new MotorDto()
            {
                Id = d.Id,
                Name = d.Name,
                RegNumber = d.RegNumber
            }).ToList();
            return new MotorsResponseModel()
            {
                Data = getall,
                Message = $"Cars Found",
                Status = true
            };
        }

        public MotorResponseModel Update(MotorRequestModel motor, int id)
        {
            var update = _Motors.Get(id);
            if (update==null)
            {
                 throw new Exception($"Motor with Id{id} does not exist");
            }

            update.Name = motor.Name;
            _Motors.Update(update);
            return new MotorResponseModel()
            {
                Message = $"Updated",
                Status = true,
                Data = new MotorDto()
                {
                    Name = update.Name
                }
            };
        }

        public IList<Payment> GetPaymentByMotor(int id)
        {
            return _Motors.GetPaymentByMotor(id);
        }

        public IList<Payment> GetAllCarPaymentOfADriver(int id)
        {
            List<Payment> payments = new List<Payment>();
            var getallcars = _driver.GetCarsByDriver(id);
            foreach (var cars in getallcars)
            {
                var getAllPayment = _Motors.GetPaymentByMotor(cars.Id);
                payments.AddRange(getAllPayment);
            }

            return payments;
        }
    }
}