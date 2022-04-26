using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ParkManagment.DTOs.Payment;
using ParkManagment.Interfaces;

namespace ParkManagment.Controllers
{
    public class PaymentController : Controller
    {
        private IPaymentService _paymentService;
        private IMotorService _motorService;
        public PaymentController(IPaymentService paymentService, IMotorService motorService)
        {
            _paymentService = paymentService;
            _motorService = motorService;
        }

        public IActionResult Index(DateTime searchStartDate, DateTime searchEndDate)
        {
            DateTime defaultDate = new DateTime();
            
            var  getAll = _paymentService.GetAll();
            if (searchEndDate != defaultDate && searchStartDate != defaultDate)
            {
                getAll = _paymentService.SearchByDate(searchStartDate, searchEndDate);
            }
            return View( getAll.Data);
        }
        
        public IActionResult Get(int id)
        {
            var get = _paymentService.Get(id);
            if (get.Data==null)
            {
                throw new Exception($"Payment Not Found");
            }
            return View(get.Data);
        }

        public IActionResult Create(int id)
        {
            var get = _motorService.Get(id);
            if (get==null)
            {
                throw new Exception($"User with Id{id} Does Not Exist");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Create(PaymentRequesModel _paymentRequesModel, int id)
        {
            var create = _paymentService.Create(_paymentRequesModel, id);
            if (create.Data!=null)
            {
                ViewBag.Messagess = "Payment Created Successfully";
                return View();
            }
            return RedirectToAction("Create");
        }
    }
}