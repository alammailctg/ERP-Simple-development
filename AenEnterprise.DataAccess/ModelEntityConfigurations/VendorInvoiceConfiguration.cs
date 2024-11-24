using AenEnterprise.DomainModel.AccountsAndFinance.AccountPayable;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class VendorInvoiceConfiguration : IEntityTypeConfiguration<VendorInvoice>
{
    public void Configure(EntityTypeBuilder<VendorInvoice> builder)
    {
        builder.HasKey(vi => vi.Id);

        builder.Property(vi => vi.InvoiceAmount)
              .HasColumnType("decimal(18, 2)");




        builder.Property(vi => vi.InvoiceDate)
            .IsRequired();

        // Foreign key to PurchaseOrder
        builder.HasOne(vi => vi.PurchaseOrder)
            .WithMany(po => po.VendorInvoices)
            .HasForeignKey(vi => vi.PurchaseOrderId);

        // Seed data (10 rows)
        //builder.HasData(
        //    new VendorInvoice { Id = 1, InvoiceAmount = 5000, InvoiceDate = DateTime.Now.AddDays(-10), PurchaseOrderId = 1 },
        //    new VendorInvoice { Id = 2, InvoiceAmount = 7000, InvoiceDate = DateTime.Now.AddDays(-9), PurchaseOrderId = 2 },
        //    new VendorInvoice { Id = 3, InvoiceAmount = 6000, InvoiceDate = DateTime.Now.AddDays(-8), PurchaseOrderId = 3 },
        //    new VendorInvoice { Id = 4, InvoiceAmount = 8000, InvoiceDate = DateTime.Now.AddDays(-7), PurchaseOrderId = 4 },
        //    new VendorInvoice { Id = 5, InvoiceAmount = 9000, InvoiceDate = DateTime.Now.AddDays(-6), PurchaseOrderId = 5 },
        //    new VendorInvoice { Id = 6, InvoiceAmount = 10000, InvoiceDate = DateTime.Now.AddDays(-5), PurchaseOrderId = 6 },
        //    new VendorInvoice { Id = 7, InvoiceAmount = 11000, InvoiceDate = DateTime.Now.AddDays(-4), PurchaseOrderId = 7 },
        //    new VendorInvoice { Id = 8, InvoiceAmount = 12000, InvoiceDate = DateTime.Now.AddDays(-3), PurchaseOrderId = 8 },
        //    new VendorInvoice { Id = 9, InvoiceAmount = 13000, InvoiceDate = DateTime.Now.AddDays(-2), PurchaseOrderId = 9 },
        //    new VendorInvoice { Id = 10, InvoiceAmount = 14000, InvoiceDate = DateTime.Now.AddDays(-1), PurchaseOrderId = 10 }
        //);
    }
}
