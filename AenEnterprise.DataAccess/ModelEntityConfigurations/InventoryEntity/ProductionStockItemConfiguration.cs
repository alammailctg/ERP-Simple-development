namespace AenEnterprise.DataAccess.ModelEntityConfigurations.InventoryEntity
{
    using global::AenEnterprise.DomainModel.InventoryManagement;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    namespace AenEnterprise.DomainModel.EntityConfigurations
    {
        public class ProductionStockItemConfiguration : IEntityTypeConfiguration<ProductionStockItem>
        {
            public void Configure(EntityTypeBuilder<ProductionStockItem> builder)
            {
                // Configure table name
                builder.ToTable("ProductionStockItems");

                // Configure primary key
                builder.HasKey(psi => psi.Id);

                // Configure properties
                builder.Property(psi => psi.CreatedDate)
                       .IsRequired()
                       .HasDefaultValueSql("GETDATE()"); // Default date is set to today

                builder.Property(psi => psi.QuantityInProduced)
                       .IsRequired()
                       .HasColumnType("decimal(18,2)"); // Define precision and scale if required

                builder.Property(psi => psi.QuantityInStock)
                       .IsRequired()
                       .HasColumnType("decimal(18,2)"); // Define precision and scale if required

                builder.Property(psi => psi.StockType)
                       .IsRequired();

                builder.Property(p => p.QuantityInProduced).HasPrecision(18, 2);
                builder.Property(p => p.QuantityInStock).HasPrecision(18, 2);

                // Configure relationships
                builder.HasOne(psi => psi.Unit)
                       .WithMany(psi => psi.ProductionStockItems) // Assuming Unit does not have a navigation property back to ProductionStockItem
                       .HasForeignKey(psi => psi.UnitId)
                       .OnDelete(DeleteBehavior.NoAction); // Use Restrict or Cascade as needed

                builder.HasOne(psi => psi.ProductionStock)
                       .WithMany(ps => ps.ProductionStockItems) // ProductionStock has a collection of ProductionStockItems
                       .HasForeignKey(psi => psi.ProductionStockId)
                       .OnDelete(DeleteBehavior.Cascade); // Cascade delete ProductionStockItem if ProductionStock is deleted

                // Configure indexes (optional, based on performance needs)
                builder.HasIndex(psi => psi.ProductId);
                builder.HasIndex(psi => psi.ProductionStockId);
            }
        }
    }

}
