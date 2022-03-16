using System;

namespace ParkManagment.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public DateTime DayOfPayment { get; set; }
        public DateTime Expire { get; set; }
        public int NumberOfDays { get; set; }
        public decimal TotalPayment { get; set; }
        public int MotorId { get; set; }
        public Motor Motor { get; set; }
    }
}