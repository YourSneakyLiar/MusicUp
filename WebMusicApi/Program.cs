
using Domain.Models;
using System.Reflection;
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Domain.Interfaces;
using BusinessLogic.Services;

namespace WebMusicApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Register DbContext
            builder.Services.AddDbContext<Domain.Models.WebMusicAppContext>(
                options => options.UseSqlServer(builder.Configuration["ConnectionString"]));



            // Register repositories
            builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            builder.Services.AddScoped<IUserService, UserService>();



            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();


           using(var scope = app.Services.CreateScope())
           {
               var services = scope.ServiceProvider;

               var context = services.GetRequiredService<WebMusicAppContext>();
                context.Database.Migrate();

           }




           // Configure the HTTP request pipeline.
            // if (app.Environment.IsDevelopment())
             {
               app.UseSwagger();
               app.UseSwaggerUI();

             }


            app.UseCors(builder => builder.WithOrigins(new[] { "https://webmusicapi.onrender.com", })
                                                    .AllowAnyHeader() 
                                                    .AllowAnyMethod()
                                                    .AllowAnyOrigin());

            

           // app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}