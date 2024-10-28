using Domain.User;
using Domain.UserInfo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasConversion(u => u.Value, u => new UserId(u));
        builder.Property(u => u.FirstName).IsRequired().HasColumnType("varchar(100)");
        builder.Property(u => u.LastName).IsRequired().HasColumnType("varchar(100)");
        builder.Property(u => u.Email).IsRequired().HasColumnType("varchar(255)");

        builder.HasOne(u => u.UserInfo)
            .WithOne()
            .HasForeignKey<UserInfo>(ui => ui.UserId);
    }
}