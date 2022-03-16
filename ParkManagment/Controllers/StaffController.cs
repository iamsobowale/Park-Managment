using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ParkManagment.DTOs.Staff;
using ParkManagment.Interfaces;

namespace ParkManagmentMVC.Controllers
{
    public class StaffController:Controller
    {
        private IStaffService _staff;
        private IParkService _parkService;
        
        public StaffController(IStaffService staff, IParkService parkService)
        {
            _staff = staff;
            _parkService = parkService;
        }

        public IActionResult Index()
        {
            var getall = _staff.GetAll();
            return View(getall.Data);
        }

        public IActionResult Create()
        {
            var dri = _parkService.GetAll();
            ViewData["Parks"] = new SelectList(dri.Data, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(StaffRequestModel _staffRequestModel)
        {
            var create = _staff.Create(_staffRequestModel);
            return RedirectToAction("Index");
        }
        public IActionResult Get(int id)
        {
            var staff = _staff.Get(id);
            if(staff == null)
            {
                return NotFound($"Staff with {id} does not exist");
            }
            return View(staff.Data);
        }
        public IActionResult Update(int id)
        {
            var get = _staff.Get(id);
            if (get==null)
            {
                throw new Exception($"User with Id{id} Does Not Exist");
            }
            return View(get);
        }

        [HttpPost]
        public IActionResult Update(StaffRequestModel staff, int id)
        {
            
           var update = _staff.Update(staff, id);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var deletestaff = _staff.Get(id);
            if (deletestaff==null)
            {
                return NotFound($"Driver with {id} does not exist");
            }

            return View(deletestaff.Data);
        }
        
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteStaff(int id)
        {
            _staff.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(StaffRequestModel _staffRequestModel)
        {
            var login =  _staff.Login(_staffRequestModel);
            if (login.Data==null)
            {
                return RedirectToAction("Login");
            }

            var id2 = login.Data.Id;
            // return RedirectToAction("Get", new{id= id2});
            return RedirectToAction("Index");
        }

    }
}