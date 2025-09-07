using SchoolSystem.Application.Features.Schedules.Commands.CreateSchedule;
public class CreateScheduleHandler(IApplicationDbContext dbContext) : ICommandHandler<CreateScheduleCommand, CreateScheduleResult>
{
    public async Task<CreateScheduleResult> Handle(CreateScheduleCommand command, CancellationToken cancellationToken)
    {
        var schedule = new Schedule
        {
            Id = Guid.NewGuid(),
            ClassId = command.Schedule.ClassId,
            SubjectId = command.Schedule.SubjectId,
            TeacherId = command.Schedule.TeacherId,
            DayOfWeek = command.Schedule.DayOfWeek,
            StartTime = command.Schedule.StartTime,
            EndTime = command.Schedule.EndTime,
            RoomNumber = command.Schedule.RoomNumber
        };

        await dbContext.Schedules.AddAsync(schedule, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateScheduleResult(schedule.Id);
    }
}