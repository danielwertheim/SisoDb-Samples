using System;
using System.Linq;

namespace Examples.Ex05TransactionScopes
{
    public class ScenarioWithoutTransactionScopeExample : Example
    {
        public override void Run()
        {
            var accountA = new Account { AccountNo = "A" };
            accountA.Deposit(15000);

            var accountB = new Account { AccountNo = "B" };

            Db.UseOnceTo().InsertMany(new[] { accountA, accountB });

            try
            {
                accountA.WithDraw(500);
                accountB.Deposit(500);

                accountA.WithDraw(400);
                accountB.Deposit(400);

                accountA.WithDraw(100);
                accountB.Deposit(100);

                Db.UseOnceTo().Update(accountA);

                using(var session = Db.BeginSession())
                {
                    session.Update(accountB);

                    throw new Exception("FAIL");
                }
            }
            catch
            {
            }

            using (var session = Db.BeginSession())
            {
                accountA = session.GetById<Account>(accountA.Id);
                accountB = session.GetById<Account>(accountB.Id);
            }

            Console.Out.WriteLine("accountA.Transactions = {0}", accountA.Transactions.Count());
            Console.Out.WriteLine("accountA.Balance = {0}", accountA.Balance);

            Console.Out.WriteLine("accountB.Transactions = {0}", accountB.Transactions.Count());
            Console.Out.WriteLine("accountB.Balance = {0}", accountB.Balance);
        }
    }
}