using AenEnterprise.DomainModel.AccountsAndFinance.AccountPayable;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ExpenseCategoryConfiguration : IEntityTypeConfiguration<ExpenseCategory>
{
    public void Configure(EntityTypeBuilder<ExpenseCategory> builder)
    {
        // Configure properties (e.g., max length for Name)
        builder.Property(ec => ec.Name)
            .IsRequired()
            .HasMaxLength(100);

        // Seed initial data using HasData
        builder.HasData(
            new ExpenseCategory { Id = 1, Name = "Operating Expenses" },
            new ExpenseCategory { Id = 2, Name = "Cost of Goods Sold (COGS)" },
            new ExpenseCategory { Id = 3, Name = "Administrative Expenses" },
            new ExpenseCategory { Id = 4, Name = "Financial Expenses" },
            new ExpenseCategory { Id = 5, Name = "Depreciation and Amortization" },
            new ExpenseCategory { Id = 6, Name = "Tax Expenses" },
            new ExpenseCategory { Id = 7, Name = "Selling, General, and Administrative (SG&A) Expenses" },
            new ExpenseCategory { Id = 8, Name = "Miscellaneous Expenses" },
            new ExpenseCategory { Id = 9, Name = "Employee Benefits and Expenses" },
            new ExpenseCategory { Id = 10, Name = "Research and Development (R&D) Expenses" },
            new ExpenseCategory { Id = 11, Name = "Advertising and Promotion Expenses" },
            new ExpenseCategory { Id = 12, Name = "IT and Technology Expenses" }
        );
    }
}
