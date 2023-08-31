using System.Collections.Generic;
using Bank.Core;

namespace Bank.Domain.Models
{
    public class Account : Entity, IAggregateRoot
    {
        protected Account(){ }
        public Account(string accountNumber, string agencyNumber, string accountHolder, decimal accountBalance)
        {
            AccountNumber = accountNumber;
            AgencyNumber = agencyNumber;
            AccountHolder = accountHolder;
            AccountBalance = accountBalance;
            Transactions = new List<Transaction>();
        }

        public string AccountNumber { get; private set; }
        public string AgencyNumber { get; private set; }
        public string AccountHolder { get; private set; }
        public decimal AccountBalance { get; private set; }
        public ICollection<Transaction> Transactions { get; private set; }


        public void Debit(decimal value)
        {
            AccountBalance -= value;
        }
        public void Deposit(decimal value)
        {
            AccountBalance += value;
        }
        public void Transfer(decimal value)
        {
            AccountBalance -= value;
        }
        public bool HasBalance(decimal value)
        {
            return AccountBalance >= value;
        }
    }
}