using System;
using Bank.Core;
using Bank.Domain.Enums;

namespace Bank.Domain.Models
{
    public class Transaction : Entity
    {
        protected Transaction(){ }
        public Transaction(ETransactionType transactionType, decimal value, Guid accountId)
        {
            TransactionType = transactionType;
            Value = value;
            CreateAt = DateTime.Now;
            AccountId = accountId;
        }

        public ETransactionType TransactionType { get; private set; }
        public decimal Value { get; private set; }
        public DateTime CreateAt { get; private set; }
        public Guid AccountId { get; private set; }
    }
}