namespace SchoolSystem.Application.Features.Teachers.Commands.UpdateTeacher;
public record UpdateTeacherCommand(Guid Id ,string FirstName, string LastName, string PhoneNumber) : ICommand<UpdateTeacherResult>;
public record UpdateTeacherResult(bool IsSuccess);

public class UpdateTeacherCommandValidator : AbstractValidator<UpdateTeacherCommand>
{
    public UpdateTeacherCommandValidator()
    {
        RuleFor(t => t.Id).NotEmpty().WithMessage("Teacher ID is required.");
        RuleFor(t => t.FirstName).NotEmpty().WithMessage("First name is required.");
        RuleFor(t => t.LastName).NotEmpty().WithMessage("Last name is required.");
    }
}