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
            throw new NotImplementedException();
        }



        public Restaurant Create(Restaurant data)
        {
            return _repo.Create(data);
        }



        public Restaurant Update(Restaurant data, string creatorId)
        {
            throw new NotImplementedException();
        }



        public void Delete(int id, string creatorId)
        {
            Restaurant restaurant = GetById(id);
            // if (restaurant.CreatorId != creatorId)
            // {
            //     throw new Exception("You cannot delete another users Restaurant");
            // }
            if (!_repo.Delete(id))
            {
                throw new Exception("Something has gone wrong...");
            };
        }
    }
}