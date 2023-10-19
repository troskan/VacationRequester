using Microsoft.OpenApi.Models;

namespace VacationRequester.Middleware
{
    public static class SwaggerConfiguration
    {
        public static void UseSwaggerAuthentication(WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Cookie, // Set to Cookie since JWT comes from cookie
                    Description = "Please enter token",
                    Name = "AccessToken",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                });

                opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                         new OpenApiSecurityScheme
                        {
                        Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
            });
        }
    }
}
