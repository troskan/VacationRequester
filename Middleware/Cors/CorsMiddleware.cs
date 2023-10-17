namespace VacationRequester.Middleware.Cors
{
    public static class CorsMiddleware
    {
        public static void AddCors(WebApplicationBuilder builder, IConfiguration configuration)
        {
            var corsSettings = new CorsSettings();
            configuration.GetSection("Cors").Bind(corsSettings);

            builder.Services.AddSingleton(corsSettings);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowMyOrigin",
                builder => builder.WithOrigins(corsSettings.AllowedOrigins)
                                  .AllowAnyHeader()
                                  .AllowAnyMethod());
            });
        }
    }
}