namespace SchoolSystem.Application.Features.Teachers.Commands.CreateTeacher;

public record CreateTeacherCommand(string FirstName,string LastName,string PhoneNumber) : ICommand<CreateTeacherResult>;
public record CreateTeacherResult(Guid Id);

public class CreateTeacherCommandValidator : AbstractValidator<CreateTeacherCommand>
{
    public CreateTeacherCommandValidator()
    {
        RuleFor(t => t.FirstName).NotEmpty().WithMessage("First name is required.");
        RuleFor(t => t.LastName).NotEmpty().WithMessage("Last name is required.");
        RuleFor(t => t.PhoneNumber).NotEmpty().WithMessage("Phone Number is required.");
    }
}