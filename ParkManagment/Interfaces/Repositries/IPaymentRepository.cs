using System;
using System.Collections.Generic;
using ParkManagment.Entities;

namespace ParkManagment.Interfaces
{
    public interface IPaymentRepository
    {
        bool Create(Payment payment);
        IList<Payment> CreateMultiple(IList<Payment> payment);
        Payment Get(int id);
        List<Payment> GetAll();
        IList<Payment> SearchByDate(DateTime day);
    }
}