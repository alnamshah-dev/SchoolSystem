namespace SchoolSystem.Application.Features.Students.Commands.CreateStudent;

public class CreateStudentHandler(IApplicationDbContext dbContext) : ICommandHandler<CreateStudentCommand, CreateStudentResult>
{
    public async Task<CreateStudentResult> Handle(CreateStudentCommand command, CancellationToken cancellationToken)
    {
        var student = new Student
        {
            Id = Guid.NewGuid(),
            FirstName = command.FirstName,
            LastName = command.LastName,
            ClassId = command.ClassId
        };

        await dbContext.Students.AddAsync(student, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateStudentResult(student.Id);
    }
}
