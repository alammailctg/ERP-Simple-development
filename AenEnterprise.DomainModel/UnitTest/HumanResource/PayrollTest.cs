using System;
using System.Collections.Generic;
using AenEnterprise.DomainModel.HumanResources; // Adjust the namespace as necessary
using Xunit;

namespace AenEnterprise.DomainModel.UnitTest.HumanResource
{
    public class PayrollTests
    {
        //[Fact]
        //public void CalculateHourlyRate_ShouldReturnCorrectHourlyRate()
        //{
        //    // Arrange
        //    var payroll = new Payroll { BaseSalary = 52000 }; // Example base salary

        //    // Act
        //    var hourlyRate = payroll.HourlyRate;

        //    // Assert
        //    Assert.Equal(25, hourlyRate); // 52000 / 2080 = 25
        //}

        //[Fact]
        //public void CalculateOvertimeRate_ShouldReturnCorrectOvertimeRate()
        //{
        //    // Arrange
        //    var payroll = new Payroll { BaseSalary = 52000 };

        //    // Act
        //    var overtimeRate = payroll.OvertimeRate;

        //    // Assert
        //    Assert.Equal(37.5m, overtimeRate); // 1.5 * 25 = 37.5
        //}

        //[Fact]
        //public void CalculateGrossSalary_ShouldDeductLeaveWithoutPayDays()
        //{
        //    // Arrange
        //    var payroll = new Payroll
        //    {
        //        BaseSalary = 52000,
        //        HoursWorked = 160,
        //        OvertimeHours = 10,
        //        LeaveWithoutPayDays = 2,
        //        Deductions = 500 // Example deduction
        //    };

        //    // Act
        //    var grossSalary = payroll.GrossSalary;

        //    // Assert
        //    decimal expectedGrossSalary = (52000 / 12) + (25 * 160) + (37.5m * 10) - (25 * 8 * 2);
        //    Assert.Equal(expectedGrossSalary, grossSalary);
        //}

        //[Fact]
        //public void CalculateNetSalary_ShouldReturnCorrectNetSalary()
        //{
        //    // Arrange
        //    var payroll = new Payroll
        //    {
        //        BaseSalary = 52000,
        //        Deductions = 500 // Example deduction
        //    };

        //    // Act
        //    var netSalary = payroll.NetSalary;

        //    // Assert
        //    Assert.Equal(payroll.GrossSalary - 500, netSalary);
        //}

        //[Fact]
        //public void CalculateLeaveWithoutPayDays_ShouldCountLeavesAndAbsences()
        //{
        //    // Arrange
        //    var payroll = new Payroll();
        //    var leaves = new List<Leave>
        //    {
        //        new Leave { EmployeeId = 1, LeaveType = new LeaveType { Id = 4 }, DaysOfLeave = 1 },
        //        new Leave { EmployeeId = 1, LeaveType = new LeaveType { Id = 4 }, DaysOfLeave = 2 },
        //    };
        //    var attendances = new List<Attendance>
        //    {
        //        new Attendance { EmployeeId = 1, Status = "Absent" },
        //        new Attendance { EmployeeId = 1, Status = "Present" },
        //        new Attendance { EmployeeId = 1, Status = "Absent" }
        //    };
        //    var leaveType = new LeaveType { Id = 4 }; // Assuming this is the ID for Leave Without Pay

        //    // Act
        //    int leaveWithoutPayDays = payroll.CalculateLeaveWithoutPayDays(1, leaves, leaveType, attendances);

        //    // Assert
        //    Assert.Equal(3, leaveWithoutPayDays); // 3 total: 3 days from leaves and 2 absences
        //}
    }
}
