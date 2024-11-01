using Domain.User;
using Domain.UserInfo;
using Domain.Addres;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

// User Configuration
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasConversion(u => u.Value, u => new UserId(u));
        builder.Property(u => u.FirstName).IsRequired().HasColumnType("varchar(100)");
        builder.Property(u => u.LastName).IsRequired().HasColumnType("varchar(100)");
        builder.Property(u => u.Email).IsRequired().HasColumnType("varchar(255)");

        // Index for faster lookups on Email
        builder.HasIndex(u => u.Email).IsUnique();

        builder.HasOne(u => u.UsersInfo)
            .WithOne()
            .HasForeignKey<UsersInfo>(ui => ui.UserId)
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete
    }
}

// UsersInfo Configuration
public class UsersInfoConfiguration : IEntityTypeConfiguration<UsersInfo>
{
    public void Configure(EntityTypeBuilder<UsersInfo> builder)
    {
        builder.HasKey(ui => ui.UserId);
        builder.Property(ui => ui.Email).IsRequired().HasColumnType("varchar(255)");
        builder.Property(ui => ui.PhoneNumber).HasColumnType("varchar(20)");
        builder.Property(ui => ui.CreatedAt).IsRequired().HasDefaultValueSql("GETUTCDATE()");
        builder.Property(ui => ui.UpdatedAt).IsRequired().HasDefaultValueSql("GETUTCDATE()");

        builder.HasOne(ui => ui.Address)
            .WithOne()
            .HasForeignKey<UsersInfo>(ui => ui.AddressId)
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete for Address
    }
}

// Address Configuration
public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Street).IsRequired().HasColumnType("varchar(200)");
        builder.Property(a => a.City).IsRequired().HasColumnType("varchar(100)");
        builder.Property(a => a.State).IsRequired().HasColumnType("varchar(50)");
        builder.Property(a => a.PostalCode).IsRequired().HasColumnType("varchar(20)");

        // Index for PostalCode
        builder.HasIndex(a => a.PostalCode);
    }
}
