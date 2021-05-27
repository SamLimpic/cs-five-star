using System.ComponentModel.DataAnnotations;

namespace five_star.server.Models
{
    public class Review
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public string Owner { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }
    }
}