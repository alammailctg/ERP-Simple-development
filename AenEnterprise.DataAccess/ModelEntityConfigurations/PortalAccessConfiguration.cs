using AenEnterprise.DomainModel.HumanResources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AenEnterprise.DataAccess.ModelEntityConfigurations
{
    public class PortalAccessConfiguration : IEntityTypeConfiguration<PortalAccess>
    {
        public void Configure(EntityTypeBuilder<PortalAccess> builder)
        {
            builder.HasKey(p => p.PortalAccessID);

            builder.HasData(
                new PortalAccess { PortalAccessID = 1, EmployeeID = 1, Username = "john.doe", Password = "password123", LastLoginDate = DateTime.Now, AccessLevel = "Employee" }
                // Add 9 more entries here...
            );
        }
    }

}
