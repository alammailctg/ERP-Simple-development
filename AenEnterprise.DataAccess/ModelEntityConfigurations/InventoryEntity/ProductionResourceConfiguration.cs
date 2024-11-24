using AenEnterprise.DomainModel.InventoryManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AenEnterprise.DataAccess.ModelEntityConfigurations.InventoryEntity
{
    internal class ProductionResourceConfiguration : IEntityTypeConfiguration<ProductionResource>
    {
        public void Configure(EntityTypeBuilder<ProductionResource> builder)
        {
            // Primary key configuration
            builder.HasKey(pr => pr.ProductionResourceId);


            // Property configurations
            builder.Property(pr => pr.ResourceName)
                   .IsRequired()
                   .HasMaxLength(100); // Adjust max length as needed

            builder.Property(pr => pr.Cost)
                   .HasColumnType("decimal(18,2"); // Specify SQL Server column type
        }
    }
}
