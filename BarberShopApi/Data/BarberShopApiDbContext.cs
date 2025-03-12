using Microsoft.EntityFrameworkCore;

namespace BarberShopApi.Data;

public class BarberShopApiDbContext(DbContextOptions<BarberShopApiDbContext> options) 
    : DbContext(options)
{
    
}