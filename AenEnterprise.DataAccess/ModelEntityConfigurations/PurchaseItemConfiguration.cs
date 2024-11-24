using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace AenEnterprise.DomainModel.SupplyAndChainManagement.Configuration
{
    public class PurchaseItemConfiguration : IEntityTypeConfiguration<PurchaseItem>
    {
        public void Configure(EntityTypeBuilder<PurchaseItem> builder)
        {
            // Table configuration
            builder.ToTable("PurchaseItems");

            // Primary key
            builder.HasKey(pi => pi.Id);

            // Properties configuration
            builder.Property(pi => pi.ItemCode)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(pi => pi.CreatedDate)
                .IsRequired();

            builder.Property(pi => pi.Quantity)
                .IsRequired();

            builder.Property(pi => pi.Price)
                .HasColumnType("decimal(18, 2)")
                .IsRequired();

            builder.Property(pi => pi.DeliveryDate)
                .IsRequired(false);

            builder.Property(pi => pi.ItemStatus)
                .HasMaxLength(50);

            // Relationships
            builder.HasOne(pi => pi.Product)
                .WithMany(pi=>pi.PurchaseItems)  // Adjust if Product has a collection of PurchaseItems
                .HasForeignKey(pi => pi.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(pi => pi.PurchaseOrder)
                .WithMany(po => po.PurchaseItems)
                .HasForeignKey(pi => pi.PurchaseOrderId)
             .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pi => pi.Unit)
                .WithMany() // Adjust if Unit has a collection of PurchaseItems
                .HasForeignKey(pi => pi.UnitId)
                    .OnDelete(DeleteBehavior.Restrict);

        }
    }

}
