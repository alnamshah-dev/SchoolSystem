using SchoolSystem.Application.Features.Subjects.Commands.UpdateSubject;
public class UpdateSubjectHandler(IApplicationDbContext dbContext) : ICommandHandler<UpdateSubjectCommand, UpdateSubjectResult>
{
    public async Task<UpdateSubjectResult> Handle(UpdateSubjectCommand command, CancellationToken cancellationToken)
    {
        var subject = await dbContext.Subjects.FindAsync([command.Id], cancellationToken: cancellationToken);
        if (subject is null)
            throw new SubjectNotFoundException(command.Id);

        subject.Name = command.Name;
        subject.Description = command.Description;
        subject.TeacherId = command.TeacherId;

        dbContext.Subjects.Update(subject);
        await dbContext.SaveChangesAsync(cancellationToken);
        return new UpdateSubjectResult(true);
    }
}