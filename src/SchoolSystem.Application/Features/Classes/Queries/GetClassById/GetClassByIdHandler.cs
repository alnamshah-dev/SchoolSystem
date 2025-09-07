using SchoolSystem.Application.Features.Classes.Queries.GetClassById;
public class GetClassByIdHandler(IApplicationDbContext dbContext) : IQueryHandler<GetClassByIdQuery, GetClassByIdResult>
{
    public async Task<GetClassByIdResult> Handle(GetClassByIdQuery query, CancellationToken cancellationToken)
    {
        var cls = await dbContext.Classes
            .Include(c => c.Students)
            .Include(c => c.Schedules)
            .FirstOrDefaultAsync(c => c.Id == query.ClassId, cancellationToken);

        if (cls is null)
            throw new ClassNotFoundException(query.ClassId);

        return new GetClassByIdResult(cls.ToClassDto());
    }
}
