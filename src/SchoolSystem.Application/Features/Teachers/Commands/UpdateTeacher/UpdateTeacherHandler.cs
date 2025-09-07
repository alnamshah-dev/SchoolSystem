using SchoolSystem.Application.Features.Teachers.Commands.UpdateTeacher;
public class UpdateTeacherHandler(IApplicationDbContext dbContext) : ICommandHandler<UpdateTeacherCommand, UpdateTeacherResult>
{
    public async Task<UpdateTeacherResult> Handle(UpdateTeacherCommand command, CancellationToken cancellationToken)
    {
        var teacher = await dbContext.Teachers.FindAsync([command.Id], cancellationToken: cancellationToken);
        if (teacher is null)
            throw new TeacherNotFoundException(command.Id);

        teacher.FirstName = command.FirstName;
        teacher.LastName = command.LastName;
        teacher.PhoneNumber = command.PhoneNumber;

        dbContext.Teachers.Update(teacher);
        await dbContext.SaveChangesAsync(cancellationToken);
        return new UpdateTeacherResult(true);
    }
}
