using Microsoft.AspNetCore.Mvc;
using ParkManagment.DTOs.Park;
using ParkManagment.Entities;
using ParkManagment.Interfaces;


namespace ParkManagmentMVC.Controllers
{
    public class ParkController:Controller
    {
        private readonly IParkService _park;

        public ParkController(IParkService park)
        {
            _park = park;
        }

        public IActionResult Index()
        {
            var getall = _park.GetAll();
            return View(getall.Data);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Park park)
        {
            _park.Create(park);
            return RedirectToAction("Index");
        }

        public IActionResult Get(int id)
        {
            var get = _park.Get(id);
            if (get==null)
            {
                return NotFound($"Park with {id} does not exist");
            }

            return View(get.Data);
        }

        public IActionResult Update(int id)
        {
            var park = _park.Get(id);
            if (park == null)
            {
                return NotFound($"Park with {id} does not exist");
            }
            return View(park.Data);
        }
        
        [HttpPost]
        public IActionResult Update(ParkResquestModel park, int id)
        {
            var update = _park.Update(park, id);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var deletepark = _park.Get(id);
            if (deletepark==null)
            {
                return NotFound($"Park with {id} does not exist");
            }

            return View(deletepark.Data);
        }
        
        [HttpPost, ActionName("DeletePark")]
        public IActionResult DeletePark(int id)
        {
            _park.Delete(id);
            return RedirectToAction("Index");
        }
    }
}