using System;
using System.Collections.Generic;
using VideoRentalShopAPI.Models;

public class Customer
{
    public int CustomerId { get; set; }
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string? Address { get; set; }

    public ICollection<RentalHeader>? RentalHeaders { get; set; }
   

    // Navigation Property: A Customer can have multiple rentals
}
