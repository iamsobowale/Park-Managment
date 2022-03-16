using System;
using System.Collections.Generic;
using ParkManagment.Entities;

namespace ParkManagment.DTOs.Payment
{
    public class PaymentDto
    {
        public int Id { get; set; }
        public DateTime DayOfPayment { get; set; }
        public DateTime Expire { get; set; }  
        public decimal TotalPayment { get; set; }
        public int MotorId { get; set; }
        public Entities.Motor Motor { get; set; }
        public string MotorName { get; set; }
        public string MotorRegNumber { get; set; }
        public int NumberOfDays { get; set; }
    }
    public class PaymentResponseModel:BaseResponse
    {
       public PaymentDto Data { get; set; }
    }
    public class PaymentsResponseModel:BaseResponse
    {
        public IList<PaymentDto> Data { get; set; }
    }
    public class PaymentRequesModel
    {
        public DateTime DayOfPayment { get; set; }
        public DateTime Expire { get; set; }
        public int NumberOfDays { get; set; }
        public int MotorId { get; set; }
        public int MotorNumberOfSits { get; set; }
    }
}