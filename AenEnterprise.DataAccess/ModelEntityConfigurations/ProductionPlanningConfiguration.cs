using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AenEnterprise.DomainModel.SupplyAndChainManagement.Configuration
{
    public class ProductionPlanningConfiguration : IEntityTypeConfiguration<ProductionPlanning>
    {
        public void Configure(EntityTypeBuilder<ProductionPlanning> builder)
        {
            builder.HasKey(pp => pp.Id);
            builder.HasOne(pp => pp.StockLevel)
                .WithMany(sl => sl.ProductionPlans)
                .HasForeignKey(pp => pp.StockLevelId);

            //builder.HasData(
            //    new ProductionPlanning { Id = 1, PlannedDate = DateTime.UtcNow, PlannedProductionQuantity = 1000, StockLevelId = 1 },
            //    new ProductionPlanning { Id = 2, PlannedDate = DateTime.UtcNow, PlannedProductionQuantity = 2000, StockLevelId = 2 }
            //);
        }
    }
}
