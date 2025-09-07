namespace SchoolSystem.Application.Features.Schedules.Commands.CreateSchedule;
public record CreateScheduleCommand(ScheduleDto Schedule) : ICommand<CreateScheduleResult>;
public record CreateScheduleResult(Guid Id);

public class CreateScheduleCommandValidator : AbstractValidator<CreateScheduleCommand>
{
    public CreateScheduleCommandValidator()
    {
        RuleFor(s => s.Schedule.ClassId).NotEmpty().WithMessage("Class ID is required.");
        RuleFor(s => s.Schedule.SubjectId).NotEmpty().WithMessage("Subject ID is required.");
        RuleFor(s => s.Schedule.TeacherId).NotEmpty().WithMessage("Teacher ID is required.");
        RuleFor(s => s.Schedule.StartTime).LessThan(s => s.Schedule.EndTime).WithMessage("Start time must be before end time.");
    }
}
