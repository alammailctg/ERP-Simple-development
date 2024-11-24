using AenEnterprise.DomainModel.UserDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        // Configure composite key
        builder.HasKey(ur => new { ur.UserId, ur.RoleId });

        builder.HasOne(ur => ur.User)
            .WithMany(u => u.UserRoles)
            .HasForeignKey(ur => ur.UserId)
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete on User side

        builder.HasOne(ur => ur.Role)
            .WithMany(r => r.UserRoles)
            .HasForeignKey(ur => ur.RoleId)
            .OnDelete(DeleteBehavior.Restrict); // Restrict delete on Role side

        // Seed data for UserRole
        builder.HasData(
            new UserRole
            {
                UserId = 1,  // Assuming UserId 1 is Admin
                RoleId = 1   // RoleId 1 is Admin role
            }
        );
    }
}
