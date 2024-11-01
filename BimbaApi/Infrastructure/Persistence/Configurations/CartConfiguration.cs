using Domain.Cart;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class CartConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.Property(a => a.CartId)
            .HasConversion(id => id.Value, value => new CartId(value));
        builder
            .HasMany(c => c.Items)
            .WithOne()
            .HasForeignKey(ci => ci.MenuItemId); 
    }
}