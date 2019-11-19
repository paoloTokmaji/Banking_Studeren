
using Banking_Studeren.Models.Domain;
using System;

namespace Banking_Studeren
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount ba = new BankAccount("123_123123_12");
            ba.Balance = 200M;
        }
    }
}
