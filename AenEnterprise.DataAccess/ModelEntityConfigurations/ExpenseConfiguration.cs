using AenEnterprise.DomainModel.AccountsAndFinance.AccountPayable;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
{
    public void Configure(EntityTypeBuilder<Expense> builder)
    {
        // Configure properties (e.g., max length for Name)
        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(100);

        // Configure foreign key to ExpenseCategory
        builder.HasOne(e => e.ExpenseCategory)
            .WithMany(ec => ec.Expenses)
            .HasForeignKey(e => e.ExpenseCategoryId);

        // Seed initial data using HasData
        builder.HasData(
            // Operating Expenses
            new Expense { Id = 1, Name = "Rent/Lease Expense", ExpenseCategoryId = 1 },
            new Expense { Id = 2, Name = "Utilities", ExpenseCategoryId = 1 },
            new Expense { Id = 3, Name = "Salaries and Wages", ExpenseCategoryId = 1 },
            new Expense { Id = 4, Name = "Office Supplies", ExpenseCategoryId = 1 },
            new Expense { Id = 5, Name = "Maintenance and Repairs", ExpenseCategoryId = 1 },
            new Expense { Id = 6, Name = "Advertising and Marketing", ExpenseCategoryId = 1 },
            new Expense { Id = 7, Name = "Insurance", ExpenseCategoryId = 1 },
            new Expense { Id = 8, Name = "Licenses and Permits", ExpenseCategoryId = 1 },
            new Expense { Id = 9, Name = "Telephone/Internet Services", ExpenseCategoryId = 1 },

            // Cost of Goods Sold (COGS)
            new Expense { Id = 10, Name = "Raw Materials", ExpenseCategoryId = 2 },
            new Expense { Id = 11, Name = "Direct Labor", ExpenseCategoryId = 2 },
            new Expense { Id = 12, Name = "Manufacturing Overheads", ExpenseCategoryId = 2 },

            // Administrative Expenses
            new Expense { Id = 13, Name = "Executive Salaries", ExpenseCategoryId = 3 },
            new Expense { Id = 14, Name = "Legal and Professional Fees", ExpenseCategoryId = 3 },
            new Expense { Id = 15, Name = "Office Equipment Depreciation", ExpenseCategoryId = 3 },
            new Expense { Id = 16, Name = "Employee Training", ExpenseCategoryId = 3 },
            new Expense { Id = 17, Name = "Travel and Entertainment", ExpenseCategoryId = 3 },

            // Financial Expenses
            new Expense { Id = 18, Name = "Interest Expense", ExpenseCategoryId = 4 },
            new Expense { Id = 19, Name = "Bank Fees", ExpenseCategoryId = 4 },
            new Expense { Id = 20, Name = "Loan Payments", ExpenseCategoryId = 4 },
            new Expense { Id = 21, Name = "Bad Debt Expense", ExpenseCategoryId = 4 },

            // Depreciation and Amortization
            new Expense { Id = 22, Name = "Depreciation Expense", ExpenseCategoryId = 5 },
            new Expense { Id = 23, Name = "Amortization Expense", ExpenseCategoryId = 5 },

            // Tax Expenses
            new Expense { Id = 24, Name = "Corporate Income Taxes", ExpenseCategoryId = 6 },
            new Expense { Id = 25, Name = "Sales Taxes", ExpenseCategoryId = 6 },
            new Expense { Id = 26, Name = "Property Taxes", ExpenseCategoryId = 6 },
            new Expense { Id = 27, Name = "Payroll Taxes", ExpenseCategoryId = 6 },
            new Expense { Id = 28, Name = "Excise Taxes", ExpenseCategoryId = 6 },

            // Selling, General, and Administrative (SG&A) Expenses
            new Expense { Id = 29, Name = "Sales Commissions", ExpenseCategoryId = 7 },
            new Expense { Id = 30, Name = "Shipping and Delivery Costs", ExpenseCategoryId = 7 },
            new Expense { Id = 31, Name = "Customer Service Expenses", ExpenseCategoryId = 7 },
            new Expense { Id = 32, Name = "Office Space and Equipment Leases", ExpenseCategoryId = 7 },

            // Miscellaneous Expenses
            new Expense { Id = 33, Name = "Donations and Charitable Contributions", ExpenseCategoryId = 8 },
            new Expense { Id = 34, Name = "Subscriptions", ExpenseCategoryId = 8 },
            new Expense { Id = 35, Name = "Fines and Penalties", ExpenseCategoryId = 8 },

            // Employee Benefits and Expenses
            new Expense { Id = 36, Name = "Health Insurance", ExpenseCategoryId = 9 },
            new Expense { Id = 37, Name = "Retirement Benefits", ExpenseCategoryId = 9 },
            new Expense { Id = 38, Name = "Bonuses and Incentives", ExpenseCategoryId = 9 },
            new Expense { Id = 39, Name = "Workers’ Compensation", ExpenseCategoryId = 9 },

            // Research and Development (R&D) Expenses
            new Expense { Id = 40, Name = "Product Development Costs", ExpenseCategoryId = 10 },
            new Expense { Id = 41, Name = "Market Research", ExpenseCategoryId = 10 },

            // Advertising and Promotion Expenses
            new Expense { Id = 42, Name = "Digital Marketing", ExpenseCategoryId = 11 },
            new Expense { Id = 43, Name = "Traditional Media Ads", ExpenseCategoryId = 11 },
            new Expense { Id = 44, Name = "Sponsorships", ExpenseCategoryId = 11 },

            // IT and Technology Expenses
            new Expense { Id = 45, Name = "Software Licenses", ExpenseCategoryId = 12 },
            new Expense { Id = 46, Name = "Cloud Services", ExpenseCategoryId = 12 },
            new Expense { Id = 47, Name = "IT Support", ExpenseCategoryId = 12 }
        );
    }
}
