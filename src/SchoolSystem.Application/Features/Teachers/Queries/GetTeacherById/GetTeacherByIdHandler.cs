using SchoolSystem.Application.Features.Teachers.Queries.GetTeacherById;
public class GetTeacherByIdHandler(IApplicationDbContext dbContext) : IQueryHandler<GetTeacherByIdQuery, GetTeacherByIdResult>
{
    public async Task<GetTeacherByIdResult> Handle(GetTeacherByIdQuery query, CancellationToken cancellationToken)
    {
        var teacher = await dbContext.Teachers
            .Include(t => t.Subjects)
            .FirstOrDefaultAsync(t => t.Id == query.TeacherId, cancellationToken);

        if (teacher is null)
            throw new TeacherNotFoundException(query.TeacherId);

        return new GetTeacherByIdResult(teacher.ToTeacherDto());
    }
}
