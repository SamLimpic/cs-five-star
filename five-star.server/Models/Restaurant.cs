using System;
using System.ComponentModel.DataAnnotations;
using five_star.server.Interfaces;

namespace five_star.server.Models
{
    public class Restaurant : IItem
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }



        public string CreatorId { get; set; }

        [Required]
        [MinLength(1)]
        public string Name { get; set; }

        [Required]
        [MinLength(1)]
        public string Location { get; set; }

        public Profile Creator { get; set; }
    }
}