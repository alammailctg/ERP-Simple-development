using AenEnterprise.DomainModel.HumanResources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AenEnterprise.DataAccess.ModelEntityConfigurations
{
    public class BenefitsAdministrationConfiguration : IEntityTypeConfiguration<BenefitsAdministration>
    {
        public void Configure(EntityTypeBuilder<BenefitsAdministration> builder)
        {
            builder.HasKey(e => e.Id);
        }
    }

}
