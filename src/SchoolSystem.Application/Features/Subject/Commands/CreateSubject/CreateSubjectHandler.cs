using SchoolSystem.Application.Features.Subjects.Commands.CreateSubject;
public class CreateSubjectHandler(IApplicationDbContext dbContext) : ICommandHandler<CreateSubjectCommand, CreateSubjectResult>
{
    public async Task<CreateSubjectResult> Handle(CreateSubjectCommand command, CancellationToken cancellationToken)
    {
        var subject = new Subject
        {
            Id = Guid.NewGuid(),
            Name = command.Name,
            Description = command.Description,
            TeacherId = command.TeacherId
        };

        await dbContext.Subjects.AddAsync(subject, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateSubjectResult(subject.Id);
    }
}