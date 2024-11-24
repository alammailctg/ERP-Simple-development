using AenEnterprise.DomainModel.AccountsAndFinance.AccountPayable;
using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable.SalesManagement;
using AenEnterprise.DomainModel.HumanResources.Benefits;
using AenEnterprise.DomainModel.HumanResources.HumanResourceInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AenEnterprise.DomainModel.HumanResources
{
    public class Payroll
    {
        private readonly List<Attendance> _attendances;
        private int _totalPresentHours;
        private decimal _totalPresentAmount;
        private decimal _hourlyRate;
        private Employee _employee;
        private int _totalOverTimeHours;
        private decimal _totalOverTimeAmount;
        private readonly IAttendanceCalculator _attendanceCalculator;
        private readonly IOverTimeCalculator _overTimeCalculator;
        private readonly IAllowanceCalculator _allowanceCalculator;
        private readonly IBenefitCalculator _benefitCalculator;
        public Payroll()
        {

        }
        public Payroll(IAttendanceCalculator attendanceCalculator, IOverTimeCalculator overTimeCalculator,
            List<Attendance> attendances, Employee employee, string status, int year, int month,
            IAllowanceCalculator allowanceCalculator, IBenefitCalculator benefitCalculator,
            List<Allowances> allowances, List<Benefit> benefits, List<AdvancePayment> advancePayments)
        {
            CreatedDate = DateTime.Now;
            _attendances = attendances;
            _attendanceCalculator = attendanceCalculator;
            _overTimeCalculator = overTimeCalculator;
            _hourlyRate = CalculateHourlyRate(year, month, employee.ActualSalary);
            _totalPresentHours = _attendanceCalculator.CountPresentHours(attendances, employee);
            _totalPresentAmount = _attendanceCalculator.CalculatePresentAmount(_hourlyRate, _totalPresentHours);
            _totalOverTimeHours = _overTimeCalculator.CalculateOverTimeHours(attendances, employee);
            _totalOverTimeAmount = _overTimeCalculator.CalculateOverTimeAmount(_hourlyRate, _totalOverTimeHours, 2);
            _allowanceCalculator = allowanceCalculator;
            _benefitCalculator = benefitCalculator;
            TotalAllowanceAmount = _allowanceCalculator.CalculateMonthlyCost(allowances, employee);
            TotalBenefitAmount = _benefitCalculator.CalculateBenefits(benefits, employee);
            GrossSalary = CalculateGrossSalary();
            NetSalary = CalculateNetSalary(advancePayments, employee);
        }
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int EmployeeId { get; set; }
        public DateTime PaymentDate { get; set; }
        public List<AdvancePayment> AdvancePayments { get; set; }
        public List<Attendance> Attendances => _attendances;

        public decimal TaxRate { get; set; } = 0.2m;
        public int TotalPresentHours
        {
            get => _totalPresentHours;
            set => _totalPresentHours = value;
        }
        public decimal HourlyRate { get => _hourlyRate; set => _hourlyRate = value; }
        public Employee Employee { get => _employee; set => _employee = value; }
        public decimal TotalPresentAmount { get => _totalPresentAmount; set => _totalPresentAmount = value; }
        public int TotalOverTimeHours { get => _totalOverTimeHours; set => _totalOverTimeHours = value; }
        public decimal TotalOverTimeAmount { get => _totalOverTimeAmount; set => _totalOverTimeAmount = value; }
        public decimal TotalAllowanceAmount { get; set; }
        public decimal TotalBenefitAmount { get; set; }
        public decimal TotalAdvanceAmount { get; set; }
        public decimal GrossSalary { get; set; }
        public decimal NetSalary { get; set; }
        public decimal CalculateHourlyRate(int year, int month, decimal actualSalary)
        {
            decimal daysInMonth = DateTime.DaysInMonth(year, month);
            decimal hourlySalary = (actualSalary / daysInMonth) / 8;
            return hourlySalary;
        }

        public decimal CalculateGrossSalary()
        {
            var grossSalary = TotalPresentAmount + TotalOverTimeAmount + TotalAllowanceAmount + TotalBenefitAmount;
            return grossSalary * (1 - TaxRate);
        }

        public decimal CalculateNetSalary(List<AdvancePayment> advancePayments, Employee employee)
        {
            decimal netSalary = 0;
            decimal advanceAmount = advancePayments.Where(a => a.EmployeeId == employee.Id).Sum(a => a.Amount);
            return netSalary = CalculateGrossSalary() - advanceAmount;
        }
    }
}



//public decimal CalculateTotalBenefitsCost(Employee employee)
//{
//    return employee.Benefits.Sum(benefit => benefit.CalculateMonthlyCost());
//}
//Old c#-6
//public Money CalculateTotalBenefitsCost(Employee employee)
//{
//    Money total = new Money(0, employee.BaseSalary.Currency); // Initialize total

//    foreach (var benefit in employee.Benefits)
//    {
//        total = total + benefit.CalculateMonthlyCost(); // Accumulate the costs
//    }

//    return total; // Return the total cost of benefits
//}