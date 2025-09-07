using SchoolSystem.Application.Features.Schedules.Commands.DeleteSchedule;
public class DeleteScheduleHandler(IApplicationDbContext dbContext) : ICommandHandler<DeleteScheduleCommand, DeleteScheduleResult>
{
    public async Task<DeleteScheduleResult> Handle(DeleteScheduleCommand command, CancellationToken cancellationToken)
    {
        var schedule = await dbContext.Schedules.FindAsync([command.Id], cancellationToken: cancellationToken);
        if (schedule is null)
            throw new ScheduleNotFoundException(command.Id);

        dbContext.Schedules.Remove(schedule);
        await dbContext.SaveChangesAsync(cancellationToken);
        return new DeleteScheduleResult(true);
    }
}