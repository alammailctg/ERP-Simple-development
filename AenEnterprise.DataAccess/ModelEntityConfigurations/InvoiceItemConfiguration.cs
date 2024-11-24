using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable.SalesManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AenEnterprise.DataAccess.ModelEntityConfigurations
{
    public class InvoiceItemConfiguration : IEntityTypeConfiguration<InvoiceItem>
    {
        public void Configure(EntityTypeBuilder<InvoiceItem> builder)
        {
            // Defining the primary key
            builder.HasKey(ii => ii.Id);

            // Defining properties with the specified decimal type
            builder.Property(ii => ii.InvoiceQuantity)
                   .HasColumnType("decimal(18,2)");

            builder.Property(ii => ii.InvoiceAmount)
                   .HasColumnType("decimal(18,2)");

            builder.Property(ii => ii.DeliveryQuantity)
                   .HasColumnType("decimal(18,2)");

            builder.Property(ii => ii.DeliveryAmount)
                   .HasColumnType("decimal(18,2)");

            builder.Property(ii => ii.BalanceQuantity)
                   .HasColumnType("decimal(18,2)");

            builder.Property(ii => ii.BalanceAmount)
                   .HasColumnType("decimal(18,2)");

            // Defining relationship with Status entity
            builder.HasOne(ii => ii.Status)
                   .WithMany(status => status.InvoiceItems)
                   .HasForeignKey(ii => ii.StatusId)
                   .OnDelete(DeleteBehavior.NoAction);

            // Additional configurations can be applied here
        }
    }
}
