using SchoolSystem.Application.Features.Students.Queries.GetStudentById;

public class GetStudentByIdHandler(IApplicationDbContext dbContext) : IQueryHandler<GetStudentByIdQuery, GetStudentByIdResult>
{
    public async Task<GetStudentByIdResult> Handle(GetStudentByIdQuery query, CancellationToken cancellationToken)
    {
        var student = await dbContext.Students
            .Include(s => s.Class)
            .Include(s => s.Grades)
            .FirstOrDefaultAsync(s => s.Id == query.StudentId, cancellationToken);

        if (student is null)
            throw new StudentNotFoundException(query.StudentId);

        return new GetStudentByIdResult(student.ToStudentDto());
    }
}