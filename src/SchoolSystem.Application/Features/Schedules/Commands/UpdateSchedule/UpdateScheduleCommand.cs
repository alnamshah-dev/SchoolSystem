namespace SchoolSystem.Application.Features.Schedules.Commands.UpdateSchedule;
public record UpdateScheduleCommand(ScheduleDto Schedule) : ICommand<UpdateScheduleResult>;
public record UpdateScheduleResult(bool IsSuccess);

public class UpdateScheduleCommandValidator : AbstractValidator<UpdateScheduleCommand>
{
    public UpdateScheduleCommandValidator()
    {
        RuleFor(s => s.Schedule.Id).NotEmpty().WithMessage("Schedule ID is required.");
        RuleFor(s => s.Schedule.StartTime).LessThan(s => s.Schedule.EndTime).WithMessage("Start time must be before end time.");
    }
}