using System;
using System.Diagnostics.CodeAnalysis;
using Bank.Domain.Enums;

namespace Bank.Application.ViewModels
{
    [ExcludeFromCodeCoverage]
    public class TransactionInputViewModel
    {
        public ETransactionType TransactionType { get; set; }
        public decimal Value { get; set; }
        public Guid AccountId { get; set; }
    }
}