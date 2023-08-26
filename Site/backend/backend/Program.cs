
using backend.Dao;
using backend.Dao.Abstract;
using backend.Dao.Implementations;
using backend.Mappers.Abstract;
using backend.Mappers.Implementations;
using backend.Services.Abstract;
using backend.Services.Implementations;
using Microsoft.EntityFrameworkCore;

namespace backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            
            #region  DB Contexts

            // Main
            builder.Services.AddDbContext<MainDbContext>
            (
                options
                    =>
                    options.UseNpgsql(builder.Configuration.GetConnectionString("MainConnection"), o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)), ServiceLifetime.Transient
            );

            #endregion
            
            #region CORS
            // CORS
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy
                (
                    policy =>
                    {
                        policy.WithOrigins
                        (
                            "http://localhost:8080"
                        );
                    }
                );
            });
            #endregion

            #region DI

            builder.Services.AddScoped<IWeatherDao, WeatherDao>();
            builder.Services.AddScoped<IWeatherService, WeatherService>();
            builder.Services.AddScoped<IExternalSourceWeatherService, ExternalSourceWeatherService>();

            builder.Services.AddSingleton<IWeatherMapper, WeatherMapper>();

            #endregion
            
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.UseCors();
            
            app.Run();
        }
    }
}