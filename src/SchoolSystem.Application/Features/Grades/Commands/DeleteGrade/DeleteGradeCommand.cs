namespace SchoolSystem.Application.Features.Grades.Commands.DeleteGrade;
public record DeleteGradeCommand(Guid Id) : ICommand<DeleteGradeResult>;
public record DeleteGradeResult(bool IsSuccess);
public class DeleteGradeCommandValidator : AbstractValidator<DeleteGradeCommand>
{
    public DeleteGradeCommandValidator()
    {
        RuleFor(g => g.Id).NotEmpty().WithMessage("Grade ID is required.");
    }
}