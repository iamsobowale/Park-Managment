using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ParkManagment.Context;
using ParkManagment.DTOs.Payment;
using ParkManagment.Entities;
using ParkManagment.Interfaces;


namespace ParkManagmentMVC.Implementions.DriverService
{
    public class PaymentService:IPaymentService
    {
        private readonly IPaymentRepository _payment;
        private readonly IMotorsRepository _motors;
        public PaymentService(IPaymentRepository payment, IMotorsRepository motors)
        {
            _payment = payment;
            _motors = motors;
        }
        public PaymentResponseModel Create(PaymentRequesModel _model, int id)
        {
            // List<Payment> payments = new List<Payment>();
            var motor =  _motors.Get(id);
            var sum = motor.NumberOfSit * motor.Park.Price*_model.NumberOfDays;
            var payment = new Payment()
            {
                NumberOfDays = _model.NumberOfDays,
                TotalPayment =sum,
                Expire = DateTime.Today.AddDays(_model.NumberOfDays),
                DayOfPayment = DateTime.Now.Date,
                MotorId = _model.MotorId,
                Motor = motor
            };
            _payment.Create(payment);
            // payments.Add(payment);
            // _payment.CreateMultiple(payments);  

            return new PaymentResponseModel()
            {
                Status = true,
                Message = $"Payment Made",
                Data = new PaymentDto()
                {
                    Expire = _model.Expire,
                    DayOfPayment = _model.DayOfPayment,
                    NumberOfDays = _model.NumberOfDays,
                }
            };
        }

        public PaymentResponseModel Get(int id)
        {
            var get = _payment.Get(id);
            if (get==null)
            {
                return new PaymentResponseModel()
                {
                    Message = $"Payment Not Found",
                    Status = false,
                };
            }

            return new PaymentResponseModel()
            {
                Message = $"Payment Found",
                Status = true,
                Data = new PaymentDto()
                {
                    Id = get.Id,
                    Expire = get.Expire,
                    DayOfPayment = get.DayOfPayment,
                    NumberOfDays = get.NumberOfDays,
                    MotorName = get.Motor.Name,
                    TotalPayment = get.TotalPayment,
                    MotorRegNumber = get.Motor.RegNumber
                }
            };
        }
        
        public PaymentsResponseModel GetAll()
        {
            var allPayments = _payment.GetAll();
                
           var allPayment= allPayments.Select(d => new PaymentDto()
            {
                Expire = d.Expire,
                Id = d.Id,
                TotalPayment = d.TotalPayment,
                MotorRegNumber = d.Motor.RegNumber,
                DayOfPayment = d.DayOfPayment,
                MotorName = d.Motor.Name,
                NumberOfDays = d.NumberOfDays
            }).ToList();
            return new PaymentsResponseModel()
            {
                Data = allPayment,
                Message = $"Payments Found",
                Status = true,
            };
        }

        public PaymentsResponseModel SearchByDate(DateTime day, DateTime expire)
        {
            var date = _payment.SearchByDate(day, expire).Select(d => new PaymentDto()
            {
                Id = d.Id,
                TotalPayment = d.TotalPayment,
                MotorName = d.Motor.Name,
                MotorRegNumber = d.Motor.RegNumber,
                Expire = d.Expire,
                DayOfPayment = d.DayOfPayment
            }).ToList();
            return new PaymentsResponseModel()
            {
                Message = $"Payment Made",
                Status = true,
                Data = date
            };
        }
    }
}