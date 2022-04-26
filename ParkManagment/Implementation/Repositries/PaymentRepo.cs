using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ParkManagment.Context;
using ParkManagment.Entities;
using ParkManagment.Interfaces;

namespace ParkManagment.Implementions.Service
{
    public class PaymentRepo:IPaymentRepository
    {
        private ApplicationContext _context;
        
        public PaymentRepo(ApplicationContext context)
        {
            _context = context;
            
        }

        public bool Create(Payment payment)
        {
            _context.Payments.Add(payment);
            _context.SaveChanges();
            return true;
        }

        public IList<Payment> CreateMultiple(IList<Payment> payment)
        {
           _context.Payments.AddRange(payment);
            _context.SaveChanges();
            return payment;
        }

        public Payment Get(int id)
        {
            var payment = _context.Payments.Include(c=>c.Motor).SingleOrDefault(o=>o.Id==id);
            return payment;
        }

        public List<Payment> GetAll()
        {
            var check = _context.Payments.Include(c=>c.Motor).ToList();
            return check;
        }

        public IList<Payment> SearchByDate(DateTime day, DateTime expire)
        {
            var get = _context.Payments.Include(d=>d.Motor).Where(c => c.DayOfPayment <= day && c.Expire >= expire).ToList();
            return get;
        }
    }
}