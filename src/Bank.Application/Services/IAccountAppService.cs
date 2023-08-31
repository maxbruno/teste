using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bank.Application.ViewModels;
using Bank.Domain.Models.Pagination;

namespace Bank.Application.Services
{
    public interface IAccountAppService : IDisposable
    {
        Page<AccountViewModel> GetAll(AccountFilterViewModel filter);
        Task<IEnumerable<TransactionViewModel>> GetByAccountId(Guid accountId);
        Task<TransactionViewModel> Transaction(TransactionInputViewModel transactionVM);        
    }
}