using SchoolSystem.Application.Features.Classes.Queries.GetClasses;
public class GetClassesHandler(IApplicationDbContext dbContext) : IQueryHandler<GetClassesQuery, GetClassesResult>
{
    public async Task<GetClassesResult> Handle(GetClassesQuery query, CancellationToken cancellationToken)
    {
        var pageIndex = query.PaginationRequest.pageIndex;
        var pageSize = query.PaginationRequest.pageSize;

        var totalCount = await dbContext.Classes.LongCountAsync(cancellationToken);

        var classes = await dbContext.Classes.AsNoTracking()
            .OrderBy(c => c.Name)
            .Skip(pageSize * (pageIndex - 1))
            .Take(pageSize)
            .ToClassDtoList()
            .ToListAsync(cancellationToken);

        return new GetClassesResult(new PaginatedResult<ClassDto>(pageIndex, pageSize, totalCount, classes));
    }
}