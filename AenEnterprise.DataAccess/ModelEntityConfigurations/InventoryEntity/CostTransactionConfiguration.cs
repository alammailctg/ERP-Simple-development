using AenEnterprise.DomainModel.InventoryManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AenEnterprise.DataAccess.ModelEntityConfigurations.InventoryEntity
{
    public class CostTransactionConfiguration : IEntityTypeConfiguration<CostTransaction>
    {
        public void Configure(EntityTypeBuilder<CostTransaction> builder)
        {
            // Define the primary key
            builder.HasKey(ct => ct.Id);

            // Configure properties
            builder.Property(ct => ct.TransactionDate)
                   .IsRequired();

            builder.Property(ct => ct.Amount)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)"); // Adjust precision as needed

            builder.Property(ct => ct.TransactionType)
                   .IsRequired()
                   .HasMaxLength(50); // Limit the length of the TransactionType

            //// Configure relationships
            //builder.HasOne(ct => ct.ProductionOrder)
            //       .WithMany(po => po.CostTransactions)
            //       .HasForeignKey(ct => ct.ProductionOrderId)
            //       .OnDelete(DeleteBehavior.Cascade); // Define cascading behavior if applicable



        }
    }


}
