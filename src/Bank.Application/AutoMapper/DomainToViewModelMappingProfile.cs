using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using Bank.Application.ViewModels;
using Bank.Domain.Models.Pagination;

namespace Bank.Application.AutoMapper
{
    [ExcludeFromCodeCoverage]
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Domain.Models.Account, AccountViewModel>();
            CreateMap<Page<Domain.Models.Account>, Page<AccountViewModel>>();
            CreateMap<Domain.Models.Transaction, TransactionViewModel>();
        }
    }
}