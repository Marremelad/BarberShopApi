using BarberShopApi.Data;
using BarberShopApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BarberShopApi.Endpoints;

public class BookingEndpoints
{
    public static void RegisterEndpoints(WebApplication app)
    {
        app.MapGet("/bookings", async (BarberShopApiDbContext context) =>
        {
            return Results.Ok(
                await context.Bookings
                    .Select(b => new
                    {
                        b.Id,
                        b.Date,
                        b.Time,
                        Customer = $"{b.Customer.FirstName} {b.Customer.LastName}",
                        Employee = $"{b.Employee.FirstName} {b.Employee.LastName}"
                    })
                    .ToListAsync()
            );
        });

        app.MapDelete("/delete-booking/{id:int}", async (BarberShopApiDbContext context, int id) =>
        {
            var booking = await context.Bookings
                .Where(b => b.Id == id)
                .FirstOrDefaultAsync();

            if (booking == null) return Results.NotFound("Not found");

            context.Bookings.Remove(booking);
            await context.SaveChangesAsync();

            return Results.Ok("Booking deleted successfully");
        });
    }
}