using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger
{
    public class ComplianceFinding
    {
        public string Description { get; set; } // Description of the compliance finding
        public string Severity { get; set; } // Severity of the finding
        public bool IsResolved { get; set; } // Resolution status of the finding

        public ComplianceFinding(string description, string severity, bool isResolved = false)
        {
            Description = description;
            Severity = severity;
            IsResolved = isResolved;
        }
    }
}
