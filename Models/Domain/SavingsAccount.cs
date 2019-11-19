using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Banking_Studeren.Models.Domain
{
    public class SavingsAccount : BankAccount
    {
        protected const decimal WithdrawCost = 0.25M;

        public decimal InterestRate { get; }

        public SavingsAccount(String bankAccountNumber, decimal interestRate) : base(bankAccountNumber)
        {
            InterestRate = interestRate;
        }

        public void addInterest()
        {
            Deposit(Balance * InterestRate);
        }

        public override void WithDraw(decimal amount)
        {
            base.WithDraw(amount);
            base.WithDraw(WithdrawCost);
            
        }
    }
}
