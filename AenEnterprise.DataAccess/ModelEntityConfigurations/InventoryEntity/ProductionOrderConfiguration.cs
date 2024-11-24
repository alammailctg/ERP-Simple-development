using AenEnterprise.DomainModel.InventoryManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace AenEnterprise.DataAccess.ModelEntityConfigurations.InventoryEntity
{
    public class ProductionOrderConfiguration : IEntityTypeConfiguration<ProductionOrder>
    {
        public void Configure(EntityTypeBuilder<ProductionOrder> builder)
        {
            // Configure primary key
            builder.HasKey(po => po.Id);

            // Configure properties
            builder.Property(po => po.ProductionOrderNo)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(po => po.CreatedDate)
                .HasDefaultValueSql("GETDATE()");

            builder.Property(p => p.DirectLaborCost).HasPrecision(18, 2);
            builder.Property(p => p.InitialProductCost).HasPrecision(18, 2);
            builder.Property(p => p.OtherInitialCosts).HasPrecision(18, 2);
            builder.Property(p => p.PurchaseCost).HasPrecision(18, 2);


            builder.HasOne(po => po.Initiator)
                .WithMany()
                .HasForeignKey(po => po.InitiatorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(po => po.AssignedTo)
                .WithMany()
                .HasForeignKey(po => po.AssignedToId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(po => po.Branch)
                .WithMany(po => po.ProductionOrders)
                .HasForeignKey(po => po.BranchId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(po => po.OrderPriority)
                .WithMany()
                .HasForeignKey(po => po.OrderPriorityId)
                .OnDelete(DeleteBehavior.Restrict);

            // CostTransactions (One-to-Many)
            builder.HasMany(po => po.CostTransactions)
                .WithOne(po => po.ProductionOrder)
                .HasForeignKey(po => po.ProductionOrderId) // assuming ProductionOrderId as FK in CostTransaction
                .OnDelete(DeleteBehavior.Cascade);

            // ProductionOrderItems (One-to-Many)
            builder.HasMany(po => po.ProductionOrderItems)
                .WithOne(po => po.ProductionOrder)
                .HasForeignKey(po => po.ProductionOrderId) // assuming ProductionOrderId as FK in ProductionOrderItem
                .OnDelete(DeleteBehavior.Cascade);

            // ProductionCost (One-to-Many)
            builder.HasMany(po => po.ProudctionCost)
                .WithOne(po => po.ProductionOrder)
                .HasForeignKey(po => po.ProductionOrderId) // assuming ProductionOrderId as FK in ProductionCost
                .OnDelete(DeleteBehavior.Cascade);

            // BillOfMaterials (One-to-Many)
            builder.HasMany(po => po.BillOfMaterials)
                .WithOne(po => po.ProductionOrder)
                .HasForeignKey(po => po.ProductionOrderId) // assuming ProductionOrderId as FK in BillOfMaterial
                .OnDelete(DeleteBehavior.Cascade);

             
        }
    }


}
