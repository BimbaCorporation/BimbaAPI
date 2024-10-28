using Domain.Address;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id).HasConversion(a => a.Value, a => new AddressId(a));
        builder.Property(a => a.Street).IsRequired().HasColumnType("varchar(255)");
        builder.Property(a => a.City).IsRequired().HasColumnType("varchar(100)");
        builder.Property(a => a.State).IsRequired().HasColumnType("varchar(100)");
        builder.Property(a => a.PostalCode).IsRequired().HasColumnType("varchar(20)");
    }
}