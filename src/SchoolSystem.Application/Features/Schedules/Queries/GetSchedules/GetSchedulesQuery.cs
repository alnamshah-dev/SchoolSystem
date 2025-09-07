namespace SchoolSystem.Application.Features.Schedules.Queries.GetSchedules;
public record GetSchedulesQuery(PaginationRequest PaginationRequest) : IQuery<GetSchedulesResult>;
public record GetSchedulesResult(PaginatedResult<ScheduleDto> Schedules);