namespace SchoolSystem.Application.Features.Students.Commands.UpdateStudent;
public record UpdateStudentCommand(Guid Id,string FirstName, string LastName, Guid ClassId) : ICommand<UpdateStudentResult>;
public record UpdateStudentResult(bool IsSuccess);

public class UpdateStudentCommandValidator : AbstractValidator<UpdateStudentCommand>
{
    public UpdateStudentCommandValidator()
    {
        RuleFor(s => s.Id).NotEmpty().WithMessage("Student ID is required.");
        RuleFor(s => s.FirstName).NotEmpty().WithMessage("First name is required.");
        RuleFor(s => s.LastName).NotEmpty().WithMessage("Last name is required.");
    }
}