using AenEnterprise.DomainModel.SupplyAndChainManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AenEnterprise.DataAccess.ModelEntityConfigurations.InventoryEntity
{
    public class BillOfMaterialConfiguration : IEntityTypeConfiguration<BillOfMaterial>
    {
        public void Configure(EntityTypeBuilder<BillOfMaterial> builder)
        {
            // Configure primary key
            builder.HasKey(b => b.Id);

            // Configure properties
            builder.Property(b => b.ProductName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(b => b.CreationDate)
                .IsRequired();

            builder.Property(b => b.Status)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(b => b.CreatedById)
                .IsRequired();

            builder.Property(b => b.ApprovedById)
                .IsRequired();

            builder.Property(b => b.CreatedEmplyeeId)
                .IsRequired();

            builder.Property(b => b.ApprovedByEmployeeId)
                .IsRequired();

            builder.HasMany(s => s.BillOfMaterialItems).WithOne(o => o.BillOfMaterial)
           .HasForeignKey(o => o.BillOfMaterialsId).OnDelete(DeleteBehavior.Cascade);
            // Configure relationships
            builder.HasOne(b => b.Employee)
                .WithMany() // Assuming Employee has no collection of BOMs
                .HasForeignKey(b => b.CreatedById);


        }
    }

}
