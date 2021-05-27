using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using five_star.server.Models;
using five_star.server.Interfaces;

namespace five_star.server.Repositories
{
    public class RestaurantsRepository : IRepository<Restaurant>
    {
        private readonly IDbConnection _db;

        public RestaurantsRepository(IDbConnection db)
        {
            _db = db;
        }



        public List<Restaurant> GetAll()
        {
            string sql = @"
                SELECT
                g.*
                a.*
                FROM restaurants g
                JOIN accounts a ON g.___ = a.Id
                ";
            return _db.Query<Restaurant, Account, Restaurant>(sql, (restaurant, account) =>
            {
                // restaurant.Creator = account;
                return restaurant;
            }, splitOn: "id").ToList();
        }



        public Restaurant GetById(int id)
        {
            string sql = @"
                SELECT 
                g.*,
                a.* 
                FROM restaurants g
                JOIN accounts a ON g.creatorId = a.id
                WHERE g.id = @id
                ";
            return _db.Query<Restaurant, Account, Restaurant>(sql, (restaurant, account) =>
            {
                restaurant.Owner = account;
                return restaurant;
            }
            , new { id }, splitOn: "id").FirstOrDefault();
        }



        public Restaurant Create(Restaurant data)
        {
            string sql = @"
                INSERT INTO restaurants
                (creatorId, name, location)
                VALUES
                (@CreatorId, @Name, @Location)
                SELECT LAST_INSERT_ID()
                ";
            data.Id = _db.ExecuteScalar<int>(sql, data);
            return data;
        }



        public bool Update(Restaurant data)
        {
            string sql = @"
            UPDATE restaurants
            SET
                creatorId = @CreatorId,
                name = @Name,
                location = @Location
            WHERE id = @id";
            int affectedRows = _db.Execute(sql, data);
            return affectedRows == 1;
        }



        public bool Delete(int id)
        {
            string sql = "DELETE FROM restaurants WHERE id = @id LIMIT 1";
            int affectedRows = _db.Execute(sql, new { id });
            return affectedRows == 1;
        }

    }
}