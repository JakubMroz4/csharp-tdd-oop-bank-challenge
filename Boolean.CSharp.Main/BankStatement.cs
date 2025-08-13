using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Boolean.CSharp.Main
{
    public class BankStatement
    {
        private List<ITransaction> _transactions = new();
        private decimal _startBalance;

        public BankStatement(List<ITransaction> transactions, decimal startBalance) 
        {
            _transactions = transactions;
            _startBalance = startBalance;
        }

        public void Print(IPrinter printer)
        {
            printer.Print(ToString()); //TODO
        }

        public override string ToString()
        {
            return BuildString();
        }

        private string BuildString()
        {
            StringBuilder sb = new();
            sb.AppendLine("date       || credit  ||  debit  || balance");

            decimal balance = 0;  

            Stack<string> transactionStrings = new();

            foreach (ITransaction transaction in _transactions) 
            { 
                var date = transaction.Date.ToString("yyyy-MM-dd");
                var value = transaction.Value.ToString("F2");
                balance += transaction.Value;

                string line = "";

                if (transaction.Type == Enums.TransactionTypeEnum.Credit)
                {
                    line = $"{date} || {value} ||         || {balance.ToString("F2")}";
                    transactionStrings.Push(line);
                }

                if (transaction.Type == Enums.TransactionTypeEnum.Debit)
                {
                    line = $"{date} ||         || {value} || {balance.ToString("F2")}";
                    transactionStrings.Push(line);
                }                
            }

            while (transactionStrings.Count > 0)
            {
                sb.AppendLine(transactionStrings.Pop());
            }

            return sb.ToString();
        }


    }
}
