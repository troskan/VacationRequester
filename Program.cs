
using Microsoft.EntityFrameworkCore;
using VacationRequester.Data;
using VacationRequester.Repositories.Interfaces;
using VacationRequester.Repositories;
using VacationRequester.Middleware;
using VacationRequester.Middleware.Cors;
using VacationRequester.Services;
using VacationRequester.Middleware.Authentication;

namespace VacationRequester
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped(typeof(IAuthenticationRepository), typeof(AuthenticationRepository));
            builder.Services.AddScoped(typeof(ILeaveRequestRepository), typeof(LeaveRequestRepository));



            //Jwt Services
            builder.Services.AddScoped<JwtService>();
            AuthenticationMiddleware.AddAuthenticationJwt(builder);

            builder.Services.AddControllers();
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
            app.Use(async (context, next) =>
            {
                await Console.Out.WriteLineAsync("Inside the app middleware");
                Console.WriteLine($"User authenticated: {context.User.Identity.IsAuthenticated}");
                await next();
            });

            app.UseCors("AllowMyOrigin");
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
            app.Use(async (context, next) =>
            {
                Console.WriteLine($"User authenticated: {context.User.Identity.IsAuthenticated}");
                await next();
            });

            app.Run();
        }
    }
}