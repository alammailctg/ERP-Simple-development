using AenEnterprise.DomainModel.AccountsAndFinance.AccountPayable;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.PaymentAmount)
             .HasColumnType("decimal(18, 2)");

        builder.Property(p => p.PaymentDate)
            .IsRequired();

        // Foreign key to VendorInvoice
        builder.HasOne(p => p.VendorInvoice)
            .WithMany(v => v.Payments)
            .HasForeignKey(p => p.VendorInvoiceId);

        // Foreign key to Reconciliation
        builder.HasOne(p => p.Reconciliation)
            .WithMany(r => r.Payments)
            .HasForeignKey(p => p.ReconciliationId);

        //// Seed data (10 rows)
        //builder.HasData(
        //    new Payment { Id = 1, PaymentAmount = 1000, PaymentDate = DateTime.Now.AddDays(-5), InvoiceId = 1, ReconciliationId = 1 },
        //    new Payment { Id = 2, PaymentAmount = 2000, PaymentDate = DateTime.Now.AddDays(-4), InvoiceId = 2, ReconciliationId = 2 },
        //    new Payment { Id = 3, PaymentAmount = 1500, PaymentDate = DateTime.Now.AddDays(-3), InvoiceId = 3, ReconciliationId = 3 },
        //    new Payment { Id = 4, PaymentAmount = 500, PaymentDate = DateTime.Now.AddDays(-2), InvoiceId = 4, ReconciliationId = 4 },
        //    new Payment { Id = 5, PaymentAmount = 3000, PaymentDate = DateTime.Now.AddDays(-1), InvoiceId = 5, ReconciliationId = 5 },
        //    new Payment { Id = 6, PaymentAmount = 1200, PaymentDate = DateTime.Now.AddDays(-6), InvoiceId = 6, ReconciliationId = 6 },
        //    new Payment { Id = 7, PaymentAmount = 2500, PaymentDate = DateTime.Now.AddDays(-7), InvoiceId = 7, ReconciliationId = 7 },
        //    new Payment { Id = 8, PaymentAmount = 3500, PaymentDate = DateTime.Now.AddDays(-8), InvoiceId = 8, ReconciliationId = 8 },
        //    new Payment { Id = 9, PaymentAmount = 4000, PaymentDate = DateTime.Now.AddDays(-9), InvoiceId = 9, ReconciliationId = 9 },
        //    new Payment { Id = 10, PaymentAmount = 4500, PaymentDate = DateTime.Now.AddDays(-10), InvoiceId = 10, ReconciliationId = 10 }
        //);
    }
}
