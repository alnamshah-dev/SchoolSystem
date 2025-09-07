using SchoolSystem.Application.Features.Subjects.Queries.GetSubjects;
public class GetSubjectsHandler(IApplicationDbContext dbContext) : IQueryHandler<GetSubjectsQuery, GetSubjectsResult>
{
    public async Task<GetSubjectsResult> Handle(GetSubjectsQuery query, CancellationToken cancellationToken)
    {
        var pageIndex = query.PaginationRequest.pageIndex;
        var pageSize = query.PaginationRequest.pageSize;

        var totalCount = await dbContext.Subjects.LongCountAsync(cancellationToken);

        var subjects = await dbContext.Subjects.AsNoTracking()
            .OrderBy(s => s.Name)
            .Skip(pageSize * (pageIndex - 1))
            .Take(pageSize)
            .ToSubjectDtoList()
            .ToListAsync(cancellationToken);

        return new GetSubjectsResult(new PaginatedResult<SubjectDto>(pageIndex, pageSize, totalCount, subjects));
    }
}