using System.Collections.Generic;

namespace ParkManagment.Entities
{
    public class Park
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        // public List<StaffRequestModel> Staffs = new List<StaffRequestModel>();
        public List<Motor> Motors = new List<Motor>();
        public List<Driver> Drivers = new List<Driver>();
    }
    
}