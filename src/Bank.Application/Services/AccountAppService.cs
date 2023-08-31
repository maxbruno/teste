using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Bank.Account.Repository.Extensions;
using Bank.Application.ViewModels;
using Bank.Domain.Enums;
using Bank.Domain.Interfaces;
using Bank.Domain.Models;
using Bank.Domain.Models.Pagination;
using Bank.Domain.Validations;

namespace Bank.Application.Services
{
    public class AccountAppService : IAccountAppService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        private readonly ITransactionService _transactionService;
        private readonly IDomainNotification _notification;

        public AccountAppService(
            IAccountRepository accountRepository,
            IMapper mapper,
            ITransactionService transactionService,
            IDomainNotification notification)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
            _transactionService = transactionService;
            _notification = notification;
        }

        public Page<AccountViewModel> GetAll(AccountFilterViewModel filter)
        {
            var query = _accountRepository.GetAccounts();
            return _mapper.Map<Page<AccountViewModel>>(query.Page(filter));
        }

        public async Task<IEnumerable<TransactionViewModel>> GetByAccountId(Guid accountId)
        {
            return _mapper.Map<IEnumerable<TransactionViewModel>>(
                await _accountRepository.GetTransactionsByAccountId(accountId));
        }

        public async Task<TransactionViewModel> Transaction(TransactionInputViewModel transactionVM)
        {
            TransactionViewModel viewModel = null;
            var transaction = _mapper.Map<Transaction>(transactionVM);
            var validation = await new TransactionInsertValidation().ValidateAsync(transaction);

            if (!validation.IsValid)
            {
                _notification.AddNotifications(validation);
                return viewModel;
            }

            switch (transaction.TransactionType)
            {
                case ETransactionType.Debit:
                    await _transactionService.DebitAccount(transaction);
                    break;
                case ETransactionType.Deposit:
                case ETransactionType.BankIncome:
                {
                    await _transactionService.DepositAccount(transaction);
                    break;
                }
                case ETransactionType.Transfer:
                    await _transactionService.TransferAccount(transaction);
                    break;
                default:
                    _notification.AddNotification("transaction", "Tipo de transação não disponível.");
                    return null;
            }

            viewModel = _mapper.Map<TransactionViewModel>(transaction);
            return viewModel;
        }

        public void Dispose()
        {
            _accountRepository?.Dispose();
        }
    }
}