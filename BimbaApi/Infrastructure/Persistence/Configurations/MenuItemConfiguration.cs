using Domain.MenuItem;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class MenuItemConfiguration : IEntityTypeConfiguration<MenuItems>
{
    public void Configure(EntityTypeBuilder<MenuItems> builder)
    {
        // Вказати первинний ключ
        builder.HasKey(mi => mi.Id);

        builder.Property(mi => mi.Id)
            .HasConversion(id => id.Value, value => new MenuItemId(value));

        builder.Property(mi => mi.Name)
            .IsRequired()
            .HasColumnType("varchar(255)");

        builder.Property(mi => mi.Price)
            .IsRequired()
            .HasColumnType("decimal(10, 2)");

        builder.Property(mi => mi.Description)
            .HasColumnType("varchar(500)");

        builder.Property(mi => mi.IsAvailable)
            .IsRequired();
    }
}