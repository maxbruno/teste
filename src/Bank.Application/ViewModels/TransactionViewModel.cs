using System;
using System.Diagnostics.CodeAnalysis;
using Bank.Domain.Enums;

namespace Bank.Application.ViewModels
{
    [ExcludeFromCodeCoverage]
    public class TransactionViewModel
    {
        public TransactionViewModel() { }

        public TransactionViewModel(ETransactionType transactionType, decimal value, Guid accountId)
        {
            TransactionType = transactionType;
            Value = value;
            AccountId = accountId;
        }

        public Guid Id { get; set; }
        public ETransactionType TransactionType { get; set; }
        public decimal Value { get; set; }
        public DateTime CreateAt { get; set; }
        public Guid AccountId { get; set; }
    }
}