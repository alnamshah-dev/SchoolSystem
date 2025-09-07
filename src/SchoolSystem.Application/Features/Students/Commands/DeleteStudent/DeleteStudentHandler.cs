using SchoolSystem.Application.Features.Students.Commands.DeleteStudent;
public class DeleteStudentHandler(IApplicationDbContext dbContext) : ICommandHandler<DeleteStudentCommand, DeleteStudentResult>
{
    public async Task<DeleteStudentResult> Handle(DeleteStudentCommand command, CancellationToken cancellationToken)
    {
        var student = await dbContext.Students.FindAsync([command.Id], cancellationToken: cancellationToken);
        if (student is null)
            throw new StudentNotFoundException(command.Id);

        dbContext.Students.Remove(student);
        await dbContext.SaveChangesAsync(cancellationToken);
        return new DeleteStudentResult(true);
    }
}