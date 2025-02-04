using System;
using System.Collections.Generic;
using VideoRentalShopAPI.Models;

public class Movie
{
    public int MovieId { get; set; }
    public string? Title { get; set; }
    public string? Genre { get; set; }
    public int? ReleaseYear { get; set; }
    public string? Director { get; set; }
    public string? Description { get; set; }
    public int Stock { get; set; }  // Number of copies available

    public ICollection<RentalDetail>? RentalDetails { get; set; }
    // Navigation Property: A movie can be rented multiple times
}
