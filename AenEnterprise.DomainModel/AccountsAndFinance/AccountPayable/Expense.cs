using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.AccountsAndFinance.AccountPayable
{
    public class Expense
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Foreign key to ExpenseCategory
        public int ExpenseCategoryId { get; set; }
        public ExpenseCategory ExpenseCategory { get; set; }

        // Optional: Any additional fields related to expense
        public string Description { get; set; }
        public decimal Amount { get; set; }
    }

}
