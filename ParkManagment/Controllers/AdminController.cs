using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkManagment.DTOs.Admin;
using ParkManagment.Entities;
using ParkManagment.Interfaces;

namespace ParkManagment.Controllers
{
    public class AdminController:Controller
    {
        private IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public IActionResult Index()
        {
            var get = _adminService.GetAll();
            return View(get.Data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(AdminRequestModel admin)
        {
            _adminService.Create(admin);
            return RedirectToAction("Index");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Admin admin)
        {
            var login =  _adminService.Login(admin);
            if (login.Data ==null)
            {
                ViewBag.Error = login.Message;
                return View();
            }
            HttpContext.Session.SetInt32("admin", login.Data.Id);
            return RedirectToAction("Index");
        }
    }
}