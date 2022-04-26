using System;
using System.Collections.Generic;
using ParkManagment.DTOs.Park;
using ParkManagment.DTOs.Payment;
// using ParkManagment.DTOs.Payment;
using ParkManagment.Entities;

namespace ParkManagment.Interfaces
{
    public interface IPaymentService
    {
        PaymentResponseModel Create(PaymentRequesModel _model, int id);
        PaymentResponseModel Get(int id);
        PaymentsResponseModel GetAll();
        PaymentsResponseModel SearchByDate(DateTime day, DateTime expire);
    }
}