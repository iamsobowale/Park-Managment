using System.Collections.Generic;

namespace ParkManagment.Entities
{
    public class Motor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RegNumber { get; set; }
        public int NumberOfSit { get; set; }
        public int DriverId { get; set; }
        public Driver Driver { get; set; }
        public int ParkId { get; set; }
        public Park Park { get; set; }
        public IEnumerable<Payment> Payments = new List<Payment>();
    }
}