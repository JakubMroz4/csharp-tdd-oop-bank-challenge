using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Enums;
using Boolean.CSharp.Main.Exceptions;
using Boolean.CSharp.Main.Implementations;
using Boolean.CSharp.Main.Static;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class ExtensionTests
    {
        [Test]
        public void CurrentAccountBranchTest()
        {
            var person = new Person("Adam Maze", "NYC 7th Avenue");
            var currentAccount = new CurrentBankAccount(person, BankBranchEnum.Stavanger);

            Assert.IsNotNull(currentAccount);
            Assert.That(currentAccount.Branch, Is.EqualTo(BankBranchEnum.Stavanger));
        }
        [Test]
        public void SavingsAccountBranchTest()
        {
            var person = new Person("Adam Maze", "NYC 7th Avenue");
            var currentAccount = new SavingsBankAccount(person, BankBranchEnum.Stavanger);

            Assert.IsNotNull(currentAccount);
            Assert.That(currentAccount.Branch, Is.EqualTo(BankBranchEnum.Stavanger));
        }

        [Test]
        public void RequestOverdraftTest()
        {
            var person = new Person("Adam Maze", "NYC 7th Avenue");
            var currentAccount = new CurrentBankAccount(person, BankBranchEnum.Stavanger);
            BankAccounts.Accounts.Add(currentAccount);

            currentAccount.RequestOverdraftLimit(-500m);
            var request = OverdraftRequests.GetRequest(currentAccount.AccountNumber);
            request.Accept();

            Console.WriteLine(currentAccount.OverdraftLimit);


            var date = DateTime.Parse("Jan 1, 2009");
            var transaction = new BankTransaction(-100m, date);
            currentAccount.AddTransaction(transaction);

            var balance = currentAccount.GetBalance();

            Assert.That(balance, Is.EqualTo(-100m));

            var date2 = DateTime.Parse("Jan 2, 2009");
            var transaction2 = new BankTransaction(-500m, date);

            Assert.Throws<NotEnoughFundsException>(() => currentAccount.AddTransaction(transaction2));
        }
    }
}
