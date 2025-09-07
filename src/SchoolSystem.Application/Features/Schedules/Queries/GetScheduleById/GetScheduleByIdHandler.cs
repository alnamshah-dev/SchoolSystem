namespace SchoolSystem.Application.Features.Schedules.Queries.GetScheduleById;

public record GetScheduleByIdQuery(Guid ScheduleId) : IQuery<GetScheduleByIdResult>;
public record GetScheduleByIdResult(ScheduleDto Schedule);