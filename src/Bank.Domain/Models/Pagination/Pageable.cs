using System.Diagnostics.CodeAnalysis;
using Bank.Domain.Interfaces.Pagination;

namespace Bank.Domain.Models.Pagination
{
    [ExcludeFromCodeCoverage]
    public class Pageable : IPageable
    {
        private int _pageSize = 10;

        public int PageNumber { get; set; } = 1;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > 50 ? 50 : value;
        }
    }
}