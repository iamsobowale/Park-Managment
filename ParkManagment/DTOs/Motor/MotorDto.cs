using System.Collections.Generic;
using ParkManagment.DTOs.Payment;
using ParkManagment.Entities;

namespace ParkManagment.DTOs
{
    public class MotorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RegNumber { get; set; }
        public int NumberOfSit { get; set; }
        public int DriverId { get; set; }
        public string DriverName { get; set; }
        public string DriverPhoneNumber { get; set; }
        public int ParkId { get; set; }
        public string ParkName { get; set; }
        public decimal ParkPrice { get; set; }
        public IEnumerable<PaymentDto> Payments = new List<PaymentDto>();
    }
    public class MotorResponseModel:BaseResponse
    {
        public MotorDto Data { get; set; }
    }
    public class MotorsResponseModel:BaseResponse
    {
        public IList<MotorDto> Data { get; set; }
    }

    public class MotorRequestModel
    {
        public string Name { get; set; }
        public int DriverId { get; set; }
        public int NumberOfSit { get; set; }
        public int ParkId { get; set; }
    }
}