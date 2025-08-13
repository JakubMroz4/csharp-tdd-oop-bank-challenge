using Boolean.CSharp.Main.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Interfaces
{
    public interface ITransaction
    {
        public Guid Id { get; }
        public Guid Account {  get; }
        public decimal Value { get; }
        public TransactionTypeEnum Type { get; }
        public DateTime Date { get; }

        public bool SetAccount(Guid account);
    }
}
