using AenEnterprise.DomainModel.SupplyAndChainManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AenEnterprise.DataAccess.ModelEntityConfigurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // Set the primary key
            builder.HasKey(c => c.Id);

            // Configure properties
            builder.Property(p => p.Name)
                .HasColumnName("Name")
                .HasColumnType("nvarchar(max)")
                .IsRequired();

            builder.Property(p => p.CompanyId)
                .HasColumnName("CompanyId")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(p => p.UnitId)
                .HasColumnName("UnitId")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(p => p.DefaultVatPercent)
                .HasColumnName("DefaultVatPercent")
                .HasColumnType("nvarchar(max)");

            builder.Property(p => p.PurchasePrice)
                .HasColumnName("PurchasePrice")
                .HasColumnType("decimal");

            builder.Property(p => p.CostPrice)
                .HasColumnName("CostPrice")
                .HasColumnType("decimal");

            builder.Property(p => p.WholesalePrice)
                .HasColumnName("WholesalePrice")
                .HasColumnType("decimal");

            builder.Property(p => p.MRP)
                .HasColumnName("MRP")
                .HasColumnType("decimal");

            builder.Property(p => p.TradePrice)
                .HasColumnName("TradePrice")
                .HasColumnType("decimal");

            builder.Property(p => p.InventoryType)
                .HasColumnName("InventoryType")
                .HasColumnType("nvarchar(max)");

            builder.Property(p => p.IsQuantityMeasureable)
                .HasColumnName("IsQuantityMeasureable")
                .HasColumnType("bit");

            builder.Property(p => p.FixedAsset)
                .HasColumnName("FixedAsset")
                .HasColumnType("bit");

            builder.Property(p => p.IsPurchaseable)
                .HasColumnName("IsPurchaseable")
                .HasColumnType("bit");

            builder.Property(p => p.IsSaleable)
                .HasColumnName("IsSaleable")
                .HasColumnType("bit");

            builder.Property(p => p.IsConsumable)
                .HasColumnName("IsConsumable")
                .HasColumnType("bit");

            builder.Property(p => p.RawMaterials)
                .HasColumnName("RawMaterials")
                .HasColumnType("bit");

            builder.Property(p => p.IsInventoryRequired)
                .HasColumnName("IsInventoryRequired")
                .HasColumnType("bit");

            builder.Property(p => p.WarehouseId)
                .HasColumnName("WarehouseId")
                .HasColumnType("int");

            builder.Property(p => p.Description)
                .HasColumnName("Description")
                .HasColumnType("nvarchar(max)")
                .IsRequired();

            builder.Property(p => p.CategoryId)
                .HasColumnName("CategoryId")
                .HasColumnType("int")
                .IsRequired();

            // Map relationships
            builder.HasOne(p => p.Categories)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);
 


            builder.HasOne(p => p.Company)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CompanyId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(
           new Product { Id = 1, Name = "Shop angle Garder", CompanyId = 1, UnitId = 1, DefaultVatPercent = "15%", PurchasePrice = 100.00m, CostPrice = 90.00m, WholesalePrice = 110.00m, MRP = 120.00m, TradePrice = 105.00m, InventoryType = "Type1", IsQuantityMeasureable = true, FixedAsset = false, IsPurchaseable = true, IsSaleable = true, IsConsumable = false, RawMaterials = true, IsInventoryRequired = true, WarehouseId = 1, Description = "Description of Shop angle Garder", CategoryId = 1 },
                new Product { Id = 2, Name = "SS Wire", CompanyId = 1, UnitId = 1, DefaultVatPercent = "18%", PurchasePrice = 50.00m, CostPrice = 45.00m, WholesalePrice = 55.00m, MRP = 60.00m, TradePrice = 52.00m, InventoryType = "Type2", IsQuantityMeasureable = true, FixedAsset = false, IsPurchaseable = true, IsSaleable = true, IsConsumable = false, RawMaterials = true, IsInventoryRequired = true, WarehouseId = 1, Description = "Description of SS Wire", CategoryId = 1 },
                new Product { Id = 3, Name = "Gateball Butterfly", CompanyId = 1, UnitId = 1, DefaultVatPercent = "12%", PurchasePrice = 25.00m, CostPrice = 22.00m, WholesalePrice = 28.00m, MRP = 30.00m, TradePrice = 27.00m, InventoryType = "Type3", IsQuantityMeasureable = true, FixedAsset = false, IsPurchaseable = true, IsSaleable = true, IsConsumable = false, RawMaterials = true, IsInventoryRequired = true, WarehouseId = 1, Description = "Description of Gateball Butterfly", CategoryId = 1 },
                new Product { Id = 4, Name = "Bate Ball+Butter fly", CompanyId = 1, UnitId = 1, DefaultVatPercent = "10%", PurchasePrice = 200.00m, CostPrice = 180.00m, WholesalePrice = 210.00m, MRP = 230.00m, TradePrice = 205.00m, InventoryType = "Type4", IsQuantityMeasureable = true, FixedAsset = false, IsPurchaseable = true, IsSaleable = true, IsConsumable = false, RawMaterials = true, IsInventoryRequired = true, WarehouseId = 1, Description = "Description of Bate Ball+Butter fly", CategoryId = 1 },
                new Product { Id = 5, Name = "Gate bulb and Butterfly", CompanyId = 1, UnitId = 1, DefaultVatPercent = "8%", PurchasePrice = 150.00m, CostPrice = 135.00m, WholesalePrice = 160.00m, MRP = 175.00m, TradePrice = 155.00m, InventoryType = "Type5", IsQuantityMeasureable = true, FixedAsset = false, IsPurchaseable = true, IsSaleable = true, IsConsumable = false, RawMaterials = true, IsInventoryRequired = true, WarehouseId = 1, Description = "Description of Gate bulb and Butterfly", CategoryId = 1 },
                new Product { Id = 6, Name = "Cold Store", CompanyId = 1, UnitId = 1, DefaultVatPercent = "18%", PurchasePrice = 80.00m, CostPrice = 75.00m, WholesalePrice = 85.00m, MRP = 90.00m, TradePrice = 82.00m, InventoryType = "Type6", IsQuantityMeasureable = true, FixedAsset = false, IsPurchaseable = true, IsSaleable = true, IsConsumable = false, RawMaterials = true, IsInventoryRequired = true, WarehouseId = 1, Description = "Description of Cold Store", CategoryId = 1 },
                new Product { Id = 7, Name = "SS Coil Pipe", CompanyId = 1, UnitId = 1, DefaultVatPercent = "15%", PurchasePrice = 120.00m, CostPrice = 110.00m, WholesalePrice = 125.00m, MRP = 135.00m, TradePrice = 122.00m, InventoryType = "Type7", IsQuantityMeasureable = true, FixedAsset = false, IsPurchaseable = true, IsSaleable = true, IsConsumable = false, RawMaterials = true, IsInventoryRequired = true, WarehouseId = 1, Description = "Description of SS Coil Pipe", CategoryId = 1 },
                new Product { Id = 8, Name = "SS Coil Nojel Pipe", CompanyId = 1, UnitId = 1, DefaultVatPercent = "10%", PurchasePrice = 250.00m, CostPrice = 230.00m, WholesalePrice = 260.00m, MRP = 275.00m, TradePrice = 255.00m, InventoryType = "Type8", IsQuantityMeasureable = true, FixedAsset = false, IsPurchaseable = true, IsSaleable = true, IsConsumable = false, RawMaterials = true, IsInventoryRequired = true, WarehouseId = 1, Description = "Description of SS Coil Nojel Pipe", CategoryId = 1 },
                new Product { Id = 9, Name = "SS Pipe", CompanyId = 1, UnitId = 1, DefaultVatPercent = "12%", PurchasePrice = 130.00m, CostPrice = 115.00m, WholesalePrice = 140.00m, MRP = 150.00m, TradePrice = 135.00m, InventoryType = "Type9", IsQuantityMeasureable = true, FixedAsset = false, IsPurchaseable = true, IsSaleable = true, IsConsumable = false, RawMaterials = true, IsInventoryRequired = true, WarehouseId = 1, Description = "Description of SS Pipe", CategoryId = 1 },
                new Product { Id = 10, Name = "Varieties Scrap", CompanyId = 1, UnitId = 1, DefaultVatPercent = "10%", PurchasePrice = 300.00m, CostPrice = 275.00m, WholesalePrice = 310.00m, MRP = 320.00m, TradePrice = 305.00m, InventoryType = "Type10", IsQuantityMeasureable = true, FixedAsset = false, IsPurchaseable = true, IsSaleable = true, IsConsumable = false, RawMaterials = true, IsInventoryRequired = true, WarehouseId = 1, Description = "Description of Varieties Scrap", CategoryId = 1 },
                new Product { Id = 11, Name = "Joint Scrap", CompanyId = 1, UnitId = 1, DefaultVatPercent = "10%", PurchasePrice = 180.00m, CostPrice = 160.00m, WholesalePrice = 190.00m, MRP = 200.00m, TradePrice = 185.00m, InventoryType = "Type11", IsQuantityMeasureable = true, FixedAsset = false, IsPurchaseable = true, IsSaleable = true, IsConsumable = false, RawMaterials = true, IsInventoryRequired = true, WarehouseId = 1, Description = "Description of Joint Scrap", CategoryId = 1 },
                new Product { Id = 12, Name = "MS Net", CompanyId = 1, UnitId = 1, DefaultVatPercent = "18%", PurchasePrice = 400.00m, CostPrice = 380.00m, WholesalePrice = 410.00m, MRP = 420.00m, TradePrice = 405.00m, InventoryType = "Type12", IsQuantityMeasureable = true, FixedAsset = false, IsPurchaseable = true, IsSaleable = true, IsConsumable = false, RawMaterials = true, IsInventoryRequired = true, WarehouseId = 1, Description = "Description of MS Net", CategoryId = 1 },
                new Product { Id = 13, Name = "Kitchen Room", CompanyId = 1, UnitId = 1, DefaultVatPercent = "18%", PurchasePrice = 500.00m, CostPrice = 480.00m, WholesalePrice = 510.00m, MRP = 525.00m, TradePrice = 505.00m, InventoryType = "Type13", IsQuantityMeasureable = true, FixedAsset = false, IsPurchaseable = true, IsSaleable = true, IsConsumable = false, RawMaterials = true, IsInventoryRequired = true, WarehouseId = 1, Description = "Description of Kitchen Room", CategoryId = 1 },
                new Product { Id = 14, Name = "Hidrolik Pump (Alumonium Body)", CompanyId = 1, UnitId = 1, DefaultVatPercent = "12%", PurchasePrice = 600.00m, CostPrice = 575.00m, WholesalePrice = 615.00m, MRP = 630.00m, TradePrice = 610.00m, InventoryType = "Type14", IsQuantityMeasureable = true, FixedAsset = false, IsPurchaseable = true, IsSaleable = true, IsConsumable = false, RawMaterials = true, IsInventoryRequired = true, WarehouseId = 1, Description = "Description of Hidrolik Pump (Alumonium Body)", CategoryId = 1 },
                new Product { Id = 15, Name = "Bit Garder", CompanyId = 1, UnitId = 1, DefaultVatPercent = "15%", PurchasePrice = 50.00m, CostPrice = 45.00m, WholesalePrice = 55.00m, MRP = 60.00m, TradePrice = 52.00m, InventoryType = "Type15", IsQuantityMeasureable = true, FixedAsset = false, IsPurchaseable = true, IsSaleable = true, IsConsumable = false, RawMaterials = false, IsInventoryRequired = true, WarehouseId = 1, Description = "Description of Bit Garder", CategoryId = 1 },
                new Product { Id = 16, Name = "Relling", CompanyId = 1, UnitId = 1, DefaultVatPercent = "10%", PurchasePrice = 150.00m, CostPrice = 140.00m, WholesalePrice = 160.00m, MRP = 170.00m, TradePrice = 155.00m, InventoryType = "Type16", IsQuantityMeasureable = true, FixedAsset = false, IsPurchaseable = true, IsSaleable = true, IsConsumable = false, RawMaterials = false, IsInventoryRequired = true, WarehouseId = 1, Description = "Description of Relling", CategoryId = 1 },
                new Product { Id = 17, Name = "Roller", CompanyId = 1, UnitId = 1, DefaultVatPercent = "8%", PurchasePrice = 90.00m, CostPrice = 85.00m, WholesalePrice = 95.00m, MRP = 100.00m, TradePrice = 92.00m, InventoryType = "Type17", IsQuantityMeasureable = true, FixedAsset = false, IsPurchaseable = true, IsSaleable = true, IsConsumable = false, RawMaterials = false, IsInventoryRequired = true, WarehouseId = 1, Description = "Description of Roller", CategoryId = 1 },
                new Product { Id = 18, Name = "Roller Garda", CompanyId = 1, UnitId = 1, DefaultVatPercent = "8%", PurchasePrice = 180.00m, CostPrice = 165.00m, WholesalePrice = 190.00m, MRP = 200.00m, TradePrice = 185.00m, InventoryType = "Type18", IsQuantityMeasureable = true, FixedAsset = false, IsPurchaseable = true, IsSaleable = true, IsConsumable = false, RawMaterials = false, IsInventoryRequired = true, WarehouseId = 1, Description = "Description of Roller Garda", CategoryId = 1 },
                new Product { Id = 19, Name = "Star pump", CompanyId = 1, UnitId = 1, DefaultVatPercent = "5%", PurchasePrice = 50.00m, CostPrice = 45.00m, WholesalePrice = 55.00m, MRP = 60.00m, TradePrice = 52.00m, InventoryType = "Type19", IsQuantityMeasureable = true, FixedAsset = false, IsPurchaseable = true, IsSaleable = true, IsConsumable = false, RawMaterials = false, IsInventoryRequired = true, WarehouseId = 1, Description = "Description of Star pump", CategoryId = 1 },
                new Product { Id = 20, Name = "Mach Iron", CompanyId = 1, UnitId = 1, DefaultVatPercent = "7%", PurchasePrice = 200.00m, CostPrice = 180.00m, WholesalePrice = 210.00m, MRP = 220.00m, TradePrice = 205.00m, InventoryType = "Type20", IsQuantityMeasureable = true, FixedAsset = false, IsPurchaseable = true, IsSaleable = true, IsConsumable = false, RawMaterials = false, IsInventoryRequired = true, WarehouseId = 1, Description = "Description of Mach Iron", CategoryId = 1 },
                new Product { Id = 21, Name = "Aluminium Stair", CompanyId = 1, UnitId = 1, DefaultVatPercent = "8%", PurchasePrice = 250.00m, CostPrice = 230.00m, WholesalePrice = 260.00m, MRP = 270.00m, TradePrice = 255.00m, InventoryType = "Type21", IsQuantityMeasureable = true, FixedAsset = false, IsPurchaseable = true, IsSaleable = true, IsConsumable = false, RawMaterials = false, IsInventoryRequired = true, WarehouseId = 1, Description = "Description of Aluminium Stair", CategoryId = 1 },
                new Product { Id = 22, Name = "Brass Cornecer Radioter", CompanyId = 1, UnitId = 1, DefaultVatPercent = "6%", PurchasePrice = 120.00m, CostPrice = 110.00m, WholesalePrice = 125.00m, MRP = 130.00m, TradePrice = 122.00m, InventoryType = "Type22", IsQuantityMeasureable = true, FixedAsset = false, IsPurchaseable = true, IsSaleable = true, IsConsumable = false, RawMaterials = false, IsInventoryRequired = true, WarehouseId = 1, Description = "Description of Brass Cornecer Radioter", CategoryId = 1 },
                new Product { Id = 23, Name = "Cast Iron", CompanyId = 1, UnitId = 1, DefaultVatPercent = "15%", PurchasePrice = 50.00m, CostPrice = 45.00m, WholesalePrice = 55.00m, MRP = 60.00m, TradePrice = 52.00m, InventoryType = "Type23", IsQuantityMeasureable = true, FixedAsset = false, IsPurchaseable = true, IsSaleable = true, IsConsumable = false, RawMaterials = false, IsInventoryRequired = true, WarehouseId = 1, Description = "Description of Cast Iron", CategoryId = 1 },
                new Product { Id = 24, Name = "Navi Item", CompanyId = 1, UnitId = 1, DefaultVatPercent = "10%", PurchasePrice = 150.00m, CostPrice = 140.00m, WholesalePrice = 160.00m, MRP = 170.00m, TradePrice = 155.00m, InventoryType = "Type24", IsQuantityMeasureable = true, FixedAsset = false, IsPurchaseable = true, IsSaleable = true, IsConsumable = false, RawMaterials = false, IsInventoryRequired = true, WarehouseId = 1, Description = "Description of Navi Item", CategoryId = 1 },
                new Product { Id = 25, Name = "Furniture", CompanyId = 1, UnitId = 1, DefaultVatPercent = "5%", PurchasePrice = 180.00m, CostPrice = 170.00m, WholesalePrice = 190.00m, MRP = 200.00m, TradePrice = 185.00m, InventoryType = "Type25", IsQuantityMeasureable = true, FixedAsset = false, IsPurchaseable = true, IsSaleable = true, IsConsumable = false, RawMaterials = false, IsInventoryRequired = true, WarehouseId = 1, Description = "Description of Furniture", CategoryId = 1 },
                new Product { Id = 26, Name = "General Store", CompanyId = 1, UnitId = 1, DefaultVatPercent = "18%", PurchasePrice = 100.00m, CostPrice = 90.00m, WholesalePrice = 110.00m, MRP = 120.00m, TradePrice = 105.00m, InventoryType = "Type26", IsQuantityMeasureable = true, FixedAsset = false, IsPurchaseable = true, IsSaleable = true, IsConsumable = false, RawMaterials = false, IsInventoryRequired = true, WarehouseId = 1, Description = "Description of General Store", CategoryId = 1 },
                new Product { Id = 27, Name = "MS Konakata", CompanyId = 1, UnitId = 1, DefaultVatPercent = "12%", PurchasePrice = 300.00m, CostPrice = 275.00m, WholesalePrice = 310.00m, MRP = 320.00m, TradePrice = 305.00m, InventoryType = "Type27", IsQuantityMeasureable = true, FixedAsset = false, IsPurchaseable = true, IsSaleable = true, IsConsumable = false, RawMaterials = false, IsInventoryRequired = true, WarehouseId = 1, Description = "Description of MS Konakata", CategoryId = 1 },
                new Product { Id = 28, Name = "MS Plance", CompanyId = 1, UnitId = 1, DefaultVatPercent = "10%", PurchasePrice = 400.00m, CostPrice = 375.00m, WholesalePrice = 410.00m, MRP = 420.00m, TradePrice = 405.00m, InventoryType = "Type28", IsQuantityMeasureable = true, FixedAsset = false, IsPurchaseable = true, IsSaleable = true, IsConsumable = false, RawMaterials = false, IsInventoryRequired = true, WarehouseId = 1, Description = "Description of MS Plance", CategoryId = 1 },
                new Product { Id = 29, Name = "Shop angle Garder", CompanyId = 1, UnitId = 1, DefaultVatPercent = "15%", PurchasePrice = 100.00m, CostPrice = 90.00m, WholesalePrice = 110.00m, MRP = 120.00m, TradePrice = 105.00m, InventoryType = "Type1", IsQuantityMeasureable = true, FixedAsset = false, IsPurchaseable = true, IsSaleable = true, IsConsumable = false, RawMaterials = true, IsInventoryRequired = true, WarehouseId = 1, Description = "Description of Shop angle Garder", CategoryId = 1 },
                new Product { Id = 30, Name = "SS Wire", CompanyId = 1, UnitId = 1, DefaultVatPercent = "18%", PurchasePrice = 50.00m, CostPrice = 45.00m, WholesalePrice = 55.00m, MRP = 60.00m, TradePrice = 52.00m, InventoryType = "Type2", IsQuantityMeasureable = true, FixedAsset = false, IsPurchaseable = true, IsSaleable = true, IsConsumable = false, RawMaterials = true, IsInventoryRequired = true, WarehouseId = 1, Description = "Description of SS Wire", CategoryId = 1 },
                new Product { Id = 31, Name = "Socket", CompanyId = 1, UnitId = 1, DefaultVatPercent = "12%", PurchasePrice = 25.00m, CostPrice = 22.00m, WholesalePrice = 28.00m, MRP = 30.00m, TradePrice = 27.00m, InventoryType = "Type3", IsQuantityMeasureable = true, FixedAsset = false, IsPurchaseable = true, IsSaleable = true, IsConsumable = false, RawMaterials = false, IsInventoryRequired = true, WarehouseId = 1, Description = "Description of Socket", CategoryId = 1 },
                new Product { Id = 32, Name = "5.8 Shop plate", CompanyId = 1, UnitId = 1, DefaultVatPercent = "10%", PurchasePrice = 200.00m, CostPrice = 180.00m, WholesalePrice = 210.00m, MRP = 230.00m, TradePrice = 205.00m, InventoryType = "Type4", IsQuantityMeasureable = true, FixedAsset = false, IsPurchaseable = true, IsSaleable = true, IsConsumable = false, RawMaterials = false, IsInventoryRequired = true, WarehouseId = 1, Description = "Description of 5.8 Shop plate", CategoryId = 1 },
                new Product { Id = 33, Name = "Shop bit garder", CompanyId = 1, UnitId = 1, DefaultVatPercent = "8%", PurchasePrice = 150.00m, CostPrice = 135.00m, WholesalePrice = 160.00m, MRP = 175.00m, TradePrice = 155.00m, InventoryType = "Type5", IsQuantityMeasureable = true, FixedAsset = false, IsPurchaseable = true, IsSaleable = true, IsConsumable = false, RawMaterials = false, IsInventoryRequired = true, WarehouseId = 1, Description = "Description of Shop bit garder", CategoryId = 1 },
                new Product { Id = 34, Name = "Cable", CompanyId = 1, UnitId = 1, DefaultVatPercent = "18%", PurchasePrice = 80.00m, CostPrice = 75.00m, WholesalePrice = 85.00m, MRP = 90.00m, TradePrice = 82.00m, InventoryType = "Type6", IsQuantityMeasureable = true, FixedAsset = false, IsPurchaseable = true, IsSaleable = true, IsConsumable = false, RawMaterials = false, IsInventoryRequired = true, WarehouseId = 1, Description = "Description of Cable", CategoryId = 1 },
                new Product { Id = 35, Name = "Shopping bit. Garder", CompanyId = 1, UnitId = 1, DefaultVatPercent = "15%", PurchasePrice = 120.00m, CostPrice = 110.00m, WholesalePrice = 125.00m, MRP = 135.00m, TradePrice = 122.00m, InventoryType = "Type7", IsQuantityMeasureable = true, FixedAsset = false, IsPurchaseable = true, IsSaleable = true, IsConsumable = false, RawMaterials = false, IsInventoryRequired = true, WarehouseId = 1, Description = "Description of Shopping bit. Garder", CategoryId = 1 },
                new Product { Id = 36, Name = "3.8 Plate Shop", CompanyId = 1, UnitId = 1, DefaultVatPercent = "10%", PurchasePrice = 250.00m, CostPrice = 230.00m, WholesalePrice = 260.00m, MRP = 275.00m, TradePrice = 255.00m, InventoryType = "Type8", IsQuantityMeasureable = true, FixedAsset = false, IsPurchaseable = true, IsSaleable = true, IsConsumable = false, RawMaterials = false, IsInventoryRequired = true, WarehouseId = 1, Description = "Description of 3.8 Plate Shop", CategoryId = 1 },
                new Product { Id = 37, Name = "Blour", CompanyId = 1, UnitId = 1, DefaultVatPercent = "12%", PurchasePrice = 130.00m, CostPrice = 115.00m, WholesalePrice = 140.00m, MRP = 150.00m, TradePrice = 135.00m, InventoryType = "Type9", IsQuantityMeasureable = true, FixedAsset = false, IsPurchaseable = true, IsSaleable = true, IsConsumable = false, RawMaterials = false, IsInventoryRequired = true, WarehouseId = 1, Description = "Description of Blour", CategoryId = 1 },
                new Product { Id = 38, Name = "1.2 Shop Plate", CompanyId = 1, UnitId = 1, DefaultVatPercent = "10%", PurchasePrice = 300.00m, CostPrice = 275.00m, WholesalePrice = 310.00m, MRP = 320.00m, TradePrice = 305.00m, InventoryType = "Type10", IsQuantityMeasureable = true, FixedAsset = false, IsPurchaseable = true, IsSaleable = true, IsConsumable = false, RawMaterials = false, IsInventoryRequired = true, WarehouseId = 1, Description = "Description of 1.2 Shop Plate", CategoryId = 1 },
                new Product { Id = 39, Name = "Ang+bit Gard", CompanyId = 1, UnitId = 1, DefaultVatPercent = "10%", PurchasePrice = 180.00m, CostPrice = 160.00m, WholesalePrice = 190.00m, MRP = 200.00m, TradePrice = 185.00m, InventoryType = "Type11", IsQuantityMeasureable = true, FixedAsset = false, IsPurchaseable = true, IsSaleable = true, IsConsumable = false, RawMaterials = false, IsInventoryRequired = true, WarehouseId = 1, Description = "Description of Ang+bit Gard", CategoryId = 1 },
                new Product { Id = 40, Name = "Electronics Item", CompanyId = 1, UnitId = 1, DefaultVatPercent = "18%", PurchasePrice = 400.00m, CostPrice = 380.00m, WholesalePrice = 410.00m, MRP = 420.00m, TradePrice = 405.00m, InventoryType = "Type12", IsQuantityMeasureable = true, FixedAsset = false, IsPurchaseable = true, IsSaleable = true, IsConsumable = false, RawMaterials = false, IsInventoryRequired = true, WarehouseId = 1, Description = "Description of Electronics Item", CategoryId = 1 },
                new Product { Id = 41, Name = "Motor", CompanyId = 1, UnitId = 1, DefaultVatPercent = "18%", PurchasePrice = 500.00m, CostPrice = 480.00m, WholesalePrice = 510.00m, MRP = 525.00m, TradePrice = 505.00m, InventoryType = "Type13", IsQuantityMeasureable = true, FixedAsset = false, IsPurchaseable = true, IsSaleable = true, IsConsumable = false, RawMaterials = false, IsInventoryRequired = true, WarehouseId = 1, Description = "Description of Motor", CategoryId = 1 },
                new Product { Id = 42, Name = "CanonPCD 320 ofset paper", CompanyId = 1, UnitId = 1, DefaultVatPercent = "12%", PurchasePrice = 600.00m, CostPrice = 575.00m, WholesalePrice = 615.00m, MRP = 630.00m, TradePrice = 610.00m, InventoryType = "Type14", IsQuantityMeasureable = true, FixedAsset = false, IsPurchaseable = true, IsSaleable = true, IsConsumable = false, RawMaterials = false, IsInventoryRequired = true, WarehouseId = 1, Description = "Description of CanonPCD 320 ofset paper", CategoryId = 1 },
                new Product { Id = 43, Name = "Gateball Butterfly", CompanyId = 1, UnitId = 1, DefaultVatPercent = "15%", PurchasePrice = 50.00m, CostPrice = 45.00m, WholesalePrice = 55.00m, MRP = 60.00m, TradePrice = 52.00m, InventoryType = "Type15", IsQuantityMeasureable = true, FixedAsset = false, IsPurchaseable = true, IsSaleable = true, IsConsumable = false, RawMaterials = false, IsInventoryRequired = true, WarehouseId = 1, Description = "Description of Gateball Butterfly", CategoryId = 1 }
                );
        }

    }
}
