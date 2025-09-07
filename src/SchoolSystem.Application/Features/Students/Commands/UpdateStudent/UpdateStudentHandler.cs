using SchoolSystem.Application.Features.Students.Commands.UpdateStudent;

public class UpdateStudentHandler(IApplicationDbContext dbContext) : ICommandHandler<UpdateStudentCommand, UpdateStudentResult>
{
    public async Task<UpdateStudentResult> Handle(UpdateStudentCommand command, CancellationToken cancellationToken)
    {
        var student = await dbContext.Students.FindAsync([command.Id], cancellationToken: cancellationToken);
        if (student is null)
            throw new StudentNotFoundException(command.Id);

        student.FirstName = command.FirstName;
        student.LastName = command.LastName;
        student.ClassId = command.ClassId;

        dbContext.Students.Update(student);
        await dbContext.SaveChangesAsync(cancellationToken);
        return new UpdateStudentResult(true);
    }
}
