namespace SchoolSystem.Application.Features.Teachers.Commands.DeleteTeacher;
public record DeleteTeacherCommand(Guid Id) : ICommand<DeleteTeacherResult>;
public record DeleteTeacherResult(bool IsSuccess);

public class DeleteTeacherCommandValidator : AbstractValidator<DeleteTeacherCommand>
{
    public DeleteTeacherCommandValidator()
    {
        RuleFor(t => t.Id).NotEmpty().WithMessage("Teacher ID is required.");
    }
}

