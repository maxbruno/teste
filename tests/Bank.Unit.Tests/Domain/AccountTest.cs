using System.Collections.Generic;
using Bank.Unit.Tests.Mocks;
using Xunit;

namespace Bank.Unit.Tests.Domain
{
    public class AccountTest
    {
        [Trait("Category", "Domain")]
        [Theory]
        [InlineData(50)]
        [InlineData(0.5)]
        public void Must_Deposit_To_Balance(decimal value)
        {
            var accountMock = AccountMock.AccountModelFaker.Generate();
            var account = new Bank.Domain.Models.Account(accountMock.AccountNumber, accountMock.AgencyNumber, accountMock.AccountHolder, accountMock.AccountBalance);
            
            account.Deposit(value);
            
            Assert.True(account.AccountBalance > accountMock.AccountBalance);
        }
        [Trait("Category", "Domain")]
        [Theory]
        [InlineData(50)]
        [InlineData(0.5)]
        public void Must_Debit_The_Balance(decimal value)
        {
            var accountMock = AccountMock.AccountModelFaker.Generate();
            var account = new Bank.Domain.Models.Account(accountMock.AccountNumber, accountMock.AgencyNumber, accountMock.AccountHolder, accountMock.AccountBalance);

            account.Debit(value);
            
            Assert.True(account.AccountBalance < accountMock.AccountBalance);
        }
        [Trait("Category", "Domain")]
        [Theory]
        [InlineData(50)]
        [InlineData(0.5)]
        public void Must_Transfer_The_Balance(decimal value)
        {
            var accountMock = AccountMock.AccountModelFaker.Generate();
            var account = new Bank.Domain.Models.Account(accountMock.AccountNumber, accountMock.AgencyNumber, accountMock.AccountHolder, accountMock.AccountBalance);

            account.Debit(value);
            
            Assert.True(account.AccountBalance < accountMock.AccountBalance);
        }
        [Trait("Category", "Domain")]
        [Theory]
        [InlineData(1)]
        [InlineData(0.5)]
        public void Give_A_Value_If_Have_True_Return_Balance(decimal value)
        {
            var accountMock = AccountMock.AccountModelFaker.Generate();
            var account = new Bank.Domain.Models.Account(accountMock.AccountNumber, accountMock.AgencyNumber, accountMock.AccountHolder, accountMock.AccountBalance);
            
            var result = account.HasBalance(value);
            
            Assert.True(result);
        }
        [Trait("Category", "Domain")]
        [Theory]
        [InlineData(51)]
        [InlineData(50.1)]
        public void Give_A_Value_If_Have_False_Return_Balance(decimal value)
        {
            var accountMock = AccountMock.AccountModelFaker.Generate();
            var account = new Bank.Domain.Models.Account(accountMock.AccountNumber, accountMock.AgencyNumber, accountMock.AccountHolder, accountMock.AccountBalance);
            
            var result = account.HasBalance(value);
            
            Assert.False(result);
        }
        
        [Trait("Category", "Domain")]
        [Fact]
        public void When_Instantiating_Account_Must_Start_Transactions_Correctly()
        {
            var accountMock = AccountMock.AccountModelFaker.Generate();
            var account = new Bank.Domain.Models.Account(accountMock.AccountNumber, accountMock.AgencyNumber, accountMock.AccountHolder, accountMock.AccountBalance);

            Assert.IsType<List<Bank.Domain.Models.Transaction>>(account.Transactions);
        }
    }
}