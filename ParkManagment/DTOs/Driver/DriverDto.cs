using System;
using System.Collections.Generic;
using ParkManagment.Entities;

namespace ParkManagment.DTOs
{
    public class DriverDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public DateTime Dob { get; set; }
        public int ParkId { get; set; }
        public string ParkName { get; set; }
        public decimal ParkPrice { get; set; }
        public string ParkDescription { get; set; }
        public List<MotorDto> motor { get; set; } = new List<MotorDto>();
    }
    public class DriverResponseModel : BaseResponse
    {
        public DriverDto Data { get; set; }
    }

    public class DriversResponseModel : BaseResponse
    {
        public List<DriverDto> Data { get; set; }
    }

    public class DriverRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Dob { get; set; }
        public string Password { get; set; }
        public IEnumerable<Entities.Motor> Motors=new List<Entities.Motor>();
        public int ParkId { get; set; }
    }

}