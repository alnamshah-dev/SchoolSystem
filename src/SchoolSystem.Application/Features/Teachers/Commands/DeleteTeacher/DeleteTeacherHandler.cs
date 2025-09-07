using SchoolSystem.Application.Features.Teachers.Commands.DeleteTeacher;
public class DeleteTeacherHandler(IApplicationDbContext dbContext) : ICommandHandler<DeleteTeacherCommand, DeleteTeacherResult>
{
    public async Task<DeleteTeacherResult> Handle(DeleteTeacherCommand command, CancellationToken cancellationToken)
    {
        var teacher = await dbContext.Teachers.FindAsync([command.Id], cancellationToken: cancellationToken);
        if (teacher is null)
            throw new TeacherNotFoundException(command.Id);

        dbContext.Teachers.Remove(teacher);
        await dbContext.SaveChangesAsync(cancellationToken);
        return new DeleteTeacherResult(true);
    }
}
