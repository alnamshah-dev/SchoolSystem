using SchoolSystem.Application.Features.Grades.Commands.UpdateGrade;
public class UpdateGradeHandler(IApplicationDbContext dbContext) : ICommandHandler<UpdateGradeCommand, UpdateGradeResult>
{
    public async Task<UpdateGradeResult> Handle(UpdateGradeCommand command, CancellationToken cancellationToken)
    {
        var grade = await dbContext.Grades.FindAsync([command.Grade.Id], cancellationToken: cancellationToken);
        if (grade is null)
            throw new GradeNotFoundException(command.Grade.Id);

        grade.Score = command.Grade.Score;
        grade.StudentId = command.Grade.StudentId;
        grade.SubjectId = command.Grade.SubjectId;

        dbContext.Grades.Update(grade);
        await dbContext.SaveChangesAsync(cancellationToken);
        return new UpdateGradeResult(true);
    }
}
