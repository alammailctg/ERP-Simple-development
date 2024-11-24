using AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DataAccess.ModelEntityConfigurations
{
    public class TrialBalanceLineConfiguration : IEntityTypeConfiguration<TrialBalanceLine>
    {
        public void Configure(EntityTypeBuilder<TrialBalanceLine> builder)
        {
            // Configure the table name
            builder.ToTable("TrialBalanceLines");

            // Configure the primary key
            builder.HasKey(tbl => tbl.AccountName);

            // Configure properties
            builder.Property(tbl => tbl.AccountName)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(tbl => tbl.TotalDebit)
                   .HasColumnType("decimal(18,2)");

            builder.Property(tbl => tbl.TotalCredit)
                   .HasColumnType("decimal(18,2)");
        }
    }
}
