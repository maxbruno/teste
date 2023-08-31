using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Bank.Domain.Models.Pagination
{
    [ExcludeFromCodeCoverage]
    public class Page<TContent>
    {
        public IList<TContent> Content { get; set; }
        public Pageable Pageable { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }

        public Page()
        {
            Pageable = new Pageable();
            Content = new List<TContent>();
        }
    }
}