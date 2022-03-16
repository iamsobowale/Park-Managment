using System;
using System.Collections.Generic;
using ParkManagment.Entities;
using ParkManagment.DTOs;
using ParkManagment.DTOs.Staff;

namespace ParkManagment.DTOs.Park
{
    public class ParkDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public IList<StaffDto> Staves { get; set; } = new List<StaffDto>();
        public IList<DriverDto> DriverDtos { get; set; } = new List<DriverDto>();
    }
    public class ParkResponseModel : BaseResponse
    {
        public ParkDto Data { get; set; }
    }
    public class ParksResponseModel : BaseResponse
    {
        public IList<ParkDto> Data { get; set; }
    }

    public class ParkResquestModel
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
    }
}