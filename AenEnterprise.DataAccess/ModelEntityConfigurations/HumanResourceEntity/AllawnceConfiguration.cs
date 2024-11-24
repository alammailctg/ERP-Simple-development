using AenEnterprise.DomainModel.HumanResources;
using AenEnterprise.DomainModel.HumanResources.Benefits;
using AenEnterprise.DomainModel.HumanResources.HumanResourceInterface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DataAccess.ModelEntityConfigurations.HumanResourceEntity
{
    public class AllawancesConfiguration : IEntityTypeConfiguration<Allowances>
    {
        public void Configure(EntityTypeBuilder<Allowances> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name)
                   .HasMaxLength(50)
                   .IsRequired(false);  // Optional property (nullable)

            
            builder.Property(a => a.MonthlyCost)
                   .HasColumnType("decimal(18,2)");

            builder.Property(a => a.PaymentType)
                   .HasMaxLength(50)
                   .IsRequired(false);  // Optional property (nullable)
        }
    }
}
