using AenEnterprise.DomainModel.InventoryManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AenEnterprise.DataAccess.ModelEntityConfigurations.InventoryEntity
{
    public class ProductionPriorityConfiguration : IEntityTypeConfiguration<ProductionPriority>
    {
        public void Configure(EntityTypeBuilder<ProductionPriority> builder)
        {
            // Define the primary key
            builder.HasKey(pp => pp.Id);

            // Configure properties
            builder.Property(pp => pp.Name)
                   .IsRequired()
                   .HasMaxLength(50);

            // Seed initial data
            builder.HasData(
                new ProductionPriority { Id = 1, Name = "Low" },
                new ProductionPriority { Id = 2, Name = "Medium" },
                new ProductionPriority { Id = 3, Name = "High" },
                new ProductionPriority { Id = 4, Name = "Critical" }
            );
        }
    }
}
