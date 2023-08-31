using Bank.Domain.Interfaces;

namespace Bank.Domain.Enums
{
    public enum ETransactionType : ushort
    {
        Debit = 1,
        Deposit = 2,
        Transfer = 3,
        BankIncome = 4
    }
}