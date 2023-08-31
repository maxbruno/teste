using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Application.ViewModels
{
    [ExcludeFromCodeCoverage]
    public class AccountIdViewModel
    {
        public AccountIdViewModel() { }
        public AccountIdViewModel(Guid accountId)
        {
            AccountId = accountId;
        }

        [FromRoute(Name = "accountId")]
        [Required(ErrorMessage = "O accountId é obrigatório")]
        public Guid AccountId { get; set; }
    }
}