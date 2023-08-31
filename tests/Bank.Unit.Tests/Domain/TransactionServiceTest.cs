using System;
using System.Threading.Tasks;
using Bank.Domain.Interfaces;
using Bank.Domain.Services;
using Bank.Unit.Tests.Mocks;
using Moq;
using Xunit;

namespace Bank.Unit.Tests.Domain;

public class TransactionServiceTest
{
    private readonly Mock<IAccountRepository> _accountRepositoryMock;
    private readonly Mock<IDomainNotification> _domainNotificationMock;
    private readonly Mock<IUnitOfWork> _unitOfWork;

    public TransactionServiceTest()
    {
        _accountRepositoryMock = new Mock<IAccountRepository>();
        _domainNotificationMock = new Mock<IDomainNotification>();
        _unitOfWork = new Mock<IUnitOfWork>();
    }

    [Trait("Category", "DomainServive")]
    [Fact]
    public async Task DebitAccount_ReturnAccountNull()
    {
        _accountRepositoryMock.Setup(x => x.GetAccountById(It.IsAny<Guid>()))
            .ReturnsAsync(It.IsAny<Bank.Domain.Models.Account>());
        
        _domainNotificationMock.Setup(x => x.AddNotification(It.IsAny<string>(), It.IsAny<string>()));

        var transactionService = new TransactionService(_accountRepositoryMock.Object, _unitOfWork.Object, _domainNotificationMock.Object);

        await transactionService.DebitAccount(TransactionMock.TransactionModelFaker);
        
        _domainNotificationMock.Verify(mock => mock.AddNotification("DebitAccount", "Não foi possível encontrar sua conta."), Times.Once());
    }
    
    [Trait("Category", "DomainServive")]
    [Fact]
    public async Task DebitAccount_ReturnAccountOK()
    {
        var accountModelFaker = AccountMock.AccountModelFaker;
        
        _accountRepositoryMock.Setup(x => x.GetAccountById(It.IsAny<Guid>()))
            .ReturnsAsync(accountModelFaker);

        var transactionService = new TransactionService(_accountRepositoryMock.Object, _unitOfWork.Object, _domainNotificationMock.Object);

        await transactionService.DebitAccount(TransactionMock.TransactionModelFaker);
        
        _unitOfWork.Verify(x => x.Commit(), Times.AtMost(2));
    }
    
    
    [Trait("Category", "DomainServive")]
    [Fact]
    public async Task DepositAccount_ReturnAccountNull()
    {
        _accountRepositoryMock.Setup(x => x.GetAccountById(It.IsAny<Guid>()))
            .ReturnsAsync(It.IsAny<Bank.Domain.Models.Account>());
        
        _domainNotificationMock.Setup(x => x.AddNotification(It.IsAny<string>(), It.IsAny<string>()));

        var transactionService = new TransactionService(_accountRepositoryMock.Object, _unitOfWork.Object, _domainNotificationMock.Object);

        await transactionService.DepositAccount(TransactionMock.TransactionModelFaker);
        
        _domainNotificationMock.Verify(mock => mock.AddNotification("DepositAccount", "Não foi possível encontrar sua conta."), Times.Once());
    }
    
    [Trait("Category", "DomainServive")]
    [Fact]
    public async Task DepositAccount_ReturnAccountOK()
    {
        var accountModelFaker = AccountMock.AccountModelFaker;
        
        _accountRepositoryMock.Setup(x => x.GetAccountById(It.IsAny<Guid>()))
            .ReturnsAsync(accountModelFaker);

        var transactionService = new TransactionService(_accountRepositoryMock.Object, _unitOfWork.Object, _domainNotificationMock.Object);

        await transactionService.DepositAccount(TransactionMock.TransactionModelFaker);
        
        _unitOfWork.Verify(x => x.Commit(), Times.AtMost(2));
    }
    
    
    [Trait("Category", "DomainServive")]
    [Fact]
    public async Task TransferAccount_ReturnAccountNull()
    {
        _accountRepositoryMock.Setup(x => x.GetAccountById(It.IsAny<Guid>()))
            .ReturnsAsync(It.IsAny<Bank.Domain.Models.Account>());
        
        _domainNotificationMock.Setup(x => x.AddNotification(It.IsAny<string>(), It.IsAny<string>()));

        var transactionService = new TransactionService(_accountRepositoryMock.Object, _unitOfWork.Object, _domainNotificationMock.Object);

        await transactionService.TransferAccount(TransactionMock.TransactionModelFaker);
        
        _domainNotificationMock.Verify(mock => mock.AddNotification("TransferAccount", "Não foi possível encontrar sua conta."), Times.Once());
    }
    
    [Trait("Category", "DomainServive")]
    [Fact]
    public async Task TransferAccount_ReturnAccountOK()
    {
        var accountModelFaker = AccountMock.AccountModelFaker;
        
        _accountRepositoryMock.Setup(x => x.GetAccountById(It.IsAny<Guid>()))
            .ReturnsAsync(accountModelFaker);

        var transactionService = new TransactionService(_accountRepositoryMock.Object, _unitOfWork.Object, _domainNotificationMock.Object);

        await transactionService.TransferAccount(TransactionMock.TransactionModelFaker);
        
        _unitOfWork.Verify(x => x.Commit(), Times.AtMost(2));
    }
}