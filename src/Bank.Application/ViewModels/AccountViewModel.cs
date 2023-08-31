using System;
using System.Diagnostics.CodeAnalysis;

namespace Bank.Application.ViewModels
{
    [ExcludeFromCodeCoverage]
    public class AccountViewModel
    {
        
        public Guid Id { get; set; }
        public string AccountNumber { get; set; }
        public string AgencyNumber { get; set; }
        public string AccountHolder { get; set; }
        public decimal AccountBalance { get; set; }
    }
}