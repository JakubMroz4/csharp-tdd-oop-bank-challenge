using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Implementations;
using NUnit.Framework;
using System.Transactions;
using Boolean.CSharp.Main.Interfaces;

using Boolean.CSharp.Main.Exceptions;
using Boolean.CSharp.Main.Enums;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {

        [Test]
        public void CreateCurrentAccountTest()
        {
            var person = new Person("Adam Maze", "NYC 7th Avenue");
            var currentAccount = new CurrentBankAccount(person, BankBranchEnum.Stavanger);

            Assert.IsNotNull(currentAccount);
            Assert.That(currentAccount.Person, Is.EqualTo(person));
            Assert.That(currentAccount.AccountType, Is.EqualTo(AccountTypeEnum.CurrentAccount));
        }

        [Test]
        public void CreateSavingsAccountTest()
        {
            var person = new Person("Adam Maze", "NYC 7th Avenue");
            var currentAccount = new SavingsBankAccount(person, BankBranchEnum.Stavanger);

            Assert.IsNotNull(currentAccount);
            Assert.That(currentAccount.Person, Is.EqualTo(person));
            Assert.That(currentAccount.AccountType, Is.EqualTo(AccountTypeEnum.SavingsAccount));
        }

        [Test]
        public void CurrentAccountAddDepositTransactionsTest()
        {
            var person = new Person("Adam Maze", "NYC 7th Avenue");
            var currentAccount = new CurrentBankAccount(person, BankBranchEnum.Stavanger);
            
            var date = DateTime.Parse("Jan 1, 2009");
            var transaction = new BankTransaction(500m, date);

            currentAccount.AddTransaction(transaction);

            var balance = currentAccount.GetBalance();

            Assert.That(balance, Is.EqualTo(500m));
        }

        [Test]
        public void CurrentAccountAddWithdrawTransactionsTest()
        {
            var person = new Person("Adam Maze", "NYC 7th Avenue");
            var currentAccount = new CurrentBankAccount(person, BankBranchEnum.Stavanger);

            var date = DateTime.Parse("Jan 1, 2009");
            var date2 = DateTime.Parse("Jan 2, 2009");

            var transaction = new BankTransaction(500m, date);
            var transaction2 = new BankTransaction(-100m, date2);

            currentAccount.AddTransaction(transaction);
            currentAccount.AddTransaction(transaction2);

            var balance = currentAccount.GetBalance();

            Assert.That(balance, Is.EqualTo(400m));
        }

        [Test]
        public void SavingsAccountAddDepositTransactionsTest()
        {
            var person = new Person("Adam Maze", "NYC 7th Avenue");
            var currentAccount = new SavingsBankAccount(person, BankBranchEnum.Stavanger);

            var date = DateTime.Parse("Jan 1, 2009");
            var transaction = new BankTransaction(500m, date);

            currentAccount.AddTransaction(transaction);

            var balance = currentAccount.GetBalance();

            Assert.That(balance, Is.EqualTo(500m));
        }

        [Test]
        public void SavingsAccountAddWithdrawTransactionsTest()
        {
            var person = new Person("Adam Maze", "NYC 7th Avenue");
            var currentAccount = new SavingsBankAccount(person, BankBranchEnum.Stavanger);

            var date = DateTime.Parse("Jan 1, 2009");
            var date2 = DateTime.Parse("Jan 2, 2009");

            var transaction = new BankTransaction(500m, date);
            var transaction2 = new BankTransaction(-100m, date2);

            currentAccount.AddTransaction(transaction);
            currentAccount.AddTransaction(transaction2);

            var balance = currentAccount.GetBalance();

            Assert.That(balance, Is.EqualTo(400m));
        }

        [Test]
        public void WithdrawFromEmptyCurrentAccountGetExceptionTest()
        {
            var person = new Person("Adam Maze", "NYC 7th Avenue");
            var currentAccount = new CurrentBankAccount(person, BankBranchEnum.Stavanger);

            var date = DateTime.Parse("Jan 1, 2009");
            var transaction2 = new BankTransaction(-100m, date);           

            Assert.Throws<NotEnoughFundsException>(() => currentAccount.AddTransaction(transaction2));
        }

        [Test]
        public void WithdrawFromEmptySavingsAccountGetExceptionTest()
        {
            var person = new Person("Adam Maze", "NYC 7th Avenue");
            var currentAccount = new SavingsBankAccount(person, BankBranchEnum.Stavanger);

            var date = DateTime.Parse("Jan 1, 2009");
            var transaction2 = new BankTransaction(-100m, date);

            Assert.Throws<NotEnoughFundsException>(() => currentAccount.AddTransaction(transaction2));
        }

        [Test]
        public void CurrentAccountGetBankStatementTest()
        {
            var person = new Person("Adam Maze", "NYC 7th Avenue");
            var currentAccount = new CurrentBankAccount(person, BankBranchEnum.Stavanger);

            var date = DateTime.Parse("Jan 10, 2012");
            var date2 = DateTime.Parse("Jan 13, 2012");
            var date3 = DateTime.Parse("Jan 14, 2012");

            var transaction = new BankTransaction(1000m, date);
            var transaction2 = new BankTransaction(2000m, date2);
            var transaction3 = new BankTransaction(-500m, date3);

            currentAccount.AddTransaction(transaction);
            currentAccount.AddTransaction(transaction2);
            currentAccount.AddTransaction(transaction3);

            var statement = currentAccount.GetStatement();

            string expected = "date       || credit  ||  debit  || balance\r\n" +
                "2012-01-14 ||         || -500,00 || 2500,00\r\n" +
                "2012-01-13 || 2000,00 ||         || 3000,00\r\n" +
                "2012-01-10 || 1000,00 ||         || 1000,00\r\n";

            var statementString = statement.ToString();

            Console.WriteLine(statementString);

            Assert.IsNotNull(statement);
            Assert.AreEqual(expected, statementString);
        }

        [Test]
        public void SavingsAccountGetBankStatementTest()
        {
            var person = new Person("Adam Maze", "NYC 7th Avenue");
            var currentAccount = new SavingsBankAccount(person, BankBranchEnum.Stavanger);

            var date = DateTime.Parse("Jan 10, 2012");
            var date2 = DateTime.Parse("Jan 13, 2012");
            var date3 = DateTime.Parse("Jan 14, 2012");

            var transaction = new BankTransaction(1000m, date);
            var transaction2 = new BankTransaction(2000m, date2);
            var transaction3 = new BankTransaction(-500m, date3);

            currentAccount.AddTransaction(transaction);
            currentAccount.AddTransaction(transaction2);
            currentAccount.AddTransaction(transaction3);

            var statement = currentAccount.GetStatement();

            string expected = "date       || credit  ||  debit  || balance\r\n" +
                "2012-01-14 ||         || -500,00 || 2500,00\r\n" +
                "2012-01-13 || 2000,00 ||         || 3000,00\r\n" +
                "2012-01-10 || 1000,00 ||         || 1000,00\r\n";

            var statementString = statement.ToString();

            Console.WriteLine(statementString);

            Assert.IsNotNull(statement);
            Assert.AreEqual(expected, statementString);
        }

    }
}