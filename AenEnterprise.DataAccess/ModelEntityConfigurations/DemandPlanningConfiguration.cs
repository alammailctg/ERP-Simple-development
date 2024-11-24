using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AenEnterprise.DomainModel.SupplyAndChainManagement.Configuration
{
    public class DemandPlanningConfiguration : IEntityTypeConfiguration<DemandPlanning>
    {
        public void Configure(EntityTypeBuilder<DemandPlanning> builder)
        {
            builder.HasKey(dp => dp.Id);
            builder.HasOne(dp => dp.Product)
                .WithMany(p => p.DemandPlannings)
                .HasForeignKey(dp => dp.ProductId);

            builder.HasData(
                new DemandPlanning { Id = 1, ProductId = 1, ForecastedDemand = 1000, ForecastDate = DateTime.UtcNow },
                new DemandPlanning { Id = 2, ProductId = 2, ForecastedDemand = 500, ForecastDate = DateTime.UtcNow }
            );
        }
    }
}
