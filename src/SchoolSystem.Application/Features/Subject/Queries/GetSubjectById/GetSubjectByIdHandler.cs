using SchoolSystem.Application.Features.Subjects.Queries.GetSubjectById;
public class GetSubjectByIdHandler(IApplicationDbContext dbContext) : IQueryHandler<GetSubjectByIdQuery, GetSubjectByIdResult>
{
    public async Task<GetSubjectByIdResult> Handle(GetSubjectByIdQuery query, CancellationToken cancellationToken)
    {
        var subject = await dbContext.Subjects
            .Include(s => s.Classes)
            .FirstOrDefaultAsync(s => s.Id == query.SubjectId, cancellationToken);

        if (subject is null)
            throw new SubjectNotFoundException(query.SubjectId);

        return new GetSubjectByIdResult(subject.ToSubjectDto());
    }
}