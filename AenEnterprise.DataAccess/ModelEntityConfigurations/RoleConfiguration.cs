using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AenEnterprise.DomainModel.UserDomain
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            // Configure primary key
            builder.HasKey(r => r.Id);

            // Configure properties
            builder.Property(r => r.RoleName)
                   .IsRequired()
                   .HasMaxLength(100); // Example max length

            builder.Property(r => r.CreatedDate)
                   .IsRequired();

            builder.Property(r => r.ModifiedDate)
                   .IsRequired();

            builder.Property(r => r.RoleDescription)
                   .HasMaxLength(500); // Example max length
                                       // Seed data for Role
            builder.HasData(
                new Role
                {
                    Id = 1,
                    RoleName = "Admin",
                    CreatedDate = DateTime.UtcNow,
                    ModifiedDate = DateTime.UtcNow,
                    RoleDescription = "Administrator with full access to system"
                },
                new Role
                {
                    Id = 2,
                    RoleName = "Manager",
                    CreatedDate = DateTime.UtcNow,
                    ModifiedDate = DateTime.UtcNow,
                    RoleDescription = "Manager with access to oversee operations"
                },
                new Role
                {
                    Id = 3,
                    RoleName = "User",
                    CreatedDate = DateTime.UtcNow,
                    ModifiedDate = DateTime.UtcNow,
                    RoleDescription = "Regular user with limited access"
                },
                new Role
                {
                    Id = 4,
                    RoleName = "Guest",
                    CreatedDate = DateTime.UtcNow,
                    ModifiedDate = DateTime.UtcNow,
                    RoleDescription = "Guest user with read-only access"
                }
            );

        }
    }
}
