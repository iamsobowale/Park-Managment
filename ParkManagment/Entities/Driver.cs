using System;
using System.Collections.Generic;

namespace ParkManagment.Entities
{
    public class Driver
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Dob { get; set; }
        public int ParkId { get; set; }
        public Park Park { get; set; }
        public IEnumerable<Motor> Motors=new List<Motor>();
        // public int EWalletId { get; set; }
    }
}