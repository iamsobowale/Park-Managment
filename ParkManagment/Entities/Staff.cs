using System;

namespace ParkManagment.Entities
{
    public class Staff
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Reg { get; set; }
        public DateTime Dob { get; set; }
        public int ParkId { get; set; }
        public Park Park { get; set; }
    }
}