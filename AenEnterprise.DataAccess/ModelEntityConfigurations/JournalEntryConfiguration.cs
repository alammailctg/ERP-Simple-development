using AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AenEnterprise.DataAccess.ModelEntityConfigurations
{
    public class JournalEntryConfiguration : IEntityTypeConfiguration<JournalEntry>
    {
        public void Configure(EntityTypeBuilder<JournalEntry> builder)
        {
            // Primary Key
            builder.HasKey(je => je.JournalEntryId);

            // Properties
            builder.Property(je => je.JournalEntryNo)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(je => je.EntryDate)
                .IsRequired();

            builder.Property(je => je.JournalName)
                .HasMaxLength(100);

            builder.Property(je => je.ReferenceNumber)
                .HasMaxLength(50);

            builder.Property(je => je.Description)
                .HasMaxLength(500);

            builder.Property(je => je.CreatedDate)
                .HasDefaultValueSql("GETDATE()");

            // Relationships
            builder.HasOne(je => je.Company)
                .WithMany(c => c.JournalEntries) // Adjust this navigation if needed
                .HasForeignKey(je => je.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(je => je.Branch)
                .WithMany(b => b.JournalEntries) // Adjust this navigation if needed
                .HasForeignKey(je => je.BranchId)
                .OnDelete(DeleteBehavior.Restrict);

            // Navigation properties
            builder.HasMany(je => je.JournalEntryLines)
                .WithOne(jel => jel.JournalEntry)
                .HasForeignKey(jel => jel.JournalEntryId)
                .OnDelete(DeleteBehavior.Cascade);

            // Table Mapping
            builder.ToTable("JournalEntries");

            // Seed Data
            builder.HasData(
                new JournalEntry
                {
                    JournalEntryId = 1,
                    JournalEntryNo = "JE20231101",
                    EntryDate = new DateTime(2023, 11, 1),
                    JournalName = "Opening Balance",
                    ReferenceNumber = "REF123",
                    Description = "Opening balance for the company",
                    CreatedDate = DateTime.Now,
                    CompanyId = 1, 
                    BranchId = 1   
                },
                new JournalEntry
                {
                    JournalEntryId = 2,
                    JournalEntryNo = "JE20231102",
                    EntryDate = new DateTime(2023, 11, 2),
                    JournalName = "Purchase Entry",
                    ReferenceNumber = "REF124",
                    Description = "Purchase of raw materials",
                    CreatedDate = DateTime.Now,
                    CompanyId = 1, 
                    BranchId = 1   
                }
            );
        }
    }
}