using AenEnterprise.DomainModel.HumanResources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PayrollConfiguration : IEntityTypeConfiguration<Payroll>
{
    public void Configure(EntityTypeBuilder<Payroll> builder)
    {
        // Configure primary key
        builder.HasKey(p => p.Id);

        // Configure properties
        builder.Property(p => p.PaymentDate)
               .IsRequired();

        builder.Property(p => p.HourlyRate)
               .HasColumnType("decimal(18,2)");

        builder.Property(p => p.TotalPresentHours)
               .HasColumnType("decimal(18,2)");

        builder.Property(p => p.TotalPresentAmount)
               .HasColumnType("decimal(18,2)");

        builder.Property(p => p.TotalOverTimeHours)
               .HasColumnType("decimal(18,2)");

        builder.Property(p => p.TotalOverTimeAmount)
               .HasColumnType("decimal(18,2)");
        builder.Property(p => p.GrossSalary)
              .HasColumnType("decimal(18,2)");

        builder.Property(p => p.NetSalary)
              .HasColumnType("decimal(18,2)");

        builder.Property(p => p.TaxRate)
               .HasColumnType("decimal(18,2)");

        builder.Property(p => p.TotalAdvanceAmount).HasPrecision(18, 2); // Precision 18, scale 2
        builder.Property(p => p.TotalAllowanceAmount).HasPrecision(18, 2);
        builder.Property(p => p.TotalBenefitAmount).HasPrecision(18, 2);

        builder.HasOne(p => p.Employee)
         .WithOne(e => e.Payroll)
         .HasForeignKey<Payroll>(p => p.EmployeeId)
         .OnDelete(DeleteBehavior.Restrict);


    }
}
