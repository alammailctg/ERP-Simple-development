using AenEnterprise.DomainModel.InventoryManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AenEnterprise.DataAccess.ModelEntityConfigurations.InventoryEntity
{
    public class ProductionCostConfiguration : IEntityTypeConfiguration<ProductionCost>
    {
        public void Configure(EntityTypeBuilder<ProductionCost> builder)
        {
            builder.HasKey(pc => pc.Id);

            builder.Property(pc => pc.CostAmount).IsRequired().HasColumnType("decimal(18,2)");

            //builder.HasOne(pc => pc.ProductionOrder)
            //       .WithMany(po => po.pr.ProductionCosts)
            //       .HasForeignKey(pc => pc.ProductionOrderId);

            builder.Property(pc => pc.CostType)
                   .HasMaxLength(50)
                   .IsRequired();
        }
    }

}
