using System;
using Microsoft.AspNetCore.Http;
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
           var create = _driverService.Create(_model);
           if (create.Status)
           {
               return RedirectToAction("Login");
           }
           ViewBag.Account ="Account Not Created";
           return View();
        }

        public IActionResult Get(int get)
        {
            var id = HttpContext.Session.GetInt32("driver");
            if (id == null)
            {
                return RedirectToAction("Login");
            }
            var staff = _driverService.Get(id.Value);
            if(!staff.Status)
            {
                return NotFound($"Staff with {id.Value} does not exist");
            }
            return View(staff.Data);
        }
        public IActionResult Update()
        {
            var id = HttpContext.Session.GetInt32("driver");
            var update = _driverService.Get(id.Value);
            if (update.Data==null)
            {
                throw new Exception($"User with Id{id} Does Not Exist");
            }
            return View(update.Data);
        }

        [HttpPost]
        public IActionResult Update(DriverRequestModel driver)
        {
            var id = HttpContext.Session.GetInt32("driver");
            _driverService.Update(driver, id.Value);
            return RedirectToAction("Get");
        }

        public IActionResult GetCarByDrivers(int id)
        {
            id = HttpContext.Session.GetInt32("driver").Value;
            var driver = _driverService.GetCarsByDriver(id);
            if(driver == null)
            {
                return NotFound($"Driver with {id} does not exist");
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
                ViewBag.Messsage = "Invalid Email or Password";
                return View();
            }
            HttpContext.Session.SetInt32("driver", login.Data.Id);
            return RedirectToAction("Get");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

    }
}