using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AenEnterprise.DomainModel.SupplyAndChainManagement.Configuration
{
    public class PurchaseOrderConfiguration : IEntityTypeConfiguration<PurchaseOrder>
    {
        public void Configure(EntityTypeBuilder<PurchaseOrder> builder)
        {
            // Table configuration
            builder.ToTable("PurchaseOrders");

            // Primary key
            builder.HasKey(po => po.Id);

            // Properties configuration
            builder.Property(po => po.CreateDate)
                .IsRequired();

            builder.Property(po => po.OrderDate)
                .IsRequired();

            builder.Property(po => po.Status)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(po => po.ExpectedDeliveryDate)
                .IsRequired();

            builder.Property(po => po.PurchaseDate)
                .IsRequired();

            builder.Property(po => po.PurchaseOrderNo)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(po => po.TotalCostAmount)
                .HasColumnType("decimal(18, 2)"); // Set precision and scale

            builder.Property(po => po.DeliveryInstructions)
                .HasMaxLength(255);

            builder.Property(po => po.PaymentTerms)
                .HasMaxLength(255);

            builder.Property(po => po.ShippingMethod)
                .HasMaxLength(50);

            builder.Property(po => po.ApprovedBy)
                .HasMaxLength(100);

            builder.Property(po => po.ApprovalDate)
                .IsRequired(false); // Nullable DateTime

            builder.Property(po => po.Notes)
                .HasMaxLength(500);

            // Relationships
            builder.HasMany(po => po.PurchaseItems)
                .WithOne(pi => pi.PurchaseOrder) // Assuming PurchaseItem has a PurchaseOrder property
                .HasForeignKey(pi => pi.PurchaseOrderId) // Specify foreign key
                .OnDelete(DeleteBehavior.Cascade); // Define delete behavior

            builder.HasMany(po => po.VendorInvoices)
                .WithOne(vi => vi.PurchaseOrder) // Assuming VendorInvoice has a PurchaseOrder property
                .HasForeignKey(vi => vi.PurchaseOrderId) // Specify foreign key
                .OnDelete(DeleteBehavior.Cascade); // Define delete behavior
        }
    }
}
