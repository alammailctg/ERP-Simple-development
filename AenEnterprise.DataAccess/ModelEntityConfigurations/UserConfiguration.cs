using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AenEnterprise.DomainModel.UserDomain
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Configure primary key
            builder.HasKey(u => u.Id);

            // Configure properties
            builder.Property(u => u.Username)
                   .IsRequired()
                   .HasMaxLength(100); // Example

            builder.Property(u => u.PasswordHash)
                   .IsRequired();

            builder.Property(u => u.PasswordSalt)
                   .IsRequired();

            builder.Property(u => u.RefreshToken)
                   .HasMaxLength(500); // Example max length

            builder.Property(u => u.TokenCreated)
                   .IsRequired();

            builder.Property(u => u.TokenExpires)
                   .IsRequired();

            builder.Property(u => u.Password)
                   .HasMaxLength(100); // Example

            // Configure one-to-many relationship between User and UserRole
            builder.HasMany(u => u.UserRoles)
                   .WithOne(ur => ur.User)
                   .HasForeignKey(ur => ur.UserId)
                   .OnDelete(DeleteBehavior.Cascade); // Use as per your requirements

            // Seed data: Adding one row of data
            builder.HasData(new User
            {
                Id = 1,
                Username = "admin",
                PasswordHash = new byte[] { }, // Example: you should use a real hash
                PasswordSalt = new byte[] { }, // Example: you should use a real salt
                RefreshToken = "sample_refresh_token",
                TokenCreated = DateTime.UtcNow,
                TokenExpires = DateTime.UtcNow.AddDays(7),
                Password = "1234" // Example: Ideally, password hashing should be done
            });
        }
    }
}
