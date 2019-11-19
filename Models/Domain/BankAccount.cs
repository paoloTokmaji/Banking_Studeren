using System;
using System.Collections.Generic;
using System.Text;

namespace Banking_Studeren.Models.Domain
{
    public class BankAccount : IBankAccount
    {
        private string _accountNumber;
        public string AccountNumber {
            get { return _accountNumber; }
            private set
            {
                if(value == string.Empty)
                {
                    throw new ArgumentException(nameof(AccountNumber), "AccountNumber must have a value");
                }
                _accountNumber = value;
            }
        }

        public decimal Balance { get; set; }

        private readonly IList<Transaction> _transactions;

        public const decimal WithdrawCost = 0.25M;

        public BankAccount(string account)
        {
            AccountNumber = account;
            Balance = Decimal.Zero;
            _transactions = new List<Transaction>();
        }

        public int NumberOfTransactions
        {
            get { return _transactions.Count; }
        }

        public IEnumerable<Transaction> GetTransactions(DateTime? from, DateTime? till)
        {
            if (from == null && till == null) return _transactions;
            if (from is null) from = DateTime.MinValue;
            if (!till.HasValue) till = DateTime.MaxValue;

            IList<Transaction> transList = new List<Transaction>();
            foreach (Transaction t in _transactions)
            {
                if (t.DateOfTrans >= from && t.DateOfTrans <= till)
                    transList.Add(t);
            }
            return transList;
        }

        public void Deposit(decimal amount)
        {
            _transactions.Add(new Transaction(amount, TransactionType.Deposit));
            if(amount <= 0)
            {
                throw new ArgumentException("Amount must be a positive number bigger than zero");
            }

            Balance += amount;
        }

        public virtual void WithDraw(decimal amount)
        {
            _transactions.Add(new Transaction(amount, TransactionType.Withdraw));
            if (amount <= 0)
            {
                throw new ArgumentException("Amount must be a positive number bigger than zero");
            }
            Balance -= amount;
        }

        public override string ToString()
        {
            return $"{AccountNumber}-{Balance}";

        }

        public override bool Equals(object obj)
        {

            if (!(obj is BankAccount account)) return false;
            return AccountNumber == account.AccountNumber;

        }

        public override int GetHashCode()
        {
            return AccountNumber?.GetHashCode() ?? 0;
        }
    }
}
