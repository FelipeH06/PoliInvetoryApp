using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PoliInventory.Domain.Entities;

namespace PoliInventory.Infrastructure.Configuration.DbMappers
{
    public class CategoryMap : IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.ToTable("Category");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Description).HasMaxLength(2000);
            builder.Property(x => x.State).IsRequired();
            builder.Property(x => x.CreationDate).HasColumnType("datetime");
        }
    }
}
