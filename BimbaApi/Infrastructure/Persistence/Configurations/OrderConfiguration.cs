using Domain.Order;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).HasConversion(o => o.Value, o => new OrderId(o));
            builder.Property(o => o.Status).IsRequired().HasColumnType("varchar(50)");

            builder
                .HasMany(o => o.Items)
                .WithOne()
                .HasForeignKey(oi => oi.OrderId); // Упевніться, що OrderItem також має поле OrderId
        }
    }
}