//using Microsoft.EntityFrameworkCore;
//using ScoutX.Application.Players.Interfaces;
//using ScoutX.Application.Players.Services;
//using ScoutX.Domain.Interfaces;
//using ScoutX.Infrastructure.Persistence;
//using ScoutX.Infrastructure.Repositories;

//namespace ScoutX.API
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            var builder = WebApplication.CreateBuilder(args);

//            builder.Services.AddDbContext<AppDbContext>(options =>
//            {
//                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
//            });

//            builder.Services.AddScoped<IPlayerService, PlayerService>();
//            builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();

//            // Add services to the container.

//            builder.Services.AddControllers();
//            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//            builder.Services.AddOpenApi();

//            var app = builder.Build();

//            // Configure the HTTP request pipeline.
//            if (app.Environment.IsDevelopment())
//            {
//                app.MapOpenApi();
//            }

//            app.UseHttpsRedirection();

//            app.UseAuthorization();


//            app.MapControllers();

//            app.Run();
//        }
//    }
//}

using Microsoft.EntityFrameworkCore;
using ScoutX.Application.Players.Interfaces;
using ScoutX.Application.Players.Services;
using ScoutX.Domain.Interfaces;
using ScoutX.Infrastructure.Persistence;
using ScoutX.Infrastructure.Repositories;

namespace ScoutX.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            // Veritabaný baðlantýsý
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                x => x.MigrationsAssembly("ScoutX.Infrastructure")); // Önemli satýr
            });

            // Baðýmlýlýklarý ekle
            builder.Services.AddScoped<IPlayerService, PlayerService>();
            builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();

            // Controller servisi
            builder.Services.AddControllers();

            // Swagger servisi (doðru olan bu)
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Swagger arayüzü (geliþtirme ortamý için)
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("AllowAll");
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}

