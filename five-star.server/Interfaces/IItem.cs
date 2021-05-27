using System;

namespace five_star.server.Interfaces
{
    public interface IItem
    {
        int Id { get; set; }
        DateTime CreatedAt { get; set; }
        DateTime UpdatedAt { get; set; }
    }
}