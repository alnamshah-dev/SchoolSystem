using SchoolSystem.Domain.Core.Models;

namespace SchoolSystem.Application.Features.Students.Commands.CreateStudent;
public record CreateStudentCommand(string FirstName, string LastName, Guid ClassId) : ICommand<CreateStudentResult>;
public record CreateStudentResult(Guid Id);

public class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommand>
{
    public CreateStudentCommandValidator()
    {
        RuleFor(s => s.FirstName).NotEmpty().WithMessage("First name is required.");
        RuleFor(s => s.LastName).NotEmpty().WithMessage("Last name is required.");
        RuleFor(s => s.ClassId).NotEmpty().WithMessage("Class ID is required.");
    }
}
