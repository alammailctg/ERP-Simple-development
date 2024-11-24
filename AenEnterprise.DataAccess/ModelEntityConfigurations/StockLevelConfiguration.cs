using AenEnterprise.DomainModel.SupplyAndChainManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class StockLevelConfiguration : IEntityTypeConfiguration<StockLevel>
{
    public void Configure(EntityTypeBuilder<StockLevel> builder)
    {
        // Setting the Primary Key
        builder.HasKey(sl => sl.Id);

        // Configuring the AvailableQuantity property with decimal column type
        builder.Property(sl => sl.AvailableQuantity)
               .HasColumnType("decimal(18,2)")
               .IsRequired();

        // Configuring relationships and preventing cascading deletes
        builder.HasOne(sl => sl.Product)
               .WithMany(st => st.StockLevels)
               .HasForeignKey(sl => sl.ProductId)
               .OnDelete(DeleteBehavior.NoAction); // Prevent cascading delete

        builder.HasOne(sl => sl.DemandPlanning)
               .WithMany(st => st.StockLevels)
               .HasForeignKey(sl => sl.DemandPlanningId)
               .OnDelete(DeleteBehavior.NoAction); // Prevent cascading delete

        //// Seeding data: 3 example rows for StockLevel
        //builder.HasData(
        //    new StockLevel { Id = 1, ProductId = 1, AvailableQuantity = 1500, DemandPlanningId = 1 },
        //    new StockLevel { Id = 2, ProductId = 2, AvailableQuantity = 2500, DemandPlanningId = 1 },
        //    new StockLevel { Id = 3, ProductId = 1, AvailableQuantity = 1000, DemandPlanningId = 2 }
        //);
    }
}
