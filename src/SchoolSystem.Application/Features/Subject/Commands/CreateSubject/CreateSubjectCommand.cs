namespace SchoolSystem.Application.Features.Subjects.Commands.CreateSubject;

public record CreateSubjectCommand(string Name, string Description, Guid TeacherId) : ICommand<CreateSubjectResult>;
public record CreateSubjectResult(Guid Id);

public class CreateSubjectCommandValidator : AbstractValidator<CreateSubjectCommand>
{
    public CreateSubjectCommandValidator()
    {
        RuleFor(s => s.Name).NotEmpty().WithMessage("Subject name is required.");
        RuleFor(s => s.TeacherId).NotEmpty().WithMessage("Teacher ID is required.");
    }
}
