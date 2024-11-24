using AenEnterprise.DomainModel.HumanResources.Benefits;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DataAccess.ModelEntityConfigurations.HumanResourceEntity
{
    public class BenefitConfiguration : IEntityTypeConfiguration<Benefit>
    {
        public void Configure(EntityTypeBuilder<Benefit> builder)
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
