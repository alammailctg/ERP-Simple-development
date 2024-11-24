using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger
{
    public class AuditFinding
    {
        public string Description { get; set; } // Description of the finding
        public string Severity { get; set; } // Severity of the finding (e.g., High, Medium, Low)
        public bool IsResolved { get; set; } // Status of the finding

        public AuditFinding(string description, string severity, bool isResolved = false)
        {
            Description = description;
            Severity = severity;
            IsResolved = isResolved;
        }
    }

}
