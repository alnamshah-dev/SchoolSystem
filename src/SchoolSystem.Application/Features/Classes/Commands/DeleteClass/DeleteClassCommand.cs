
namespace SchoolSystem.Application.Features.Classes.Commands.DeleteClass;
public record DeleteClassCommand(Guid Id) : ICommand<DeleteClassResult>;
public record DeleteClassResult(bool IsSuccess);
public class DeleteClassCommandValidator : AbstractValidator<DeleteClassCommand>
{
    public DeleteClassCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty().WithMessage("Class ID is required.");
    }
}