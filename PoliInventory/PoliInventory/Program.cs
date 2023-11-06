using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using PoliInventory.Application.Features.Categories;
using PoliInventory.Application.Interfaces;
using PoliInventory.Domain.Entities;
using PoliInventory.Infrastructure.Configuration;
using PoliInventory.Infrastructure.Repositories;
using System.Reflection;

namespace PoliInventory
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            IConfiguration configuration = builder.Configuration;

            // Add DbContext
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Database")));

            // Add services to the container.
            builder.Services.AddTransient<ICategoryService, CategoryService>();

            // Add Repositories
            builder.Services.AddTransient<IGenericRepository<CategoryEntity>, GenericRepository<CategoryEntity>>();

            // Add automapper
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddControllers().AddFluentValidation(v =>
            {
                v.ImplicitlyValidateChildProperties = true;
                v.ImplicitlyValidateRootCollectionElements = true;
                v.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            });

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