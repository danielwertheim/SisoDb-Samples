using System;
using System.Collections.Generic;
using System.Linq;
using PineCone.Annotations;

namespace Examples.Ex05TransactionScopes
{
    public class Account
    {
        private readonly List<Transaction> _transactions = new List<Transaction>();

        public Guid Id { get; set; }

        [Unique(UniqueModes.PerType)]
        public string AccountNo { get; set; }

        public IEnumerable<Transaction> Transactions
        {
            get
            {
                return _transactions;
            }
            private set
            {
                _transactions.Clear();
                _transactions.AddRange(value);
            }
        }

        public decimal Balance
        {
            get { return Transactions.Sum(t => t.Amount); }
        }

        public void Deposit(decimal amount)
        {
            _transactions.Add(new Transaction(amount));
        }

        public void WithDraw(decimal amount)
        {
            _transactions.Add(new Transaction(Math.Abs(amount) * -1));
        }
    }
}