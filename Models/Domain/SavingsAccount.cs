using System;

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

        public override void Withdraw(decimal amount)
        {

            if (amount <= 0)
            {
                throw new ArgumentException("Amount must be a positive number bigger than zero");
            }
            if((base.Balance - amount) <= 0)
            {
                throw new InvalidOperationException("You can't go below zero on your savingsaccount, chose a smaller amount to withdraw!");
            }
            base.Withdraw(amount);
            base.Withdraw(WithdrawCost);

        }
    }
}
