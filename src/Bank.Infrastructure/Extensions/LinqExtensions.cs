using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Bank.Domain.Interfaces.Pagination;
using Bank.Domain.Models.Pagination;

namespace Bank.Account.Repository.Extensions;

[ExcludeFromCodeCoverage]
public static class LinqExtensions
{
    public static Page<T> Page<T>(this IQueryable<T> query,
        IPageable pageable) where T : class
    {
        var page = new Page<T>
        {
            Pageable =
            {
                PageNumber = pageable.PageNumber,
                PageSize = pageable.PageSize
            },
            TotalRecords = query.Count()
        };

        var pageCount = (double)page.TotalRecords / pageable.PageSize;
        page.TotalPages = (int)Math.Ceiling(pageCount);

        var skip = (pageable.PageNumber - 1) * pageable.PageSize;
        var content = query
            .Skip(skip)
            .Take(pageable.PageSize)
            .ToList();

        page.Content = content;

        return page;
    }
}