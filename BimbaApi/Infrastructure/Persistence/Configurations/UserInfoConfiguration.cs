using Domain.UserInfo;
using Domain.Address;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class UserInfoConfiguration : IEntityTypeConfiguration<UserInfo>
{
    public void Configure(EntityTypeBuilder<UserInfo> builder)
    {
        builder.HasKey(ui => ui.Id);
        builder.Property(ui => ui.Id).HasConversion(ui => ui.Value, ui => new UserInfoId(ui));
        builder.Property(ui => ui.AddressId).IsRequired(false);
        
        builder.HasOne(ui => ui.Address)
            .WithMany()
            .HasForeignKey(ui => ui.AddressId);
    }
}