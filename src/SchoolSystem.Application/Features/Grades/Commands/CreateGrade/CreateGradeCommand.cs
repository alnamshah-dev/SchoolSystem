namespace SchoolSystem.Application.Features.Grades.Commands.CreateGrade;
public record CreateGradeCommand(GradeDto Grade) : ICommand<CreateGradeResult>;
public record CreateGradeResult(Guid Id);
public class CreateGradeCommandValidator : AbstractValidator<CreateGradeCommand>
{
    public CreateGradeCommandValidator()
    {
        RuleFor(g => g.Grade.StudentId).NotEmpty().WithMessage("Student ID is required.");
        RuleFor(g => g.Grade.SubjectId).NotEmpty().WithMessage("Subject ID is required.");
        RuleFor(g => g.Grade.Score).InclusiveBetween(0, 100).WithMessage("Score must be between 0 and 100.");
    }
}

