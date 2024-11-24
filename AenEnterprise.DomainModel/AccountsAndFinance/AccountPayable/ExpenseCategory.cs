using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.AccountsAndFinance.AccountPayable
{
    public class ExpenseCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation property for the expenses that belong to this category
        public List<Expense> Expenses { get; set; }
    }

}
