using Boolean.CSharp.Main.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Interfaces
{
    public interface IBankAccount
    {
        public Guid Id { get; }
        public Guid AccountNumber { get; }
        public decimal OverdraftLimit { get; }
        public AccountTypeEnum AccountType { get; }
        public BankBranchEnum Branch { get; }
        public Person Person { get; }

        public BankStatement GetStatement();
        public decimal GetBalance();
        public void AddTransaction(ITransaction transaction);
        public void RequestOverdraftLimit(decimal overdraftLimit);
        public void SetOverdraftLimit(decimal overdraftLimit);
    }
}
