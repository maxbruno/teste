using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using Bank.Application.ViewModels;

namespace Bank.Application.AutoMapper
{
    [ExcludeFromCodeCoverage]
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<AccountViewModel, Domain.Models.Account>();
            CreateMap<TransactionViewModel, Domain.Models.Transaction>();
            CreateMap<TransactionInputViewModel, Domain.Models.Transaction>();
            
        }
    }
}