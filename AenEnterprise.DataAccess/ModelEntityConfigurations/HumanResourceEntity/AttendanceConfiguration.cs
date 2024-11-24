using AenEnterprise.DomainModel.HumanResources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AenEnterprise.DataAccess.ModelEntityConfigurations.HumanResourceEntity
{
    public class AttendanceConfiguration : IEntityTypeConfiguration<Attendance>
    {
        public void Configure(EntityTypeBuilder<Attendance> builder)
        {
            // Configure primary key
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Status)
                   .HasMaxLength(50)
                   .IsRequired(false);  // Optional property (nullable)

            builder.Property(a => a.Remarks)
                   .HasMaxLength(200)
                   .IsRequired(false);  // Optional property (nullable)


            builder.Property(a => a.RegularHours)
                   .HasColumnType("decimal(18,2)")
                   .HasDefaultValue(8m);

            builder.Property(a => a.WorkingHours)
                   .HasColumnType("decimal(18,2)")
                   .HasComputedColumnSql("IIF(CheckOutTime IS NOT NULL AND CheckInTime IS NOT NULL, DATEDIFF(HOUR, CheckInTime, CheckOutTime), 0)");

            builder.Property(a => a.OverTimeHours)
                   .HasColumnType("decimal(18,2)")
                   .HasComputedColumnSql("IIF(WorkingHours > 8, WorkingHours - 8, 0)");

            builder.Property(a => a.PiecesProduced)
                   .IsRequired()
                   .HasDefaultValue(0);

            // Configure relationships

            // Employee -> Attendance (Many to One)
            builder.HasOne(a => a.Employee)
                   .WithMany(e => e.Attendances)  // Assuming an Employee has many Attendances
                   .HasForeignKey(a => a.EmployeeId)
                   .OnDelete(DeleteBehavior.Restrict);  // Prevent cascade delete

            // LeaveType -> Attendance (Many to One)
            builder.HasOne(a => a.LeaveType)
                   .WithMany(lt => lt.Attendances)  // Assuming a LeaveType has many Attendances
                   .HasForeignKey(a => a.LeaveTypeId)
                   .OnDelete(DeleteBehavior.Restrict);  // Prevent cascade delete

            // Seed initial data for Attendance
            builder.HasData(
                new Attendance
                {
                    Id = 1,
                    Status = "Present",
                    CheckInTime = new TimeSpan(9, 0, 0),
                    CheckOutTime = new TimeSpan(17, 0, 0),
                    LeaveTypeId = 1, // Assuming '1' corresponds to a valid LeaveType
                    Remarks = "On time",
                    EmployeeId = 1 // Assuming '1' corresponds to a valid Employee
                },
                new Attendance
                {
                    Id = 2,
                    Status = "Absent",
                    LeaveTypeId = 2, // Assuming '2' corresponds to a valid LeaveType
                    Remarks = "Sick leave",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    EmployeeId = 2 // Assuming '2' corresponds to a valid Employee
                }
            );
        }
    }
}
