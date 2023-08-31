using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Bank.Application.Services;
using Bank.Application.ViewModels;
using Bank.Domain.Interfaces;
using Bank.Domain.Models;
using Bank.Domain.Models.Pagination;
using Bank.Unit.Tests.Mocks;
using Moq;
using Xunit;

namespace Bank.Unit.Tests.Application
{
    public class AccountAppServiceTest
    {
        private readonly Mock<ITransactionService> _transactionServiceMock;
        private readonly Mock<IAccountRepository> _accountRepositoryMock;
        private readonly Mock<IDomainNotification> _domainNotificationMock;
        private readonly Mock<IMapper> _mapperMock;

        public AccountAppServiceTest()
        {
            _transactionServiceMock = new Mock<ITransactionService>();
            _accountRepositoryMock = new Mock<IAccountRepository>();
            _domainNotificationMock = new Mock<IDomainNotification>();
            _mapperMock = new Mock<IMapper>();
        }

        [Trait("Category", "Application")]
        [Fact]
        public void GetAll_ReturnAccountViewModelTestAsync()
        {
            var filter = new AccountFilterViewModel();
            
            
            _accountRepositoryMock.Setup(x => x.GetAccounts())
                .Returns(AccountMock.AccountModelFaker.Generate(3).AsQueryable());
        
            _mapperMock.Setup(x =>
                    x.Map<Page<AccountViewModel>>(It.IsAny<Page<Bank.Domain.Models.Account>>()))
                .Returns(AccountMock.PageAccountViewModelModelFaker.Generate());
        
            var accountAppService = new AccountAppService(_accountRepositoryMock.Object,
                _mapperMock.Object, _transactionServiceMock.Object, _domainNotificationMock.Object);
        
            var accountMethod = accountAppService.GetAll(filter);
        
            var accountResult = Assert.IsAssignableFrom<Page<AccountViewModel>>(accountMethod);
        
            Assert.NotNull(accountResult);
            Assert.NotEmpty(accountResult.Content);
        }

        [Trait("Category", "Application")]
        [Fact]
        public async Task GetByAccountId_ReturnTransactionViewModelTestAsync()
        {
            var transactions = TransactionMock.TransactionModelFaker.Generate(3);

            _accountRepositoryMock.Setup(x => x.GetTransactionsByAccountId(transactions.FirstOrDefault().AccountId))
                .ReturnsAsync(transactions);

            _mapperMock.Setup(x =>
                    x.Map<IEnumerable<TransactionViewModel>>(It.IsAny<IEnumerable<Transaction>>()))
                .Returns(TransactionMock.TransactionViewModelModelFaker.Generate(3));

            var accountAppService = new AccountAppService(_accountRepositoryMock.Object,
                _mapperMock.Object, _transactionServiceMock.Object, _domainNotificationMock.Object);

            var accountMethod = await accountAppService.GetByAccountId(transactions.FirstOrDefault().AccountId);

            var accountResult = Assert.IsAssignableFrom<IEnumerable<TransactionViewModel>>(accountMethod);

            Assert.NotNull(accountResult);
            Assert.NotEmpty(accountResult);
        }

