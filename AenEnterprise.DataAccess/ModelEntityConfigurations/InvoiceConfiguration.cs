using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable.SalesManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AenEnterprise.DataAccess.ModelEntityConfigurations
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            // Defining the primary key
            builder.HasKey(inv => inv.Id);

            // Defining properties with the specified decimal type
            builder.Property(inv => inv.OutstandingAmount)
                   .HasColumnType("decimal(18,2)");

            builder.Property(inv => inv.InvoiceAmount)
                   .HasColumnType("decimal(18,2)");

            // Defining the relationship with SalesOrder
            builder.HasOne(inv => inv.SalesOrder)
                   .WithMany(so => so.Invoices)
                   .HasForeignKey(inv => inv.SalesOrderId)
                   .OnDelete(DeleteBehavior.NoAction);

            // Additional configurations can go here
            // For example, constraints, default values, indexes, etc.
        }
    }
}
