using AenEnterprise.DomainModel.HumanResources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AenEnterprise.DataAccess.ModelEntityConfigurations
{
    public class PerformanceReviewConfiguration : IEntityTypeConfiguration<PerformanceReview>
    {
        public void Configure(EntityTypeBuilder<PerformanceReview> builder)
        {
            builder.HasKey(pr => pr.Id);
            builder.HasData(
                new PerformanceReview { Id = 1, EmployeeId = 1, ReviewDate = DateTime.Now, Score = 5, Feedback = "Excellent" }
                // Add 9 more entries here...
            );
        }
    }

}
