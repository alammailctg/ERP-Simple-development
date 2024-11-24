using AenEnterprise.DomainModel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DataAccess.ModelEntityConfigurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            // Primary Key
            builder.HasKey(c => c.Id);

            // Properties
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(c => c.RegistrationNumber)
                .HasMaxLength(50);

            builder.Property(c => c.TaxIdentifier)
                .HasMaxLength(50);

            builder.Property(c => c.IndustryType)
                .HasMaxLength(100);

            builder.Property(c => c.CompanyAddress)
                .HasMaxLength(200);

            builder.Property(c => c.Country)
                .HasMaxLength(50);

            builder.Property(c => c.CompanyEmail)
                .HasMaxLength(100);

            builder.Property(c => c.CompanyPhone)
                .HasMaxLength(20);

            builder.Property(c => c.AnnualRevenue)
                .HasColumnType("decimal(18,2)");

            // Relationships
            builder.HasMany(c => c.Branches)
                .WithOne(b => b.Company)
                .HasForeignKey(b => b.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.AccountGroups)
                .WithOne(ag => ag.Company)
                .HasForeignKey(ag => ag.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.JournalEntries)
                .WithOne(je => je.Company)
                .HasForeignKey(je => je.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            // Seed Data
            builder.HasData(
                new Company
                {
                    Id = 1,
                    Name = "AEN Enterprise",
                    RegistrationNumber = "REG123456",
                    TaxIdentifier = "TAX123456",
                    IndustryType = "ERP Solutions",
                    CompanyAddress = "123 Main Street, Dhaka, Bangladesh",
                    Country = "Bangladesh",
                    CompanyEmail = "info@aenenterprise.com",
                    CompanyPhone = "+880123456789",
                    IncorporationDate = new DateTime(2020, 1, 1),
                    AnnualRevenue = 10000000.00m,
                    CreatedDate = DateTime.Now,
                    ExpiryDate = DateTime.Now.AddYears(5),
                    IsPrimary = true,
                    IsPubliclyListed = false,
                    IsDeleted = false,
                    IsMultipleWareHouse = true
                }
            );
        }
    }
}
