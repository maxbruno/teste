using Bank.Account.Data.Repositories;
using Bank.Account.Repository;
using Bank.Application.Services;
using Bank.Domain.Interfaces;
using Bank.Domain.Notifications;
using Bank.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Bank.API.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDiConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IAccountAppService, AccountAppService>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            
            services.AddScoped<IDomainNotification, DomainNotification>();
            services.AddScoped<ITransactionService, TransactionService>();
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}