        [Fact]
        public async Task VerifyGetDebitTransaction_ReturnAccountViewModelTestAsync()
        {
            var account = AccountMock.AccountModelFaker.Generate();
            var transactionDebitInputViewModel = TransactionMock.TransactionDebitInputViewModelModelFaker.Generate();

            _mapperMock.Setup(x => x.Map<Transaction>(It.IsAny<TransactionInputViewModel>()))
                .Returns(TransactionMock.TransactionModelFakerTyped(transactionDebitInputViewModel).Generate());

            _mapperMock.Setup(x => x.Map<TransactionViewModel>(It.IsAny<Transaction>()))
                .Returns(TransactionMock.TransactionViewModelModelFaker.Generate());

            _accountRepositoryMock.Setup(x => x.GetAccountById(account.Id))
                .ReturnsAsync(AccountMock.AccountModelFaker.Generate());

            _transactionServiceMock.Setup(x => x.DebitAccount(It.IsAny<Transaction>()))
                .Returns(Task.CompletedTask);

            var accountAppService = new AccountAppService(_accountRepositoryMock.Object,
                _mapperMock.Object, _transactionServiceMock.Object, _domainNotificationMock.Object);

            var accountMethod = await accountAppService.Transaction(transactionDebitInputViewModel);
            var accountResult = Assert.IsAssignableFrom<TransactionViewModel>(accountMethod);

            _transactionServiceMock.Verify(x => x.DebitAccount(It.IsAny<Transaction>()), Times.Once());
            Assert.NotNull(accountResult);
        }

        [Fact]
        public async Task VerifyGetDepositTransaction_ReturnAccountViewModelTestAsync()
        {
            var account = AccountMock.AccountModelFaker.Generate();
            var transactionDepositInputViewModel =
                TransactionMock.TransactionDepositInputViewModelModelFaker.Generate();

            _mapperMock.Setup(x => x.Map<Transaction>(It.IsAny<TransactionInputViewModel>()))
                .Returns(TransactionMock.TransactionModelFakerTyped(transactionDepositInputViewModel).Generate());

            _mapperMock.Setup(x => x.Map<TransactionViewModel>(It.IsAny<Transaction>()))
                .Returns(TransactionMock.TransactionViewModelModelFaker.Generate());

            _accountRepositoryMock.Setup(x => x.GetAccountById(account.Id))
                .ReturnsAsync(AccountMock.AccountModelFaker.Generate());

            _transactionServiceMock.Setup(x => x.DepositAccount(It.IsAny<Transaction>()))
                .Returns(Task.CompletedTask);

            var accountAppService = new AccountAppService(_accountRepositoryMock.Object,
                _mapperMock.Object, _transactionServiceMock.Object, _domainNotificationMock.Object);

            var accountMethod = await accountAppService.Transaction(transactionDepositInputViewModel);
            var accountResult = Assert.IsAssignableFrom<TransactionViewModel>(accountMethod);

            _transactionServiceMock.Verify(x => x.DepositAccount(It.IsAny<Transaction>()), Times.Once());
            Assert.NotNull(accountResult);
        }

        [Fact]
        public async Task VerifyGetTransferTransaction_ReturnAccountViewModelTestAsync()
        {
            var account = AccountMock.AccountModelFaker.Generate();
            var transactionTransferInputViewModel =
                TransactionMock.TransactionTransferInputViewModelModelFaker.Generate();

            _mapperMock.Setup(x => x.Map<Transaction>(It.IsAny<TransactionInputViewModel>()))
                .Returns(TransactionMock.TransactionModelFakerTyped(transactionTransferInputViewModel).Generate());

            _mapperMock.Setup(x => x.Map<TransactionViewModel>(It.IsAny<Transaction>()))
                .Returns(TransactionMock.TransactionViewModelModelFaker.Generate());

            _accountRepositoryMock.Setup(x => x.GetAccountById(account.Id))
                .ReturnsAsync(AccountMock.AccountModelFaker.Generate());

            _transactionServiceMock.Setup(x => x.TransferAccount(It.IsAny<Transaction>()))
                .Returns(Task.CompletedTask);

            var accountAppService = new AccountAppService(_accountRepositoryMock.Object,
                _mapperMock.Object, _transactionServiceMock.Object, _domainNotificationMock.Object);

            var accountMethod = await accountAppService.Transaction(transactionTransferInputViewModel);
            var accountResult = Assert.IsAssignableFrom<TransactionViewModel>(accountMethod);

            _transactionServiceMock.Verify(x => x.TransferAccount(It.IsAny<Transaction>()), Times.Once());
            Assert.NotNull(accountResult);
        }
    }
}