using AenEnterprise.DomainModel.HumanResources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AenEnterprise.DataAccess.ModelEntityConfigurations
{
    public class TrainingConfiguration : IEntityTypeConfiguration<Training>
    {
        public void Configure(EntityTypeBuilder<Training> builder)
        {
            builder.HasKey(t => t.Id);


            builder.HasData(
                new Training { Id = 1, EmployeeId = 1, CourseName = "Leadership", TrainingStartDate = DateTime.Now, CompletionDate = DateTime.Now.AddMonths(1), Certificate = "Certified" }
                // Add 9 more entries here...
            );
        }
    }

}
