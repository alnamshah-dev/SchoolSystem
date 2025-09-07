using SchoolSystem.Application.Features.Students.Queries.GetStudents;
public class GetStudentsHandler(IApplicationDbContext dbContext) : IQueryHandler<GetStudentsQuery, GetStudentsResult>
{
    public async Task<GetStudentsResult> Handle(GetStudentsQuery query, CancellationToken cancellationToken)
    {
        var pageIndex = query.PaginationRequest.pageIndex;
        var pageSize = query.PaginationRequest.pageSize;

        var totalCount = await dbContext.Students.LongCountAsync(cancellationToken);

        var students = await dbContext.Students.AsNoTracking()
            .OrderBy(s => s.LastName)
            .Skip(pageSize * (pageIndex - 1))
            .Take(pageSize)
            .ToStudentDtoList()
            .ToListAsync(cancellationToken);

        return new GetStudentsResult(new PaginatedResult<StudentDto>(pageIndex, pageSize, totalCount, students));
    }
}