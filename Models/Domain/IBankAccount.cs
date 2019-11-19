using System;
using System.Collections.Generic;

namespace Banking_Studeren.Models.Domain
{
    public interface IBankAccount
    {
        string AccountNumber { get; }
        decimal Balance { get; set; }
        int NumberOfTransactions { get; }

        void Deposit(decimal amount);
        IEnumerable<Transaction> GetTransactions(DateTime? from, DateTime? till);
        void WithDraw(decimal amount);
    }
}