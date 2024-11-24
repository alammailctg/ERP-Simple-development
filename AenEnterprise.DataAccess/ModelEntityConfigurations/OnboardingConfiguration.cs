using AenEnterprise.DomainModel.HumanResources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AenEnterprise.DataAccess.ModelEntityConfigurations
{
    public class OnboardingConfiguration : IEntityTypeConfiguration<Onboarding>
    {
        public void Configure(EntityTypeBuilder<Onboarding> builder)
        {
            builder.HasKey(o => o.Id);




        }
    }

}
