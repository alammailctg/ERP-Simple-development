using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.AccountsAndFinance.CashManagement
{
    public class CashForecasting
    {
        public int CashForecastingId { get; set; }
        public DateTime ForecastDate { get; set; }
        public decimal EstimatedCashInflow { get; set; }
        public decimal EstimatedCashOutflow { get; set; }

        // Navigation to BankAccount
        public int BankAccountId { get; set; }
        public BankAccount BankAccount { get; set; }
    }

}
