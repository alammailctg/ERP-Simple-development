using AenEnterprise.DomainModel.HumanResources.Benefits;
using AenEnterprise.DomainModel.HumanResources.HumanResourceInterface;
using AenEnterprise.DomainModel.InventoryManagement;
using System;
using System.Net.Http.Headers;

namespace AenEnterprise.DomainModel.HumanResources
{
    public class Employee
    {
        public Employee()
        {
          Attendances=new List<Attendance>();
        }
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Designation { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public DateTime HireDate { get; set; }
        public decimal ActualSalary { get; set; }
        public string HireStatus { get; set; }
        public decimal BasicSalary => ActualSalary/2;
        public string Status { get; set; }
        public string AppointmentType { get; set; }
        public string WorkingType { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        public string JobLocation { get; set; }
        public string PaymentType { get; set; }
        public Payroll Payroll { get; set; }
        public List<Attendance> Attendances { get; set; }
        public List<Resignation> Resignations { get; set; }
    }
}


 
