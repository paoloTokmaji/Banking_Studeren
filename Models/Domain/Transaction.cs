using System;
using System.Collections.Generic;
using System.Text;

namespace Banking_Studeren.Models.Domain
{
    public class Transaction
    {
        public decimal Amount { get; }
        public DateTime DateOfTrans { get; }
        public TransactionType TransactionType { get; }

        public bool IsDeposit => TransactionType == TransactionType.Deposit;
        
        public bool IsWithdraw
        {
            get { return TransactionType == TransactionType.Withdraw; }
        }

        public Transaction(decimal amount, TransactionType type)
        {
            Amount = amount;
            TransactionType = type;
            DateOfTrans = DateTime.Now;
        }
    }
}
