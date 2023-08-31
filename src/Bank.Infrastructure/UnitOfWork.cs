using System;
using System.Threading.Tasks;
using Bank.Domain.Interfaces;

namespace Bank.Account.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AccountContext _accountContext;

        public UnitOfWork(AccountContext accountContext)
        {
            _accountContext = accountContext;
        }
        public async Task<bool> Commit()
        {
            return await _accountContext.SaveChangesAsync() > 0;
        }
        public void Dispose()
        {
            _accountContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}