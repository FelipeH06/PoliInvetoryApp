using Microsoft.EntityFrameworkCore;
using PoliInventory.Domain.Entities;
using System.Reflection;

namespace PoliInventory.Infrastructure.Configuration
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public virtual DbSet<CategoryEntity> CategoryEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Registrar todos los modelos
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
