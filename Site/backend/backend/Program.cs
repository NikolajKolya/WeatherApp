
namespace backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            
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