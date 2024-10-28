using Domain.OrderHistory;
using Domain.Order;
using Domain.User; 
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class OrderHistoryConfiguration : IEntityTypeConfiguration<OrderHistory>
    {
        public void Configure(EntityTypeBuilder<OrderHistory> builder)
        {
            builder.HasKey(oh => oh.Id);
            builder.Property(oh => oh.Id).HasConversion(oh => oh.Value, oh => new OrderHistoryId(oh));
            builder.Property(oh => oh.UserId).IsRequired();

            builder
                .HasMany<Order>() 
                .WithOne()
                .HasForeignKey(oh => oh.UserId);
        }
    }
}