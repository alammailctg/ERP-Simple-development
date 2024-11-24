using AenEnterprise.DomainModel.HumanResources;
using Microsoft.EntityFrameworkCore;

namespace AenEnterprise.DataAccess.ModelEntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;

    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            // Configure primary key
            builder.HasKey(e => e.Id);

            // Configure properties
            builder.Property(e => e.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(e => e.Designation)
                   .HasMaxLength(50);

            builder.Property(e => e.Address)
                   .HasMaxLength(50);
            builder.Property(e => e.HireStatus)
                 .HasMaxLength(50);


            builder.Property(e => e.JobLocation)
                  .HasMaxLength(50);

            builder.Property(e => e.PaymentType)
                  .HasMaxLength(50);

            builder.Property(e => e.WorkingType)
                  .HasMaxLength(50);

            builder.Property(e => e.AppointmentType)
                  .HasMaxLength(50);

            builder.Property(e => e.HireDate)
                   .IsRequired();

            builder.Property(e => e.Status)
                   .HasMaxLength(20);

            builder.Property(e => e.ActualSalary)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");


            builder.HasOne(e => e.Department)
                   .WithMany(d => d.Employees)
                   .HasForeignKey(e => e.DepartmentId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Payroll)
                   .WithOne(p => p.Employee)
                   .HasForeignKey<Payroll>(p => p.EmployeeId);

            // Seed data for Employee entity
            builder.HasData(
                new Employee
                {
                    Id = 1,
                    Name = "Azam",
                    Designation = "Driver",
                    Address = "Chittagong",
                    HireStatus = "Confirm",
                    AppointmentType = "Parmanent",
                    CompanyId = 1,
                    JobLocation = "Chittagong",
                    BranchId = 1,
                    PaymentType = "Monthly",
                    WorkingType = "Full Time",
                    DepartmentId = 1,
                    HireDate = new DateTime(2022, 1, 15),
                    Status = "Active",
                    ActualSalary = 60000m
                },
                 new Employee
                 {
                     Id = 2,
                     Name = "Hanif",
                     Designation = "Commarcial manager",
                     Address = "Chittagong",
                     HireStatus = "Confirm",
                     AppointmentType = "Parmanent",
                     CompanyId = 1,
                     JobLocation = "Chittagong",
                     BranchId = 1,
                     PaymentType = "Monthly",
                     WorkingType = "Full Time",
                     DepartmentId = 1,
                     HireDate = new DateTime(2022, 1, 15),
                     Status = "Active",
                     ActualSalary = 60000m
                 }
            );
        }
    }


}




