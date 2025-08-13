using Boolean.CSharp.Main.Enums;
using Boolean.CSharp.Main.Exceptions;
using Boolean.CSharp.Main.Interfaces;
using Boolean.CSharp.Main.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Implementations
{
    public class SavingsBankAccount : IBankAccount
    {
        private readonly List<ITransaction> _transactionHistory = new();
        private decimal _overdraftLimit = 0;

        public Guid Id { get; } = Guid.NewGuid();

        public Guid AccountNumber { get; } = Guid.NewGuid();

        public decimal OverdraftLimit { get { return _overdraftLimit; } }

        public AccountTypeEnum AccountType { get; }

        public Person Person { get; }

        public BankBranchEnum Branch { get; }

        public SavingsBankAccount(Person person, BankBranchEnum branch)
        {
            Person = person;
            AccountType = AccountTypeEnum.SavingsAccount;
            Branch = branch;
        }

        public void AddTransaction(ITransaction transaction)
        {
            if (transaction.Value == 0)
            {
                throw new EmptyTransactionException();
            }

            var successful = transaction.SetAccount(AccountNumber);

            if (!successful)
            {
                throw new TransactionAlreadyHasOwnerException();
            }

            if (transaction.Type == TransactionTypeEnum.Credit)
            {
                _transactionHistory.Add(transaction);
                return;
            }

            if (GetBalance() + transaction.Value < _overdraftLimit)
            {
                throw new NotEnoughFundsException();
            }

            _transactionHistory.Add(transaction);
        }

        public decimal GetBalance()
        {
            var sum = _transactionHistory.Sum(t => t.Value);
            return sum;
        }

        public BankStatement GetStatement()
        {
            var statement = new BankStatement(_transactionHistory.OrderBy(t => t.Date).ToList(), 0);
            return statement;
        }

        public void RequestOverdraftLimit(decimal overdraftLimit)
        {
            var request = new OverdraftRequest(AccountNumber, overdraftLimit);
            OverdraftRequests.Requests.Add(request);
        }

        public void SetOverdraftLimit(decimal limit)
        {
            _overdraftLimit = limit;
        }
    }
}
