using FluentValidation;
using SchoolSystem.Application.Abstracts.CQRS;
using SchoolSystem.Application.Data;
namespace SchoolSystem.Application.Features.Grades.Commands.UpdateGrade;
public record UpdateGradeCommand(GradeDto Grade) : ICommand<UpdateGradeResult>;
public record UpdateGradeResult(bool IsSuccess);

public class UpdateGradeCommandValidator : AbstractValidator<UpdateGradeCommand>
{
    public UpdateGradeCommandValidator()
    {
        RuleFor(g => g.Grade.Id).NotEmpty().WithMessage("Grade ID is required.");
        RuleFor(g => g.Grade.Score).InclusiveBetween(0, 100).WithMessage("Score must be between 0 and 100.");
    }
}

