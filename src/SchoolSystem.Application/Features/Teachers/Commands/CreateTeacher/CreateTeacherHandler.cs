using SchoolSystem.Application.Features.Teachers.Commands.CreateTeacher;
public class CreateTeacherHandler(IApplicationDbContext dbContext) : ICommandHandler<CreateTeacherCommand, CreateTeacherResult>
{
    public async Task<CreateTeacherResult> Handle(CreateTeacherCommand command, CancellationToken cancellationToken)
    {
        var teacher = new Teacher
        {
            Id = Guid.NewGuid(),
            FirstName = command.FirstName,
            LastName = command.LastName,
            PhoneNumber = command.PhoneNumber
        };

        await dbContext.Teachers.AddAsync(teacher, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateTeacherResult(teacher.Id);
    }
}