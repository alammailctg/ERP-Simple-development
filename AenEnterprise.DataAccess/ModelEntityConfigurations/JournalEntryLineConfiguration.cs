using AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger;

namespace AenEnterprise.DataAccess.ModelEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class JournalEntryLineConfiguration : IEntityTypeConfiguration<JournalEntryLine>
    {
        public void Configure(EntityTypeBuilder<JournalEntryLine> builder)
        {
            // Table Name
            builder.ToTable("JournalEntryLines");

            // Primary Key
            builder.HasKey(jel => jel.JournalEntryLineId);

            // Properties
            builder.Property(jel => jel.JournalEntryLineId)
                .ValueGeneratedOnAdd(); // Auto-increment

            builder.Property(jel => jel.Description)
                .HasMaxLength(500); // Limit length of description

            builder.Property(jel => jel.DebitAmount)
                .HasColumnType("decimal(18,2)"); // Precision for currency values

            builder.Property(jel => jel.CreditAmount)
                .HasColumnType("decimal(18,2)"); // Precision for currency values

           

            builder.Property(jel => jel.CreatedDate)
                .HasDefaultValueSql("GETDATE()"); // SQL default value for created date

            // Relationships
            builder.HasOne(jel => jel.JournalEntry)
                .WithMany(je => je.JournalEntryLines) // Assuming JournalEntry has a collection of JournalEntryLines
                .HasForeignKey(jel => jel.JournalEntryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(jel => jel.AccountGroup)
                .WithMany(ag => ag.JournalEntryLines) // Assuming AccountGroup has a collection of JournalEntryLines
                .HasForeignKey(jel => jel.AccountGroupId)
                .OnDelete(DeleteBehavior.Restrict);

            // Seed data
            builder.HasData(
                new JournalEntryLine
                {
                    JournalEntryLineId = 1, // Primary Key
                    Description = "Initial Journal Entry",
                    DebitAmount = 1000.00m,
                    CreditAmount = 0.00m,
                    CreatedDate = DateTime.Today,
                    JournalEntryId = 1, // Reference to the parent JournalEntry
                    AccountGroupId = 1 // Reference to the Account if needed
                },
                new JournalEntryLine
                {
                    JournalEntryLineId = 2, // Primary Key
                    Description = "Second Journal Entry",
                    DebitAmount = 0.00m,
                    CreditAmount = 500.00m,
                    CreatedDate = DateTime.Today,
                    JournalEntryId = 1, // Reference to the parent JournalEntry
                    AccountGroupId = 2 // Reference to the Account if needed
                }
            );
        }
    }


}
