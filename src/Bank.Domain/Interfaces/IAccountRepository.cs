using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bank.Domain.Models;

namespace Bank.Domain.Interfaces
{
    public interface IAccountRepository : IDisposable
    {
        IQueryable<Domain.Models.Account> GetAccounts();
        Task<Models.Account> GetAccountById(Guid accountId);
        Task<IEnumerable<Transaction>> GetTransactionsByAccountId(Guid accountId);
        void AddTransaction(Transaction transaction);
        void UpdateAccount(Models.Account account);
    }
}