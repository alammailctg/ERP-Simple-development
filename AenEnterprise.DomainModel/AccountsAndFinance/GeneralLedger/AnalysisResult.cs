using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger
{
    public class AnalysisResult
    {
        public string ResultName { get; set; } // Name of the result
        public decimal Value { get; set; } // Value of the result
        public string Interpretation { get; set; } // Interpretation of the result

        public AnalysisResult(string resultName, decimal value, string interpretation)
        {
            ResultName = resultName;
            Value = value;
            Interpretation = interpretation;
        }
    }
}
