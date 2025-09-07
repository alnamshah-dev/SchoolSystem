namespace SchoolSystem.Application.Features.Classes.Queries.GetClassById;
public record GetClassByIdQuery(Guid ClassId) : IQuery<GetClassByIdResult>;
public record GetClassByIdResult(ClassDto Class);