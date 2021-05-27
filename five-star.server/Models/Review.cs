using System;
using System.ComponentModel.DataAnnotations;
using five_star.server.Interfaces;

namespace five_star.server.Models
{
    public class Review : IItem
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }



        public string Title { get; set; }

        public string Body { get; set; }

        public string Owner { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

    }
}