using AenEnterprise.DomainModel.HumanResources;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DataAccess.ModelEntityConfigurations.HumanResourceEntity
{
    public class AdvancePaymentConfiguration: IEntityTypeConfiguration<AdvancePayment>
    {
        public void Configure(EntityTypeBuilder<AdvancePayment> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Amount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(e => e.AdvanceAgainst)
                .HasMaxLength(100);

            builder.Property(e => e.CreateDate)
                .HasDefaultValueSql("GETDATE()");

            builder.Property(e => e.ProposalDate)
                .IsRequired();

            builder.HasOne(e => e.Employee)
                .WithMany()
                .HasForeignKey(e => e.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
