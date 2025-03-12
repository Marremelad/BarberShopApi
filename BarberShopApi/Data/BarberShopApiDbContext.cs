using BarberShopApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BarberShopApi.Data;

public class BarberShopApiDbContext(DbContextOptions<BarberShopApiDbContext> options) 
    : DbContext(options)
{
    public DbSet<Customer> Customers { get; set; }

    public DbSet<Employee> Employees { get; set; }

    public DbSet<Booking> Bookings { get; set; }
}