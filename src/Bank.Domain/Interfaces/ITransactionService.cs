using System;
using System.Threading.Tasks;
using Bank.Domain.Models;

namespace Bank.Domain.Interfaces
{
    public interface ITransactionService : IDisposable
    {
        Task DebitAccount(Transaction transaction);
        Task DepositAccount(Transaction transaction);
        Task TransferAccount(Transaction transaction);
    }
}