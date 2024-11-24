using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.DomainModel.HumanResources.Benefits
{
    public class Money
    {
        public decimal Amount { get; private set; }
        public string Currency { get; private set; }

        public Money(decimal amount, string currency)
        {
            if (amount < 0) throw new ArgumentException("Amount cannot be negative.");
            if (currency != "Tk" && currency != "৳" && currency != "USD")
                throw new ArgumentException("Currency must be Tk, ৳, or USD.");

            Amount = amount;
            Currency = currency;
        }

        public Money Add(Money other)
        {
            if (Currency != other.Currency)
                throw new InvalidOperationException("Cannot add money with different currencies.");
            return new Money(Amount + other.Amount, Currency);
        }

        public Money Multiply(decimal multiplier)
        {
            return new Money(Amount * multiplier, Currency);
        }

        public Money ConvertTo(string targetCurrency, decimal exchangeRate)
        {
            if (Currency == targetCurrency)
                return this;
            return new Money(Amount * exchangeRate, targetCurrency);
        }

        // Overloading the + operator
        public static Money operator +(Money a, Money b)
        {
            if (a.Currency != b.Currency)
                throw new InvalidOperationException("Cannot add money with different currencies.");
            return new Money(a.Amount + b.Amount, a.Currency);
        }

        public override string ToString() => $"{Amount} {Currency}";
    }


}
