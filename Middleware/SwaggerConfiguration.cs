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
                    In = ParameterLocation.Header,
                    Description = "Please enter token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"

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
