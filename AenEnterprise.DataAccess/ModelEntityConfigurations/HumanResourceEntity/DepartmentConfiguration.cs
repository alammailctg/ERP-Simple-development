using AenEnterprise.DomainModel.HumanResources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AenEnterprise.DataAccess.ModelEntityConfigurations.HumanResourceEntity
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            // Primary Key
            builder.HasKey(d => d.Id);

            // Properties
            builder.Property(d => d.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            // Seed data for Departments
            builder.HasData(
                new Department { Id = 1, Name = "IT" },
                new Department { Id = 2, Name = "HR" }
            );
        }
    }

}
