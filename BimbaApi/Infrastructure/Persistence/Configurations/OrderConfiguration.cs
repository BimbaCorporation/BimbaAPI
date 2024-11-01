using Domain.Order;
using Domain.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Orders>
    {
        public void Configure(EntityTypeBuilder<Orders> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).HasConversion(o => o.Value, o => new OrderId(o));
            builder.Property(o => o.Status).IsRequired().HasColumnType("varchar(50)");

            builder
                .HasMany(o => o.Items)
                .WithOne()
                .HasForeignKey(oi => oi.OrderId); // Упевніться, що OrderItem також має поле OrderId
            builder.HasOne(u => u.User)
                .WithMany()
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}