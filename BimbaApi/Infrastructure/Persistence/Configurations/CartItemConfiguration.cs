using Domain.Cart;
using Domain.CartItem;
using Domain.MenuItem;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class CartItemConfiguration : IEntityTypeConfiguration<CartItems>
{
    public void Configure(EntityTypeBuilder<CartItems> builder)
    {
        builder.HasKey(ci => ci.Id);
        builder.Property(ci => ci.Id).HasConversion(ci => ci.Value, ci => new CartItemId(ci));
        builder.Property(ci => ci.Quantity).IsRequired();

        builder.HasOne<MenuItems>()
            .WithMany()
            .HasForeignKey(ci => ci.MenuItemId);
    }
}