namespace SchoolSystem.Application.Features.Classes.Commands.UpdateClass;
public record UpdateClassCommand(Guid Id,string Name, string Section, string RoomNumber) : ICommand<UpdateClassResult>;
public record UpdateClassResult(bool IsSuccess);
public class UpdateClassCommandValidator : AbstractValidator<UpdateClassCommand>
{
    public UpdateClassCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty().WithMessage("Class ID is required.");
        RuleFor(c => c.Name).NotEmpty().WithMessage("Class name is required.");
        RuleFor(c => c.Section).NotEmpty().WithMessage("Section is required.");
    }
}
