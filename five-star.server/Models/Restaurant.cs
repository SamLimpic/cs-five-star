using System;
using five_star.server.Interfaces;

namespace five_star.server.Models
{
    public class Restaurant : IItem
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }



        public string CreatorId { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

    }
}