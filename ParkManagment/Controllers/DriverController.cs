using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ParkManagment.DTOs;
using ParkManagment.Entities;
using ParkManagment.Interfaces;

namespace ParkManagmentMVC.Controllers
{
    public class DriverController:  Controller
    {
        private readonly IDriverService _driverService;
        private readonly IParkService _parkService;

        public DriverController(IDriverService driverService, IParkService parkService)
        {
            _driverService = driverService;
            _parkService = parkService;
        }

        public IActionResult Index()
        {
            var n = _driverService.GetAll();
            return View(n.Data);
        }
        public IActionResult Create()
        {
            var getAll = _parkService.GetAll();
            ViewData["Parks"] = new SelectList(getAll.Data, "Id", "Name");
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(DriverRequestModel _model)
        {
            _driverService.Create(_model);
            return RedirectToAction("Index");
        }

        public IActionResult Get(int id)
        {
            var driver = _driverService.Get(id);
            if(driver == null)
            {
                return NotFound($"User with {id} does not exist");
            }
            return View(driver.Data);
        }

        public IActionResult Update(int id)
        {
            var update = _driverService.Get(id);
            if (update==null)
            {
                throw new Exception($"User with Id{id} Does Not Exist");
            }
            return View(update);
        }

        [HttpPost]
        public IActionResult Update(Driver driver, int id)
        {
            
            _driverService.Update(driver, id);
            return RedirectToAction("Index");
        }

        public IActionResult GetCarByDrivers(int id)
        {
            var driver = _driverService.GetCarsByDriver(id);
            if(driver == null)
            {
                return NotFound($"Student with {id} does not exist");
            }
            return View(driver);
        }
        public IActionResult Delete(int id)
        {
            var deletedriver = _driverService.Get(id);
            if (deletedriver==null)
            {
                return NotFound($"Driver with {id} does not exist");
            }
            return View(deletedriver.Data);
        }
        
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteDriver(int id)
        {
            _driverService.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(DriverRequestModel _driverRequest)
        {
           var login =  _driverService.Login(_driverRequest);
            if (login.Data==null)
            {
                return RedirectToAction("Login");
            }

            var id2 = login.Data.Id;
            return RedirectToAction("Get", new{id= id2});
        }

    }
}