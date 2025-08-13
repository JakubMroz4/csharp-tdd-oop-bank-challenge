using Boolean.CSharp.Main.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class OverdraftRequest
    {
        public Guid Account { get; }
        public decimal Amount { get; }

        public OverdraftRequest(Guid account, decimal amount)
        {
            Account = account;
            Amount = amount;
        }

        public void Accept()
        {
            var account = BankAccounts.Accounts.Where(a => a.AccountNumber == Account).FirstOrDefault();

            if ( account is not null)
            {
                account.SetOverdraftLimit(Amount);
            }
        }
    }
}
