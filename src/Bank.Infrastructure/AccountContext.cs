using System.Linq;
using System.Reflection;
using Bank.Account.Repository.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Bank.Account.Repository
{
    public class AccountContext : DbContext
    {
        public AccountContext(DbContextOptions<AccountContext> options)
            : base(options)
        {
        }

        public DbSet<Domain.Models.Account> Account { get; set; }
        public DbSet<Domain.Models.Transaction> Transaction { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
        }
    }
}