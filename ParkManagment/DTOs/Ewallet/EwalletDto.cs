using System.Collections.Generic;

namespace ParkManagment.DTOs.Ewallet
{
    public class EwalletDto
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public string DriverName { get; set; }
    }

    public class EwalletResponseModel:BaseResponse
    {
        public EwalletDto Data { get; set; }
    }
    public class EwalletsResponseModel:BaseResponse
    {
        public IList<EwalletDto> Data { get; set; }
    }
    public class EwalletRequestModel
    {
        public decimal Balance { get; set; }
        public int DriverId { get; set; }
    }
}