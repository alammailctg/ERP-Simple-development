using AenEnterprise.DomainModel.InventoryManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AenEnterprise.DataAccess.ModelEntityConfigurations
{
    public class CostTypeConfiguration : IEntityTypeConfiguration<CostType>
    {
        public void Configure(EntityTypeBuilder<CostType> builder)
        {
            // Define table and primary key
            builder.ToTable("CostTypes");
            builder.HasKey(ct => ct.Id);

            // Define properties
            builder.Property(ct => ct.Name)
                .IsRequired()
                .HasMaxLength(50);

            // Seed initial data
            builder.HasData(
                new CostType { Id = 1, Name = "Material" },
                new CostType { Id = 2, Name = "Labor" },
                new CostType { Id = 3, Name = "Overhead" },
                new CostType { Id = 4, Name = "Miscellaneous" }
            );
        }
    }
}
