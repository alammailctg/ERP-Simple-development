using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable.Configuration
{
    public class CreditMemoConfiguration : IEntityTypeConfiguration<CreditMemo>
    {
        public void Configure(EntityTypeBuilder<CreditMemo> builder)
        {
            // Setting the Primary Key
            builder.HasKey(cm => cm.Id);

            // Configuring the CreditAmount property with precision and scale
            builder.Property(cm => cm.CreditAmount)
                .HasColumnType("decimal(18, 2)"); // Specify the SQL column type correctly

            // Configuring relationships
            builder.HasOne(cm => cm.Customer)
                   .WithMany(c => c.CreditMemos)
                   .HasForeignKey(cm => cm.CustomerId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(cm => cm.Invoice)
                   .WithMany(i => i.CreditMemos)
                   .HasForeignKey(cm => cm.InvoiceId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Seeding 10 rows of data
            //builder.HasData(
            //    new CreditMemo { Id = 1, CreditAmount = 1000m, IssueDate = DateTime.Now.AddDays(-10), CustomerId = 1, InvoiceId = 1 },
            //    new CreditMemo { Id = 2, CreditAmount = 1500m, IssueDate = DateTime.Now.AddDays(-8), CustomerId = 2, InvoiceId = 2 },
            //    new CreditMemo { Id = 3, CreditAmount = 2000m, IssueDate = DateTime.Now.AddDays(-6), CustomerId = 3, InvoiceId = 3 },
            //    new CreditMemo { Id = 4, CreditAmount = 2500m, IssueDate = DateTime.Now.AddDays(-4), CustomerId = 4, InvoiceId = 4 },
            //    new CreditMemo { Id = 5, CreditAmount = 3000m, IssueDate = DateTime.Now.AddDays(-2), CustomerId = 5, InvoiceId = 5 },
            //    new CreditMemo { Id = 6, CreditAmount = 1200m, IssueDate = DateTime.Now.AddDays(-5), CustomerId = 6, InvoiceId = 6 },
            //    new CreditMemo { Id = 7, CreditAmount = 900m, IssueDate = DateTime.Now.AddDays(-7), CustomerId = 7, InvoiceId = 7 },
            //    new CreditMemo { Id = 8, CreditAmount = 1800m, IssueDate = DateTime.Now.AddDays(-9), CustomerId = 8, InvoiceId = 8 },
            //    new CreditMemo { Id = 9, CreditAmount = 1100m, IssueDate = DateTime.Now.AddDays(-12), CustomerId = 9, InvoiceId = 9 },
            //    new CreditMemo { Id = 10, CreditAmount = 2100m, IssueDate = DateTime.Now.AddDays(-3), CustomerId = 10, InvoiceId = 10 }
            //);
        }
    }
}
