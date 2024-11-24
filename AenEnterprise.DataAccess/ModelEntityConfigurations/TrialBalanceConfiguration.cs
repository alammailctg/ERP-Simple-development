using AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DataAccess.ModelEntityConfigurations
{
    public class TrialBalanceConfiguration : IEntityTypeConfiguration<TrialBalance>
    {
        public void Configure(EntityTypeBuilder<TrialBalance> builder)
        {
            // Configure the table name
            builder.ToTable("TrialBalances");

            // Configure the primary key
            builder.HasKey(tb => tb.AsOfDate);

            // Ignore calculated properties
            builder.Ignore(tb => tb.TotalDebit);
            builder.Ignore(tb => tb.TotalCredit);

            // Configure the one-to-many relationship
            builder.HasMany(tb => tb.TrialBalanceLines)
                   .WithOne()
                   .OnDelete(DeleteBehavior.Cascade);

            // Configure other properties
            builder.Property(tb => tb.AsOfDate)
                   .IsRequired();
        }
    }
}
