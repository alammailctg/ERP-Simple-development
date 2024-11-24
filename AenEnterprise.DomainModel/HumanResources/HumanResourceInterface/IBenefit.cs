using AenEnterprise.DomainModel.HumanResources.Benefits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.HumanResources.HumanResourceInterface
{
    public interface IBenefit
    {
        decimal? MonthlyCost { get; set; }
    }

}
