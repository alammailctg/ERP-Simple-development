using AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AenEnterprise.DataAccess.ModelEntityConfigurations
{
    public class AccountGroupConfiguration : IEntityTypeConfiguration<AccountGroup>
    {
        public void Configure(EntityTypeBuilder<AccountGroup> builder)
        {
            // Table Name
            builder.ToTable("AccountGroups");

            // Primary Key
            builder.HasKey(ag => ag.AccountGroupId);

            // Properties
            builder.Property(ag => ag.AccountGroupId)
                .ValueGeneratedOnAdd(); // Auto-increment

            builder.Property(ag => ag.AccountName)
                .IsRequired()
                .HasMaxLength(100); 

            builder.Property(ag => ag.AccountNumber)
                .IsRequired()
                .HasMaxLength(50); 

            builder.Property(ag => ag.Balance)
                .HasColumnType("decimal(18,2)"); 

            builder.Property(ag => ag.AccountCode)
                .HasMaxLength(20);

            // Relationships
            builder.HasOne(ag => ag.AccountType)
                .WithMany(at => at.AccountGroups) 
                .HasForeignKey(ag => ag.AccountTypeId)
                .OnDelete(DeleteBehavior.Restrict); 

            builder.HasOne(ag => ag.Company)
                .WithMany(c => c.AccountGroups) 
                .HasForeignKey(ag => ag.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ag => ag.Branch)
                .WithMany(b => b.AccountGroups) 
                .HasForeignKey(ag => ag.BranchId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(ag => ag.LedgerPostings)
                .WithOne(lp => lp.AccountGroup) 
                .HasForeignKey(lp => lp.AccountGroupId)
                .OnDelete(DeleteBehavior.Restrict);

    
            builder.HasData(
                new AccountGroup
                {
                    AccountGroupId = 1,
                    AccountName = "Cash in Hand",
                    AccountNumber = "1001",
                    Balance = 10000.00m,
                    AccountCode = "CASH",
                    AccountTypeId = 1, // Make sure these IDs exist in the AccountType table
                    CompanyId = 1,     // Make sure these IDs exist in the Company table
                    BranchId = 1       // Make sure these IDs exist in the Branch table
                },
                new AccountGroup
                {
                    AccountGroupId = 2,
                    AccountName = "Inventory",
                    AccountNumber = "2001",
                    Balance = 50000.00m,
                    AccountCode = "INV",
                    AccountTypeId = 2, // Make sure these IDs exist in the AccountType table
                    CompanyId = 1,     // Make sure these IDs exist in the Company table
                    BranchId = 1       // Make sure these IDs exist in the Branch table
                }
            );
        }
    }

}
