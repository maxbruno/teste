using System;
using System.Threading.Tasks;

namespace Bank.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
         Task<bool> Commit();
    }
}