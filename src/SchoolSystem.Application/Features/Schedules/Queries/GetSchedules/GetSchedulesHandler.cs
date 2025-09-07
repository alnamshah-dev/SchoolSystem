using SchoolSystem.Application.Features.Schedules.Queries.GetSchedules;
public class GetSchedulesHandler(IApplicationDbContext dbContext) : IQueryHandler<GetSchedulesQuery, GetSchedulesResult>
{
    public async Task<GetSchedulesResult> Handle(GetSchedulesQuery query, CancellationToken cancellationToken)
    {
        var pageIndex = query.PaginationRequest.pageIndex;
        var pageSize = query.PaginationRequest.pageSize;

        var totalCount = await dbContext.Schedules.LongCountAsync(cancellationToken);

        var schedules = await dbContext.Schedules.AsNoTracking()
            .OrderBy(s => s.DayOfWeek)
            .Skip(pageSize * (pageIndex - 1))
            .Take(pageSize)
            .ToScheduleDtoList()
            .ToListAsync(cancellationToken);

        return new GetSchedulesResult(new PaginatedResult<ScheduleDto>(pageIndex, pageSize, totalCount, schedules));
    }
}