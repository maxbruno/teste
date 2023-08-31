using Bank.Domain.Models;
using FluentValidation;
namespace Bank.Domain.Validations
{
    public class TransactionInsertValidation  : AbstractValidator<Transaction>
    {
        public TransactionInsertValidation()
        {
            RuleFor(x => x.TransactionType)
                .IsInEnum()
                .WithMessage("Tipo de operação não permitida");

            RuleFor(x => x.Value)
                .GreaterThan(0)
                .WithMessage("O valor informado precisa ser maior que 0");
        }
    }
}