using ApiCatalogo.Context;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace ApiCatalogo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ApiCatalogoDbContext>(option =>
            option.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));

            // Add services to the container.

            builder.Services.AddControllers()
                .AddJsonOptions(options =>
            options.JsonSerializerOptions
            .ReferenceHandler = ReferenceHandler.IgnoreCycles);
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

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}