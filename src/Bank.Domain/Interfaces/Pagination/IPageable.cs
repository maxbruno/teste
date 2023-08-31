namespace Bank.Domain.Interfaces.Pagination
{
    public interface IPageable
    {
        int PageNumber { get; set; }
        int PageSize { get; set; }
    }
}