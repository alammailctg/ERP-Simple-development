using AenEnterprise.DomainModel.SupplyAndChainManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AenEnterprise.DataAccess.ModelEntityConfigurations.InventoryEntity
{
    public class BillOfMaterialItemConfiguration : IEntityTypeConfiguration<BillOfMaterialItem>
    {
        public void Configure(EntityTypeBuilder<BillOfMaterialItem> builder)
        {
            // Configure primary key
            builder.HasKey(bi => bi.Id);

            // Configure properties
            builder.Property(bi => bi.MaterialName)
                .IsRequired()
                .HasMaxLength(100); // Set the maximum length as needed

            builder.Property(bi => bi.Quantity)
                .IsRequired()
                .HasColumnType("decimal(18,2)"); // Set precision and scale as needed

            builder.Property(bi => bi.UnitCost)
                .IsRequired()
                .HasColumnType("decimal(18,2)"); // Set precision and scale as needed


        }
    }
}
