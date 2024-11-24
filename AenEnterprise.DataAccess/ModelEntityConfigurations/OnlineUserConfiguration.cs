using AenEnterprise.DomainModel.UserDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class OnlineUserConfiguration : IEntityTypeConfiguration<OnlineUser>
{
    public void Configure(EntityTypeBuilder<OnlineUser> builder)
    {
        // Specify the table name
        builder.ToTable("OnlineUsers");

        // Specify primary key
        builder.HasKey(ou => ou.Id);

        // Configure properties
        builder.Property(ou => ou.Username)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(ou => ou.LoginTime)
               .IsRequired();

        builder.Property(ou => ou.ExpirationTime)
               .IsRequired();

        // Add any other constraints or configurations if needed
    }
}
