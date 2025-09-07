using SchoolSystem.Application.Features.Grades.Commands.DeleteGrade;
public class DeleteGradeHandler(IApplicationDbContext dbContext) : ICommandHandler<DeleteGradeCommand, DeleteGradeResult>
{
    public async Task<DeleteGradeResult> Handle(DeleteGradeCommand command, CancellationToken cancellationToken)
    {
        var grade = await dbContext.Grades.FindAsync([command.Id], cancellationToken: cancellationToken);
        if (grade is null)
            throw new GradeNotFoundException(command.Id);

        dbContext.Grades.Remove(grade);
        await dbContext.SaveChangesAsync(cancellationToken);
        return new DeleteGradeResult(true);
    }
}