using HRnetApi.Data;
using HRnetApi.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;

namespace HRnetApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<AppDbContext>(
                options => options.UseInMemoryDatabase("EmployeeDb")
                );

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyCors", builder =>
                {
                    //4200 usual port for angular server
                    builder.WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });

            //add the employee repository to the DI (dependency injection).
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            //AddScoped - for every new http request it creates a new EmployeeRepository instance
            //an advantage is when we create tests. we could scope over a mock repository: 
            //builder.Services.AddScoped<IEmployeeRepository, MockEmployeeRepository>();

            builder.Services.AddControllers();

            //swagger settings
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            //swagger usage
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c=> 
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
                    c.RoutePrefix = string.Empty;
                });
            }

            app.UseCors("MyCors");

            app.MapControllers();

            app.Run();
        }
    }
}
