using System;

namespace Examples.Ex05TransactionScopes
{
    public class Transaction
    {
        public decimal Amount { get; private set; }

        public DateTime When { get; private set; }

        public Transaction(decimal amount)
        {
            Amount = amount;
            When = DateTime.Now;
        }
    }
}