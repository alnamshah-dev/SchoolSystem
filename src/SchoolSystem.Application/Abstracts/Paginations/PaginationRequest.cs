namespace SchoolSystem.Application.Abstracts.Paginations
{
    public record PaginationRequest(int pageIndex = 0, int pageSize = 10);
}
