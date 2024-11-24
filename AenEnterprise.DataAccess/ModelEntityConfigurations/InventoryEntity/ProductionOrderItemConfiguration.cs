using AenEnterprise.DomainModel.InventoryManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AenEnterprise.DataAccess.ModelEntityConfigurations.InventoryEntity
{
    public class ProductionOrderItemConfiguration : IEntityTypeConfiguration<ProductionOrderItem>
    {
        public void Configure(EntityTypeBuilder<ProductionOrderItem> builder)
        {
            builder.HasKey(poi => poi.ProductionOrderItemId);

            builder.Property(poi => poi.CostPerUnit).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(poi => poi.QuantityRequested).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(poi => poi.QuantityProduced).IsRequired().HasColumnType("decimal(18,2)");


            builder.Property(poi => poi.Status)
                   .HasMaxLength(20)
                   .HasDefaultValue("Pending");

           
            builder.HasOne(poi => poi.ApprovalStatus)
               .WithMany(poi => poi.ProductionOrderItems)
               .HasForeignKey(poi => poi.ApprovalStatusId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(poi => poi.Product)
              .WithMany(poi => poi.ProductionOrderItems)
              .HasForeignKey(poi => poi.ProductId)
              .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(poi => poi.Unit)
              .WithMany(poi => poi.ProductionOrderItems)
              .HasForeignKey(poi => poi.UnitId)
              .OnDelete(DeleteBehavior.NoAction);



        }
    }
}
