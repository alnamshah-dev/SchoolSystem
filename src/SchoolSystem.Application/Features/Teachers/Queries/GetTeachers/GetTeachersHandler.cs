using SchoolSystem.Application.Features.Teachers.Queries.GetTeachers;
public class GetTeachersHandler(IApplicationDbContext dbContext) : IQueryHandler<GetTeachersQuery, GetTeachersResult>
{
    public async Task<GetTeachersResult> Handle(GetTeachersQuery query, CancellationToken cancellationToken)
    {
        var pageIndex = query.PaginationRequest.pageIndex;
        var pageSize = query.PaginationRequest.pageSize;

        var totalCount = await dbContext.Teachers.LongCountAsync(cancellationToken);

        var teachers = await dbContext.Teachers.AsNoTracking()
            .OrderBy(t => t.LastName)
            .Skip(pageSize * (pageIndex - 1))
            .Take(pageSize)
            .ToTeacherDtoList()
            .ToListAsync(cancellationToken);

        return new GetTeachersResult(new PaginatedResult<TeacherDto>(pageIndex, pageSize, totalCount, teachers));
    }
}