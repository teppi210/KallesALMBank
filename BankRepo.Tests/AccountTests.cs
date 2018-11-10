﻿using System;
using BankRepo.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankRepo.Tests
{
    [TestClass]
    public class AccountTests
    {
        private Account account;

        [TestInitialize]
        public void TestInitialize()
        {
            account = new Account();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WithdrawZero()
        {
            account.Withdrawl(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WithdrawNegative()
        {
            account.Withdrawl(-10);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void WithdrawInsufficient()
        {
            account.Withdrawl(10);
        }

        [TestMethod]
        public void WithdrawAfterDeposit()
        {
            account.Deposit(10);
            account.Withdrawl(5);

            Assert.AreEqual(5, account.Balance);
        }

        [TestMethod]
        public void WithdrawTwiceAfterDeposit()
        {
            account.Deposit(10);
            account.Withdrawl(5);
            account.Withdrawl(5);

            Assert.AreEqual(0, account.Balance);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void WithdrawAfterDepositInsufficient()
        {
            account.Deposit(5);
            account.Withdrawl(10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DepositZero()
        {
            account.Deposit(0);
        }

        [TestMethod]
        public void DepositPositive()
        {
            account.Deposit(5);

            Assert.AreEqual(5, account.Balance);
        }

        [TestMethod]
        public void DepositPositiveTwice()
        {
            account.Deposit(5);
            account.Deposit(5);

            Assert.AreEqual(10, account.Balance);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DepositNegative()
        {
            account.Deposit(-5);
        }
    }
}