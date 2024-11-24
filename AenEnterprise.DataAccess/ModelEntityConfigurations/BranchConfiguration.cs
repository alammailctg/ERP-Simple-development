using AenEnterprise.DomainModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AenEnterprise.DataAccess.ModelEntityConfigurations
{
    public class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            // Primary Key
            builder.HasKey(b => b.BranchId);

            // Properties
            builder.Property(b => b.BranchName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(b => b.BranchAddress)
                .HasMaxLength(200);

            builder.Property(b => b.City)
                .HasMaxLength(50);

            builder.Property(b => b.State)
                .HasMaxLength(50);

            builder.Property(b => b.PostalCode)
                .HasMaxLength(20);

            builder.Property(b => b.BranchEmail)
                .HasMaxLength(100);

            builder.Property(b => b.BranchPhone)
                .HasMaxLength(20);

            // Relationships
            builder.HasOne(b => b.Company)
                .WithMany(c => c.Branches)
                .HasForeignKey(b => b.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            // Seed Data
            builder.HasData(
                new Branch
                {
                    BranchId = 1,
                    BranchName = "Dhaka Branch",
                    BranchAddress = "456 Central Road, Dhaka, Bangladesh",
                    City = "Dhaka",
                    State = "Dhaka Division",
                    PostalCode = "1205",
                    BranchEmail = "dhaka.branch@aenenterprise.com",
                    BranchPhone = "+880987654321",
                    OpeningDate = new DateTime(2021, 1, 1),
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                    CompanyId = 1 // Assuming this branch belongs to the Company with Id = 1
                }
            );
        }
    }
}
