
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using VacationRequester.Data;
using VacationRequester.Repositories.Interfaces;
using VacationRequester.Repositories;
using VacationRequester.Middleware;

namespace VacationRequester
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            //

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            //Add bearer token UI
            SwaggerAuthentication.UseSwaggerAuthentication(builder);

            //Add Cors
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowMyOrigin",
                builder => builder.WithOrigins("http://localhost:5173") // Your client app's URL here
                                   .AllowAnyHeader()
                                   .AllowAnyMethod());
            });

            //Connection String
            builder.Services.AddDbContext<AppDbContext>(options =>
                        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            //Serivces


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowMyOrigin");
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}