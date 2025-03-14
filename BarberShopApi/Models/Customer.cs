﻿using System.ComponentModel.DataAnnotations;

namespace BarberShopApi.Models;

public class Customer
{
    [Key]
    public int Id { get; set; }

    [StringLength(35)]
    public required string FirstName { get; set; }

    [StringLength(35)]
    public required string LastName { get; set; }

    [StringLength(254)]
    public required string Email { get; set; }
    
    public virtual List<Booking>? Bookings { get; set; }
}