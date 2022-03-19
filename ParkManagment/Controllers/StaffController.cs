using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ParkManagment.DTOs.Staff;
using ParkManagment.Entities;
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
        public IActionResult Get()
        {
            var id = HttpContext.Session.GetInt32("user");
            if (id == null)
            {
                return RedirectToAction("Login");
            }
            var staff = _staff.Get(id.Value);
            if(!staff.Status)
            {
                return NotFound($"Staff with {id.Value} does not exist");
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
                ViewBag.StaffMesssage = "Invalid Email or Password";
                return View();
            }
                
            HttpContext.Session.SetInt32("user", login.Data.Id);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, login.Data.Id.ToString())
            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authenticationProperties = new AuthenticationProperties();
            var principal = new ClaimsPrincipal(claimsIdentity);
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authenticationProperties );
            return RedirectToAction("Get");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

    }
}