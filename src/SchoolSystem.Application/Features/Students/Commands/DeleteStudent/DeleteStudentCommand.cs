using FluentValidation;
using SchoolSystem.Application.Abstracts.CQRS;
using SchoolSystem.Application.Data;
using SchoolSystem.Application.Exceptions;

namespace SchoolSystem.Application.Features.Students.Commands.DeleteStudent;

public record DeleteStudentCommand(Guid Id) : ICommand<DeleteStudentResult>;
public record DeleteStudentResult(bool IsSuccess);

public class DeleteStudentCommandValidator : AbstractValidator<DeleteStudentCommand>
{
    public DeleteStudentCommandValidator()
    {
        RuleFor(s => s.Id).NotEmpty().WithMessage("Student ID is required.");
    }
}

