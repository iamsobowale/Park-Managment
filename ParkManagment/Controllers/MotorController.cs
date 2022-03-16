using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ParkManagment.DTOs;
using ParkManagment.Entities;
using ParkManagment.Interfaces;

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

        public IActionResult Create()
        {
            var dri = _driver.GetAll();
            var park = _parkService.GetAll();
            ViewData["Parks"] = new SelectList(park.Data, "Id", "Name");
            ViewData["Drivers"] = new SelectList(dri.Data, "Id", "FirstName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(MotorRequestModel _model)
        {
            _motorService.Create(_model);
            return RedirectToAction("Index");
        }

        public IActionResult Get(int id)
        {
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
    }
}