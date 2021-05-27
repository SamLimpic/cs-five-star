using System;
using System.Collections.Generic;
using five_star.server.Models;
using five_star.server.Repositories;
using five_star.server.Interfaces;

namespace five_star.server.Services
{
    public class RestaurantsService : IService<Restaurant>
    {
        private readonly RestaurantsRepository _repo;

        public RestaurantsService(RestaurantsRepository repo)
        {
            _repo = repo;
        }



        public List<Restaurant> GetAll()
        {
            return _repo.GetAll();
        }



        public Restaurant GetById(int id)
        {
            return _repo.GetById(id);
        }



        public Restaurant Create(Restaurant data)
        {
            return _repo.Create(data);
        }



        public Restaurant Update(Restaurant edit, string creatorId)
        {
            Restaurant original = _repo.GetById(edit.Id);
            original.Name = edit.Name.Length > 0 ? edit.Name : original.Name;
            original.Location = edit.Location.Length > 0 ? edit.Location : original.Location;
            if (original == null)
            {
                throw new Exception("Invalid Id");
            }
            if (edit.CreatorId != creatorId)
            {
                throw new Exception("You cannot delete another users Restaurant");
            }
            return _repo.Update(original);
        }



        public void Delete(int id, string creatorId)
        {
            Restaurant restaurant = GetById(id);
            if (restaurant == null)
            {
                throw new Exception("Invalid Id");
            }
            if (restaurant.CreatorId != creatorId)
            {
                throw new Exception("You cannot delete another users Restaurant");
            }
            _repo.Delete(id);
        }
    }
}