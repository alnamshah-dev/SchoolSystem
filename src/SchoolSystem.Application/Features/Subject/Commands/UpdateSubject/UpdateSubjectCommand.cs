using FluentValidation;
using SchoolSystem.Application.Abstracts.CQRS;
using SchoolSystem.Application.Data;
using SchoolSystem.Application.Dtos;
using SchoolSystem.Application.Exceptions;

namespace SchoolSystem.Application.Features.Subjects.Commands.UpdateSubject;

public record UpdateSubjectCommand(Guid Id,string Name, string Description, Guid TeacherId) : ICommand<UpdateSubjectResult>;
public record UpdateSubjectResult(bool IsSuccess);

public class UpdateSubjectCommandValidator : AbstractValidator<UpdateSubjectCommand>
{
    public UpdateSubjectCommandValidator()
    {
        RuleFor(s => s.Id).NotEmpty().WithMessage("Subject ID is required.");
        RuleFor(s => s.Name).NotEmpty().WithMessage("Subject name is required.");
    }
}
