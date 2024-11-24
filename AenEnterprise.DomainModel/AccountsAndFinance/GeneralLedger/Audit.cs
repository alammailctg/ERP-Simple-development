using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger
{
    public class Audit
    {
        public int AuditId { get; set; } // Unique identifier for the audit
        public DateTime AuditDate { get; set; } // Date of the audit
        public string AuditType { get; set; } // Type of audit (e.g., internal, external, compliance)
        public string AuditorName { get; set; } // Name of the auditor
        public List<AuditFinding> Findings { get; set; } // List of findings from the audit

        public Audit()
        {
            Findings = new List<AuditFinding>();
            AuditDate = DateTime.Today; // Default to today
        }

        // Method to add a finding to the audit
        public void AddFinding(AuditFinding finding)
        {
            Findings.Add(finding);
        }

        // Method to summarize total findings
        public int TotalFindings => Findings.Count;

        public void PerformAuditAndComplianceChecks()
        {
            // Create a new audit
            Audit audit = new Audit { AuditType = "Internal", AuditorName = "John Doe" };
            audit.AddFinding(new AuditFinding("Lack of proper documentation", "High"));
            audit.AddFinding(new AuditFinding("Outdated software versions", "Medium"));

            Console.WriteLine($"Audit ID: {audit.AuditId}, Date: {audit.AuditDate}, Type: {audit.AuditType}, Auditor: {audit.AuditorName}");
            Console.WriteLine($"Total Findings: {audit.TotalFindings}");
            foreach (var finding in audit.Findings)
            {
                Console.WriteLine($"Finding: {finding.Description}, Severity: {finding.Severity}, Resolved: {finding.IsResolved}");
            }

            // Create a new compliance check
            ComplianceCheck complianceCheck = new ComplianceCheck { Regulation = "GDPR", IsCompliant = false };
            complianceCheck.CheckDate = DateTime.Today;

            Console.WriteLine($"\nCompliance Check ID: {complianceCheck.ComplianceCheckId}, Date: {complianceCheck.CheckDate}, Regulation: {complianceCheck.Regulation}, Status: {complianceCheck.GetComplianceStatus()}");
            complianceCheck.AddFinding(new ComplianceFinding("Personal data not encrypted", "High", false));

            Console.WriteLine($"Compliance Finding: {complianceCheck.Findings.First().Description}, Severity: {complianceCheck.Findings.First().Severity}, Resolved: {complianceCheck.Findings.First().IsResolved}");
        }
    }
}
