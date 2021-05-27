using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using five_star.server.Models;
using five_star.server.Interfaces;

namespace five_star.server.Repositories
{
    public class ReviewsRepository : IRepository<Review>
    {
        private readonly IDbConnection _db;

        public ReviewsRepository(IDbConnection db)
        {
            _db = db;
        }



        public List<Review> GetAll()
        {
            string sql = @"
                SELECT
                g.*
                a.*
                FROM reviews g
                JOIN accounts a ON g.___ = a.Id
                ";
            return _db.Query<Review, Account, Review>(sql, (review, account) =>
            {
                // review.Creator = account;
                return review;
            }, splitOn: "id").ToList();
        }



        public Review GetById(int id)
        {
            string sql = @"
                SELECT 
                g.*,
                a.* 
                FROM reviews g
                JOIN accounts a ON g.creatorId = a.id
                WHERE g.id = @id
                ";
            return _db.Query<Review, Account, Review>(sql, (review, account) =>
            {
                // review.Creator = account;
                return review;
            }
            , new { id }, splitOn: "id").FirstOrDefault();
        }



        public Review Create(Review data)
        {
            string sql = @"
                INSERT INTO reviews
                (title, body, owner, rating)
                VALUES
                (@Title, @Body, @Owner, @Rating)
                SELECT LAST_INSERT_ID()
                ";
            data.Id = _db.ExecuteScalar<int>(sql, data);
            return data;
        }



        public Review Update(Review edit)
        {
            string sql = @"
            UPDATE reviews
            SET
                title = @Title,
                body = @Body,
                owner = @Owner,
                rating = @Rating
            WHERE id = @id";
            _db.Execute(sql, edit);
            return edit;
        }



        public void Delete(int id)
        {
            string sql = "DELETE FROM reviews WHERE id = @id LIMIT 1";
            _db.Execute(sql, new { id });

        }
    }
}