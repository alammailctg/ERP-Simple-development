using AenEnterprise.DomainModel.HumanResources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AenEnterprise.DataAccess.ModelEntityConfigurations
{
    public class TalentAcquisitionConfiguration : IEntityTypeConfiguration<TalentAcquisition>
    {
        public void Configure(EntityTypeBuilder<TalentAcquisition> builder)
        {
            // Primary Key
            builder.HasKey(ta => ta.Id);

            // Properties
            builder.Property(ta => ta.Position)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(ta => ta.Department)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(ta => ta.CandidateName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(ta => ta.ApplicationDate)
                   .IsRequired();

            builder.Property(ta => ta.InterviewDate)
                   .IsRequired();

            builder.Property(ta => ta.Status)
                   .IsRequired()
                   .HasMaxLength(20);

            // Seed initial data
            builder.HasData(
                new TalentAcquisition
                {
                    Id = 1,
                    Position = "Software Engineer",
                    Department = "IT",
                    CandidateName = "John Doe",
                    ApplicationDate = DateTime.Now.AddMonths(-2),
                    InterviewDate = DateTime.Now.AddMonths(-1),
                    Status = "Hired"
                },
                new TalentAcquisition
                {
                    Id = 2,
                    Position = "Project Manager",
                    Department = "Operations",
                    CandidateName = "Jane Smith",
                    ApplicationDate = DateTime.Now.AddMonths(-3),
                    InterviewDate = DateTime.Now.AddMonths(-2),
                    Status = "Offered"
                }
            );
        }
    }


}
