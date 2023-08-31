using System.Threading.Tasks;
using Bank.Domain.Interfaces;
using Bank.Domain.Models;

namespace Bank.Domain.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDomainNotification _notification;

        public TransactionService(IAccountRepository accountRepository, IUnitOfWork unitOfWork,
            IDomainNotification notification)
        {
            _accountRepository = accountRepository;
            _unitOfWork = unitOfWork;
            _notification = notification;
        }

        public async Task DebitAccount(Transaction transaction)
        {
            var account = await _accountRepository.GetAccountById(transaction.AccountId);

            if (account == null)
            {
                _notification.AddNotification("DebitAccount", "Não foi possível encontrar sua conta.");
                return;
            }

            if (!account.HasBalance(transaction.Value))
            {
                _notification.AddNotification("DebitAccount", "Saldo insuficiente para saque.");
                return;
            }

            account.Debit(transaction.Value);

            _accountRepository.AddTransaction(transaction);
            _accountRepository.UpdateAccount(account);
            await _unitOfWork.Commit();
        }

        public async Task DepositAccount(Transaction transaction)
        {
            var account = await _accountRepository.GetAccountById(transaction.AccountId);
            
            if (account == null)
            {
                _notification.AddNotification("DepositAccount", "Não foi possível encontrar sua conta.");
                return;
            }
            account.Deposit(transaction.Value);

            _accountRepository.AddTransaction(transaction);
            _accountRepository.UpdateAccount(account);
            await _unitOfWork.Commit();
        }

        public async Task TransferAccount(Transaction transaction)
        {
            var account = await _accountRepository.GetAccountById(transaction.AccountId);

           
            if (account == null)
            {
                _notification.AddNotification("TransferAccount", "Não foi possível encontrar sua conta.");
                return;
            }

            if (!account.HasBalance(transaction.Value))
            {
                _notification.AddNotification("TransferAccount", "Saldo insuficiente para transferência.");
                return;
            }

            account.Transfer(transaction.Value);
            
            _accountRepository.AddTransaction(transaction);
            _accountRepository.UpdateAccount(account);
            await _unitOfWork.Commit();
        }

        public void Dispose()
        {
            _accountRepository.Dispose();
        }
    }
}