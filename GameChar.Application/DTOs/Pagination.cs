namespace GameChar.Application.DTOs;

public class Pagination<T>(int totalCount, int pageSize, int currentPage, IEnumerable<T> items)
{
    public int TotalCount { get; set; } = totalCount;
    public int PageSize { get; set; } = pageSize;
    public int CurrentPage { get; set; } = currentPage;
    public IEnumerable<T> Items { get; set; } = items;
}
