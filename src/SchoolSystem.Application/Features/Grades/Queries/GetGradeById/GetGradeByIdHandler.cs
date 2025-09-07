using SchoolSystem.Application.Features.Grades.Queries.GetGradeById;
public class GetGradeByIdHandler(IApplicationDbContext dbContext) : IQueryHandler<GetGradeByIdQuery, GetGradeByIdResult>
{
    public async Task<GetGradeByIdResult> Handle(GetGradeByIdQuery query, CancellationToken cancellationToken)
    {
        var grade = await dbContext.Grades
            .Include(g => g.Student)
            .Include(g => g.Subject)
            .FirstOrDefaultAsync(g => g.Id == query.GradeId, cancellationToken);

        if (grade is null)
            throw new GradeNotFoundException(query.GradeId);

        return new GetGradeByIdResult(grade.ToGradeDto());
    }
}