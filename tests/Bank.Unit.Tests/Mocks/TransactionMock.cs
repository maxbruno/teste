using Bank.Application.ViewModels;
using Bank.Domain.Enums;
using Bank.Domain.Models;
using Bogus;

namespace Bank.Unit.Tests.Mocks
{
    public class TransactionMock
    {
        public static Faker<Transaction> TransactionModelFaker =>
            new Faker<Transaction>()
                .CustomInstantiator(x => new Transaction
                (
                    (ETransactionType) x.Random.Number(1, 3),
                    x.Finance.Amount(0, 50),
                    x.Random.Guid()
                ));

        public static Faker<Transaction> TransactionModelFakerTyped(TransactionInputViewModel inputViewModel) =>
            new Faker<Transaction>()
                .CustomInstantiator(x => new Transaction
                (
                    (ETransactionType)inputViewModel.TransactionType,
                    x.Finance.Amount(0, 50),
                    x.Random.Guid()
                ));

        public static Faker<TransactionViewModel> TransactionViewModelModelFaker =>
            new Faker<TransactionViewModel>()
                .RuleFor(x => x.Id, f => f.Random.Guid())
                .RuleFor(x => x.TransactionType, f => (ETransactionType) f.Random.Number(1, 3))
                .RuleFor(x => x.Value, f => f.Finance.Amount(0, 50))
                .RuleFor(x => x.AccountId, f => f.Random.Guid());

        public static Faker<TransactionInputViewModel> TransactionDebitInputViewModelModelFaker =>
            new Faker<TransactionInputViewModel>()
                .RuleFor(x => x.TransactionType, (ETransactionType)1)
                .RuleFor(x => x.Value, f => f.Finance.Amount(0, 50))
                .RuleFor(x => x.AccountId, f => f.Random.Guid());

        public static Faker<TransactionInputViewModel> TransactionDepositInputViewModelModelFaker =>
            new Faker<TransactionInputViewModel>()
                .RuleFor(x => x.TransactionType, ETransactionType.Deposit)
                .RuleFor(x => x.Value, f => f.Finance.Amount(0, 50))
                .RuleFor(x => x.AccountId, f => f.Random.Guid());

        public static Faker<TransactionInputViewModel> TransactionTransferInputViewModelModelFaker =>
            new Faker<TransactionInputViewModel>()
                .RuleFor(x => x.TransactionType, ETransactionType.Transfer)
                .RuleFor(x => x.Value, f => f.Finance.Amount(0, 50))
                .RuleFor(x => x.AccountId, f => f.Random.Guid());
    }
}