using System;
using System.Collections.Generic;
using System.Linq;
using ParkManagment.DTOs.Park;
using ParkManagment.Entities;
using ParkManagment.Interfaces;
using ParkManagment.Interfaces;

namespace ParkManagment.Implementions.Service
{
    public class ParkService:IParkService
    {
        private IParkRepository _park;
        private IParkService _parkServiceImplementation;

        public ParkService(IParkRepository park)
        {
            _park = park;
        }

        public ParkResponseModel Create(Park park)
        {
            Entities.Park parks = new Entities.Park()
            {
                Name = park.Name,
                Price = park.Price,
                Description = park.Description,
            };
            _park.Create(parks);
            return new ParkResponseModel()
            {
                Message = $"Park Created",
                Status = true,
                Data = new ParkDto()
                {
                    Name = park.Name,
                    Description = park.Description,
                    Price = park.Price
                }
            };
        }

        public bool Delete(int id)
        {
            var delete = _park.Get(id);
            if (delete==null)
            {
                throw new Exception($"Park with Id{id} does not exist");
            }

            _park.DeletePark(id);
            return true;
        }

        public ParkResponseModel Get(int id)
        {
            var get = _park.Get(id);
            if (get==null)
            {
                throw new Exception($"Park with Id{id} does not exist");
            }
            _park.Get(id);
            return new ParkResponseModel()
            {
                Message = $"Park Found",
                Status = true,
                Data = new ParkDto()
                {
                    Description = get.Description,
                    Name = get.Name,
                    Price = get.Price,
                    Id = get.Id,
                }
            };
        }

        public ParksResponseModel GetAll()
        {
            var getall = _park.GetAll();
            var get = getall.Select(d => new ParkDto()
            {
                Description = d.Description,
                Id = d.Id,
                Name = d.Name,
                Price = d.Price
            }).ToList();
            return new ParksResponseModel()
            {
                Data = get,
                Message = $"Parks Found",
                Status = true
            };
        }

        public ParkResponseModel Update(ParkResquestModel park, int id)
        {
            var update = _park.Get(id);
            if (update==null)
            {
                throw new Exception($"Park with Id{id} does not exist");
            }
            update.Name = park.Name;
            update.Price = park.Price;
            update.Description = park.Description;
            _park.Update(update);
            return new ParkResponseModel()
            {
                Status = true,
                Message = $"Park Updated",
                Data = new ParkDto()
                {
                    Description = park.Description,
                    Name = park.Name,
                    Price = park.Price,
                }
            };
        }
    }
}