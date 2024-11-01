using Domain.MenuItem;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class MenuItemConfiguration : IEntityTypeConfiguration<MenuItems>
{
    public void Configure(EntityTypeBuilder<MenuItems> builder)
    {
        builder.HasKey(mi => mi.Id);
        builder.Property(mi => mi.Id).HasConversion(mi => mi.Value, mi => new MenuItemId(mi));
        builder.Property(mi => mi.Name).IsRequired().HasColumnType("varchar(255)");
        builder.Property(mi => mi.Price).IsRequired().HasColumnType("decimal(10, 2)");
    }
}