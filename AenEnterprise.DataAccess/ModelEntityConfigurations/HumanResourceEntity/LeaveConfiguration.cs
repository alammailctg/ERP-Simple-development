using AenEnterprise.DomainModel.HumanResources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AenEnterprise.DataAccess.ModelEntityConfigurations.HumanResourceEntity
{
    public class LeaveConfiguration : IEntityTypeConfiguration<Leave>
    {
        public void Configure(EntityTypeBuilder<Leave> builder)
        {
            // Primary Key
            builder.HasKey(l => l.Id);

            // Required Fields
            builder.Property(l => l.LeaveFrom)
                   .IsRequired();

            builder.Property(l => l.LeaveTo)
                   .IsRequired();

            builder.Property(l => l.LeaveTypeId)
                   .IsRequired();

            // Optional Fields with length constraints
            builder.Property(l => l.ReasonForLeave)
                   .HasMaxLength(500);

            builder.Property(l => l.PlaceDuringLeave)
                   .HasMaxLength(100);

            // Relationship with LeaveType
            builder.HasOne(l => l.LeaveType)
                   .WithMany()
                   .HasForeignKey(l => l.LeaveTypeId)
                   .OnDelete(DeleteBehavior.Restrict); // Set DeleteBehavior as needed
            // Optional Field for ApplyingDate
            builder.Property(l => l.ApplyingDate)
                   .HasDefaultValueSql("GETDATE()"); // Sets default to current date
        }
    }
}
