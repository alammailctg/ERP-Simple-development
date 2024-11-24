using AenEnterprise.DomainModel.HumanResources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AenEnterprise.DataAccess.ModelEntityConfigurations
{
    public class TimeTrackingConfiguration : IEntityTypeConfiguration<TimeTracking>
    {
        public void Configure(EntityTypeBuilder<TimeTracking> builder)
        {
            builder.HasKey(t => t.Id);



            builder.HasData(
                new TimeTracking { Id = 1, EmployeeId = 1, CheckInTime = DateTime.Now.AddHours(-8), CheckOutTime = DateTime.Now, WorkHours = new TimeSpan(8, 0, 0), TimeOff = false }
                // Add 9 more entries here...
            );
        }
    }

}
