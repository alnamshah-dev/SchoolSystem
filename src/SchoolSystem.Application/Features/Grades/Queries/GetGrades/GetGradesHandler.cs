
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Application.Abstracts.CQRS;
using SchoolSystem.Application.Abstracts.Paginations;
using SchoolSystem.Application.Data;
using SchoolSystem.Application.Dtos;
using SchoolSystem.Application.Extensions;
using SchoolSystem.Application.Features.Grades.Queries.GetGrades;

public class GetGradesHandler(IApplicationDbContext dbContext) : IQueryHandler<GetGradesQuery, GetGradesResult>
{
    public async Task<GetGradesResult> Handle(GetGradesQuery query, CancellationToken cancellationToken)
    {
        var pageIndex = query.PaginationRequest.pageIndex;
        var pageSize = query.PaginationRequest.pageSize;

        var totalCount = await dbContext.Grades.LongCountAsync(cancellationToken);

        var grades = await dbContext.Grades.AsNoTracking()
            .OrderByDescending(g => g.Score)
            .Skip(pageSize * (pageIndex - 1))
            .Take(pageSize)
            .ToGradeDtoList()
            .ToListAsync(cancellationToken);

        return new GetGradesResult(new PaginatedResult<GradeDto>(pageIndex, pageSize, totalCount, grades));
    }
}
