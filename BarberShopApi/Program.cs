using BarberShopApi.Data;
using BarberShopApi.Endpoints;
using Microsoft.EntityFrameworkCore;

namespace BarberShopApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        builder.Services.AddDbContext<BarberShopApiDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });
        
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();
        
        app.Use(async (context, next) =>
        {
            Console.WriteLine("Request Received.");
            var configuredApiKey = builder.Configuration["ApiKey"];
            var apiKey = context.Request.Headers["X-API-Key"].FirstOrDefault();

            if (apiKey != configuredApiKey)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Unauthorized");
                return;
            }

            await next(context);
        });
        
        BookingEndpoints.RegisterEndpoints(app);
        
        app.Run();
    }
}