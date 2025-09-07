namespace SchoolSystem.Application.Features.Classes.Commands.CreateClass;
public record CreateClassCommand(string Name,string Section,string RoomNumber) : ICommand<CreateClassResult>;
public record CreateClassResult(Guid Id);
public class CreateClassCommandValidator : AbstractValidator<CreateClassCommand>
{
    public CreateClassCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().WithMessage("Class name is required.");
        RuleFor(c => c.Section).NotEmpty().WithMessage("Section is required.");
        RuleFor(c => c.RoomNumber).NotEmpty().WithMessage("Room number is required.");
    }
}