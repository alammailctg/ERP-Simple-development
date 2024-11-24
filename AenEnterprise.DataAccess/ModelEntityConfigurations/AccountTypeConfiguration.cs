using AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class AccountTypeConfiguration : IEntityTypeConfiguration<AccountType>
{
    public void Configure(EntityTypeBuilder<AccountType> builder)
    {
        // Define the primary key
        builder.HasKey(at => at.Id);

        // Define property constraints
        builder.Property(at => at.TypeName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(at => at.Description)
            .HasMaxLength(200);

        

        // Seed initial data using HasData
        builder.HasData(
            new AccountType { Id = 1, TypeName = "Asset", Description = "Accounts representing company assets"},
            new AccountType { Id = 2, TypeName = "Liability", Description = "Accounts representing company liabilities"},
            new AccountType { Id = 3, TypeName = "Equity", Description = "Accounts representing owner's equity" },
            new AccountType { Id = 4, TypeName = "Revenue", Description = "Accounts representing company revenues" },
            new AccountType { Id = 5, TypeName = "Expense", Description = "Accounts representing company expenses" }
        );
    }
}
