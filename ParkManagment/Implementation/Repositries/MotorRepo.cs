using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ParkManagment.Context;
using ParkManagment.DTOs;
using ParkManagment.Entities;
using ParkManagment.Interfaces;

namespace ParkManagmentMVC.Implementions.DriverRepostory
{
    public class MotorRepo:IMotorsRepository
    {
        private readonly ApplicationContext _context;
        public MotorRepo(ApplicationContext context)
        {
            _context = context;
        }

        public bool Create(Motor motor)
        {
            _context.Motors.Add(motor);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var find = _context.Motors.Find(id);
            _context.Motors.Remove(find);
            _context.SaveChanges();
            return true;
        }
        public Motor Get(int id)
        {
            var get = _context.Motors.Include(c=>c.Driver).ThenInclude(d=>d.Park).SingleOrDefault(d=>d.Id==id);
           if (get==null)
           {
               throw new Exception("Motor Not Found");
           }
           return get;
        }
        public List<Motor> GetAll()
        {
            var getall =  _context.Motors.Include(a => a.Driver).ThenInclude(d=>d.Park).ToList();
            return getall;
        }

        public Motor Update(Motor motor)
        {
            var update = _context.Motors.Update(motor);
            _context.SaveChanges();
            return motor;
        }
    }
}