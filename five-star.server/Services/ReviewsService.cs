using System;
using System.Collections.Generic;
using five_star.server.Models;
using five_star.server.Repositories;
using five_star.server.Interfaces;

namespace five_star.server.Services
{
    public class ReviewsService : IService<Review>
    {
        private readonly ReviewsRepository _repo;

        public ReviewsService(ReviewsRepository repo)
        {
            _repo = repo;
        }



        public List<Review> GetAll()
        {
            return _repo.GetAll();
        }



        public Review GetById(int id)
        {
            throw new NotImplementedException();
        }



        public Review Create(Review data)
        {
            throw new NotImplementedException();
        }



        public Review Update(Review data, string creatorId)
        {
            throw new NotImplementedException();
        }



        public void Delete(int id, string creatorId)
        {
            Review review = GetById(id);
            if (review.CreatorId != creatorId)
            {
                throw new Exception("You cannot delete another users Review");
            }
            _repo.Delete(id);
        }
    }
}