using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Tests
{
    [TestClass()]
    public class AccountTests
    {
        // Unit test naming standards
        // https://osherove.com/blog/2005/4/3/naming-standards-for-unit-tests.html

        [TestInitialize] // Run this method before EVERY unit test
        public void InitTest()
        {
            acc = new Account();
            acc.Owner = "Some Person";
            acc.AccountNumber = "ABC123";

        }

        Account acc;


        [TestMethod()]
        [TestCategory("Deposit")]
        public void Deposit_PositiveAmount_AddsToBalance()
        {
            // AAA Pattern (Arrange, Act, Assert)

            // Arrange - Init objects/variables
            Account checking = new Account();
            double depositAmount = 10;
            double expectedBalance = 10;

            // Act - Call method under test
            checking.Deposit(depositAmount);

            // Assert - Verification step
            Assert.AreEqual(expectedBalance, checking.Balance);
        }

        [TestMethod]
        [TestCategory("Deposit")]
        public void Deposit_PositiveAmount_ReturnsUpdatedBalance()
        {
            // Arrange
            Account acc = new Account();
            double depositAmount = 10.55;
            double expectedReturn = 10.55;

            // Act
            double result = acc.Deposit(depositAmount);

            // Assert
            Assert.AreEqual(expectedReturn, result);
        }

        [TestMethod]
        [TestCategory("Deposit")]
        public void Deposit_NegativeAmount_ThrowsArgumentException()
        {
            // Arrange
            Account acc = new Account();
            double depositAmount = -1;

            // Assert => Act
            Assert.ThrowsException<ArgumentException>
                (() => acc.Deposit(depositAmount));
        }

        [TestMethod]
        [TestCategory("Deposit")]
        [DataRow(99)]
        [DataRow(99.99)]
        [DataRow(10000)]
        [DataRow(10.995)]
        public void Deposit_SinglePositiveAmounts_AddsToBalance(double amt)
        {
            Account checking = new Account();
            double expectedBalance = amt;

            checking.Deposit(amt);

            Assert.AreEqual(expectedBalance, checking.Balance);
        }

        [TestMethod]
        public void Withdraw_PositiveAmount_ReducesBalance()
        {
            double initialDeposit = 100;
            double withdrawAmount = 10;
            double expectedAmount = 90;

            acc.Deposit(initialDeposit);
            acc.Withdraw(withdrawAmount);

            Assert.AreEqual(expectedAmount, acc.Balance);
        }

        [TestMethod]
        [DataRow("123456")]
        [DataRow("ABC123")]
        [DataRow("A")]
        [DataRow("999999999")]
        public void AccountNum_SetValidAccNum_UpdateAccNum(string validAcc)
        {
            acc.AccountNumber = validAcc;

            Assert.AreEqual(validAcc, acc.AccountNumber);
        }

        [TestMethod]
        [DataRow("ABC#")]
        [DataRow("#ABC")]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("  ")]
        public void AccountNum_SetInvalidAccNum_ThrowsException(string invalidAcc)
        {
            // TODO: Split this into multiple tests with specific exceptions
            Assert.ThrowsException<Exception>(() => acc.AccountNumber = invalidAcc);
        }
    }
}