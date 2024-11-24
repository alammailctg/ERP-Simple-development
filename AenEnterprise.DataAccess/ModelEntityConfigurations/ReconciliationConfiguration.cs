using AenEnterprise.DomainModel.AccountsAndFinance.AccountPayable;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ReconciliationConfiguration : IEntityTypeConfiguration<Reconciliation>
{
    public void Configure(EntityTypeBuilder<Reconciliation> builder)
    {
        builder.HasKey(r => r.ReconciliationId);

        builder.Property(r => r.ReconciliationDate)
            .IsRequired();

        //// Seed data (10 rows)
        //builder.HasData(
        //    new Reconciliation { ReconciliationId = 1, ReconciliationDate = DateTime.Now.AddDays(-10) },
        //    new Reconciliation { ReconciliationId = 2, ReconciliationDate = DateTime.Now.AddDays(-9) },
        //    new Reconciliation { ReconciliationId = 3, ReconciliationDate = DateTime.Now.AddDays(-8) },
        //    new Reconciliation { ReconciliationId = 4, ReconciliationDate = DateTime.Now.AddDays(-7) },
        //    new Reconciliation { ReconciliationId = 5, ReconciliationDate = DateTime.Now.AddDays(-6) },
        //    new Reconciliation { ReconciliationId = 6, ReconciliationDate = DateTime.Now.AddDays(-5) },
        //    new Reconciliation { ReconciliationId = 7, ReconciliationDate = DateTime.Now.AddDays(-4) },
        //    new Reconciliation { ReconciliationId = 8, ReconciliationDate = DateTime.Now.AddDays(-3) },
        //    new Reconciliation { ReconciliationId = 9, ReconciliationDate = DateTime.Now.AddDays(-2) },
        //    new Reconciliation { ReconciliationId = 10, ReconciliationDate = DateTime.Now.AddDays(-1) }
        //);
    }
}
