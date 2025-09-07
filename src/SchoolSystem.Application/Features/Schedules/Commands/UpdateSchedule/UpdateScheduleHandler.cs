using SchoolSystem.Application.Features.Schedules.Commands.UpdateSchedule;
public class UpdateScheduleHandler(IApplicationDbContext dbContext) : ICommandHandler<UpdateScheduleCommand, UpdateScheduleResult>
{
    public async Task<UpdateScheduleResult> Handle(UpdateScheduleCommand command, CancellationToken cancellationToken)
    {
        var schedule = await dbContext.Schedules.FindAsync([command.Schedule.Id], cancellationToken: cancellationToken);
        if (schedule is null)
            throw new ScheduleNotFoundException(command.Schedule.Id);

        schedule.DayOfWeek = command.Schedule.DayOfWeek;
        schedule.StartTime = command.Schedule.StartTime;
        schedule.EndTime = command.Schedule.EndTime;
        schedule.RoomNumber = command.Schedule.RoomNumber;
        schedule.SubjectId = command.Schedule.SubjectId;
        schedule.TeacherId = command.Schedule.TeacherId;
        schedule.ClassId = command.Schedule.ClassId;

        dbContext.Schedules.Update(schedule);
        await dbContext.SaveChangesAsync(cancellationToken);
        return new UpdateScheduleResult(true);
    }
}