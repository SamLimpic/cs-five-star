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
                r.*
                a.name,
                a.picture
                FROM restaurants r
                JOIN accounts a ON r.creatorId = a.id
                ";
            return _db.Query<Restaurant, Account, Restaurant>(sql, (restaurant, account) =>
            {
                restaurant.Creator = account;
                return restaurant;
            }, splitOn: "id").ToList();
        }



        public Restaurant GetById(int id)
        {
            string sql = @"
                SELECT 
                r.*,
                a.name,
                a.picture 
                FROM restaurants r
                JOIN accounts a ON r.creatorId = a.id
                WHERE r.id = @id
                ";
            return _db.Query<Restaurant, Account, Restaurant>(sql, (restaurant, account) =>
            {
                restaurant.Creator = account;
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



        public Restaurant Update(Restaurant edit)
        {
            string sql = @"
            UPDATE restaurants
            SET
                name = @Name,
                location = @Location
            WHERE id = @Id";
            _db.Execute(sql, edit);
            return edit;
        }



        public void Delete(int id)
        {
            string sql = "DELETE FROM restaurants WHERE id = @id LIMIT 1";
            _db.Execute(sql, new { id });
        }
    }
}