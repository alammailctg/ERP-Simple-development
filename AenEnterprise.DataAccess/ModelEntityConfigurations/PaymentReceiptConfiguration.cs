using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable.Configuration
{
    public class PaymentReceiptConfiguration : IEntityTypeConfiguration<PaymentReceipt>
    {
        public void Configure(EntityTypeBuilder<PaymentReceipt> builder)
        {
            // Setting the primary key
            builder.HasKey(pr => pr.Id);

            builder.Property(p => p.PaymentAmount)
            .HasPrecision(18, 2);

            builder.HasOne(pr => pr.Invoice)
       .WithMany(i => i.paymentReceipts)
       .HasForeignKey(pr => pr.InvoiceId)
       .OnDelete(DeleteBehavior.Restrict);


            //// Seeding 10 rows of data
            //builder.HasData(
            //    new PaymentReceipt { Id = 1, PaymentAmount = 5000, PaymentDate = DateTime.Now.AddDays(-10), InvoiceId = 1 },
            //    new PaymentReceipt { Id = 2, PaymentAmount = 7000, PaymentDate = DateTime.Now.AddDays(-8), InvoiceId = 2 },
            //    new PaymentReceipt { Id = 3, PaymentAmount = 1500, PaymentDate = DateTime.Now.AddDays(-6), InvoiceId = 3 },
            //    new PaymentReceipt { Id = 4, PaymentAmount = 2000, PaymentDate = DateTime.Now.AddDays(-5), InvoiceId = 4 },
            //    new PaymentReceipt { Id = 5, PaymentAmount = 3200, PaymentDate = DateTime.Now.AddDays(-4), InvoiceId = 5 },
            //    new PaymentReceipt { Id = 6, PaymentAmount = 1800, PaymentDate = DateTime.Now.AddDays(-3), InvoiceId = 6 },
            //    new PaymentReceipt { Id = 7, PaymentAmount = 4000, PaymentDate = DateTime.Now.AddDays(-2), InvoiceId = 7 },
            //    new PaymentReceipt { Id = 8, PaymentAmount = 2200, PaymentDate = DateTime.Now.AddDays(-1), InvoiceId = 8 },
            //    new PaymentReceipt { Id = 9, PaymentAmount = 1000, PaymentDate = DateTime.Now.AddDays(-20), InvoiceId = 9 },
            //    new PaymentReceipt { Id = 10, PaymentAmount = 4500, PaymentDate = DateTime.Now.AddDays(-15), InvoiceId = 10 }
            //);
        }
    }
}
