
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using VacationRequester.Data;
using VacationRequester.Repositories.Interfaces;
using VacationRequester.Repositories;
using VacationRequester.Middleware;
using VacationRequester.Middleware.Cors;
using VacationRequester.Services;

namespace VacationRequester
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            builder.Services.AddScoped<JwtService>();
            //

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            //Add bearer token UI
            SwaggerConfiguration.UseSwaggerAuthentication(builder);

            //Add Cors
            CorsMiddleware.AddCors(builder, builder.Configuration);


            //Connection String
            builder.Services.AddDbContext<AppDbContext>(options =>
                        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


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