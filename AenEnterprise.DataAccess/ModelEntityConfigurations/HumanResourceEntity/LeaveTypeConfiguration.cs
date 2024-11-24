using AenEnterprise.DomainModel.HumanResources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
{
    public void Configure(EntityTypeBuilder<LeaveType> builder)
    {
        // Configuring the LeaveType entity
        builder.HasKey(lt => lt.Id);

        builder.Property(lt => lt.Name)
            .IsRequired()
            .HasMaxLength(100); // Assuming you want to limit the length of the Name property

        // Seeding data for LeaveType
        builder.HasData(
            new LeaveType { Id = 1, Name = "Annual Leave" },
            new LeaveType { Id = 2, Name = "Sick Leave" },
            new LeaveType { Id = 3, Name = "Casual Leave" },
            new LeaveType { Id = 4, Name = "Leave Without Pay" },
            new LeaveType { Id = 5, Name = "Maternity Leave" },
            new LeaveType { Id = 6, Name = "Paternity Leave" },
            new LeaveType { Id = 7, Name = "Bereavement Leave" },
            new LeaveType { Id = 8, Name = "Public Holiday" },
            new LeaveType { Id = 9, Name = "Absent" },
            new LeaveType { Id = 10, Name = "Other" }

        );
    }
}
