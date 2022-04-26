using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ParkManagment.DTOs;
using ParkManagment.Entities;
using ParkManagment.Interfaces;
using Microsoft.AspNetCore.Http;

namespace ParkManagmentMVC.Controllers
{
    public class MotorController:Controller
    {
        private IMotorService _motorService;
        private IDriverService _driver;
        private IParkService _parkService;

        public MotorController(IMotorService motorService, IDriverService driver, IParkService parkService)
        {
            _motorService = motorService;
            _driver = driver;
            _parkService = parkService;
        }

        public IActionResult Index()
        {
            var get = _motorService.GetAll();
            return View(get.Data);
        }

        public IActionResult Create(int id)
        {
            var park = _parkService.GetAll();
            ViewData["Parks"] = new SelectList(park.Data, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(MotorRequestModel _model)
        {
            var id = HttpContext.Session.GetInt32("driver");
            var user = _driver.Get(id.Value);
            _motorService.Create(_model, user.Data.Id);
            ViewBag.CarCreated = "Car Successfully Created";
            return View();
        }

        public IActionResult Get(int id)
        {
           id = HttpContext.Session.GetInt32("driver").Value;
            var get = _motorService.Get(id);
            if (get==null)
            {
                throw new Exception($"Motor With Id{id} Does Not Exist");
            }

            return View(get);
        }

        public IActionResult Update(int id)
        {
            var update = _motorService.Get(id);
            if (update==null)
            {
                 throw new Exception($"Motor With Id{id} Does Not Exist");
            }

            return View(update);
        }
        
        [HttpPost]

        public IActionResult Update(MotorRequestModel motor, int id)
        {
            var update = _motorService.Update(motor, id);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var deletedriver = _motorService.Get(id);
            if (deletedriver==null)
            {
                return NotFound($"Driver with {id} does not exist");
            }

            return View(deletedriver);
        }
        
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteDriver(int id)
        {
            _motorService.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult GetPaymentByCar(int id)
        {
            var get =  _motorService.GetPaymentByMotor(id);
            if (get==null)
            {
                return View();
            }
            return View(get);
        }

        public IActionResult GetAllCarPayment(int id)
        {
            var getAllPayment = _motorService.GetAllCarPaymentOfADriver(id);
            if (getAllPayment==null)
            {
                ViewBag.GetAll = "Payments not found";
                return View();
            }

            return View(getAllPayment);
        }
    }
}