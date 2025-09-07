using SchoolSystem.Application.Features.Grades.Commands.CreateGrade;
public class CreateGradeHandler(IApplicationDbContext dbContext) : ICommandHandler<CreateGradeCommand, CreateGradeResult>
{
    public async Task<CreateGradeResult> Handle(CreateGradeCommand command, CancellationToken cancellationToken)
    {
        var grade = new Grade
        {
            Id = Guid.NewGuid(),
            StudentId = command.Grade.StudentId,
            SubjectId = command.Grade.SubjectId,
            Score = command.Grade.Score
        };

        await dbContext.Grades.AddAsync(grade, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateGradeResult(grade.Id);
    }
}
