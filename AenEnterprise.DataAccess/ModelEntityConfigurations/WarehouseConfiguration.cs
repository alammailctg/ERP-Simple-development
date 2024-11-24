using AenEnterprise.DomainModel.SupplyAndChainManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class WarehouseConfiguration : IEntityTypeConfiguration<Warehouse>
{
    public void Configure(EntityTypeBuilder<Warehouse> builder)
    {
        // Set the primary key
        builder.HasKey(w => w.Id);

        // Configure properties
        builder.Property(w => w.WarehouseName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(w => w.Location)
            .IsRequired()
            .HasMaxLength(200);



        // Seed data
        builder.HasData(
            new Warehouse { Id = 1, WarehouseName = "Warehouse A", Location = "Location A" },
            new Warehouse { Id = 2, WarehouseName = "Warehouse B", Location = "Location B" },
            new Warehouse { Id = 3, WarehouseName = "Warehouse C", Location = "Location C" },
            new Warehouse { Id = 4, WarehouseName = "Warehouse D", Location = "Location D" },
            new Warehouse { Id = 5, WarehouseName = "Warehouse E", Location = "Location E" },
            new Warehouse { Id = 6, WarehouseName = "Warehouse F", Location = "Location F" },
            new Warehouse { Id = 7, WarehouseName = "Warehouse G", Location = "Location G" },
            new Warehouse { Id = 8, WarehouseName = "Warehouse H", Location = "Location H" },
            new Warehouse { Id = 9, WarehouseName = "Warehouse I", Location = "Location I" },
            new Warehouse { Id = 10, WarehouseName = "Warehouse J", Location = "Location J" }
        );
    }
}
