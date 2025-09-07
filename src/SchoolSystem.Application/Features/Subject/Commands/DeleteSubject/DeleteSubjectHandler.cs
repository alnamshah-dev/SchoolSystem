using SchoolSystem.Application.Features.Subjects.Commands.DeleteSubject;

public class DeleteSubjectHandler(IApplicationDbContext dbContext) : ICommandHandler<DeleteSubjectCommand, DeleteSubjectResult>
{
    public async Task<DeleteSubjectResult> Handle(DeleteSubjectCommand command, CancellationToken cancellationToken)
    {
        var subject = await dbContext.Subjects.FindAsync([command.Id], cancellationToken: cancellationToken);
        if (subject is null)
            throw new SubjectNotFoundException(command.Id);

        dbContext.Subjects.Remove(subject);
        await dbContext.SaveChangesAsync(cancellationToken);
        return new DeleteSubjectResult(true);
    }
}