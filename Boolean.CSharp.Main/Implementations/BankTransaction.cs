using Boolean.CSharp.Main.Enums;
using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Implementations 
{
    public class BankTransaction : ITransaction
    {
        private Guid _account = Guid.Empty;

        public Guid Id { get; } = Guid.NewGuid();

        public Guid Account { get { return _account; } }

        public decimal Value {  get; }

        public TransactionTypeEnum Type { get; }

        public DateTime Date { get; }

        public BankTransaction(decimal value, DateTime date)
        {
            Value = value;
            Date = date;

            Type = TransactionTypeEnum.Debit;
            if (value > 0)
            {
                Type = TransactionTypeEnum.Credit;
            }
            
        }

        public bool SetAccount(Guid account)
        {
            if (_account == Guid.Empty)
            {
                _account = account;
                return true;
            }
            
            return false;
        }
    }
}
