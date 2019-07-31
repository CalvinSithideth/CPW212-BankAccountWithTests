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

        [TestMethod()]
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
        public void Deposit_NegativeAmount_ThrowsArgumentException()
        {
            // Arrange
            Account acc = new Account();
            double depositAmount = -1;

            // Assert => Act
            Assert.ThrowsException<ArgumentException>
                (() => acc.Deposit(depositAmount));
        }
    }
}