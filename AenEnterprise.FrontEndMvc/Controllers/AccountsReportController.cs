using AenEnterprise.ServiceImplementations.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace AenEnterprise.FrontEndMvc.Controllers
{
    public class AccountsReportController : Controller
    {
        private readonly BaseGenerateReport _baseGenerateReport;

        public AccountsReportController(IWebHostEnvironment env, ISalesOrderService salesOrderService)
        {
            _baseGenerateReport = new BaseGenerateReport(env);
        }

        public FileContentResult GetTrialBalanceByDate(DateTime asOfDate)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@AsOfDate", SqlDbType.DateTime) {Value = asOfDate  },
            };
            string query = @"
        SELECT 
            JournalEntries.CreatedDate, 
            Accounts.AccountName, 
            JournalEntryLines.DebitAmount, 
            JournalEntryLines.CreditAmount
        FROM 
            JournalEntries
        INNER JOIN 
            JournalEntryLines ON JournalEntries.JournalEntryId = JournalEntryLines.JournalEntryId
        INNER JOIN 
            Accounts ON JournalEntryLines.AccountId = Accounts.AccountId
        WHERE 
            JournalEntries.CreatedDate BETWEEN (SELECT MIN(CreatedDate) FROM JournalEntries) AND @AsOfDate";
            return _baseGenerateReport.GenerateReport(query, parameters, "DataSetAccounts", "TrialBalance.rdlc", "DataSetAccounts");
        }

    }
}
