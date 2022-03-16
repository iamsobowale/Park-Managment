using System;
using System.Collections.Generic;

namespace ParkManagment.DTOs.Staff
{
    public class StaffDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Reg { get; set; }
        public DateTime Dob { get; set; }
        public int ParkId { get; set; }
        public string ParkName { get; set; }
    }
    public class StaffResponseModel:BaseResponse
    {
        public StaffDto Data { get; set; }
    }
    public class StaffsResponseModel:BaseResponse
    {
        public IList<StaffDto> Data { get; set; }
    }
    public class StaffRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Dob { get; set; }
        public int ParkId { get; set; }
    }
    
}