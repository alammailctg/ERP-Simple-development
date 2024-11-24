using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger
{
    public class ComplianceCheck
    {
        public int ComplianceCheckId { get; set; } // Unique identifier for the compliance check
        public DateTime CheckDate { get; set; } // Date of the compliance check
        public string Regulation { get; set; } // Regulation or policy being checked
        public bool IsCompliant { get; set; } // Compliance status
        public List<ComplianceFinding> Findings { get; set; } // List of findings for the compliance check

        public ComplianceCheck()
        {
            Findings = new List<ComplianceFinding>();
            CheckDate = DateTime.Today; // Default to today
        }

        // Method to add a finding to the compliance check
        public void AddFinding(ComplianceFinding finding)
        {
            Findings.Add(finding);
        }

        // Method to get compliance status
        public string GetComplianceStatus()
        {
            return IsCompliant ? "Compliant" : "Non-Compliant";
        }
    }
}
