using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AenEnterprise.DomainModel.SupplyAndChainManagement.Configuration
{
    public class MaterialsRequirementConfiguration : IEntityTypeConfiguration<MaterialsRequirement>
    {
        public void Configure(EntityTypeBuilder<MaterialsRequirement> builder)
        {
            builder.HasKey(mr => mr.Id);
            builder.Property(mr => mr.MaterialName).IsRequired();
            builder.HasOne(mr => mr.ProductionPlanning)
                .WithMany(pp => pp.MaterialsRequirements)
                .HasForeignKey(mr => mr.ProductionPlanningId);

            //// Seed data
            //builder.HasData(
            //    new MaterialsRequirement { Id = 1, MaterialName = "Steel", RequiredQuantity = 100, ProductionPlanningId = 1 },
            //    new MaterialsRequirement { Id = 2, MaterialName = "Aluminum", RequiredQuantity = 200, ProductionPlanningId = 2 }
            //);
        }
    }
}
