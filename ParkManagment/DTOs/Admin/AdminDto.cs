using System.Collections.Generic;

namespace ParkManagment.DTOs.Admin
{
    public class AdminDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
    }
    public class AdminResponseModel:BaseResponse
    {
        public AdminDto Data {get; set; }
    }
    public class AdminsResponseModel:BaseResponse
    {
        public IList<AdminDto> Data {get; set; }
    }

    public class AdminRequestModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}