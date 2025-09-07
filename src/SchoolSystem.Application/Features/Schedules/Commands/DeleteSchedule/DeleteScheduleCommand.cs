namespace SchoolSystem.Application.Features.Schedules.Commands.DeleteSchedule;
public record DeleteScheduleCommand(Guid Id) : ICommand<DeleteScheduleResult>;
public record DeleteScheduleResult(bool IsSuccess);

public class DeleteScheduleCommandValidator : AbstractValidator<DeleteScheduleCommand>
{
    public DeleteScheduleCommandValidator()
    {
        RuleFor(s => s.Id).NotEmpty().WithMessage("Schedule ID is required.");
    }
}