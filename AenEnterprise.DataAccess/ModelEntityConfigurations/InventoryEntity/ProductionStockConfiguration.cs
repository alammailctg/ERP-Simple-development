using AenEnterprise.DomainModel.InventoryManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AenEnterprise.DataAccess.ModelEntityConfigurations.InventoryEntity
{
    public class ProductionStockConfiguration : IEntityTypeConfiguration<ProductionStock>
    {
        public void Configure(EntityTypeBuilder<ProductionStock> builder)
        {
            // Configure table name
            builder.ToTable("ProductionStocks");

            // Configure primary key
            builder.HasKey(ps => ps.Id);

            // Configure properties
            builder.Property(ps => ps.StockLocation)
                   .IsRequired() // Stock location cannot be null
                   .HasMaxLength(100); // Max length for stock location

            builder.Property(ps => ps.StockDate)
                   .IsRequired(); // Stock date cannot be null

            builder.Property(ps => ps.CreatedDate)
                   .HasDefaultValueSql("GETDATE()"); // Default to current date

            // Configure relationships
            builder.HasOne(ps => ps.ProductionOrder)
                   .WithMany(po => po.ProductionStocks) // Assuming ProductionOrder has a collection of ProductionStocks
                   .HasForeignKey(ps => ps.ProductionOrderId) // Foreign key in ProductionStock
                   .OnDelete(DeleteBehavior.Cascade); // Cascading delete

            // Configure collection of ProductionStockItems
            builder.HasMany(ps => ps.ProductionStockItems)
                   .WithOne() // Assuming ProductionStockItem does not have a navigation property back to ProductionStock
                   .OnDelete(DeleteBehavior.Cascade); // Cascading delete for related items
        }
    }
}
