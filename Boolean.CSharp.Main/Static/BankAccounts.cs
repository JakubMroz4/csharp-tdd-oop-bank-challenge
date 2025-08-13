using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Static
{
    public static class BankAccounts
    {
        public static List<IBankAccount> Accounts { get; } = new();
    }
}
