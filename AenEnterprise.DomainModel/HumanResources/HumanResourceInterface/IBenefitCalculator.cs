using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AenEnterprise.DomainModel.HumanResources.Benefits;

namespace AenEnterprise.DomainModel.HumanResources.HumanResourceInterface
{
    public interface IBenefitCalculator
    {
        decimal CalculateBenefits(List<Benefit> benefits, Employee employee);
    }
}
