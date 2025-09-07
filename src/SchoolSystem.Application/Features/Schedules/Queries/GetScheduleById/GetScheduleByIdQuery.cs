using SchoolSystem.Application.Features.Schedules.Queries.GetScheduleById;

public class GetScheduleByIdHandler(IApplicationDbContext dbContext) : IQueryHandler<GetScheduleByIdQuery, GetScheduleByIdResult>
{
    public async Task<GetScheduleByIdResult> Handle(GetScheduleByIdQuery query, CancellationToken cancellationToken)
    {
        var schedule = await dbContext.Schedules
            .Include(s => s.Subject)
            .Include(s => s.Teacher)
            .Include(s => s.Class)
            .FirstOrDefaultAsync(s => s.Id == query.ScheduleId, cancellationToken);

        if (schedule is null)
            throw new ScheduleNotFoundException(query.ScheduleId);

        return new GetScheduleByIdResult(schedule.ToScheduleDto());
    }
}